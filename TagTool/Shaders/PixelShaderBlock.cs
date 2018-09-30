﻿using System.Collections.Generic;
using TagTool.Tags;

namespace TagTool.Shaders
{
    [TagStructure(Size = 0x50)]
    public class PixelShaderBlock : TagStructure
	{
        public byte[] Unknown;
        public byte[] PCShaderBytecode;
        public TagBlock<ShaderParameter> XboxParameters;
        public uint Unknown6;
        public TagBlock<ShaderParameter> PCParameters;
        public uint Unknown8;
        public uint Unknown9;
        public PixelShaderReference XboxShaderReference;
    }
}
