using TagTool.Cache;
using TagTool.Common;
using System.Collections.Generic;

namespace TagTool.Tags.Definitions
{
    [TagStructure(Name = "gui_group_widget_definition", Tag = "grup", Size = 0x5C, MaxVersion = CacheVersion.Halo3ODST)]
    [TagStructure(Name = "gui_group_widget_definition", Tag = "grup", Size = 0x60, MinVersion = CacheVersion.HaloOnline106708)]
    public class GuiGroupWidgetDefinition : TagStructure
	{
        public uint Flags;
        public StringId Name;
        public short Unknown;
        public short Layer;
        public short WidescreenYOffset;
        public short WidescreenXOffset;
        public short WidescreenYUnknown;
        public short WidescreenXUnknown;
        public short StandardYOffset;
        public short StandardXOffset;
        public short StandardYUnknown;
        public short StandardXUnknown;
        public CachedTagInstance Animation;
        public TagBlock<ListWidget> ListWidgets;
        public TagBlock<TextWidget> TextWidgets;
        public TagBlock<BitmapWidget> BitmapWidgets;
        public TagBlock<ModelWidget> ModelWidgets;

        [TagField(MinVersion = CacheVersion.HaloOnline106708)]
        public uint Unknown2;

        [TagStructure(Size = 0x80)]
        public class ListWidget : TagStructure
		{
            public CachedTagInstance Parent;
            public uint Flags;
            public StringId Name;
            public short Unknown;
            public short Layer;
            public short WidescreenYOffset;
            public short WidescreenXOffset;
            public short WidescreenYUnknown;
            public short WidescreenXUnknown;
            public short StandardYOffset;
            public short StandardXOffset;
            public short StandardYUnknown;
            public short StandardXUnknown;
            public CachedTagInstance Animation;
            public StringId DataSourceName;
            public CachedTagInstance Skin;
            public int RowCount;
            public TagBlock<ListWidgetItem> ListWidgetItems;
            public CachedTagInstance UpArrowBitmap;
            public CachedTagInstance DownArrowBitmap;

            [TagStructure(Size = 0x30)]
            public class ListWidgetItem : TagStructure
			{
                public uint Flags;
                public StringId Name;
                public short Unknown;
                public short Layer;
                public short WidescreenYOffset;
                public short WidescreenXOffset;
                public short WidescreenYUnknown;
                public short WidescreenXUnknown;
                public short StandardYOffset;
                public short StandardXOffset;
                public short StandardYUnknown;
                public short StandardXUnknown;
                public CachedTagInstance Animation;
                public StringId Target;
            }
        }

        [TagStructure(Size = 0x4C)]
        public class TextWidget : TagStructure
		{
            public CachedTagInstance Parent;
            public uint Flags;
            public StringId Name;
            public short Unknown;
            public short Layer;
            public short WidescreenYBoundsMin;
            public short WidescreenXBoundsMin;
            public short WidescreenYBoundsMax;
            public short WidescreenXBoundsMax;
            public short StandardYBoundsMin;
            public short StandardXBoundsMin;
            public short StandardYBoundsMax;
            public short StandardXBoundsMax;
            public CachedTagInstance Animation;
            public StringId DataSourceName;
            public StringId TextString;
            public StringId TextColor;
            public short TextFont;
            public short Unknown2;
        }

        [TagStructure(Size = 0x6C)]
        public class BitmapWidget : TagStructure
		{
            public CachedTagInstance Parent;
            public uint Flags;
            public StringId Name;
            public short Unknown;
            public short Layer;
            public short WidescreenYBoundsMin;
            public short WidescreenXBoundsMin;
            public short WidescreenYBoundsMax;
            public short WidescreenXBoundsMax;
            public short StandardYBoundsMin;
            public short StandardXBoundsMin;
            public short StandardYBoundsMax;
            public short StandardXBoundsMax;
            public CachedTagInstance Animation;
            public CachedTagInstance Bitmap;
            public CachedTagInstance Unknown2;
            public BlendMethodValue BlendMethod;
            public short Unknown3;
            public short SpriteIndex;
            public short Unknown4;
            public StringId DataSourceName;
            public StringId SpriteDataSourceName;

            public enum BlendMethodValue : short
            {
                Standard,
                Unknown,
                Unknown2,
                Alpha,
                Overlay,
                Unknown3,
                LighterColor,
                Unknown4,
                Unknown5,
                Unknown6,
                InvertedAlpha,
                Unknown7,
                Unknown8,
                Unknown9,
            }
        }

        [TagStructure(Size = 0x94)]
        public class ModelWidget : TagStructure
		{
            public CachedTagInstance Parent;
            public uint Flags;
            public StringId Name;
            public short Unknown;
            public short Unknown2;
            public short WidescreenYBoundsMin;
            public short WidescreenXBoundsMin;
            public short WidescreenYBoundsMax;
            public short WidescreenXBoundsMax;
            public short StandardYBoundsMin;
            public short StandardXBoundsMin;
            public short StandardYBoundsMax;
            public short StandardXBoundsMax;
            public CachedTagInstance Animation;
            public TagBlock<UnknownBlock> Unknown3;
            public uint Unknown4;
            public uint Unknown5;
            public uint Unknown6;
            public uint Unknown7;
            public uint Unknown8;
            public uint Unknown9;
            public uint Unknown10;
            public TagBlock<UnknownBlock2> Unknown11;
            public short Unknown12;
            public short Unknown13;
            public short Unknown14;
            public short Unknown15;
            public short Unknown16;
            public short Unknown17;
            public short Unknown18;
            public short Unknown19;
            public short Unknown20;
            public short Unknown21;
            public short Unknown22;
            public short Unknown23;
            public TagBlock<UnknownBlock3> Unknown24;

            [TagStructure(Size = 0xA0)]
            public class UnknownBlock : TagStructure
			{
                public StringId Biped;
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
                public uint Unknown17;
                public uint Unknown18;
                public uint Unknown19;
                public uint Unknown20;
                public uint Unknown21;
                public uint Unknown22;
                public uint Unknown23;
                public uint Unknown24;
                public TagBlock<UnknownBlock2> Unknown25;
                public uint Unknown26;
                public uint Unknown27;
                public Angle Unknown28;
                public uint Unknown29;
                public Angle Unknown30;
                public uint Unknown31;
                public uint Unknown32;
                public CachedTagInstance Unknown33;
                public uint Unknown34;

                [TagStructure(Size = 0x14)]
                public class UnknownBlock2 : TagStructure
				{
                    public byte[] Unknown;
                }
            }

            [TagStructure(Size = 0x14)]
            public class UnknownBlock2 : TagStructure
			{
                public byte[] Unknown;
            }

            [TagStructure(Size = 0x14)]
            public class UnknownBlock3 : TagStructure
			{
                public StringId Unknown;
                public uint Unknown2;
                public uint Unknown3;
                public uint Unknown4;
                public uint Unknown5;
            }
        }
    }
}
