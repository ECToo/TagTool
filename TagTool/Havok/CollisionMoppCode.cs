using TagTool.Tags;
using System.Collections.Generic;

namespace TagTool.Havok
{
    [TagStructure(Size = 0x10, Align = 0x10)]
    public class CollisionMoppCode : MoppCode
    {
        public TagBlock<Datum> Data;
        public sbyte MoppBuildType;

        [TagField(Padding = true, Length = 3)]
        public byte[] Unused = new byte[3];

        [TagStructure(Size = 0x1)]
		public /*was_struct*/ class Datum : TagStructure
        {
            public byte Value;
        }
    }
}