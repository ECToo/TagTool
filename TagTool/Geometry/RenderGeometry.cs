using TagTool.Cache;
using TagTool.Common;
using TagTool.Tags;
using System.Collections.Generic;

namespace TagTool.Geometry
{
    [TagStructure(Name = "render_geometry", Size = 0x84)]
    public class RenderGeometry : TagStructure
	{
        /// <summary>
        /// The runtime flags of the render geometry.
        /// </summary>
        public RenderGeometryRuntimeFlags RuntimeFlags;

        /// <summary>
        /// The meshes of the render geometry.
        /// </summary>
        public TagBlock<Mesh> Meshes;

        /// <summary>
        /// The compression information of the render geometry.
        /// </summary>
        public TagBlock<RenderGeometryCompression> Compression;

        /// <summary>
        /// The bounding spheres of the render geometry.
        /// </summary>
        public TagBlock<BoundingSphere> BoundingSpheres;

        public TagBlock<UnknownBlock> Unknown2;

        public uint Unknown3;
        public uint Unknown4;
        public uint Unknown5;

        public TagBlock<UnknownSection> UnknownSections;

        /// <summary>
        /// The per-mesh node mappings of the render geometry.
        /// </summary>
        public TagBlock<PerMeshNodeMap> PerMeshNodeMaps;

        /// <summary>
        /// The per-mesh subpart visibility of the render geometry.
        /// </summary>
        public TagBlock<PerMeshSubpartVisibilityBlock> PerMeshSubpartVisibility;

        public uint Unknown7;
        public uint Unknown8;
        public uint Unknown9;

        /// <summary>
        /// The per-mesh level-of-detail data of the render geometry.
        /// </summary>
        public TagBlock<PerMeshLodDatum> PerMeshLodData;
        
        /// <summary>
        /// The resource containing the raw geometry data.
        /// </summary>
        [TagField(Pointer = true, MinVersion = CacheVersion.HaloOnline106708)]
        public PageableResource Resource;

        /// <summary>
        /// The index of the resource entry in the cache_file_resource_gestalt tag.
        /// </summary>
        [TagField(MaxVersion = CacheVersion.Halo3ODST)]
        public int ZoneAssetHandle;
        
        [TagField(Padding = true, Length = 4)]
        public byte[] Unused;

        [TagStructure(Size = 0x30)]
        public class BoundingSphere : TagStructure
		{
            public RealPlane3d Plane;
            public RealPoint3d Position;
            public float Radius;

            [TagField(Length = 4)]
            public sbyte[] NodeIndices;

            [TagField(Length = 3)]
            public float[] NodeWeights;
        }

        [TagStructure(Size = 0x18)]
        public class UnknownBlock : TagStructure
		{
            public byte UnknownByte1;
            public byte UnknownByte2;
            public short Unknown2;
            public byte[] Unknown3;
        }

        [TagStructure(Size = 0x20)]
        public class UnknownSection : TagStructure
		{
            [TagField(Align = 0x10)]
            public byte[] Unknown;

            public TagBlock<UnknownBlock> Unknown2;

            [TagStructure(Size = 0x2)]
			public /*was_struct*/ class UnknownBlock : TagStructure
			{
                public short Unknown;
            }
        }

        [TagStructure(Size = 0xC)]
		public /*was_struct*/ class PerMeshNodeMap : TagStructure
		{
            public TagBlock<NodeIndex> NodeIndices;

            [TagStructure(Size = 0x1)]
			public /*was_struct*/ class NodeIndex : TagStructure
			{
                public byte Node;
            }
        }

        [TagStructure(Size = 0xC)]
        public class PerMeshSubpartVisibilityBlock : TagStructure
		{
            public TagBlock<BoundingSphere> BoundingSpheres;
        }

        [TagStructure(Size = 0x10)]
        public class PerMeshLodDatum : TagStructure
		{
            public TagBlock<Index> Indices;

            public short VertexBufferIndex;

            [TagField(Padding = true, Length = 2)]
            public byte[] Unused;

            [TagStructure(Size = 0x4)]
			public /*was_struct*/ class Index : TagStructure
			{
                public int Value;
            }
        }
    }
}