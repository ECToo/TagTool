using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TagTool.Cache;
using TagTool.Common;
using TagTool.IO;
using TagTool.Serialization;
using TagTool.Tags;
using TagTool.Tags.Definitions;
using TagTool.Tags.Resources;

namespace TagTool.Commands.Porting
{
    partial class PortTag2Command
    {
        private PageableResource ConvertStructureBspCacheFileTagResources(CacheFile blam_cache, ScenarioStructureBsp bsp, Dictionary<ResourceLocation, Stream> resourceStreams)
        {
            //
            // Set up ElDorado resource reference
            //

            bsp.PathfindingResource = new PageableResource
            {
                Page = new RawPage
                {
                    Index = -1
                },
                Resource = new TagResource
                {
                    Type = TagResourceType.Pathfinding,
                    DefinitionData = new byte[0x30],
                    DefinitionAddress = new CacheAddress(CacheAddressType.Definition, 0),
                    ResourceFixups = new List<TagResource.ResourceFixup>(),
                    ResourceDefinitionFixups = new List<TagResource.ResourceDefinitionFixup>(),
                    Unknown2 = 1
                }
            };

            //
            // Load Blam resource data
            //

            var resourceData = blam_cache_version > CacheVersion.Halo3Retail ?
                    blam_cache.GetRawFromID(bsp.ZoneAssetIndex4) :
                    null;

            if (resourceData == null)
            {
                if (blam_cache_version >= CacheVersion.Halo3ODST)
                    return bsp.PathfindingResource;

                resourceData = new byte[0x30];
            }

            //
            // Port Blam resource definition
            //
            
            StructureBspCacheFileTagResources resourceDefinition = null;

            if (blam_cache_version >= CacheVersion.Halo3ODST)
            {
                var resourceEntry = blam_cache.ResourceGestalt.TagResources[bsp.ZoneAssetIndex4 & ushort.MaxValue];

                bsp.PathfindingResource.Resource.DefinitionAddress = new CacheAddress(CacheAddressType.Definition, resourceEntry.DefinitionAddress);
                bsp.PathfindingResource.Resource.DefinitionData = blam_cache.ResourceGestalt.FixupInformation.Skip(resourceEntry.FixupInformationOffset).Take(resourceEntry.FixupInformationLength).ToArray();

                using (var definitionStream = new MemoryStream(bsp.PathfindingResource.Resource.DefinitionData, true))
                using (var definitionReader = new EndianReader(definitionStream, EndianFormat.BigEndian))
                using (var definitionWriter = new EndianWriter(definitionStream, EndianFormat.BigEndian))
                {
                    foreach (var fixup in resourceEntry.ResourceFixups)
                    {
                        var newFixup = new TagResource.ResourceFixup
                        {
                            BlockOffset = (uint)fixup.BlockOffset,
                            Address = new CacheAddress(
                                fixup.Type == 4 ?
                                    CacheAddressType.Resource :
                                    CacheAddressType.Definition,
                                fixup.Offset)
                        };

                        definitionStream.Position = newFixup.BlockOffset;
                        definitionWriter.Write(newFixup.Address.Value);

                        bsp.PathfindingResource.Resource.ResourceFixups.Add(newFixup);
                    }

                    var dataContext = new DataSerializationContext(definitionReader, definitionWriter, CacheAddressType.Definition);

                    definitionStream.Position = bsp.PathfindingResource.Resource.DefinitionAddress.Offset;
                    resourceDefinition = blam_cache.Deserializer.Deserialize<StructureBspCacheFileTagResources>(dataContext);
                }
            }
            else
            {
                resourceDefinition = new StructureBspCacheFileTagResources()
                {
                    UnknownRaw6ths = new TagBlock<ScenarioStructureBsp.UnknownRaw6th>(bsp.UnknownRaw6ths.Count, new CacheAddress()),
                    UnknownRaw1sts = new TagBlock<ScenarioStructureBsp.UnknownRaw1st>(bsp.UnknownRaw1sts.Count, new CacheAddress()),
                    UnknownRaw7ths = new TagBlock<ScenarioStructureBsp.UnknownRaw7th>(bsp.UnknownRaw7ths.Count, new CacheAddress()),
                    PathfindingData = new List<StructureBspCacheFileTagResources.PathfindingDatum>() // TODO: copy from bsp.PathfindingData...
                };
            }

            //
            // Port Blam resource to ElDorado resource cache
            //

            using (var blamResourceStream = new MemoryStream(resourceData))
            using (var resourceReader = new EndianReader(blamResourceStream, EndianFormat.BigEndian))
            using (var dataStream = new MemoryStream())
            using (var resourceWriter = new EndianWriter(dataStream, EndianFormat.LittleEndian))
            {
                var dataContext = new DataSerializationContext(resourceReader, resourceWriter);

                //
                // UnknownRaw6ths
                //

                StreamUtil.Align(dataStream, 0x4);

                if (blam_cache_version >= CacheVersion.Halo3ODST)
                    blamResourceStream.Position = resourceDefinition.UnknownRaw6ths.Address.Offset;

                resourceDefinition.UnknownRaw6ths = new TagBlock<ScenarioStructureBsp.UnknownRaw6th>(
                    (blam_cache_version < CacheVersion.Halo3ODST ? bsp.UnknownRaw6ths.Count : resourceDefinition.UnknownRaw6ths.Count),
                    new CacheAddress(CacheAddressType.Resource, (int)dataStream.Position));

                for (var i = 0; i < resourceDefinition.UnknownRaw6ths.Count; i++)
                {
                    var element = blam_cache_version < CacheVersion.Halo3ODST ?
                        bsp.UnknownRaw6ths[i] :
                        blam_cache.Deserializer.Deserialize<ScenarioStructureBsp.UnknownRaw6th>(dataContext);

                    if (blam_cache_version < CacheVersion.Halo3ODST)
                    {
                        element.Unknown1EntryCount = element.Unknown1EntryCountHalo3;
                        element.Unknown1StartIndex = element.Unknown1StartIndexHalo3;
                    }

                    CacheContext.Serializer.Serialize(dataContext, element);
                }

                //
                // UnknownRaw1sts
                //

                StreamUtil.Align(dataStream, 0x4);

                if (blam_cache_version >= CacheVersion.Halo3ODST)
                    blamResourceStream.Position = resourceDefinition.UnknownRaw1sts.Address.Offset;

                resourceDefinition.UnknownRaw1sts = new TagBlock<ScenarioStructureBsp.UnknownRaw1st>(
                    (blam_cache_version < CacheVersion.Halo3ODST ? bsp.UnknownRaw1sts.Count : resourceDefinition.UnknownRaw1sts.Count),
                    new CacheAddress(CacheAddressType.Resource, (int)dataStream.Position));

                for (var i = 0; i < resourceDefinition.UnknownRaw1sts.Count; i++)
                {
                    var element = blam_cache_version < CacheVersion.Halo3ODST ?
                        bsp.UnknownRaw1sts[i] :
                        blam_cache.Deserializer.Deserialize<ScenarioStructureBsp.UnknownRaw1st>(dataContext);

                    CacheContext.Serializer.Serialize(dataContext, element);
                }

                //
                // UnknownRaw7ths
                //

                StreamUtil.Align(dataStream, 0x4);

                if (blam_cache_version >= CacheVersion.Halo3ODST)
                    blamResourceStream.Position = resourceDefinition.UnknownRaw7ths.Address.Offset;

                resourceDefinition.UnknownRaw7ths = new TagBlock<ScenarioStructureBsp.UnknownRaw7th>(
                    (blam_cache_version < CacheVersion.Halo3ODST ? bsp.UnknownRaw7ths.Count : resourceDefinition.UnknownRaw7ths.Count),
                    new CacheAddress(CacheAddressType.Resource, (int)dataStream.Position));

                for (var i = 0; i < resourceDefinition.UnknownRaw7ths.Count; i++)
                {
                    var element = blam_cache_version < CacheVersion.Halo3ODST ?
                        bsp.UnknownRaw7ths[i] :
                        blam_cache.Deserializer.Deserialize<ScenarioStructureBsp.UnknownRaw7th>(dataContext);

                    CacheContext.Serializer.Serialize(dataContext, element);
                }

                if (blam_cache_version < CacheVersion.Halo3ODST && bsp.PathfindingData.Count != 0)
                {
                    var pathfinding = new StructureBspCacheFileTagResources.PathfindingDatum()
                    {
                        StructureChecksum = bsp.PathfindingData[0].StructureChecksum,
                        ObjectReferences = new List<StructureBspCacheFileTagResources.PathfindingDatum.ObjectReference>(),
                        Unknown2s = new List<StructureBspCacheFileTagResources.PathfindingDatum.Unknown2Block>(),
                        Unknown3s = new List<StructureBspCacheFileTagResources.PathfindingDatum.Unknown3Block>()
                    };

                    foreach (var oldObjectReference in bsp.PathfindingData[0].ObjectReferences)
                    {
                        var objectReference = new StructureBspCacheFileTagResources.PathfindingDatum.ObjectReference
                        {
                            Unknown = oldObjectReference.Unknown,
                            Unknown2 = new List<StructureBspCacheFileTagResources.PathfindingDatum.ObjectReference.Unknown1Block>(),
                            Unknown3 = oldObjectReference.Unknown3,
                            Unknown4 = oldObjectReference.Unknown4,
                            Unknown5 = oldObjectReference.Unknown5
                        };

                        foreach (var oldUnknown in oldObjectReference.Unknown2)
                        {
                            objectReference.Unknown2.Add(new StructureBspCacheFileTagResources.PathfindingDatum.ObjectReference.Unknown1Block
                            {
                                Unknown1 = oldUnknown.Unknown1,
                                Unknown2 = oldUnknown.Unknown2,
                                Unknown3 = oldUnknown.Unknown3,
                                Unknown4 = oldUnknown.Unknown4,
                                Unknown5 = oldUnknown.Unknown5,
                                Unknown6 = oldUnknown.Unknown6,
                                Unknown7 = new TagBlock<ScenarioStructureBsp.PathfindingDatum.ObjectReference.UnknownBlock.UnknownBlock2>(oldUnknown.Unknown7.Count, new CacheAddress()),
                                Unknown8 = oldUnknown.Unknown8
                            });
                        }

                        pathfinding.ObjectReferences.Add(objectReference);
                    }

                    foreach (var oldUnknown2 in bsp.PathfindingData[0].Unknown2s)
                    {
                        pathfinding.Unknown2s.Add(new StructureBspCacheFileTagResources.PathfindingDatum.Unknown2Block
                        {
                            Unknown = new TagBlock<ScenarioStructureBsp.PathfindingDatum.Unknown2Block.UnknownBlock>(
                                oldUnknown2.Unknown.Count, new CacheAddress())
                        });
                    }

                    foreach (var oldUnknown3 in bsp.PathfindingData[0].Unknown3s)
                    {
                        pathfinding.Unknown3s.Add(new StructureBspCacheFileTagResources.PathfindingDatum.Unknown3Block
                        {
                            Unknown1 = oldUnknown3.Unknown1,
                            Unknown2 = oldUnknown3.Unknown2,
                            Unknown3 = oldUnknown3.Unknown3,
                            Unknown4 = new TagBlock<ScenarioStructureBsp.PathfindingDatum.Unknown3Block.UnknownBlock>(
                                oldUnknown3.Unknown4.Count, new CacheAddress())
                        });
                    }

                    resourceDefinition.PathfindingData.Add(pathfinding);
                }

                foreach (var pathfindingDatum in resourceDefinition.PathfindingData)
                {
                    StreamUtil.Align(dataStream, 0x4);
                    if (blam_cache_version >= CacheVersion.Halo3ODST)
                        blamResourceStream.Position = pathfindingDatum.Sectors.Address.Offset;
                    pathfindingDatum.Sectors = new TagBlock<ScenarioStructureBsp.PathfindingDatum.Sector>(
                        (blam_cache_version < CacheVersion.Halo3ODST ? bsp.PathfindingData[0].Sectors.Count : pathfindingDatum.Sectors.Count),
                        new CacheAddress(CacheAddressType.Resource, (int)dataStream.Position));
                    for (var i = 0; i < pathfindingDatum.Sectors.Count; i++)
                        CacheContext.Serializer.Serialize(dataContext,
                            blam_cache_version < CacheVersion.Halo3ODST ?
                            bsp.PathfindingData[0].Sectors[i] :
                            blam_cache.Deserializer.Deserialize<ScenarioStructureBsp.PathfindingDatum.Sector>(dataContext));

                    StreamUtil.Align(dataStream, 0x4);
                    if (blam_cache_version >= CacheVersion.Halo3ODST)
                        blamResourceStream.Position = pathfindingDatum.Links.Address.Offset;
                    pathfindingDatum.Links = new TagBlock<ScenarioStructureBsp.PathfindingDatum.Link>(
                        (blam_cache_version < CacheVersion.Halo3ODST ? bsp.PathfindingData[0].Links.Count : pathfindingDatum.Links.Count),
                        new CacheAddress(CacheAddressType.Resource, (int)dataStream.Position));
                    for (var i = 0; i < pathfindingDatum.Links.Count; i++)
                        CacheContext.Serializer.Serialize(dataContext,
                            blam_cache_version < CacheVersion.Halo3ODST ?
                            bsp.PathfindingData[0].Links[i] :
                            blam_cache.Deserializer.Deserialize<ScenarioStructureBsp.PathfindingDatum.Link>(dataContext));

                    StreamUtil.Align(dataStream, 0x4);
                    if (blam_cache_version >= CacheVersion.Halo3ODST)
                        blamResourceStream.Position = pathfindingDatum.References.Address.Offset;
                    pathfindingDatum.References = new TagBlock<ScenarioStructureBsp.PathfindingDatum.Reference>(
                        (blam_cache_version < CacheVersion.Halo3ODST ? bsp.PathfindingData[0].References.Count : pathfindingDatum.References.Count),
                        new CacheAddress(CacheAddressType.Resource, (int)dataStream.Position));
                    for (var i = 0; i < pathfindingDatum.References.Count; i++)
                        CacheContext.Serializer.Serialize(dataContext,
                            blam_cache_version < CacheVersion.Halo3ODST ?
                            bsp.PathfindingData[0].References[i] :
                            blam_cache.Deserializer.Deserialize<ScenarioStructureBsp.PathfindingDatum.Reference>(dataContext));

                    StreamUtil.Align(dataStream, 0x4);
                    if (blam_cache_version >= CacheVersion.Halo3ODST)
                        blamResourceStream.Position = pathfindingDatum.Bsp2dNodes.Address.Offset;
                    pathfindingDatum.Bsp2dNodes = new TagBlock<ScenarioStructureBsp.PathfindingDatum.Bsp2dNode>(
                        (blam_cache_version < CacheVersion.Halo3ODST ? bsp.PathfindingData[0].Bsp2dNodes.Count : pathfindingDatum.Bsp2dNodes.Count),
                        new CacheAddress(CacheAddressType.Resource, (int)dataStream.Position));
                    for (var i = 0; i < pathfindingDatum.Bsp2dNodes.Count; i++)
                        CacheContext.Serializer.Serialize(dataContext,
                            blam_cache_version < CacheVersion.Halo3ODST ?
                            bsp.PathfindingData[0].Bsp2dNodes[i] :
                            blam_cache.Deserializer.Deserialize<ScenarioStructureBsp.PathfindingDatum.Bsp2dNode>(dataContext));

                    StreamUtil.Align(dataStream, 0x4);
                    if (blam_cache_version >= CacheVersion.Halo3ODST)
                        blamResourceStream.Position = pathfindingDatum.Vertices.Address.Offset;
                    pathfindingDatum.Vertices = new TagBlock<ScenarioStructureBsp.PathfindingDatum.Vertex>(
                        (blam_cache_version < CacheVersion.Halo3ODST ? bsp.PathfindingData[0].Vertices.Count : pathfindingDatum.Vertices.Count),
                        new CacheAddress(CacheAddressType.Resource, (int)dataStream.Position));
                    for (var i = 0; i < pathfindingDatum.Vertices.Count; i++)
                        CacheContext.Serializer.Serialize(dataContext,
                            blam_cache_version < CacheVersion.Halo3ODST ?
                            bsp.PathfindingData[0].Vertices[i] :
                            blam_cache.Deserializer.Deserialize<ScenarioStructureBsp.PathfindingDatum.Vertex>(dataContext));

                    for (var objRefIdx = 0; objRefIdx < pathfindingDatum.ObjectReferences.Count; objRefIdx++)
                    {
                        for (var unk2Idx = 0; unk2Idx < pathfindingDatum.ObjectReferences[objRefIdx].Unknown2.Count; unk2Idx++)
                        {
                            var unknown2 = pathfindingDatum.ObjectReferences[objRefIdx].Unknown2[unk2Idx];

                            StreamUtil.Align(dataStream, 0x4);
                            if (blam_cache_version >= CacheVersion.Halo3ODST)
                                blamResourceStream.Position = unknown2.Unknown7.Address.Offset;
                            unknown2.Unknown7.Address = new CacheAddress(CacheAddressType.Resource, (int)dataStream.Position);

                            for (var unk3Idx = 0; unk3Idx < unknown2.Unknown7.Count; unk3Idx++)
                                CacheContext.Serializer.Serialize(dataContext,
                                    blam_cache_version < CacheVersion.Halo3ODST ?
                                    bsp.PathfindingData[0].ObjectReferences[objRefIdx].Unknown2[unk2Idx].Unknown7[unk3Idx] :
                                    blam_cache.Deserializer.Deserialize<ScenarioStructureBsp.PathfindingDatum.ObjectReference.UnknownBlock.UnknownBlock2>(dataContext));
                        }
                    }

                    StreamUtil.Align(dataStream, 0x4);
                    if (blam_cache_version >= CacheVersion.Halo3ODST)
                        blamResourceStream.Position = pathfindingDatum.PathfindingHints.Address.Offset;
                    pathfindingDatum.PathfindingHints = new TagBlock<ScenarioStructureBsp.PathfindingDatum.PathfindingHint>(
                        (blam_cache_version < CacheVersion.Halo3ODST ? bsp.PathfindingData[0].PathfindingHints.Count : pathfindingDatum.PathfindingHints.Count),
                        new CacheAddress(CacheAddressType.Resource, (int)dataStream.Position));
                    for (var i = 0; i < pathfindingDatum.PathfindingHints.Count; i++)
                        CacheContext.Serializer.Serialize(dataContext,
                            blam_cache_version < CacheVersion.Halo3ODST ?
                            bsp.PathfindingData[0].PathfindingHints[i] :
                            blam_cache.Deserializer.Deserialize<ScenarioStructureBsp.PathfindingDatum.PathfindingHint>(dataContext));

                    StreamUtil.Align(dataStream, 0x4);
                    if (blam_cache_version >= CacheVersion.Halo3ODST)
                        blamResourceStream.Position = pathfindingDatum.InstancedGeometryReferences.Address.Offset;
                    pathfindingDatum.InstancedGeometryReferences = new TagBlock<ScenarioStructureBsp.PathfindingDatum.InstancedGeometryReference>(
                        (blam_cache_version < CacheVersion.Halo3ODST ? bsp.PathfindingData[0].InstancedGeometryReferences.Count : pathfindingDatum.InstancedGeometryReferences.Count),
                        new CacheAddress(CacheAddressType.Resource, (int)dataStream.Position));
                    for (var i = 0; i < pathfindingDatum.InstancedGeometryReferences.Count; i++)
                        CacheContext.Serializer.Serialize(dataContext,
                            blam_cache_version < CacheVersion.Halo3ODST ?
                            bsp.PathfindingData[0].InstancedGeometryReferences[i] :
                            blam_cache.Deserializer.Deserialize<ScenarioStructureBsp.PathfindingDatum.InstancedGeometryReference>(dataContext));

                    StreamUtil.Align(dataStream, 0x4);
                    if (blam_cache_version >= CacheVersion.Halo3ODST)
                        blamResourceStream.Position = pathfindingDatum.Unknown1s.Address.Offset;
                    pathfindingDatum.Unknown1s = new TagBlock<ScenarioStructureBsp.PathfindingDatum.Unknown1Block>(
                        (blam_cache_version < CacheVersion.Halo3ODST ? bsp.PathfindingData[0].Unknown1s.Count : pathfindingDatum.Unknown1s.Count),
                        new CacheAddress(CacheAddressType.Resource, (int)dataStream.Position));
                    for (var i = 0; i < pathfindingDatum.Unknown1s.Count; i++)
                        CacheContext.Serializer.Serialize(dataContext,
                            blam_cache_version < CacheVersion.Halo3ODST ?
                            bsp.PathfindingData[0].Unknown1s[i] :
                            blam_cache.Deserializer.Deserialize<ScenarioStructureBsp.PathfindingDatum.Unknown1Block>(dataContext));

                    for (var unk2Idx = 0; unk2Idx < pathfindingDatum.Unknown2s.Count; unk2Idx++)
                    {
                        var unknown2 = pathfindingDatum.Unknown2s[unk2Idx];

                        StreamUtil.Align(dataStream, 0x4);

                        if (blam_cache_version >= CacheVersion.Halo3ODST)
                            blamResourceStream.Position = unknown2.Unknown.Address.Offset;

                        unknown2.Unknown = new TagBlock<ScenarioStructureBsp.PathfindingDatum.Unknown2Block.UnknownBlock>(
                            (blam_cache_version < CacheVersion.Halo3ODST ? bsp.PathfindingData[0].Unknown2s[unk2Idx].Unknown.Count : unknown2.Unknown.Count),
                            new CacheAddress(CacheAddressType.Resource, (int)dataStream.Position));

                        for (var unkIdx = 0; unkIdx < unknown2.Unknown.Count; unkIdx++)
                            CacheContext.Serializer.Serialize(dataContext,
                                blam_cache_version < CacheVersion.Halo3ODST ?
                                    bsp.PathfindingData[0].Unknown2s[unk2Idx].Unknown[unkIdx] :
                                    blam_cache.Deserializer.Deserialize<ScenarioStructureBsp.PathfindingDatum.Unknown2Block.UnknownBlock>(dataContext));
                    }

                    for (var unk3Idx = 0; unk3Idx < pathfindingDatum.Unknown3s.Count; unk3Idx++)
                    {
                        var unknown3 = pathfindingDatum.Unknown3s[unk3Idx];

                        StreamUtil.Align(dataStream, 0x4);

                        if (blam_cache_version >= CacheVersion.Halo3ODST)
                            blamResourceStream.Position = unknown3.Unknown4.Address.Offset;

                        unknown3.Unknown4 = new TagBlock<ScenarioStructureBsp.PathfindingDatum.Unknown3Block.UnknownBlock>(
                            (blam_cache_version < CacheVersion.Halo3ODST ? bsp.PathfindingData[0].Unknown3s[unk3Idx].Unknown4.Count : unknown3.Unknown4.Count),
                            new CacheAddress(CacheAddressType.Resource, (int)dataStream.Position));

                        for (var unk4Idx = 0; unk4Idx < unknown3.Unknown4.Count; unk4Idx++)
                            CacheContext.Serializer.Serialize(dataContext,
                                blam_cache_version < CacheVersion.Halo3ODST ?
                                    bsp.PathfindingData[0].Unknown3s[unk3Idx].Unknown4[unk4Idx] :
                                    blam_cache.Deserializer.Deserialize<ScenarioStructureBsp.PathfindingDatum.Unknown3Block.UnknownBlock>(dataContext));
                    }

                    StreamUtil.Align(dataStream, 0x4);
                    if (blam_cache_version >= CacheVersion.Halo3ODST)
                        blamResourceStream.Position = pathfindingDatum.Unknown4s.Address.Offset;
                    pathfindingDatum.Unknown4s = new TagBlock<ScenarioStructureBsp.PathfindingDatum.Unknown4Block>(
                        (blam_cache_version < CacheVersion.Halo3ODST ? bsp.PathfindingData[0].Unknown4s.Count : pathfindingDatum.Unknown4s.Count),
                        new CacheAddress(CacheAddressType.Resource, (int)dataStream.Position));
                    for (var i = 0; i < pathfindingDatum.Unknown4s.Count; i++)
                        CacheContext.Serializer.Serialize(dataContext,
                            blam_cache_version < CacheVersion.Halo3ODST ?
                            bsp.PathfindingData[0].Unknown4s[i] :
                            blam_cache.Deserializer.Deserialize<ScenarioStructureBsp.PathfindingDatum.Unknown4Block>(dataContext));
                }

                CacheContext.Serializer.Serialize(new ResourceSerializationContext(bsp.PathfindingResource), resourceDefinition);
                resourceWriter.BaseStream.Position = 0;
                dataStream.Position = 0;

                bsp.PathfindingResource.ChangeLocation(ResourceLocation.ResourcesB);
                var resource = bsp.PathfindingResource;

                if (resource == null)
                    throw new ArgumentNullException("resource");

                if (!dataStream.CanRead)
                    throw new ArgumentException("The input stream is not open for reading", "dataStream");

                var cache = CacheContext.GetResourceCache(ResourceLocation.ResourcesB);

                if (!resourceStreams.ContainsKey(ResourceLocation.ResourcesB))
                {
                    resourceStreams[ResourceLocation.ResourcesB] = Flags.HasFlag(PortingFlags.Memory) ?
                        new MemoryStream() :
                        (Stream)CacheContext.OpenResourceCacheReadWrite(ResourceLocation.ResourcesB);

                    if (Flags.HasFlag(PortingFlags.Memory))
                        using (var resourceStream = CacheContext.OpenResourceCacheRead(ResourceLocation.ResourcesB))
                            resourceStream.CopyTo(resourceStreams[ResourceLocation.ResourcesB]);
                }

                var dataSize = (int)(dataStream.Length - dataStream.Position);
                var data = new byte[dataSize];
                dataStream.Read(data, 0, dataSize);

                resource.Page.Index = cache.Add(resourceStreams[ResourceLocation.ResourcesB], data, out uint compressedSize);
                resource.Page.CompressedBlockSize = compressedSize;
                resource.Page.UncompressedBlockSize = (uint)dataSize;
                resource.DisableChecksum();
            }

            if (blam_cache_version < CacheVersion.Halo3ODST)
            {
                bsp.UnknownRaw6ths.Clear();
                bsp.UnknownRaw1sts.Clear();
                bsp.UnknownRaw7ths.Clear();
                bsp.PathfindingData.Clear();
            }

            return bsp.PathfindingResource;
        }
    }
}