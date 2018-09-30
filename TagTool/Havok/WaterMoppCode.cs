﻿using TagTool.Cache;
using TagTool.Tags;
using System.Collections.Generic;

namespace TagTool.Havok
{
    [TagStructure(Size = 0x10, Align = 0x10)]
    public class WaterMoppCode : MoppCode
    {
        public TagBlock<Datum> Data;

        public sbyte MoppBuildType;

        [TagField(Padding = true, Length = 3)]
        public byte[] Unused = new byte[3];

        [TagStructure(Size = 0x1, MaxVersion = CacheVersion.Halo3ODST)]
        [TagStructure(Size = 0x2, MinVersion = CacheVersion.HaloOnline106708)]
		public /*was_struct*/ class Datum : TagStructure
		{
            [TagField(MaxVersion = CacheVersion.Halo3ODST)]
            public byte ValueOld;

            [TagField(MinVersion = CacheVersion.HaloOnline106708)]
            public ushort ValueNew;
        }
    }
}