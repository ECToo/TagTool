using TagTool.Common;
using TagTool.Tags;
using System.Collections.Generic;

namespace TagTool.Ai
{
    [TagStructure(Size = 0x14)]
    public class AiMissionDialogueLine : TagStructure
	{
        [TagField(Label = true)]
        public StringId Name;
        public TagBlock<AiMissionDialogueLineVariant> Variants;
        public StringId DefaultSoundEffect;
    }
}
