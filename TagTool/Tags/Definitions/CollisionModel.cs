using TagTool.Cache;
using TagTool.Common;
using TagTool.Geometry;
using TagTool.Havok;
using System;
using System.Collections.Generic;

namespace TagTool.Tags.Definitions
{
    [TagStructure(Name = "collision_model", Tag = "coll", Size = 0x44)]
    public class CollisionModel : TagStructure
	{
        public int CollisionModelChecksum;

        [TagField(Padding = true, Length = 12)]
        public byte[] UnusedErrorsBlock = new byte[12];

        public CollisionModelFlags Flags;

        public TagBlock<Material> Materials;
        public TagBlock<Region> Regions;
        public TagBlock<PathfindingSphere> PathfindingSpheres;
        public TagBlock<Node> Nodes;
        
        [TagStructure(Size = 0x4)]
        public class Material : TagStructure
		{
            [TagField(Label = true)]
            public StringId Name;
        }

        [TagStructure(Size = 0x10)]
        public class Region : TagStructure
		{
            [TagField(Label = true)]
            public StringId Name;
            public TagBlock<Permutation> Permutations;

            [TagStructure(Size = 0x28)]
            public class Permutation : TagStructure
			{
                [TagField(Label = true)]
                public StringId Name;
                public TagBlock<Bsp> Bsps;
                public TagBlock<BspPhysicsBlock> BspPhysics;
                public TagBlock<CollisionMoppCode> BspMoppCodes;

                [TagStructure(Size = 0x64)]
                public class Bsp : TagStructure
				{
                    public short NodeIndex;

                    [TagField(Padding = true, Length = 2)]
                    public byte[] Unused = new byte[2];

                    public CollisionGeometry Geometry;
                }

                [TagStructure(Size = 0x70, MaxVersion = CacheVersion.Halo3Retail)]
                [TagStructure(Size = 0x80, MinVersion = CacheVersion.Halo3ODST)]
                public class BspPhysicsBlock : TagStructure
				{
                    public int Unknown;
                    public short Size;
                    public short Count;
                    public int Offset;
                    public int Unknown2;
                    public uint Unknown3;
                    public uint Unknown4;
                    public uint Unknown5;
                    public uint Unknown6;
                    public float Unknown7;
                    public float Unknown8;
                    public float Unknown9;
                    public uint Unknown10;
                    public float Unknown11;
                    public float Unknown12;
                    public float Unknown13;
                    public uint Unknown14;
                    [TagField(Short = true)] public CachedTagInstance Model;
                    public uint Unknown15;
                    public uint Unknown16;
                    public short Unknown17;
                    public short Unknown18;
                    public uint Unknown19;
                    public uint Unknown20;
                    [TagField(MinVersion = CacheVersion.HaloOnline106708)]
                    public uint Unknown21;
                    [TagField(MinVersion = CacheVersion.HaloOnline106708)]
                    public uint Unknown22;
                    [TagField(MinVersion = CacheVersion.HaloOnline106708)]
                    public uint Unknown23;
                    public uint Unknown24;
                    public uint Unknown25;
                    public uint Unknown26;
                    public short Size2;
                    public short Count2;
                    public int Offset2;
                    public int Unknown27;
                    [TagField(MinVersion = CacheVersion.Halo3ODST)]
                    public uint Unknown28;
                    [TagField(MinVersion = CacheVersion.Halo3ODST)]
                    public uint Unknown29;
                    [TagField(MinVersion = CacheVersion.Halo3ODST)]
                    public uint Unknown30;
                    [TagField(MinVersion = CacheVersion.Halo3ODST)]
                    public uint Unknown31;
                }
            }
        }

        [Flags]
        public enum PathfindingSphereFlags : ushort
        {
            None = 0,
            RemainsWhenOpen = 1 << 0,
            VehicleOnly = 1 << 1,
            WithSectors = 1 << 2
        }

        [TagStructure(Size = 0x14)]
        public class PathfindingSphere : TagStructure
		{
            public short Node;
            public PathfindingSphereFlags Flags;
            public RealPoint3d Center;
            public float Radius;
        }

        [Flags]
        public enum NodeFlags : ushort
        {
            None = 0,
            GenerateNavMesh = 1 << 0
        }

        [TagStructure(Size = 0xC)]
        public class Node : TagStructure
		{
            [TagField(Label = true)]
            public StringId Name;
            public NodeFlags Flags;
            public short ParentNode;
            public short NextSiblingNode;
            public short FirstChildNode;
        }
    }

    [Flags]
    public enum CollisionModelFlags : int
    {
        None = 0,
        ContainsOpenEdges = 1 << 0,
        PhysicsBuilt = 1 << 1,
        PhysicsInUse = 1 << 2,
        Processed = 1 << 3,
        HasTwoSidedSurfaces = 1 << 4
    }
}
