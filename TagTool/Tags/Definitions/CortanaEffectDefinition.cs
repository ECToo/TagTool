using TagTool.Cache;
using TagTool.Common;
using System.Collections.Generic;

namespace TagTool.Tags.Definitions
{
    [TagStructure(Name = "cortana_effect_definition", Tag = "crte", Size = 0x80)]
    public class CortanaEffectDefinition : TagStructure
	{
        public StringId ScenarioName;
        public int Unknown1;

        public TagBlock<SoundBlock> Sounds;

        public byte[] Data1;
        public byte[] Data2;
        public CachedTagInstance CinematicScene;
        public StringId Name;

        public TagBlock<UnknownBlock1> Unknown2;
        public TagBlock<PassBlock> Pass;

        public TagBlock<UnknownBlock2> Unknown3;

        public TagBlock<UnknownBlock2> Unknown4;

        [TagStructure(Size = 0x14)]
        public class SoundBlock : TagStructure
		{
            public uint Unknown;
            public CachedTagInstance Sound;
        }

        [TagStructure(Size = 0x48)]
        public class UnknownBlock1 : TagStructure
		{
            public TagBlock<UnknownStandardBlock1> Unknown1;
            public TagBlock<UnknownStandardBlock2> Unknown2;
            public TagBlock<UnknownStandardBlock2> Unknown3;
            public TagBlock<UnknownStandardBlock1> Unknown4;
            public TagBlock<UnknownStandardBlock1> Unknown5;
            public TagBlock<UnknownStandardBlock1> Unknown6;
        }

        [TagStructure(Size = 0x30)]
        public class PassBlock : TagStructure
		{
            public TagBlock<UnknownStandardBlock2> Unknown1;
            public TagBlock<UnknownStandardBlock2> Unknown2;
            public TagBlock<UnknownStandardBlock1> Unknown3;
            public TagBlock<UnknownStandardBlock2> Unknown4;
        }

        [TagStructure(Size = 0x24)]
        public class UnknownBlock2 : TagStructure
		{
            public TagBlock<UnknownStandardBlock1> Unknown1;
            public TagBlock<UnknownStandardBlock2> Unknown2;
            public TagBlock<UnknownStandardBlock1> Unknown3;
        }
        
        [TagStructure(Size = 0x30)]
        public class UnknownStandardBlock1 : TagStructure
		{
            public byte Flags;
            public byte Unknown1;
            public short Unknown2;
            public float Unknown3;
            public float Unknown4;
            public float Unknown5;
            public float Unknown6;
            public float Unknown7;

            public TagBlock<TimedTagFunctionBlock> Unknown8;

            public float Unknown9;
            public float Unknown10;

            [TagStructure(Size = 0x20)]
            public class TimedTagFunctionBlock : TagStructure
			{
                public TagBlock<UnknownBlock> Unknown1;
                public TagFunction Unknown2 = new TagFunction { Data = new byte[0] };

                [TagStructure(Size = 0xC)]
                public class UnknownBlock : TagStructure
				{
                    public int Frame;
                    public float Unknown1;
                    public float Unknown2;
                }
            }
        }

        [TagStructure(Size = 0x38)]
        public class UnknownStandardBlock2 : TagStructure
		{
            public byte Flags;
            public byte Unknown1;
            public short Unknown2;
            public float Unknown3;
            public float Unknown4;
            public float Unknown5;
            public float Unknown6;
            public float Unknown7;
            public float Unknown8;

            public TagBlock<TimedTagFunctionBlock> Unknown9;

            public float Unknown10;
            public float Unknown11;
            public float Unknown12;
            public float Unknown13;

            [TagStructure(Size = 0x20)]
            public class TimedTagFunctionBlock : TagStructure
			{
                public TagBlock<UnknownBlock> Unknown1;
                public TagFunction Unknown2 = new TagFunction { Data = new byte[0] };

                [TagStructure(Size = 0x10)]
                public class UnknownBlock : TagStructure
				{
                    public int Frame;
                    public float Unknown1;
                    public float Unknown2;
                    public float Unknown3;
                }
            }
        }
    }
}