using TagTool.Serialization;

namespace TagTool.Shaders
{
    [TagStructure(Size = 0x8)]
    public class ShaderCodeHeader
    {
        public uint ConstantDataSize;
        public uint CodeDataSize;
    }
}