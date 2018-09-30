using TagTool.Cache;
using TagTool.Common;
using System.Collections.Generic;

namespace TagTool.Tags.Definitions
{
    [TagStructure(Name = "podium_settings", Tag = "pdm!", Size = 0x3C)]
    public class PodiumSettings : TagStructure
	{
        public uint Unknown;
        public uint Unknown2;
        public uint Unknown3;
        public Angle Unknown4;
        public Angle Unknown5;
        public uint Unknown6;
        public Angle Unknown7;
        public int Unknown8;
        public CachedTagInstance Unknown9;
        public TagBlock<UnknownBlock> Unknown10;

        [TagStructure(Size = 0x2C)]
        public class UnknownBlock : TagStructure
		{
            public uint Unknown;
            public uint Unknown2;
            public uint Unknown3;
            public Angle Unknown4;
            public uint Unknown5;
            public uint Unknown6;
            public int Unknown7;
            public CachedTagInstance Effect;
        }
    }
}