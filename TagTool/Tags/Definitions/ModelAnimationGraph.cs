using TagTool.Cache;
using TagTool.Common;
using System;
using System.Collections.Generic;

namespace TagTool.Tags.Definitions
{
    [TagStructure(Name = "model_animation_graph", Tag = "jmad", Size = 0xBC, MaxVersion = CacheVersion.Halo2Vista)]
    [TagStructure(Name = "model_animation_graph", Tag = "jmad", Size = 0x104, MinVersion = CacheVersion.Halo3Retail)]
    public class ModelAnimationGraph : TagStructure
	{
        public CachedTagInstance ParentAnimationGraph;
        public AnimationInheritanceFlags InheritanceFlags;
        public AnimationPrivateFlags PrivateFlags;
        public short AnimationCodecPack;
        public TagBlock<SkeletonNode> SkeletonNodes;
        public TagBlock<AnimationTagReference> SoundReferences;
        public TagBlock<AnimationTagReference> EffectReferences;
        public TagBlock<BlendScreen> BlendScreens;

        [TagField(MinVersion = CacheVersion.Halo3Retail)]
        public TagBlock<Leg> Legs;

        public TagBlock<Animation> Animations;
        public TagBlock<Mode> Modes;
        public TagBlock<VehicleSuspensionBlock> VehicleSuspension;
        public TagBlock<ObjectOverlay> ObjectOverlays;
        public TagBlock<Inheritance> InheritanceList;
        public TagBlock<WeaponListBlock> WeaponList;

        [TagField(Length = 8)]
        public uint[] LeftArmNodes;

        [TagField(Length = 8)]
        public uint[] RightArmNodes;

        public byte[] LastImportResults;

        public TagBlock<AdditionalNodeDataBlock> AdditionalNodeData;

        [TagField(MaxVersion = CacheVersion.Halo2Vista)]
        public TagBlock<CacheBlock> CacheBlocks;

        [TagField(MaxVersion = CacheVersion.Halo2Vista)]
        public TagBlock<CacheUnknown> CacheUnknowns;

        [TagField(MinVersion = CacheVersion.Halo3Retail)]
        public TagBlock<ResourceGroup> ResourceGroups;

        [Flags]
        public enum AnimationInheritanceFlags : byte
        {
            None = 0,
            InheritRootTransScaleOnly = 1 << 0,
            InheritForUseOnPlayer = 1 << 1
        }

        [Flags]
        public enum AnimationPrivateFlags : byte
        {
            None = 0,
            PreparedForCache = 1 << 0,
            Bit1 = 1 << 1,
            ImportedWithCodecCompressors = 1 << 2,
            Bit3 = 1 << 3,
            WrittenToCache = 1 << 4,
            AnimationDataReordered = 1 << 5,
            ReadyForUse = 1 << 6
        }

        [TagStructure(Size = 0x20)]
        public class SkeletonNode : TagStructure
		{
            [TagField(Label = true)]
            public StringId Name;
            public short NextSiblingNodeIndex;
            public short FirstChildNodeIndex;
            public short ParentNodeIndex;
            public SkeletonModelFlags ModelFlags;
            public SkeletonNodeJointFlags NodeJointFlags;
            public RealVector3d BaseVector;
            public float VectorRange;
            public float ZPosition;

            [Flags]
            public enum SkeletonModelFlags : byte
            {
                None = 0,
                PrimaryModel = 1 << 0,
                SecondaryModel = 1 << 1,
                LocalRoot = 1 << 2,
                LeftHand = 1 << 3,
                RightHand = 1 << 4,
                LeftArmMember = 1 << 5
            }

            [Flags]
            public enum SkeletonNodeJointFlags : byte
            {
                None = 0,
                BallSocket = 1 << 0,
                Hinge = 1 << 1,
                NoMovement = 1 << 2
            }
        }

        [Flags]
        public enum AnimationTagReferenceFlags : ushort
        {
            None = 0,
            AllowOnPlayer = 1 << 0,
            LeftArmOnly = 1 << 1,
            RightArmOnly = 1 << 2,
            FirstPersonOnly = 1 << 3,
            ForwardOnly = 1 << 4,
            ReverseOnly = 1 << 5,
            Bit6 = 1 << 6,
            Bit7 = 1 << 7,
            Bit8 = 1 << 8,
            Bit9 = 1 << 9,
            Bit10 = 1 << 10,
            Bit11 = 1 << 11,
            Bit12 = 1 << 12,
            Bit13 = 1 << 13,
            Bit14 = 1 << 14,
            Bit15 = 1 << 15
        }

        [TagStructure(Size = 0xC, MaxVersion = CacheVersion.Halo2Vista)]
        [TagStructure(Size = 0x14, MinVersion = CacheVersion.Halo3Retail)]
        public class AnimationTagReference : TagStructure
		{
            public CachedTagInstance Reference;
            public AnimationTagReferenceFlags Flags;
            public short Unknown;
        }

        [TagStructure(Size = 0x1C)]
        public class BlendScreen : TagStructure
		{
            [TagField(Label = true)]
            public StringId Label;
            public Angle RightYawPerFrame;
            public Angle LeftYawPerFrame;
            public short RightFrameCount;
            public short LeftFrameCount;
            public Angle DownPitchPerFrame;
            public Angle UpPitchPerFrame;
            public short DownPitchFrameCount;
            public short UpPitchFrameCount;
        }

        [TagStructure(Size = 0x1C)]
        public class Leg : TagStructure
		{
            public StringId FootMarker;
            public Bounds<float> FootBounds;
            public StringId AnkleMarker;
            public Bounds<float> AnkleBounds;
            public AnchorsValue Anchors;
            public short Unknown;

            public enum AnchorsValue : short
            {
                False,
                True
            }
        }

        public enum FrameType : sbyte
        {
            Base,
            Overlay,
            Replacement
        }

        public enum FrameMovementDataType : sbyte
        {
            None,
            DxDy,
            DxDyDyaw,
            DxDyDzDyaw
        }
        
        [TagStructure(Size = 0x6C, MaxVersion = CacheVersion.Halo2Vista)]
        [TagStructure(Size = 0x88, MinVersion = CacheVersion.Halo3Retail)]
        public class Animation : TagStructure
		{
            [TagField(Label = true)]
            public StringId Name;

            [TagField(MaxVersion = CacheVersion.Halo2Vista)]
            public int NodeListChecksumOld;

            [TagField(MinVersion = CacheVersion.Halo3Retail)]
            public float WeightNew;

            [TagField(MaxVersion = CacheVersion.Halo2Vista)]
            public int ProductionChecksumOld;

            [TagField(MinVersion = CacheVersion.Halo3Retail)]
            public short LoopFrameIndexNew;

            [TagField(MaxVersion = CacheVersion.Halo2Vista)]
            public int ImportChecksum;

            [TagField(MinVersion = CacheVersion.Halo3Retail)]
            public PlaybackFlagsValue PlaybackFlagsNew;

            [TagField(MaxVersion = CacheVersion.Halo2Vista)]
            public FrameType TypeOld;

            [TagField(MinVersion = CacheVersion.Halo3Retail)]
            public sbyte BlendScreenNew;

            [TagField(MaxVersion = CacheVersion.Halo2Vista)]
            public FrameMovementDataType FrameInfoTypeOld;

            [TagField(MinVersion = CacheVersion.Halo3Retail)]
            public CompressionValue DesiredCompressionNew;

            [TagField(MaxVersion = CacheVersion.Halo2Vista)]
            public sbyte BlendScreenOld;

            [TagField(MinVersion = CacheVersion.Halo3Retail)]
            public CompressionValue CurrentCompressionNew;
            
            public sbyte NodeCount;
            
            public short FrameCount;

            [TagField(MinVersion = CacheVersion.Halo3Retail)]
            public FrameType TypeNew;

            [TagField(MinVersion = CacheVersion.Halo3Retail)]
            public FrameMovementDataType FrameInfoTypeNew;

            [TagField(MinVersion = CacheVersion.Halo3Retail)]
            public ProductionFlagsNewValue ProductionFlagsNew;

            [TagField(MaxVersion = CacheVersion.Halo2Vista)]
            public InternalFlagsOldValue InternalFlagsOld;

            [TagField(MaxVersion = CacheVersion.Halo2Vista)]
            public ProductionFlagsOldValue ProductionFlagsOld;

            [TagField(MinVersion = CacheVersion.Halo3Retail)]
            public InternalFlagsNewValue InternalFlagsNew;

            [TagField(MaxVersion = CacheVersion.Halo2Vista)]
            public PlaybackFlagsValue PlaybackFlagsOld;

            [TagField(MaxVersion = CacheVersion.Halo2Vista)]
            public CompressionValue DesiredCompressionOld;

            [TagField(MaxVersion = CacheVersion.Halo2Vista)]
            public CompressionValue CurrentCompressionOld;

            [TagField(MinVersion = CacheVersion.Halo3Retail)]
            public int NodeListChecksumNew;

            [TagField(MaxVersion = CacheVersion.Halo2Vista)]
            public float WeightOld;

            [TagField(MinVersion = CacheVersion.Halo3Retail)]
            public int ProductionChecksumNew;

            [TagField(MaxVersion = CacheVersion.Halo2Xbox)]
            public int ParentGraphIndex;

            [TagField(MaxVersion = CacheVersion.Halo2Xbox)]
            public int ParentGraphBlockIndex;

            [TagField(MaxVersion = CacheVersion.Halo2Xbox)]
            public int ParentGraphBlockOffset;

            [TagField(MaxVersion = CacheVersion.Halo2Xbox)]
            public short ParentGraphStartingPoint;

            [TagField(MaxVersion = CacheVersion.Halo2Vista)]
            public short LoopFrameIndexOld;

            [TagField(MinVersion = CacheVersion.Halo3Retail)]
            public short Unknown;

            [TagField(MaxVersion = CacheVersion.Halo2Vista)]
            public short PreviousVariantSiblingOld;

            [TagField(MinVersion = CacheVersion.Halo3Retail)]
            public short Unknown2;

            [TagField(MaxVersion = CacheVersion.Halo2Vista)]
            public short NextVariantSiblingOld;

            [TagField(MinVersion = CacheVersion.Halo3Retail)]
            public short PreviousVariantSiblingNew;

            [TagField(MinVersion = CacheVersion.Halo3Retail)]
            public short NextVariantSiblingNew;

            [TagField(MaxVersion = CacheVersion.Halo2Vista)]
            public byte[] AnimationData;

            [TagField(MinVersion = CacheVersion.Halo3Retail)]
            public short ResourceGroupIndex;

            [TagField(MinVersion = CacheVersion.Halo3Retail)]
            public short ResourceGroupMemberIndex;

            [TagField(MaxVersion = CacheVersion.Halo2Vista)]
            public sbyte StaticNodeFlags;
            [TagField(MaxVersion = CacheVersion.Halo2Vista)]
            public sbyte AnimatedNodeFlags;
            [TagField(MaxVersion = CacheVersion.Halo2Vista)]
            public short MovementData;
            [TagField(MaxVersion = CacheVersion.Halo2Vista)]
            public short PillOffsetData;
            [TagField(MaxVersion = CacheVersion.Halo2Vista)]
            public short DefaultData;
            [TagField(MaxVersion = CacheVersion.Halo2Vista)]
            public int UncompressedData;
            [TagField(MaxVersion = CacheVersion.Halo2Vista)]
            public int CompressedData;

            public TagBlock<FrameEvent> FrameEvents;
            public TagBlock<SoundEvent> SoundEvents;
            public TagBlock<EffectEvent> EffectEvents;

            [TagField(MinVersion = CacheVersion.Halo3Retail)]
            public TagBlock<DialogueEvent> DialogueEvents;

            public TagBlock<ObjectSpaceParentNode> ObjectSpaceParentNodes;

            [TagField(MinVersion = CacheVersion.Halo3Retail)]
            public TagBlock<LegAnchoringBlock> LegAnchoring;

            [TagField(MinVersion = CacheVersion.Halo3Retail)]
            public float Unknown13;
            [TagField(MinVersion = CacheVersion.Halo3Retail)]
            public float Unknown14;
            [TagField(MinVersion = CacheVersion.Halo3Retail)]
            public float Unknown15;
            [TagField(MinVersion = CacheVersion.Halo3Retail)]
            public float Unknown16;
            [TagField(MinVersion = CacheVersion.Halo3Retail)]
            public float Unknown17;

            [Flags]
            public enum InternalFlagsOldValue : byte
            {
                None,
                Unused1 = 1 << 0,
                WorldRelative = 1 << 1,
                Unused2 = 1 << 2,
                Unused3 = 1 << 3,
                Unused4 = 1 << 4,
                CompressionDisabled = 1 << 5,
                OldProductionChecksum = 1 << 6,
                ValidProductionChecksum = 1 << 7
            }

            [Flags]
            public enum InternalFlagsNewValue : ushort
            {
                None,
                Unused1 = 1 << 0,
                WorldRelative = 1 << 1,
                Unused2 = 1 << 2,
                Unused3 = 1 << 3,
                Unused4 = 1 << 4,
                CompressionDisabled = 1 << 5,
                OldProductionChecksum = 1 << 6,
                ValidProductionChecksum = 1 << 7
            }

            [Flags]
            public enum ProductionFlagsOldValue : byte
            {
                None,
                DoNotMonitorChanges = 1 << 0,
                VerifySoundEvents = 1 << 1,
                DoNotInheritForPlayerGraphs = 1 << 2
            }

            [Flags]
            public enum ProductionFlagsNewValue : ushort
            {
                None,
                DoNotMonitorChanges = 1 << 0,
                VerifySoundEvents = 1 << 1,
                DoNotInheritForPlayerGraphs = 1 << 2
            }

            [Flags]
            public enum PlaybackFlagsValue : ushort
            {
                None,
                DisableInterpolationIn = 1 << 0,
                DisableInterpolationOut = 1 << 1,
                DisableModeIk = 1 << 2,
                DisableWeaponIk = 1 << 3,
                DisableWeaponAim1stPerson = 1 << 4,
                DisableLookScreen = 1 << 5,
                DisableTransitionAdjustment = 1 << 6
            }

            public enum CompressionValue : sbyte
            {
                BestScore,
                BestCompression,
                BestAccuracy,
                BestFullframe,
                BestSmallKeyframe,
                BestLargeKeyframe
            }

            public enum FrameEventType : short
            {
                PrimaryKeyframe,
                SecondaryKeyframe,
                LeftFoot,
                RightFoot,
                AllowInterruption,
                TransitionA,
                TransitionB,
                TransitionC,
                TransitionD,
                BothFeetShuffle,
                BodyImpact,
                LeftFootLock,
                LeftFootUnlock,
                RightFootLock,
                RightFootUnlock,
                BlendRangeMarker,
                StrideExpansion,
                StrideContraction,
                RagdollKeyframe,
                DropWeaponKeyframe,
                MatchA,
                MatchB,
                MatchC,
                MatchD,
                JetpackClosed,
                JetpackOpen,
                SoundEvent,
                EffectEvent,
                LeftHand,
                RightHand,
                StartBAMF,
                EndBAMF,
                Hide
            }

            [TagStructure(Size = 0x4)]
            public class FrameEvent : TagStructure
			{
                public FrameEventType Type;
                public short Frame;
            }

            [TagStructure(Size = 0x8)]
            public class SoundEvent : TagStructure
			{
                public short Sound;
                public short Frame;
                public StringId MarkerName;
            }

            [TagStructure(Size = 0x4, MaxVersion = CacheVersion.Halo2Vista)]
            [TagStructure(Size = 0x8, MaxVersion = CacheVersion.Halo3Retail)]
            [TagStructure(Size = 0xC, MinVersion = CacheVersion.Halo3ODST)]
            public class EffectEvent : TagStructure
			{
                public short Effect;
                public short Frame;
                [TagField(MinVersion = CacheVersion.Halo2Vista)]
                public StringId MarkerName;
                [TagField(MinVersion = CacheVersion.Halo3ODST)]
                public uint Unknown;
            }

            public enum DialogueEventType : short
            {
                Bump,
                Dive,
                Evade,
                Lift,
                Sigh,
                Contempt,
                Anger,
                Fear,
                Relief,
                Sprint,
                SprintEnd,
                AssGrabber,
                KillAss,
                AssGrabbed,
                DieAss
            }

            [TagStructure(Size = 0x4)]
            public class DialogueEvent : TagStructure
			{
                public DialogueEventType EventType;
                public short Frame;
            }

            [Flags]
            public enum ObjectSpaceParentNodeFlags : ushort
            {
                None = 0,
                Rotation = 1 << 0,
                Translation = 1 << 1,
                Scale = 1 << 2,
                MotionRoot = 1 << 3
            }

            [TagStructure(Size = 0x1C)]
            public class ObjectSpaceParentNode : TagStructure
			{
                public short NodeIndex;
                public ObjectSpaceParentNodeFlags Flags;
                public short RotationX;
                public short RotationY;
                public short RotationZ;
                public short RotationW;
                public RealPoint3d DefaultTranslation;
                public float DefaultScale;
            }

            [TagStructure(Size = 0x10)]
            public class LegAnchoringBlock : TagStructure
			{
                public short LegIndex;
                public short Unknown;
                public TagBlock<UnknownBlock> Unknown2;

                [TagStructure(Size = 0x14)]
                public class UnknownBlock : TagStructure
				{
                    public short Frame1a;
                    public short Frame2a;
                    public short Frame1b;
                    public short Frame2b;
                    public uint Unknown;
                    public uint Unknown2;
                    public uint Unknown3;
                }
            }
        }

        [TagStructure(Size = 0x14, MaxVersion = CacheVersion.Halo2Vista)]
        [TagStructure(Size = 0x28, MinVersion = CacheVersion.Halo3Retail)]
        public class Mode : TagStructure
		{
            [TagField(Label = true)]
            public StringId Label;
            public TagBlock<WeaponClassBlock> WeaponClass;
            public TagBlock<ModeIkBlock> ModeIk;

            [TagField(MinVersion = CacheVersion.Halo3Retail)]
            public uint Unknown;
            [TagField(MinVersion = CacheVersion.Halo3Retail)]
            public uint Unknown2;
            [TagField(MinVersion = CacheVersion.Halo3Retail)]
            public uint Unknown3;

            [TagStructure(Size = 0x14, MaxVersion = CacheVersion.Halo2Vista)]
            [TagStructure(Size = 0x1C, MaxVersion = CacheVersion.Halo3ODST)]
            [TagStructure(Size = 0x28, MinVersion = CacheVersion.HaloOnline106708)]
            public class WeaponClassBlock : TagStructure
			{
                [TagField(Label = true)]
                public StringId Label;

                public TagBlock<WeaponTypeBlock> WeaponType;

                public TagBlock<ModeIkBlock> WeaponIk;

                [TagField(MinVersion = CacheVersion.HaloOnline106708)]
                public TagBlock<SyncActionGroup> SyncActionGroups;

                [TagStructure(Size = 0x34)]
                public class WeaponTypeBlock : TagStructure
				{
                    [TagField(Label = true)]
                    public StringId Label;

                    public TagBlock<Entry> Actions;
                    public TagBlock<Entry> Overlays;
                    public TagBlock<DeathAndDamageBlock> DeathAndDamage;
                    public TagBlock<Transition> Transitions;

                    [TagField(MaxVersion = CacheVersion.Halo2Vista)]
                    public TagBlock<PrecacheListBlock> HighPrecache;

                    [TagField(MaxVersion = CacheVersion.Halo2Vista)]
                    public TagBlock<PrecacheListBlock> LowPrecache;

                    [TagStructure(Size = 0x8)]
                    public class Entry : TagStructure
					{
                        [TagField(Label = true)]
                        public StringId Label;
                        public short GraphIndex;
                        public short Animation;
                    }

                    [TagStructure(Size = 0xC, MaxVersion = CacheVersion.Halo2Vista)]
                    [TagStructure(Size = 0x10, MinVersion = CacheVersion.Halo3Retail)]
                    public class DeathAndDamageBlock : TagStructure
					{
                        [TagField(Label = true)]
                        public StringId Label;

                        public TagBlock<Direction> Directions;

                        [TagStructure(Size = 0x8, MaxVersion = CacheVersion.Halo2Vista)]
                        [TagStructure(Size = 0xC, MinVersion = CacheVersion.Halo3Retail)]
                        public class Direction : TagStructure
						{
                            public TagBlock<Region> Regions;

                            [TagStructure(Size = 0x4)]
                            public class Region : TagStructure
							{
                                public short GraphIndex;
                                public short Animation;
                            }
                        }
                    }

                    [TagStructure(Size = 0x14, MaxVersion = CacheVersion.Halo2Vista)]
                    [TagStructure(Size = 0x18, MinVersion = CacheVersion.Halo3Retail)]
                    public class Transition : TagStructure
					{
                        [TagField(Label = true)]
                        public StringId FullName;
                        public StringId StateName;
                        public short Unknown;
                        public sbyte IndexA;
                        public sbyte IndexB;
                        public TagBlock<Destination> Destinations;

                        [TagStructure(Size = 0x14)]
                        public class Destination : TagStructure
						{
                            [TagField(Label = true)]
                            public StringId FullName;
                            public StringId ModeName;
                            public StringId StateName;
                            public FrameEventLinkValue FrameEventLink;
                            public sbyte Unknown;
                            public sbyte IndexA;
                            public sbyte IndexB;
                            public short GraphIndex;
                            public short Animation;

                            public enum FrameEventLinkValue : sbyte
                            {
                                NoKeyframe,
                                KeyframeTypeA,
                                KeyframeTypeB,
                                KeyframeTypeC,
                                KeyframeTypeD
                            }
                        }
                    }

                    [TagStructure(Size = 0x4)]
                    public class PrecacheListBlock : TagStructure
					{
                        public int CacheBlockIndex;
                    }
                }

                [TagStructure(Size = 0x10)]
                public class SyncActionGroup : TagStructure
				{
                    [TagField(Label = true)]
                    public StringId Name;
                    public TagBlock<SyncAction> SyncActions;

                    [TagStructure(Size = 0x1C)]
                    public class SyncAction : TagStructure
					{
                        [TagField(Label = true)]
                        public StringId Name;
                        public TagBlock<SameTypeParticipant> SameTypeParticipants;
                        public TagBlock<OtherParticipant> OtherParticipants;

                        [TagStructure(Size = 0x30)]
                        public class SameTypeParticipant : TagStructure
						{
                            public ParticipantFlags Flags;
                            public short GraphIndex;
                            public short Animation;
                            public RealPoint3d StartOffset;
                            public RealVector3d StartFacing;
                            public RealVector3d EndOffset;
                            public float TimeUntilHurt;

                            [Flags]
                            public enum ParticipantFlags : int
                            {
                                None = 0,
                                Initiator = 1 << 0,
                                CriticalParticipant = 1 << 1,
                                Disabled = 1 << 2,
                                Airborne = 1 << 3,
                                Partner = 1 << 4
                            }
                        }

                        [TagStructure(Size = 0x14)]
                        public class OtherParticipant : TagStructure
						{
                            public ParticipantFlags Flags;
                            public CachedTagInstance ObjectType;

                            public enum ParticipantFlags : int
                            {
                                None = 0,
                                SupportsAnyType = 1 << 0,
                                Disabled = 1 << 1
                            }
                        }
                    }
                }
            }

            [TagStructure(Size = 0x8)]
            public class ModeIkBlock : TagStructure
			{
                public StringId Marker;
                public StringId AttachToMarker;
            }
        }

        [TagStructure(Size = 0x28)]
        public class VehicleSuspensionBlock : TagStructure
		{
            [TagField(Label = true)]
            public StringId Label;
            public short GraphIndex;
            public short Animation;
            public StringId MarkerName;
            public float MassPointOffset;
            public float FullExtensionGroundDepth;
            public float FullCompressionGroundDepth;
            public StringId RegionName;
            public float DestroyedMassPointOffset;
            public float DestroyedFullExtensionGroundDepth;
            public float DestroyedFullCompressionGroundDepth;
        }

        [TagStructure(Size = 0x14)]
        public class ObjectOverlay : TagStructure
		{
            [TagField(Label = true)]
            public StringId Label;
            public short GraphIndex;
            public short Animation;

            [TagField(Padding = true, Length = 2)]
            public byte[] Unused1;

            public FunctionControlsValue FunctionControls;
            public StringId Function;

            [TagField(Padding = true, Length = 4)]
            public byte[] Unused2;

            public enum FunctionControlsValue : short
            {
                Frame,
                Scale
            }
        }

        [Flags]
        public enum InheritanceListFlags : int
        {
            None = 0,
            TightenNodes = 1 << 0
        }

        [TagStructure(Size = 0x20, MaxVersion = CacheVersion.Halo2Vista)]
        [TagStructure(Size = 0x30, MinVersion = CacheVersion.Halo3Retail)]
        public class Inheritance : TagStructure
		{
            public CachedTagInstance InheritedGraph;
            public TagBlock<NodeMapBlock> NodeMap;
            public TagBlock<NodeMapFlag> NodeMapFlags;
            public float RootZOffset;
            public InheritanceListFlags Flags;

            [TagStructure(Size = 0x2)]
            public class NodeMapBlock : TagStructure
			{
                public short LocalNode;
            }

            [TagStructure(Size = 0x4)]
            public class NodeMapFlag : TagStructure
			{
                public int LocalNodeFlags;
            }
        }

        [TagStructure(Size = 0x8)]
        public class WeaponListBlock : TagStructure
		{
            [TagField(Label = true)]
            public StringId WeaponName;
            public StringId WeaponClass;
        }

        [TagStructure(Size = 0x3C)]
        public class AdditionalNodeDataBlock : TagStructure
		{
            [TagField(Label = true)]
            public StringId NodeName;
            public RealQuaternion DefaultRotation;
            public RealPoint3d DefaultTranslation;
            public float DefaultScale;
            public RealPoint3d MinimumBounds;
            public RealPoint3d MaximumBounds;
        }

        [TagStructure(Size = 0x14)]
        public class CacheBlock : TagStructure
		{
            [TagField(Short = true)]
            public CachedTagInstance Owner;

            public int BlockSize;
            public int BlockOffset;

            public short Unknown1;
            public byte Unknown2;
            public byte Unknown3;
            public int Unknown4;
        }

        [TagStructure(Size = 0x18)]
        public class CacheUnknown : TagStructure
		{
            public int Unknown1;
            public int Unknown2;
            public int Unknown3;
            public int Unknown4;
            public int Unknown5;
            public int Unknown6;
        }

        [TagStructure(Size = 0xC)]
        public class ResourceGroup : TagStructure
		{
            public int MemberCount;

            [TagField(MaxVersion = CacheVersion.Halo3ODST)]
            public int ZoneAssetDatumIndex;

            [TagField(Pointer = true, MinVersion = CacheVersion.HaloOnline106708)]
            public PageableResource Resource;

            [TagField(Padding = true, Length = 4)]
            public byte[] Padding;
        }
    }
}