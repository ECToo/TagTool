using TagTool.Cache;
using TagTool.Common;
using System.Collections.Generic;

namespace TagTool.Tags.Definitions
{
    [TagStructure(Name = "sound_effect_collection", Tag = "sfx+", Size = 0xC, MinVersion = CacheVersion.Halo3Retail, MaxVersion = CacheVersion.Halo3ODST)]
    [TagStructure(Name = "sound_effect_collection", Tag = "sfx+", Size = 0x10, MinVersion = CacheVersion.HaloOnline106708)]
    public class SoundEffectCollection : TagStructure
	{
        public TagBlock<SoundEffect> SoundEffects;

        [TagField(Padding = true, Length = 4, MinVersion = CacheVersion.HaloOnline106708)]
        public byte[] Unused;

        [TagStructure(Size = 0x4C)]
        public class SoundEffect : TagStructure
		{
            public StringId Name;
            public uint Unknown;
            public uint Unknown2;
            public uint Unknown3;
            public uint Flags;
            public uint Unknown4;
            public uint Unknown5;
            public TagBlock<FilterBlock> Filter;
            public TagBlock<PitchLFOBlock> PitchLFO;
            public TagBlock<FilterLFOBlock> FilterLFO;
            public TagBlock<SoundEffectBlock> SoundEffect2;

            [TagStructure(Size = 0x48)]
            public class FilterBlock : TagStructure
			{
                public int FilterType;
                public int FilterWidth;
                public Bounds<float> LeftFrequencyScale;
                public Bounds<float> LeftFrequencyRandomBaseVariance;
                public Bounds<float> LeftGainScale;
                public Bounds<float> LeftGainRandomBaseVariance;
                public Bounds<float> RightFrequencyScale;
                public Bounds<float> RightFrequencyRandomBaseVariance;
                public Bounds<float> RightGainScale;
                public Bounds<float> RightGainRandomBaseVariance;
            }

            [TagStructure(Size = 0x30)]
            public class PitchLFOBlock : TagStructure
			{
                public Bounds<float> DelayScale;
                public Bounds<float> DelayRandomBaseVariance;
                public Bounds<float> FrequencyScale;
                public Bounds<float> FrequencyRandomBaseVariance;
                public Bounds<float> PitchModulationScale;
                public Bounds<float> PitchModulationRandomBaseVariance;
            }

            [TagStructure(Size = 0x40)]
            public class FilterLFOBlock : TagStructure
			{
                public Bounds<float> DelayScale;
                public Bounds<float> DelayRandomBaseVariance;
                public Bounds<float> FrequencyScale;
                public Bounds<float> FrequencyRandomBaseVariance;
                public Bounds<float> CutoffModulationScale;
                public Bounds<float> CutoffModulationRandomBaseVariance;
                public Bounds<float> GainModulationScale;
                public Bounds<float> GainModulationRandomBaseVariance;

            }

            [TagStructure(Size = 0x48)]
            public class SoundEffectBlock : TagStructure
			{
                public CachedTagInstance SoundEffectTemplate;
                public TagBlock<Component> Components;
                public TagBlock<TemplateCollectionBlock> TemplateCollection;
                public uint Unknown1;
                public uint Unknown2;
                public uint Unknown3;
                public uint Unknown4;
                public uint Unknown5;
                public uint Unknown6;
                public uint Unknown7;
                public uint Unknown8;

                [TagStructure(Size = 0x18)]
                public class Component : TagStructure
				{
                    public CachedTagInstance Sound;
                    public uint Gain;
                    public int Flags;
                }

                [TagStructure(Size = 0x10)]
                public class TemplateCollectionBlock : TagStructure
				{
                    public StringId DSPEffect;
                    public TagBlock<Parameter> Parameters;

                    [TagStructure(Size = 0x2C)]
                    public class Parameter : TagStructure
					{
                        public StringId Name;
                        public float Unknown;
                        public float Unknown2;
                        public float HardwareOffset;
                        public float Unknown3;
                        public float DefaultScalarValue;
                        public TagFunction Function = new TagFunction { Data = new byte[0] };
                    }
                }
            }
        }
    }
}