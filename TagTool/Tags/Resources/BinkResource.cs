namespace TagTool.Tags.Resources
{
    [TagStructure(Name = "bink_resource", Size = 0x14)]
    public class BinkResource : TagStructure
    {
        [TagField(IsResourceData = true)]
        public TagData Data;
    }
}