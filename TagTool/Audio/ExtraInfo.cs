﻿using System.Collections.Generic;
using TagTool.Cache;
using TagTool.Common;
using TagTool.Tags;

namespace TagTool.Audio
{
    [TagStructure(Size = 0xC, MaxVersion = CacheVersion.Halo3ODST)]
    [TagStructure(Size = 0x28, MinVersion = CacheVersion.HaloOnline106708)]
    public class ExtraInfo : TagStructure
	{
        [TagField(MinVersion = CacheVersion.HaloOnline106708)]
        public TagBlock<LanguagePermutation> LanguagePermutations;

        public TagBlock<EncodedPermutationSection> EncodedPermutationSections;

        [TagField(MinVersion = CacheVersion.HaloOnline106708)]
        public uint Unknown1;
        [TagField(MinVersion = CacheVersion.HaloOnline106708)]
        public uint Unknown2;
        [TagField(MinVersion = CacheVersion.HaloOnline106708)]
        public uint Unknown3;
        [TagField(MinVersion = CacheVersion.HaloOnline106708)]
        public uint Unknown4;

        [TagStructure(Size = 0xC)]
        public class LanguagePermutation : TagStructure
		{
            public TagBlock<RawInfoBlock> RawInfo;

            [TagStructure(Size = 0x7C)]
            public class RawInfoBlock : TagStructure
			{
                public StringId SkipFractionName;
                public uint Unknown1;
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
                public uint Unknown17;
                public uint Unknown18;
                public TagBlock<Unknown> UnknownList;
                public short Compression;
                public byte Language;
                public byte Unknown19;
                public uint SampleCount;
                public uint ResourceSampleOffset;
                public uint ResourceSampleSize;
                public uint Unknown20;
                public uint Unknown21;
                public uint Unknown22;
                public uint Unknown23;
                public int Unknown24;

                [TagStructure(Size = 0x18)]
                public class Unknown : TagStructure
				{
                    public uint Unknown1;
                    public uint Unknown2;
                    public uint Unknown3;
                    public uint Unknown4;
                    public uint Unknown5;
                    public uint Unknown6;
                }
            }
        }

        [TagStructure(Size = 0x2C)]
        public class EncodedPermutationSection : TagStructure
		{
            public byte[] EncodedData;
            public TagBlock<SoundDialogueInfoBlock> SoundDialogueInfo;
            public TagBlock<UnknownBlock> Unknown;

            [TagStructure(Size = 0x10)]
            public class SoundDialogueInfoBlock : TagStructure
			{
                public uint MouthDataOffset;
                public uint MouthDataLength;
                public uint LipsyncDataOffset;
                public uint LipsyncDataLength;
            }

            [TagStructure(Size = 0xC)]
            public class UnknownBlock : TagStructure
			{
                public TagBlock<UnknownBlock2> Unknown;

                [TagStructure(Size = 0x28)]
                public class UnknownBlock2 : TagStructure
				{
                    public float Unknown1;
                    public float Unknown2;
                    public float Unknown3;
                    public float Unknown4;
                    public TagBlock<UnknownBlock2_1> Unknown5;
                    public TagBlock<UnknownBlock2_2> Unknown6;

                    [TagStructure(Size = 0x8)]
                    public class UnknownBlock2_1 : TagStructure
					{
                        public uint Unknown1;
                        public uint Unknown2;
                    }

                    [TagStructure(Size = 0x8)]
                    public class UnknownBlock2_2 : TagStructure
					{
                        public short Unknown1;
                        public sbyte Unknown2;
                        public sbyte Unknown3;
                        public sbyte Unknown4;
                        public sbyte Unknown5;
                        public sbyte Unknown6;
                        public sbyte Unknown7;
                    }
                }
            }
        }
    }
}