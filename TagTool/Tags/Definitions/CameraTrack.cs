using TagTool.Cache;
using TagTool.Common;
using System;
using System.Collections.Generic;

namespace TagTool.Tags.Definitions
{
    [TagStructure(Name = "camera_track", Tag = "trak", Size = 0x10, MaxVersion = CacheVersion.Halo3ODST)]
    [TagStructure(Name = "camera_track", Tag = "trak", Size = 0x14, MinVersion = CacheVersion.HaloOnline106708)]
    public class CameraTrack : TagStructure
	{
        public CameraTrackFlags Flags;

        [TagField(Padding = true, Length = 3)]
        public byte[] Unused1 = new byte[3];

        public TagBlock<CameraPoint> CameraPoints;

        [TagField(Padding = true, Length = 4, MinVersion = CacheVersion.HaloOnline106708)]
        public byte[] Unused2 = new byte[4];

        [TagStructure(Size = 0x1C)]
        public class CameraPoint : TagStructure
		{
            public RealVector3d Position;
            public RealQuaternion Orientation;
        }
    }

    [Flags]
    public enum CameraTrackFlags : byte
    {
        None,
        LensEnabled = 1 << 0
    }
}