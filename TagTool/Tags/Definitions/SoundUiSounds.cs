using TagTool.Cache;
using System.Collections.Generic;

namespace TagTool.Tags.Definitions
{
    [TagStructure(Name = "sound_ui_sounds", Tag = "sus!", Size = 0x10, MinVersion = CacheVersion.HaloOnline106708)]
    public class SoundUiSounds : TagStructure
	{
        public TagBlock<UiSound> UiSounds;
        public uint Unknown;

        [TagStructure(Size = 0x10)]
        public class UiSound : TagStructure
		{
            public CachedTagInstance Sound;
        }
    }
}