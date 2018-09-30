using TagTool.Cache;
using TagTool.Common;
using System.Collections.Generic;

namespace TagTool.Tags.Definitions
{
    // TODO: Update this for cert_ms30_oct19
    [TagStructure(Name = "texture_render_list", Tag = "trdf", Size = 0x48, MinVersion = CacheVersion.HaloOnline106708)]
    public class TextureRenderList : TagStructure
	{
        public TagBlock<Bitmap> Bitmaps;
        public TagBlock<Light> Lights;
        public TagBlock<Bink> Binks;
        public TagBlock<Mannequin> Mannequins;
        public TagBlock<Weapon> Weapons;
        public uint Unknown;
        public uint Unknown2;
        public uint Unknown3;

        [TagStructure(Size = 0x110)]
        public class Bitmap : TagStructure
		{
            public int Index;
            [TagField(Length = 256)] public string Filename;
            public int Unknown;
            public int Width;
            public int Height;
        }

        [TagStructure(Size = 0x1C, MaxVersion = CacheVersion.HaloOnline571627)]
        [TagStructure(Size = 0x28, MinVersion = CacheVersion.HaloOnline700123)]
        public class Light : TagStructure
		{
            [TagField(MaxVersion = CacheVersion.HaloOnline571627)]
            public TagBlock<UnknownBlock> Unknown;

            [TagField(MinVersion = CacheVersion.HaloOnline700123)]
            public uint U1;
            [TagField(MinVersion = CacheVersion.HaloOnline700123)]
            public uint U2;
            [TagField(MinVersion = CacheVersion.HaloOnline700123)]
            public uint U3;

            public float Unknown2;
            public float Unknown3;
            public float Unknown4;
            public float Unknown5;

            [TagStructure(Size = 0x28)]
            public class UnknownBlock : TagStructure
			{
                public float Unknown;
                public float Unknown2;
                public float Unknown3;
                public Angle Unknown4;
                public Angle Unknown5;
                public Angle Unknown6;
                public CachedTagInstance Light;
            }
        }

        [TagStructure(Size = 0x30)]
        public class Bink : TagStructure
		{
            [TagField(Length = 32)] public string Name;
            public CachedTagInstance Bink2;
        }

        [TagStructure(Size = 0x4C)]
        public class Mannequin : TagStructure
		{
            public int Unknown;
            public CachedTagInstance Biped;
            public int Unknown2;
            public float Unknown3;
            public float Unknown4;
            public float Unknown5;
            public float Unknown6;
            public float Unknown7;
            public float Unknown8;
            public float Unknown9;
            public float Unknown10;
            public float Unknown11;
            public float Unknown12;
            public float Unknown13;
            public float Unknown14;
            public float Unknown15;
        }

        [TagStructure(Size = 0x64)]
        public class Weapon : TagStructure
		{
            [TagField(Length = 32)] public string Name;
            public CachedTagInstance Weapon2;
            public float Unknown;
            public float Unknown2;
            public float Unknown3;
            public float Unknown4;
            public float Unknown5;
            public float Unknown6;
            public float Unknown7;
            public float Unknown8;
            public float Unknown9;
            public float Unknown10;
            public float Unknown11;
            public float Unknown12;
            public float Unknown13;
        }
    }
}