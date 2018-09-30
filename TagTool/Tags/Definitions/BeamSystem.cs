using TagTool.Cache;
using TagTool.Common;
using System.Collections.Generic;

namespace TagTool.Tags.Definitions
{
    [TagStructure(Name = "beam_system", Tag = "beam", Size = 0xC, MaxVersion = CacheVersion.Halo3ODST)]
    [TagStructure(Name = "beam_system", Tag = "beam", Size = 0x18, MinVersion = CacheVersion.HaloOnline106708)]
    public class BeamSystem : TagStructure
	{
        public TagBlock<BeamSystemBlock> Beam;

        [TagField(Padding = true, Length = 12, MinVersion = CacheVersion.HaloOnline106708)]
        public byte[] Unused1;

        [TagStructure(Size = 0x208, Align = 0x10)]
        public class BeamSystemBlock : TagStructure
		{
            [TagField(Label = true)]
            public StringId Name;
            public RenderMethod RenderMethod;

            public uint Unknown1;
            public uint Unknown2;
            public uint Unknown3;
            public uint Unknown4;
            public uint Unknown5;
            public uint Unknown6;
            public uint Unknown7;
            public uint Unknown8;
            public uint Unknown9;

            public TagMapping ShaderFunction1;
            public TagMapping ShaderFunction2;
            public TagMapping ShaderFunction3;
            public TagMapping ShaderFunction4;

            public uint Unknown10;
            public uint Unknown11;
            public uint Unknown12;
            public uint Unknown13;

            public TagMapping ShaderFunction5;
            public TagMapping ShaderFunction6;
            public TagMapping ShaderFunction7;
            public TagMapping ShaderFunction8;
            public TagMapping ShaderFunction9;
            public TagMapping ShaderFunction10;
            public TagMapping ShaderFunction11;

            public int Unknown14;
            public int Unknown15;
            public int Unknown16;

            public TagBlock<UnknownBlock> Unknown17;
            public TagBlock<CompiledFunction> CompiledFunctions;
            public TagBlock<CompiledColorFunction> CompiledColorFunctions;

            
            [TagStructure(Size = 0x10, Align = 0x10)]
            public class UnknownBlock : TagStructure
			{
                public uint Unknown;
                public uint Unknown2;
                public uint Unknown3;
                public uint Unknown4;
            }

            [TagStructure(Size = 0x40, Align = 0x10)]
            public class CompiledFunction : TagStructure
			{
                public uint Unknown;
                public uint Unknown2;
                public uint Unknown3;
                public uint Unknown4;
                public uint Unknown5;
                public uint Unknown6;
                public uint Unknown7;
                public uint Unknown8;
                public uint Unknown9;
                public uint Unknown10;
                public uint Unknown11;
                public uint Unknown12;
                public uint Unknown13;
                public uint Unknown14;
                public uint Unknown15;
                public uint Unknown16;
            }

            [TagStructure(Size = 0x10, Align = 0x10)]
            public class CompiledColorFunction : TagStructure
			{
                public RealRgbColor Color;
                public float Magnitude;
            }
        }
    }
}
