using TagTool.Cache;
using TagTool.Common;
using TagTool.Scripting;
using System;
using System.Collections.Generic;
using TagTool.Ai;

namespace TagTool.Tags.Definitions
{
    [TagStructure(Name = "scenario", Tag = "scnr", Size = 0x7B8, MaxVersion = CacheVersion.Halo3Retail)]
    [TagStructure(Name = "scenario", Tag = "scnr", Size = 0x834, MaxVersion = CacheVersion.Halo3ODST)]
    [TagStructure(Name = "scenario", Tag = "scnr", Size = 0x824, MaxVersion = CacheVersion.HaloOnline449175)]
    [TagStructure(Name = "scenario", Tag = "scnr", Size = 0x834, MinVersion = CacheVersion.HaloOnline498295)]
    public class Scenario : TagStructure
	{
        [TagField(MinVersion = CacheVersion.Halo3Retail, MaxVersion = CacheVersion.Halo3Retail)]
        public byte MapTypePadding;

        public ScenarioMapType MapType;

        [TagField(MinVersion = CacheVersion.Halo3ODST)]
        public ScenarioMapSubType MapSubType;

        public ScenarioFlags Flags;
        public int CampaignId;
        public int MapId;
        public Angle LocalNorth;
        public float SandboxBudget;
        public TagBlock<StructureBspBlock> StructureBsps;

        [TagField(MinVersion = CacheVersion.Halo3ODST, MaxVersion = CacheVersion.Halo3ODST)]
        public CachedTagInstance ScenarioPda;
        [TagField(MinVersion = CacheVersion.Halo3ODST, MaxVersion = CacheVersion.Halo3ODST)]
        public uint Unknown0;
        [TagField(MinVersion = CacheVersion.Halo3ODST, MaxVersion = CacheVersion.Halo3ODST)]
        public uint Unknown1;
        [TagField(MinVersion = CacheVersion.Halo3ODST, MaxVersion = CacheVersion.Halo3ODST)]
        public uint Unknown2;

        public CachedTagInstance Unknown;
        public TagBlock<SkyReference> SkyReferences;
        public TagBlock<ZoneSetPotentiallyVisibleSet> ZoneSetPotentiallyVisibleSets;
        public TagBlock<ZoneSetAudibilityBlock> ZoneSetAudibility;
        public TagBlock<ZoneSet> ZoneSets;
        public TagBlock<BspAtlasBlock> BspAtlas;

        [TagField(MinVersion = CacheVersion.Halo3ODST)]
        public TagBlock<CampaignPlayer> CampaignPlayers;

        public uint Unknown9;
        public uint Unknown10;
        public uint Unknown11;
        public uint Unknown12;
        public uint Unknown13;
        public uint Unknown14;
        public uint Unknown15;
        public uint Unknown16;
        public uint Unknown17;
        public byte[] EditorScenarioData; //Found no example to support that it could be a tagfunction, if you find one let me know : btz
        public TagBlock<Comment> Comments;
        public TagBlock<ObjectName> ObjectNames;
        public TagBlock<SceneryInstance> Scenery;
        public TagBlock<ScenarioPaletteEntry> SceneryPalette;
        public TagBlock<BipedInstance> Bipeds;
        public TagBlock<ScenarioPaletteEntry> BipedPalette;
        public TagBlock<VehicleInstance> Vehicles;
        public TagBlock<ScenarioPaletteEntry> VehiclePalette;
        public TagBlock<EquipmentInstance> Equipment;
        public TagBlock<ScenarioPaletteEntry> EquipmentPalette;
        public TagBlock<WeaponInstance> Weapons;
        public TagBlock<ScenarioPaletteEntry> WeaponPalette;
        public TagBlock<DeviceGroup> DeviceGroups;
        public TagBlock<MachineInstance> Machines;
        public TagBlock<ScenarioPaletteEntry> MachinePalette;
        public TagBlock<TerminalInstance> Terminals;
        public TagBlock<ScenarioPaletteEntry> TerminalPalette;
        [TagField(MinVersion = CacheVersion.Halo3ODST)]
        public TagBlock<AlternateRealityDeviceInstance> AlternateRealityDevices;
        [TagField(MinVersion = CacheVersion.Halo3ODST)]
        public TagBlock<ScenarioPaletteEntry> AlternateRealityDevicePalette;
        public TagBlock<ControlInstance> Controls;
        public TagBlock<ScenarioPaletteEntry> ControlPalette;
        public TagBlock<SoundSceneryInstance> SoundScenery;
        public TagBlock<ScenarioPaletteEntry> SoundSceneryPalette;
        public TagBlock<GiantInstance> Giants;
        public TagBlock<ScenarioPaletteEntry> GiantPalette;
        public TagBlock<EffectSceneryInstance> EffectScenery;
        public TagBlock<ScenarioPaletteEntry> EffectSceneryPalette;
        public TagBlock<LightVolumeInstance> LightVolumes;
        public TagBlock<ScenarioPaletteEntry> LightVolumePalette;
        public TagBlock<SandboxObject> SandboxVehicles;
        public TagBlock<SandboxObject> SandboxWeapons;
        public TagBlock<SandboxObject> SandboxEquipment;
        public TagBlock<SandboxObject> SandboxScenery;
        public TagBlock<SandboxObject> SandboxTeleporters;
        public TagBlock<SandboxObject> SandboxGoalObjects;
        public TagBlock<SandboxObject> SandboxSpawning;
        public TagBlock<SoftCeiling> SoftCeilings;
        public TagBlock<PlayerStartingProfileBlock> PlayerStartingProfile;
        public TagBlock<PlayerStartingLocation> PlayerStartingLocations;
        public TagBlock<TriggerVolume> TriggerVolumes;
        public TagBlock<RecordedAnimation> RecordedAnimations;
        public TagBlock<ZoneSetSwitchTriggerVolume> ZonesetSwitchTriggerVolumes;
        public TagBlock<UnknownBlock> Unknown32;
        public TagBlock<UnknownBlock> Unknown33;
        public TagBlock<UnknownBlock> Unknown34;
        public TagBlock<UnknownBlock> Unknown35;
        public TagBlock<UnknownBlock> Unknown36;
        public uint Unknown45;
        public uint Unknown46;
        public uint Unknown47;
        public uint Unknown48;
        public uint Unknown49;
        public uint Unknown50;
        public uint Unknown51;
        public uint Unknown52;
        public uint Unknown53;
        public uint Unknown54;
        public uint Unknown55;
        public uint Unknown56;
        public uint Unknown57;
        public uint Unknown58;
        public uint Unknown59;
        public uint Unknown60;
        public uint Unknown61;
        public uint Unknown62;
        public uint Unknown63;
        public uint Unknown64;
        public uint Unknown65;
        public uint Unknown66;
        public uint Unknown67;
        public uint Unknown68;
        public uint Unknown69;
        public uint Unknown70;
        public uint Unknown71;
        public uint Unknown72;
        public uint Unknown73;
        public uint Unknown74;
        public uint Unknown75;
        public uint Unknown76;
        public uint Unknown77;
        public uint Unknown78;
        public uint Unknown79;
        public uint Unknown80;
        public TagBlock<Decal> Decals;
        public TagBlock<TagReferenceBlock> DecalPalette;
        public TagBlock<TagReferenceBlock> DetailObjectCollectionPalette;
        public TagBlock<TagReferenceBlock> StylePalette;
        public TagBlock<SquadGroup> SquadGroups;
        public TagBlock<Squad> Squads;
        public TagBlock<Zone> Zones;
        [TagField(MinVersion = CacheVersion.Halo3ODST)]
        public TagBlock<SquadPatrol> SquadPatrols;
        public TagBlock<MissionScene> MissionScenes;
        public TagBlock<TagReferenceBlock> CharacterPalette;
        public uint Unknown88;
        public uint Unknown89;
        public uint Unknown90;
        public TagBlock<AiPathfindingDatum> AiPathfindingData;
        public uint Unknown91;
        public uint Unknown92;
        public uint Unknown93;
        public byte[] ScriptStrings;
        public TagBlock<Script> Scripts;
        public TagBlock<ScriptGlobal> Globals;
        public TagBlock<TagReferenceBlock> ScriptSourceFileReferences;
        public TagBlock<TagReferenceBlock> ScriptExternalFileReferences;
        public TagBlock<ScriptingDatum> ScriptingData;
        public TagBlock<CutsceneFlag> CutsceneFlags;
        public TagBlock<CutsceneCameraPoint> CutsceneCameraPoints;
        public TagBlock<CutsceneTitle> CutsceneTitles;
        public CachedTagInstance CustomObjectNameStrings;
        public CachedTagInstance ChapterTitleStrings;
        [TagField(MinVersion = CacheVersion.HaloOnline498295)]
        public CachedTagInstance Unknown156;
        public TagBlock<ScenarioResource> ScenarioResources;
        public TagBlock<UnitSeatsMappingBlock> UnitSeatsMapping;
        public TagBlock<ScenarioKillTrigger> ScenarioKillTriggers;
        public TagBlock<ScenarioSafeTrigger> ScenarioSafeTriggers;
        public TagBlock<ScriptExpression> ScriptExpressions;
        public uint Unknown97;
        public uint Unknown98;
        public uint Unknown99;
        public uint Unknown100;
        public uint Unknown101;
        public uint Unknown102;
        public TagBlock<BackgroundSoundEnvironmentPaletteBlock> BackgroundSoundEnvironmentPalette;
        public uint Unknown103;
        public uint Unknown104;
        public uint Unknown105;
        public uint Unknown106;
        public uint Unknown107;
        public uint Unknown108;
        public TagBlock<UnknownBlock3> Unknown109;
        public TagBlock<FogBlock> Fog;
        public TagBlock<CameraFxBlock> CameraFx;
        public uint Unknown110;
        public uint Unknown111;
        public uint Unknown112;
        public uint Unknown113;
        public uint Unknown114;
        public uint Unknown115;
        public uint Unknown116;
        public uint Unknown117;
        public uint Unknown118;
        public TagBlock<ScenarioClusterDatum> ScenarioClusterData;
        public uint Unknown119;
        public uint Unknown120;
        public uint Unknown121;
        [TagField(Length = 32)]
        public int[] ObjectSalts = new int[32];
        public TagBlock<SpawnDatum> SpawnData;
        public CachedTagInstance SoundEffectsCollection;
        public TagBlock<CrateInstance> Crates;
        public TagBlock<ScenarioPaletteEntry> CratePalette;
        public TagBlock<TagReferenceBlock> FlockPalette;
        public TagBlock<Flock> Flocks;
        public CachedTagInstance SubtitleStrings;
        public TagBlock<CreatureInstance> Creatures;
        public TagBlock<ScenarioPaletteEntry> CreaturePalette;
        public TagBlock<EditorFolder> EditorFolders;
        public CachedTagInstance TerritoryLocationNameStrings;
        public uint Unknown125;
        public uint Unknown126;
        public TagBlock<TagReferenceBlock> MissionDialogue;
        public CachedTagInstance ObjectiveStrings;
        public TagBlock<Interpolator> Interpolators;
        public uint Unknown127;
        public uint Unknown128;
        public uint Unknown129;
        public uint Unknown130;
        public uint Unknown131;
        public uint Unknown132;
        public TagBlock<SimulationDefinitionTableBlock> SimulationDefinitionTable;
        public CachedTagInstance DefaultCameraFx;
        public CachedTagInstance DefaultScreenFx;
        [TagField(MinVersion = CacheVersion.HaloOnline106708)]
        public CachedTagInstance Unknown133;
        public CachedTagInstance SkyParameters;
        public CachedTagInstance GlobalLighting;
        public CachedTagInstance Lightmap;
        public CachedTagInstance PerformanceThrottles;
        public TagBlock<AiObjectId> AiObjectIds;
        public TagBlock<AiObjective> AiObjectives;
        public TagBlock<DesignerZoneSet> DesignerZoneSets;
        public TagBlock<UnknownBlock5> Unknown135;
        public uint Unknown136;
        public uint Unknown137;
        public uint Unknown138;
        public TagBlock<TagReferenceBlock> Cinematics;
        public TagBlock<CinematicLightingBlock> CinematicLighting;
        public uint Unknown139;
        public uint Unknown140;
        public uint Unknown141;
        public TagBlock<ScenarioMetagameBlock> ScenarioMetagame;
        public TagBlock<UnknownBlock6> Unknown142;
        public TagBlock<UnknownBlock7> Unknown143;
        public TagBlock<TagReferenceBlock> CortanaEffects;
        public TagBlock<LightmapAirprobe> LightmapAirprobes;
        [TagField(Padding = true, Length = 12)]
        public byte[] Unused;
        [TagField(MinVersion = CacheVersion.Halo3ODST)]
        public CachedTagInstance MissionVisionModeEffect;
        [TagField(MinVersion = CacheVersion.Halo3ODST, MaxVersion = CacheVersion.Halo3ODST)]
        public CachedTagInstance MissionVisionModeTheaterEffect;
        [TagField(MinVersion = CacheVersion.Halo3ODST)]
        public CachedTagInstance MissionVisionMode;
        [TagField(MinVersion = CacheVersion.HaloOnline106708)]
        public TagBlock<TagReferenceBlock> Unknown155;

        [Flags]
        public enum BspFlags : int
        {
            None = 0,
            Bsp0 = 1 << 0,
            Bsp1 = 1 << 1,
            Bsp2 = 1 << 2,
            Bsp3 = 1 << 3,
            Bsp4 = 1 << 4,
            Bsp5 = 1 << 5,
            Bsp6 = 1 << 6,
            Bsp7 = 1 << 7,
            Bsp8 = 1 << 8,
            Bsp9 = 1 << 9,
            Bsp10 = 1 << 10,
            Bsp11 = 1 << 11,
            Bsp12 = 1 << 12,
            Bsp13 = 1 << 13,
            Bsp14 = 1 << 14,
            Bsp15 = 1 << 15,
            Bsp16 = 1 << 16,
            Bsp17 = 1 << 17,
            Bsp18 = 1 << 18,
            Bsp19 = 1 << 19,
            Bsp20 = 1 << 20,
            Bsp21 = 1 << 21,
            Bsp22 = 1 << 22,
            Bsp23 = 1 << 23,
            Bsp24 = 1 << 24,
            Bsp25 = 1 << 25,
            Bsp26 = 1 << 26,
            Bsp27 = 1 << 27,
            Bsp28 = 1 << 28,
            Bsp29 = 1 << 29,
            Bsp30 = 1 << 30,
            Bsp31 = 1 << 31
        }

        [Flags]
        public enum BspShortFlags : ushort
        {
            None = 0,
            Bsp0 = 1 << 0,
            Bsp1 = 1 << 1,
            Bsp2 = 1 << 2,
            Bsp3 = 1 << 3,
            Bsp4 = 1 << 4,
            Bsp5 = 1 << 5,
            Bsp6 = 1 << 6,
            Bsp7 = 1 << 7,
            Bsp8 = 1 << 8,
            Bsp9 = 1 << 9,
            Bsp10 = 1 << 10,
            Bsp11 = 1 << 11,
            Bsp12 = 1 << 12,
            Bsp13 = 1 << 13,
            Bsp14 = 1 << 14,
            Bsp15 = 1 << 15
        }

        [TagStructure(Size = 0x6C)]
        public class StructureBspBlock : TagStructure
		{
            public CachedTagInstance StructureBsp;
            public CachedTagInstance Design;
            public CachedTagInstance Lighting;
            public int Unknown;
            public float Unknown2;
            public uint Unknown3;
            public uint Unknown4;
            public short Unknown5;
            public short Unknown6;
            public short Unknown7;
            public short Unknown8;
            public CachedTagInstance Cubemap;
            public CachedTagInstance Wind;
            public int Unknown9;
        }

        [TagStructure(Size = 0x14)]
        public class SkyReference : TagStructure
		{
            public CachedTagInstance SkyObject;
            [TagField(Label = true)]
            public short NameIndex;
            public BspShortFlags ActiveBsps;
        }

        [Flags]
        public enum ZoneSetPotentiallyVisibleSetFlags : ushort
        {
            None = 0,
            EmptyDebugPotentiallyVisibleSet = 1 << 0
        }

        [TagStructure(Size = 0x2C)]
        public class ZoneSetPotentiallyVisibleSet : TagStructure
		{
            public uint StructureBspMask;
            public short Version;
            public ZoneSetPotentiallyVisibleSetFlags Flags;
            public TagBlock<BspChecksum> BspChecksums;
            public TagBlock<StructureBspPotentiallyVisibleSet> StructureBspPotentiallyVisibleSets;
            public TagBlock<PortalToDeviceMapping> PortalToDeviceMappings;

            [TagStructure(Size = 0x4)]
            public class BspChecksum : TagStructure
			{
                public uint Checksum;
            }

            [TagStructure(Size = 0x54)]
            public class StructureBspPotentiallyVisibleSet : TagStructure
			{
                public TagBlock<Cluster> Clusters;
                public TagBlock<Cluster> ClustersDoorsClosed;
                public TagBlock<Sky> ClusterSkies;
                public TagBlock<Sky> ClusterVisibleSkies;
                public TagBlock<UnknownBlock> Unknown;
                public TagBlock<UnknownBlock> Unknown2;
                public TagBlock<Cluster2> Clusters2;

                [TagStructure(Size = 0xC)]
                public class Cluster : TagStructure
				{
                    public TagBlock<BitVector> BitVectors;

                    [TagStructure(Size = 0xC)]
                    public class BitVector : TagStructure
					{
                        public TagBlock<Bit> Bits;

                        [TagStructure(Size = 0x4)]
                        public class Bit : TagStructure
						{
                            public AllowFlags Allow;

                            [Flags]
                            public enum AllowFlags : int
                            {
                                None = 0,
                                Bit0 = 1 << 0,
                                Bit1 = 1 << 1,
                                Bit2 = 1 << 2,
                                Bit3 = 1 << 3,
                                Bit4 = 1 << 4,
                                Effects = 1 << 5,
                                Bit6 = 1 << 6,
                                Bit7 = 1 << 7,
                                Bit8 = 1 << 8,
                                Bit9 = 1 << 9,
                                Bit10 = 1 << 10,
                                Bit11 = 1 << 11,
                                Bit12 = 1 << 12,
                                Bit13 = 1 << 13,
                                Bit14 = 1 << 14,
                                Bit15 = 1 << 15,
                                FiringEffects = 1 << 16,
                                Bit17 = 1 << 17,
                                Bit18 = 1 << 18,
                                Bit19 = 1 << 19,
                                Bit20 = 1 << 20,
                                Bit21 = 1 << 21,
                                Bit22 = 1 << 22,
                                Bit23 = 1 << 23,
                                Bit24 = 1 << 24,
                                Bit25 = 1 << 25,
                                Bit26 = 1 << 26,
                                Bit27 = 1 << 27,
                                Bit28 = 1 << 28,
                                Bit29 = 1 << 29,
                                Bit30 = 1 << 30,
                                Bit31 = 1 << 31
                            }
                        }
                    }
                }

                [TagStructure(Size = 0x1)]
                public class Sky : TagStructure
				{
                    public sbyte SkyIndex;
                }

                [TagStructure(Size = 0x4)]
                public class UnknownBlock : TagStructure
				{
                    public uint Unknown;
                }

                [TagStructure(Size = 0xC)]
                public class Cluster2 : TagStructure
				{
                    public TagBlock<UnknownBlock> Unknowns;

                    [TagStructure(Size = 0x1)]
                    public class UnknownBlock : TagStructure
					{
                        public sbyte Unknown;
                    }
                }
            }

            [TagStructure(Size = 0x18)]
            public class PortalToDeviceMapping : TagStructure
			{
                public TagBlock<DevicePortalAssociation> DevicePortalAssociations;
                public TagBlock<GamePortalToPortalMapping> GamePortalToPortalMappings;

                [TagStructure(Size = 0xC)]
                public class DevicePortalAssociation : TagStructure
				{
                    public int UniqueId;
                    public short OriginBspIndex;
                    public ScenarioObjectType ObjectType;
                    public ObjectSource Source;
                    public short FirstGamePortalIndex;
                    public ushort GamePortalCount;
                }

                [TagStructure(Size = 0x2)]
                public class GamePortalToPortalMapping : TagStructure
				{
                    public short PortalIndex;
                }
            }
        }

        public enum ObjectSource : sbyte
        {
            Structure,
            Editor,
            Dynamic,
            Legacy,
            Sky,
            Parent
        }

        [TagStructure(Size = 0x64)]
        public class ZoneSetAudibilityBlock : TagStructure
		{
            public int DoorPortalCount;
            public int UniqueClusterCount;
            public Bounds<float> ClusterDistanceBounds;
            public TagBlock<EncodedDoorPa> EncodedDoorPas;
            public TagBlock<RoomDoorPortalEncodedPa> ClusterDoorPortalEncodedPas;
            public TagBlock<AiDeafeningPa> AiDeafeningPas;
            public TagBlock<RoomDistance> RoomDistances;
            public TagBlock<GamePortalToDoorOccluderMapping> GamePortalToDoorOccluderMappings;
            public TagBlock<BspClusterToRoomBoundsMapping> BspClusterToRoomBoundsMappings;
            public TagBlock<BspClusterToRoomIndex> BspClusterToRoomIndices;

            [TagStructure(Size = 0x4)]
            public class EncodedDoorPa : TagStructure
			{
                public int EncodedData;
            }

            [TagStructure(Size = 0x4)]
            public class RoomDoorPortalEncodedPa : TagStructure
			{
                public int EncodedData;
            }

            [TagStructure(Size = 0x4)]
            public class AiDeafeningPa : TagStructure
			{
                public int EncodedData;
            }

            [TagStructure(Size = 0x4)]
            public class RoomDistance : TagStructure
			{
                public sbyte EncodedData;
            }

            [TagStructure(Size = 0x8)]
            public class GamePortalToDoorOccluderMapping : TagStructure
			{
                public int FirstDoorOccluderIndex;
                public int DoorOccluderCount;
            }

            [TagStructure(Size = 0x8)]
            public class BspClusterToRoomBoundsMapping : TagStructure
			{
                public int FirstRoomIndex;
                public int RoomIndexCount;
            }

            [TagStructure(Size = 0x2)]
            public class BspClusterToRoomIndex : TagStructure
			{
                public short RoomIndex;
            }
        }

        [Flags]
        public enum ZoneSetFlags : int
        {
            None = 0,
            Set0 = 1 << 0,
            Set1 = 1 << 1,
            Set2 = 1 << 2,
            Set3 = 1 << 3,
            Set4 = 1 << 4,
            Set5 = 1 << 5,
            Set6 = 1 << 6,
            Set7 = 1 << 7,
            Set8 = 1 << 8,
            Set9 = 1 << 9,
            Set10 = 1 << 10,
            Set11 = 1 << 11,
            Set12 = 1 << 12,
            Set13 = 1 << 13,
            Set14 = 1 << 14,
            Set15 = 1 << 15,
            Set16 = 1 << 16,
            Set17 = 1 << 17,
            Set18 = 1 << 18,
            Set19 = 1 << 19,
            Set20 = 1 << 20,
            Set21 = 1 << 21,
            Set22 = 1 << 22,
            Set23 = 1 << 23,
            Set24 = 1 << 24,
            Set25 = 1 << 25,
            Set26 = 1 << 26,
            Set27 = 1 << 27,
            Set28 = 1 << 28,
            Set29 = 1 << 29,
            Set30 = 1 << 30,
            Set31 = 1 << 31
        }

        [TagStructure(Size = 0x24)]
        public class ZoneSet : TagStructure
		{
            [TagField(Label = true)]
            public StringId Name;
            public int PotentiallyVisibleSetIndex;
            public int ImportLoadedBsps;
            public BspFlags LoadedBsps;
            public ZoneSetFlags LoadedDesignerZoneSets;
            public ZoneSetFlags UnloadedDesignerZoneSets;
            public ZoneSetFlags LoadedCinematicZoneSets;
            public int BspAtlasIndex;
            public int ScenarioBspAudibilityIndex;
        }

        [TagStructure(Size = 0xC)]
        public class BspAtlasBlock : TagStructure
		{
            [TagField(Label = true)]
            public StringId Name;
            public BspFlags Bsp;
            public BspFlags ConnectedBsps;
        }

        [TagStructure(Size = 0x4)]
        public class CampaignPlayer : TagStructure
		{
            [TagField(Label = true)]
            public StringId PlayerRepresentationName;
        }

        [TagStructure(Size = 0x130)]
        public class Comment : TagStructure
		{
            public RealPoint3d Position;

            public TypeValue Type;

            [TagField(Label = true, Length = 32)]
            public string Name;

            [TagField(Length = 256)]
            public string Text;

            public enum TypeValue : int
            {
                Generic
            }
        }

        [TagStructure(Size = 0x24)]
        public class ObjectName : TagStructure
		{
            [TagField(Label = true, Length = 32)]
            public string Name;
            public GameObjectType ObjectType;
            public short PlacementIndex;
        }

        [Flags]
        public enum ObjectPlacementFlags : int
        {
            None = 0,
            NotAutomatically = 1 << 0,
            NotOnEasy = 1 << 1,
            NotOnNormal = 1 << 2,
            NotOnHard = 1 << 3,
            LockTypeToEnvObject = 1 << 4,
            LockTransformToEnvObject = 1 << 5,
            NeverPlaced = 1 << 6,
            LockNameToEnvObject = 1 << 7,
            CreateAtRest = 1 << 8,
            StoreOrientations = 1 << 9,
            Startup = 1 << 10,
            AttachPhysically = 1 << 11,
            AttachWithScale = 1 << 12,
            NoParentLighting = 1 << 13
        }

        [TagStructure(Size = 0x1C)]
        public class ObjectNodeOrientation : TagStructure
		{
            public short NodeCount;
            [TagField(Padding = true, Length = 2)]
            public byte[] Unused;
            public TagBlock<BitVector> BitVectors;
            public TagBlock<Orientation> Orientations;

            [TagStructure(Size = 0x1)]
            public class BitVector : TagStructure
			{
                public byte Data;
            }

            [TagStructure(Size = 0x2)]
            public class Orientation : TagStructure
			{
                public short Number;
            }
        }

        [TagStructure(Size = 0x54)]
        public class ScenarioInstance : TagStructure
		{
            public short PaletteIndex;
            [TagField(Label = true)]
            public short NameIndex;
            public ObjectPlacementFlags PlacementFlags;
            public RealPoint3d Position;
            public RealEulerAngles3d Rotation;
            public float Scale;
            public TagBlock<ObjectNodeOrientation> NodeOrientations;
            public short Unknown2;
            public ushort OldManualBspFlagsNowZoneSets;
            public StringId UniqueName;
            public uint UniqueHandle;
            public short OriginBspIndex;
            public ScenarioObjectType ObjectType;
            public SourceValue Source;
            public BspPolicyValue BspPolicy;
            public sbyte Unknown3;
            public short EditorFolderIndex;
            public short Unknown4;
            public short ParentNameIndex;
            public StringId ChildName;
            public StringId Unknown5;
            public ushort AllowedZoneSets;
            public short Unknown6;

            public enum SourceValue : sbyte
            {
                Structure,
                Editor,
                Dynamic,
                Legacy,
            }

            public enum BspPolicyValue : sbyte
            {
                Default,
                AlwaysPlaced,
                ManualBspIndex,
            }
        }

        [TagStructure(Size = 0x18, MaxVersion = CacheVersion.Halo3ODST)]
        [TagStructure(Size = 0x1C, MinVersion = CacheVersion.HaloOnline106708)]
        public class PermutationInstance : ScenarioInstance
        {
            public StringId Variant;
            public byte ActiveChangeColors;
            public sbyte Unknown7;
            public sbyte Unknown8;
            public sbyte Unknown9;
            public ArgbColor PrimaryColor;
            public ArgbColor SecondaryColor;
            public ArgbColor TertiaryColor;
            public ArgbColor QuaternaryColor;

            [TagField(MinVersion = CacheVersion.HaloOnline106708)]
            public uint Unknown10;
        }

        [TagStructure(Size = 0x30)]
        public class ScenarioPaletteEntry : TagStructure
		{
            public CachedTagInstance Object;
            public uint Unknown;
            public uint Unknown2;
            public uint Unknown3;
            public uint Unknown4;
            public uint Unknown5;
            public uint Unknown6;
            public uint Unknown7;
            public uint Unknown8;
        }

        [TagStructure(Size = 0x48)]
        public class SceneryInstance : PermutationInstance
        {
            public PathfindingPolicyValue PathfindingPolicy;
            public LightmappingPolicyValue LightmappingPolicy;
            public TagBlock<PathfindingReference> PathfindingReferences;
            public short Unknown11;
            public short Unknown12;
            public SymmetryValue Symmetry;
            public ushort EngineFlags;
            public TeamValue Team;
            public sbyte SpawnSequence;
            public sbyte RuntimeMinimum;
            public sbyte RuntimeMaximum;
            public byte MultiplayerFlags;
            public short SpawnTime;
            public short UnknownSpawnTime;
            public sbyte Unknown13;
            public ShapeValue Shape;
            public sbyte TeleporterChannel;
            public sbyte Unknown14;
            public short Unknown15;
            public short AttachedNameIndex;
            public uint Unknown16;
            public uint Unknown17;
            public float WidthRadius;
            public float Depth;
            public float Top;
            public float Bottom;
            public uint Unknown18;

            public enum PathfindingPolicyValue : short
            {
                TagDefault,
                Dynamic,
                CutOut,
                Standard,
                None,
            }

            public enum LightmappingPolicyValue : short
            {
                TagDefault,
                Dynamic,
                PerVertex,
            }

            [TagStructure]
            public class PathfindingReference : TagStructure
			{
                public short BspIndex;
                public short PathfindingObjectIndex;
            }

            public enum SymmetryValue : int
            {
                Both,
                Symmetric,
                Asymmetric,
            }

            public enum TeamValue : short
            {
                Red,
                Blue,
                Green,
                Orange,
                Purple,
                Yellow,
                Brown,
                Pink,
                Neutral,
            }

            public enum ShapeValue : sbyte
            {
                None,
                Sphere,
                Cylinder,
                Box,
            }
        }

        [TagStructure(Size = 0x8)]
        public class BipedInstance : PermutationInstance
        {
            public float BodyVitalityPercentage;
            public uint Flags;
        }

        [TagStructure(Size = 0x3C)]
        public class VehicleInstance : PermutationInstance
        {
            public float BodyVitalityPercentage;
            public uint Flags;
            public SymmetryValue Symmetry;
            public ushort EngineFlags;
            public TeamValue Team;
            public sbyte SpawnSequence;
            public sbyte RuntimeMinimum;
            public sbyte RuntimeMaximum;
            public byte MultiplayerFlags;
            public short SpawnTime;
            public short UnknownSpawnTime;
            public sbyte Unknown11;
            public ShapeValue Shape;
            public sbyte TeleporterChannel;
            public sbyte Unknown12;
            public short Unknown13;
            public short AttachedNameIndex;
            public uint Unknown14;
            public uint Unknown15;
            public float WidthRadius;
            public float Depth;
            public float Top;
            public float Bottom;
            public uint Unknown16;

            public enum SymmetryValue : int
            {
                Both,
                Symmetric,
                Asymmetric,
            }

            public enum TeamValue : short
            {
                Red,
                Blue,
                Green,
                Orange,
                Purple,
                Yellow,
                Brown,
                Pink,
                Neutral,
            }

            public enum ShapeValue : sbyte
            {
                None,
                Sphere,
                Cylinder,
                Box,
            }
        }

        [TagStructure(Size = 0x38)]
        public class EquipmentInstance : ScenarioInstance
        {
            public uint EquipmentFlags;
            public SymmetryValue Symmetry;
            public ushort EngineFlags;
            public TeamValue Team;
            public sbyte SpawnSequence;
            public sbyte RuntimeMinimum;
            public sbyte RuntimeMaximum;
            public byte MultiplayerFlags;
            public short SpawnTime;
            public short UnknownSpawnTime;
            public sbyte Unknown7;
            public ShapeValue Shape;
            public sbyte TeleporterChannel;
            public sbyte Unknown8;
            public short Unknown9;
            public short AttachedNameIndex;
            public uint Unknown10;
            public uint Unknown11;
            public float WidthRadius;
            public float Depth;
            public float Top;
            public float Bottom;
            public uint Unknown12;

            public enum SymmetryValue : int
            {
                Both,
                Symmetric,
                Asymmetric,
            }

            public enum TeamValue : short
            {
                Red,
                Blue,
                Green,
                Orange,
                Purple,
                Yellow,
                Brown,
                Pink,
                Neutral,
            }

            public enum ShapeValue : sbyte
            {
                None,
                Sphere,
                Cylinder,
                Box,
            }
        }

        [TagStructure(Size = 0x3C)]
        public class WeaponInstance : PermutationInstance
        {
            public short RoundsLeft;
            public short RoundsLoaded;
            public uint WeaponFlags;
            public SymmetryValue Symmetry;
            public ushort EngineFlags;
            public TeamValue Team;
            public sbyte SpawnSequence;
            public sbyte RuntimeMinimum;
            public sbyte RuntimeMaximum;
            public byte MultiplayerFlags;
            public short SpawnTime;
            public short UnknownSpawnTime;
            public sbyte Unknown11;
            public ShapeValue Shape;
            public sbyte TeleporterChannel;
            public sbyte Unknown12;
            public short Unknown13;
            public short AttachedNameIndex;
            public uint Unknown14;
            public uint Unknown15;
            public float WidthRadius;
            public float Depth;
            public float Top;
            public float Bottom;
            public uint Unknown16;

            public enum SymmetryValue : int
            {
                Both,
                Symmetric,
                Asymmetric,
            }

            public enum TeamValue : short
            {
                Red,
                Blue,
                Green,
                Orange,
                Purple,
                Yellow,
                Brown,
                Pink,
                Neutral,
            }

            public enum ShapeValue : sbyte
            {
                None,
                Sphere,
                Cylinder,
                Box,
            }
        }

        [Flags]
        public enum DeviceGroupFlags : int
        {
            None = 0,
            OnlyUseOnce = 1 << 0
        }

        [TagStructure(Size = 0x28, MaxVersion = CacheVersion.Halo3Retail)]
        [TagStructure(Size = 0x2C, MinVersion = CacheVersion.Halo3ODST)]
        public class DeviceGroup : TagStructure
		{
            [TagField(Label = true, Length = 32)]
            public string Name;
            public float InitialValue;
            public DeviceGroupFlags Flags;
            [TagField(MinVersion = CacheVersion.Halo3ODST)]
            public short EditorFolderIndex;
            [TagField(MinVersion = CacheVersion.Halo3ODST)]
            public short Unknown;
        }

        [TagStructure(Size = 0x1C, MaxVersion = CacheVersion.Halo3Retail)]
        [TagStructure(Size = 0x34, MaxVersion = CacheVersion.Halo3ODST)]
        [TagStructure(Size = 0x38, MinVersion = CacheVersion.HaloOnline106708)]
        public class MachineInstance : ScenarioInstance
        {
            [TagField(MinVersion = CacheVersion.Halo3ODST)]
            public StringId Variant;
            [TagField(MinVersion = CacheVersion.Halo3ODST)]
            public byte ActiveChangeColors;
            [TagField(MinVersion = CacheVersion.Halo3ODST)]
            public sbyte Unknown7;
            [TagField(MinVersion = CacheVersion.Halo3ODST)]
            public sbyte Unknown8;
            [TagField(MinVersion = CacheVersion.Halo3ODST)]
            public sbyte Unknown9;
            [TagField(MinVersion = CacheVersion.Halo3ODST)]
            public ArgbColor PrimaryColor;
            [TagField(MinVersion = CacheVersion.Halo3ODST)]
            public ArgbColor SecondaryColor;
            [TagField(MinVersion = CacheVersion.Halo3ODST)]
            public ArgbColor TertiaryColor;
            [TagField(MinVersion = CacheVersion.Halo3ODST)]
            public ArgbColor QuaternaryColor;

            [TagField(MinVersion = CacheVersion.HaloOnline106708)]
            public uint Unknown10;


            public short PowerGroup;
            public short PositionGroup;
            public uint DeviceFlags;
            public uint MachineFlags;
            public TagBlock<PathfindingReference> PathfindingReferences;
            public PathfindingPolicyValue PathfindingPolicy;
            public short Unknown11;

            [TagStructure]
            public class PathfindingReference : TagStructure
			{
                public short BspIndex;
                public short PathfindingObjectIndex;
            }

            public enum PathfindingPolicyValue : short
            {
                TagDefault,
                CutOut,
                Sectors,
                Discs,
                None,
            }
        }

        [TagStructure(Size = 0xC, MaxVersion = CacheVersion.Halo3Retail)]
        [TagStructure(Size = 0x24, MinVersion = CacheVersion.Halo3ODST, MaxVersion = CacheVersion.Halo3ODST)]
        [TagStructure(Size = 0x28, MinVersion = CacheVersion.HaloOnline106708)]
        public class TerminalInstance : ScenarioInstance
        {
            [TagField(MinVersion = CacheVersion.Halo3ODST)]
            public StringId Variant;
            [TagField(MinVersion = CacheVersion.Halo3ODST)]
            public byte ActiveChangeColors;
            [TagField(MinVersion = CacheVersion.Halo3ODST)]
            public sbyte Unknown7;
            [TagField(MinVersion = CacheVersion.Halo3ODST)]
            public sbyte Unknown8;
            [TagField(MinVersion = CacheVersion.Halo3ODST)]
            public sbyte Unknown9;
            [TagField(MinVersion = CacheVersion.Halo3ODST)]
            public ArgbColor PrimaryColor;
            [TagField(MinVersion = CacheVersion.Halo3ODST)]
            public ArgbColor SecondaryColor;
            [TagField(MinVersion = CacheVersion.Halo3ODST)]
            public ArgbColor TertiaryColor;
            [TagField(MinVersion = CacheVersion.Halo3ODST)]
            public ArgbColor QuaternaryColor;

            [TagField(MinVersion = CacheVersion.HaloOnline106708)]
            public uint Unknown10;

            public short PowerGroup;
            public short PositionGroup;
            public uint DeviceFlags;
            public uint MachineFlags;
        }

        [TagStructure(Size = 0x4C)]
        public class AlternateRealityDeviceInstance : PermutationInstance
        {
            public short PowerGroup;
            public short PositionGroup;
            public uint DeviceFlags;
            [TagField(Length = 32)]
            public string TapScriptName;
            [TagField(Length = 32)]
            public string HoldScriptName;
            public short TapScriptIndex;
            public short HoldScriptIndex;
        }

        [TagStructure(Size = 0x10, MaxVersion = CacheVersion.Halo3Retail)]
        [TagStructure(Size = 0x28, MinVersion = CacheVersion.Halo3ODST, MaxVersion = CacheVersion.Halo3ODST)]
        [TagStructure(Size = 0x2C, MinVersion = CacheVersion.HaloOnline106708)]
        public class ControlInstance : ScenarioInstance
        {
            [TagField(MinVersion = CacheVersion.Halo3ODST)]
            public StringId Variant;
            [TagField(MinVersion = CacheVersion.Halo3ODST)]
            public byte ActiveChangeColors;
            [TagField(MinVersion = CacheVersion.Halo3ODST)]
            public sbyte Unknown7;
            [TagField(MinVersion = CacheVersion.Halo3ODST)]
            public sbyte Unknown8;
            [TagField(MinVersion = CacheVersion.Halo3ODST)]
            public sbyte Unknown9;
            [TagField(MinVersion = CacheVersion.Halo3ODST)]
            public ArgbColor PrimaryColor;
            [TagField(MinVersion = CacheVersion.Halo3ODST)]
            public ArgbColor SecondaryColor;
            [TagField(MinVersion = CacheVersion.Halo3ODST)]
            public ArgbColor TertiaryColor;
            [TagField(MinVersion = CacheVersion.Halo3ODST)]
            public ArgbColor QuaternaryColor;

            [TagField(MinVersion = CacheVersion.HaloOnline106708)]
            public uint Unknown10;

            public short PowerGroup;
            public short PositionGroup;
            public uint DeviceFlags;
            public uint ControlFlags;
            public short Unknown11;
            public short Unknown12;
        }

        [TagStructure(Size = 0x1C)]
        public class SoundSceneryInstance : ScenarioInstance
        {
            public int VolumeType;
            public float Height;
            public Bounds<float> OverrideDistance;
            public Bounds<Angle> OverrideConeAngle;
            public float OverrideOuterConeGain;
        }

        [TagStructure(Size = 0x18)]
        public class GiantInstance : PermutationInstance
        {
            public float BodyVitalityPercentage;
            public uint Flags;
            public short Unknown11;
            public short Unknown12;
            public TagBlock<PathfindingReference> PathfindingReferences;

            [TagStructure]
            public class PathfindingReference : TagStructure
			{
                public short BspIndex;
                public short PathfindingObjectIndex;
            }
        }

        [TagStructure(Size = 0x0)]
        public class EffectSceneryInstance : ScenarioInstance
        {
        }

        [TagStructure(Size = 0x38)]
        public class LightVolumeInstance : ScenarioInstance
        {
            public short PowerGroup;
            public short PositionGroup;
            public uint DeviceFlags;
            public TypeValue2 Type2;
            public ushort Flags;
            public LightmapTypeValue LightmapType;
            public ushort LightmapFlags;
            public float LightmapHalfLife;
            public float LightmapLightScale;
            public float X;
            public float Y;
            public float Z;
            public float Width;
            public float HeightScale;
            public Angle FieldOfView;
            public float FalloffDistance;
            public float CutoffDistance;

            public enum TypeValue2 : short
            {
                Sphere,
                Projective,
            }

            public enum LightmapTypeValue : short
            {
                UseLightTagSetting,
                DynamicOnly,
                DynamicWithLightmaps,
                LightmapsOnly,
            }
        }

        [TagStructure(Size = 0x30)]
        public class SandboxObject : TagStructure
		{
            public CachedTagInstance Object;
            [TagField(Label = true)]
            public StringId Name;
            public int MaxAllowed;
            public float Cost;
            public uint Unknown;
            public uint Unknown2;
            public uint Unknown3;
            public uint Unknown4;
            public uint Unknown5;
        }

        [Flags]
        public enum SoftCeilingFlags : ushort
        {
            None = 0,
            IgnoreBipeds = 1 << 0,
            IgnoreVehicles = 1 << 1,
            IgnoreCamera = 1 << 2,
            IgnoreHugeVehicles = 1 << 3
        }

        public enum SoftCeilingType : short
        {
            Acceleration,
            SoftKill,
            SlipSurface
        }

        [TagStructure(Size = 0xC)]
        public class SoftCeiling : TagStructure
		{
            public SoftCeilingFlags Flags;
            public SoftCeilingFlags RuntimeFlags;
            [TagField(Label = true)]
            public StringId Name;
            public SoftCeilingType Type;
            [TagField(Padding = true, Length = 2)]
            public byte[] Unused;
        }

        [TagStructure(Size = 0x54, MaxVersion = CacheVersion.Halo3Retail)]
        [TagStructure(Size = 0x58, MaxVersion = CacheVersion.Halo3ODST)]
        [TagStructure(Size = 0x60, MinVersion = CacheVersion.HaloOnline106708)]
        public class PlayerStartingProfileBlock : TagStructure
		{
            [TagField(Label = true, Length = 32)]
            public string Name;
            public float StartingHealthDamage;
            public float StartingShieldDamage;
            public CachedTagInstance PrimaryWeapon;
            public short PrimaryRoundsLoaded;
            public short PrimaryRoundsTotal;
            public CachedTagInstance SecondaryWeapon;
            public short SecondaryRoundsLoaded;
            public short SecondaryRoundsTotal;
            [TagField(MinVersion = CacheVersion.HaloOnline106708)]
            public uint Unknown;
            [TagField(MinVersion = CacheVersion.HaloOnline106708)]
            public uint Unknown2;
            public byte StartingFragGrenadeCount;
            public byte StartingPlasmaGrenadeCount;
            public byte StartingSpikeGrenadeCount;
            public byte StartingFirebombGrenadeCount;
            [TagField(MinVersion = CacheVersion.Halo3ODST)]
            public short Unknown3;
            [TagField(MinVersion = CacheVersion.Halo3ODST)]
            public short Unknown4;
        }

        public enum PlayerUnitTypeValue : short
        {
            MasterChief,
            Dervish,
            ChiefMultiplayer,
            EliteMultiplayer,
            EliteCoop,
            Monitor
        }

        [Flags]
        public enum PlayerStartingLocationFlags : ushort
        {
            None = 0,
            SurvivalMode = 1 << 0,
            SurvivalModeElite = 1 << 1
        }

        [TagStructure(Size = 0x18, MaxVersion = CacheVersion.Halo3Retail)]
        [TagStructure(Size = 0x1C, MinVersion = CacheVersion.Halo3ODST)]
        public class PlayerStartingLocation : TagStructure
		{
            public RealPoint3d Position;
            public RealEulerAngles2d Facing;
            public short InsertionPointIndex;
            [TagField(MaxVersion = CacheVersion.Halo3Retail)]
            public PlayerUnitTypeValue UnitType;
            [TagField(MinVersion = CacheVersion.Halo3ODST)]
            public PlayerStartingLocationFlags Flags;
            [TagField(MinVersion = CacheVersion.Halo3ODST)]
            public short EditorFolderIndex;
            [TagField(Padding = true, Length = 2, MinVersion = CacheVersion.Halo3ODST)]
            public byte[] Unused;
        }

        public enum TriggerVolumeType : short
        {
            BoundingBox,
            Sector
        }

        [TagStructure(Size = 0x44, MaxVersion = CacheVersion.Halo3Retail)]
        [TagStructure(Size = 0x7C, MinVersion = CacheVersion.Halo3ODST)]
        public class TriggerVolume : TagStructure
		{
            [TagField(Label = true)]
            public StringId Name;
            public short ObjectName;
            public short RuntimeNodeIndex;
            public StringId NodeName;
            [TagField(MinVersion = CacheVersion.Halo3ODST)]
            public TriggerVolumeType Type;
            [TagField(Padding = true, Length = 2, MinVersion = CacheVersion.Halo3ODST)]
            public byte[] Unused;
            public RealVector3d Forward;
            public RealVector3d Up;
            public RealPoint3d Position;
            public RealPoint3d Extents;
            public float ZSink;
            [TagField(MinVersion = CacheVersion.Halo3ODST)]
            public TagBlock<SectorPoint> SectorPoints;
            [TagField(MinVersion = CacheVersion.Halo3ODST)]
            public TagBlock<RuntimeTriangle> RuntimeTriangles;
            [TagField(MinVersion = CacheVersion.Halo3ODST)]
            public Bounds<float> RuntimeSectorXBounds;
            [TagField(MinVersion = CacheVersion.Halo3ODST)]
            public Bounds<float> RuntimeSectorYBounds;
            [TagField(MinVersion = CacheVersion.Halo3ODST)]
            public Bounds<float> RuntimeSectorZBounds;
            [TagField(MinVersion = CacheVersion.Halo3ODST)]
            public float C;
            public short KillVolume;
            public short EditorFolderIndex;

            [TagStructure(Size = 0x14)]
            public class SectorPoint : TagStructure
			{
                public RealPoint3d Position;
                public RealEulerAngles2d Normal;
            }

            [TagStructure(Size = 0x50)]
            public class RuntimeTriangle : TagStructure
			{
                public uint Unknown1;
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
            }
        }

        [TagStructure(Size = 0x40)]
        public class RecordedAnimation : TagStructure
		{
            [TagField(Label = true, Length = 32)]
            public string Name;
            public sbyte Version;
            public sbyte RawAnimationData;
            public sbyte UnitControlDataVersion;
            [TagField(Padding = true, Length = 1)]
            public byte[] Unused1;
            public short LengthOfAnimation;
            [TagField(Padding = true, Length = 2)]
            public byte[] Unused2;
            [TagField(Padding = true, Length = 4)]
            public byte[] Unused3;
            public byte[] RecordedAnimationEventStream;
        }

        [TagStructure(Size = 0x8, MaxVersion = CacheVersion.Halo3Retail)]
        [TagStructure(Size = 0xC, MinVersion = CacheVersion.Halo3ODST)]
        public class ZoneSetSwitchTriggerVolume : TagStructure
		{
            public FlagBits Flags;
            public short BeginZoneSet;
            public short TriggerVolume;
            public short CommitZoneSet;
            [TagField(MinVersion = CacheVersion.Halo3ODST)]
            public short Unknown2;
            [TagField(MinVersion = CacheVersion.Halo3ODST)]
            public short Unknown3;

            [Flags]
            public enum FlagBits : ushort
            {
                None,
                TeleportVehicles = 1 << 0
            }
        }

        [TagStructure(Size = 0x14)]
        public class UnknownBlock : TagStructure
		{
            public uint Unknown;
            public uint Unknown2;
            public uint Unknown3;
            public uint Unknown4;
            public uint Unknown5;
        }

        [TagStructure(Size = 0x24)]
        public class Decal : TagStructure
		{
            public short DecalPaletteIndex;
            public sbyte Yaw;
            public sbyte Pitch;
            public RealQuaternion Rotation;
            public RealPoint3d Position;
            public float Scale;
        }

        [TagStructure(Size = 0x28)]
        public class SquadGroup : TagStructure
		{
            [TagField(Label = true, Length = 32)]
            public string Name = "";

            public short ParentIndex = -1;

            [TagField(Padding = true, Length = 2, MaxVersion = CacheVersion.Halo3Retail)]
            public byte[] Unused1 = new byte[2];

            public short InitialObjective = -1;

            [TagField(Padding = true, Length = 2)]
            public byte[] Unused2 = new byte[2];

            [TagField(MinVersion = CacheVersion.Halo3ODST)]
            public short EditorFolderIndex = -1;
        }

        [Flags]
        public enum SquadFlags : int
        {
            None = 0,
            Bit0 = 1 << 0,
            Blind = 1 << 1,
            Deaf = 1 << 2,
            Braindead = 1 << 3,
            InitiallyPlaced = 1 << 4,
            UnitsNotEnterableByPlayer = 1 << 5,
            FireteamAbsorber = 1 << 6,
            SquadIsRuntime = 1 << 7,
            NoWaveSpawn = 1 << 8,
            SquadIsMusketeer = 1 << 9
        }

        public enum SquadTeam : short
        {
            Default,
            Player,
            Human,
            Covenant,
            Flood,
            Sentinel,
            Heretic,
            Prophet,
            Guilty,
            Unused9,
            Unused10,
            Unused11,
            Unused12,
            Unused13,
            Unused14,
            Unused15,
        }

        [Flags]
        public enum SquadDifficultyFlags : ushort
        {
            None = 0,
            Easy = 1 << 0,
            Normal = 1 << 1,
            Heroic = 1 << 2,
            Legendary = 1 << 3
        }

        public enum SquadMovementMode : short
        {
            Default,
            Climbing,
            Flying
        }

        public enum SquadPatrolMode : short
        {
            PingPong,
            Loop,
            Random
        }

        public enum SquadActivity : short
        {
            None,
            Patrol,
            Stand,
            Crouch,
            StandDrawn,
            CrouchDrawn,
            Combat,
            Backup,
            Guard,
            GuardCrouch,
            GuardWall,
            Typing,
            Kneel,
            Gaze,
            Poke,
            Sniff,
            Track,
            Watch,
            Examine,
            Sleep,
            AtEase,
            Cower,
            TaiChi,
            Pee,
            Doze,
            Eat,
            Medic,
            Work,
            Cheering,
            Injured,
            Captured
        }

        [Flags]
        public enum SquadPointFlags : ushort
        {
            None = 0,
            SingleUse = 1 << 0
        }

        [TagStructure(Size = 0x38)]
        public class SquadPoint : TagStructure
		{
            public short PointIndex;
            public SquadPointFlags Flags;
            public float Delay;
            public float AngleDegrees;
            public StringId ActivityName;
            public SquadActivity Activity;
            public short ActivityVariant;
            [TagField(Length = 32)]
            public string CommandScriptName;
            public short CommandScriptIndex;
            [TagField(Padding = true, Length = 2)]
            public byte[] Unused;
        }

        public enum SquadSeatType : short
        {
            Default,
            Passenger,
            Gunner,
            Driver,
            OutOfVehicle,
            VehicleOnly = 6,
            Passenger2
        }

        public enum SquadGrenadeType : short
        {
            None,
            Frag,
            Plasma,
            Spike,
            Fire
        }

        [TagStructure(Size = 0x40, MaxVersion = CacheVersion.Halo3Retail)]
        [TagStructure(Size = 0x68, MinVersion = CacheVersion.Halo3ODST)]
        public class Squad : TagStructure
		{
            /// <summary>
            /// The name of the squad.
            /// </summary>
            [TagField(Label = true, Length = 32)]
            public string Name;

            /// <summary>
            /// The flags of the squad.
            /// </summary>
            public SquadFlags Flags;

            /// <summary>
            /// The team the squad is on.
            /// </summary>
            public SquadTeam Team;

            /// <summary>
            /// The index of the parent group of the squad.
            /// </summary>
            public short ParentSquadGroupIndex;

            /// <summary>
            /// The initial zone index the squad is placed on.
            /// </summary>
            public short InitialZoneIndex;

            [TagField(MaxVersion = CacheVersion.Halo3Retail)]
            public short TriggerIndex;
            
            public short ObjectiveIndex;

            public short ObjectiveRoleIndex;

            [TagField(MinVersion = CacheVersion.Halo3ODST)]
            public short EditorFolderIndex;

            [TagField(MaxVersion = CacheVersion.Halo3Retail)]
            public TagBlock<BaseSquadBlock> BaseSquad;

            [TagField(MinVersion = CacheVersion.Halo3ODST)]
            public TagBlock<SpawnFormation> SpawnFormations;

            [TagField(MinVersion = CacheVersion.Halo3ODST)]
            public TagBlock<SpawnPoint> SpawnPoints;

            [TagField(MaxVersion = CacheVersion.Halo3Retail)]
            public short Unknown1;
            [TagField(MaxVersion = CacheVersion.Halo3Retail)]
            public short Unknown2;

            [TagField(MinVersion = CacheVersion.Halo3ODST)]
            public StringId ModuleId;

            [TagField(Short = true, MinVersion = CacheVersion.Halo3ODST)]
            public CachedTagInstance SquadTemplate;

            [TagField(MinVersion = CacheVersion.Halo3ODST)]
            public TagBlock<Cell> DesignerCells;

            [TagField(MinVersion = CacheVersion.Halo3ODST)]
            public TagBlock<Cell> TemplatedCells;

            [TagStructure(Size = 0x60)]
            public class BaseSquadBlock : TagStructure
			{
                public SquadDifficultyFlags DifficultyFlags;
                [TagField(Padding = true, Length = 2)]
                public byte[] Unused;
                public short Count;
                public short Unknown3;
                public short CharacterType;
                public short InitialPrimaryWeapon;
                public short InitialSecondaryWeapon;
                public SquadGrenadeType GrenadeType;
                public short Equipment;
                public short Vehicle;
                public StringId VehicleVariant;

                [TagField(Length = 32)]
                public string CommandScriptName;

                public short CommandScriptIndex;
                public short CommandScriptUnknown;

                public StringId InitialState;

                public short ActivityIndex;
                public short ActivityUnknown;

                public short PointSetIndex;
                public SquadPatrolMode PatrolMode;

                public TagBlock<SquadPoint> MultiState;
                public TagBlock<SpawnPoint> StartingLocations;
            }

            [TagStructure(Size = 0x6C)]
            public class SpawnFormation : TagStructure
			{
                public SquadDifficultyFlags DifficultyFlags;
                [TagField(Padding = true, Length = 2)]
                public byte[] Unused;
                public uint Unknown3;
                public uint Unknown4;
                [TagField(Label = true)]
                public StringId Name;
                public RealPoint3d Position;
                public short ReferenceFrameIndex;
                public short ReferenceNavMeshIndex;
                public RealEulerAngles3d Facing;
                public StringId FormationType;
                public uint InitialMovementDistance;
                public SquadMovementMode InitialMovementMode;
                public short PlacementScriptIndex;
                [TagField(Length = 32)]
                public string PlacementScriptName;
                public StringId InitialState;
                public short PointSetIndex;
                public SquadPatrolMode PatrolMode;
                public TagBlock<SquadPoint> Points;
            }

            public enum SpawnPointFlags : ushort
            {
                None = 0,
                InfectionFormExplode = 1 << 0,
                Nothing = 1 << 2,
                AlwaysPlace = 1 << 3,
                InitiallyHidden = 1 << 4,
                VehicleDestroyedWhenNoDriver = 1 << 5,
                VehicleOpen = 1 << 6,
                ActorSurfaceEmerge = 1 << 7,
                ActorSurfaceEmergeAuto = 1 << 8,
                ActorSurfaceEmergeUpwards = 1 << 9
            }

            [TagStructure(Size = 0x88, MaxVersion = CacheVersion.Halo3Retail)]
            [TagStructure(Size = 0x90, MinVersion = CacheVersion.Halo3ODST)]
            public class SpawnPoint : TagStructure
			{
                public SquadDifficultyFlags DifficultyFlags;
                public short Unknown1;

                [TagField(MinVersion = CacheVersion.Halo3ODST)]
                public uint Unknown2;

                [TagField(MinVersion = CacheVersion.Halo3ODST)]
                public uint Unknown3;

                [TagField(Label = true)]
                public StringId Name;

                [TagField(MinVersion = CacheVersion.Halo3ODST)]
                public short CellIndex;
                [TagField(MinVersion = CacheVersion.Halo3ODST)]
                public short Unknown4;

                public RealPoint3d Position;
                public short ReferenceFrameIndex;
                public short ReferenceNavMeshIndex;
                public RealEulerAngles3d Facing;

                [TagField(MaxVersion = CacheVersion.Halo3Retail)]
                public short Unknown5;

                public SpawnPointFlags Flags;
                public short CharacterTypeIndex;
                public short InitialPrimaryWeaponIndex;
                public short InitialSecondaryWeaponIndex;
                public short InitialEquipmentIndex;
                public short VehicleTypeIndex;
                public SquadSeatType SeatType;
                public SquadGrenadeType InitialGrenades;
                public short SwarmCount;

                [TagField(MinVersion = CacheVersion.Halo3ODST)]
                public short Unknown6;

                public StringId ActorVariant;
                public StringId VehicleVariant;
                
                public float InitialMovementDistance;

                [TagField(MinVersion = CacheVersion.Halo3ODST)]
                public SquadMovementMode InitialMovementMode;

                public short EmitterVehicleIndex;
                public short EmitterGiantIndex;
                public short EmitterBipedIndex;

                [TagField(MaxVersion = CacheVersion.Halo3Retail)]
                public SquadMovementMode InitialMovementMode_H3;

                [TagField(Length = 32)]
                public string CommandScriptName;

                public short CommandScriptIndex;
                public short CommandScriptUnknown;

                [TagField(MaxVersion = CacheVersion.Halo3Retail)]
                public StringId InitialState;

                public short ActivityIndex;
                public short ActivityUnknown;

                public short PointSetIndex;
                public SquadPatrolMode PatrolMode;

                public TagBlock<SquadPoint> Points;
            }

            [TagStructure(Size = 0x84)]
            public class Cell : TagStructure
			{
                [TagField(Label = true)]
                public StringId Name;
                public SquadDifficultyFlags DifficultyFlags;
                [TagField(Padding = true, Length = 2)]
                public byte[] Unused1;
                public short MinimumRound;
                public short MaximumRound;
                public short Unknown2;
                public short Unknown3;
                public short Count;
                public short Unknown4;
                public TagBlock<CharacterTypeBlock> CharacterType;
                public TagBlock<ItemBlock> InitialWeapon;
                public TagBlock<ItemBlock> InitialSecondaryWeapon;
                public TagBlock<ItemBlock> InitialEquipment;
                public SquadGrenadeType GrenadeType;
                public short VehicleTypeIndex;
                public StringId VehicleVariant;

                [TagField(Length = 32)]
                public string CommandScriptName;

                public short CommandScriptIndex;
                public short CommandScriptUnknown;

                public StringId InitialState;

                public short PointSetIndex;
                public SquadPatrolMode PatrolMode;

                public TagBlock<SquadPoint> Points;

                [TagStructure(Size = 0x10)]
                public class CharacterTypeBlock : TagStructure
				{
                    public SquadDifficultyFlags DifficultyFlags;
                    [TagField(Padding = true, Length = 2)]
                    public byte[] Unused;
                    public short MinimumRound;
                    public short MaximumRound;
                    public uint Unknown3;
                    public short CharacterTypeIndex;
                    public short Chance;
                }

                [TagStructure(Size = 0x10)]
                public class ItemBlock : TagStructure
				{
                    public short Unknown;
                    public short Unknown2;
                    public short MinimumRound;
                    public short MaximumRound;
                    public uint Unknown3;
                    public short Weapon2;
                    public short Probability;
                }
            }
        }

        [TagStructure(Size = 0x40, MaxVersion = CacheVersion.Halo3Retail)]
        [TagStructure(Size = 0x3C, MinVersion = CacheVersion.Halo3ODST)]
        public class Zone : TagStructure
		{
            [TagField(Label = true, Length = 32)]
            public string Name;

            [TagField(MaxVersion = CacheVersion.Halo3Retail)]
            public ZoneFlags FlagsOld;
            [TagField(MinVersion = CacheVersion.Halo3ODST)]
            public BspFlags FlagsNew;

            [TagField(MaxVersion = CacheVersion.Halo3Retail)]
            public short ManualBspIndex;
            [TagField(MaxVersion = CacheVersion.Halo3Retail)]
            public short Unused;

            public TagBlock<FiringPosition> FiringPositions;
            public TagBlock<Area> Areas;

            [Flags]
            public enum ZoneFlags : int
            {
                None,
                UsesManualBspIndex = 1 << 0
            }

            [TagStructure(Size = 0x28)]
            public class FiringPosition : TagStructure
			{
                public RealPoint3d Position;
                public short ReferenceFrame;
                public short Unknown1;
                public FlagsValue Flags;
                public PostureFlagsValue PostureFlags;
                public short AreaIndex;
                public short ClusterIndex;
                public short Unknown3;
                public short Unknown4;
                public RealEulerAngles2d Normal;
                public uint Unknown5;

                [Flags]
                public enum FlagsValue : ushort
                {
                    None = 0,
                    Open = 1 << 0,
                    Partial = 1 << 1,
                    Closed = 1 << 2,
                    Mobile = 1 << 3,
                    WallLean = 1 << 4,
                    Perch = 1 << 5,
                    GroundPoint = 1 << 6,
                    DynamicCoverPoint = 1 << 7,
                    AutomaticallyGenerated = 1 << 8,
                    NavVolume = 1 << 9,
                    CenterBunkering = 1 << 10
                }

                [Flags]
                public enum PostureFlagsValue : ushort
                {
                    None = 0,
                    CornerLeft = 1 << 0,
                    CornerRight = 1 << 1,
                    Bunker = 1 << 2,
                    BunkerHigh = 1 << 3,
                    BunkerLow = 1 << 4
                }
            }

            [TagStructure(Size = 0x6C, MaxVersion = CacheVersion.Halo3Retail)]
            [TagStructure(Size = 0xA8, MinVersion = CacheVersion.Halo3ODST)]
            public class Area : TagStructure
			{
                [TagField(Label = true, Length = 32)]
                public string Name;
                public AreaFlags Flags;
                public RealPoint3d RuntimeRelativeMeanPoint;
                public int Unknown;
                public float RuntimeStandardDeviation;
                public short FiringPositionStartIndex;
                public short FiringPositionCount;

                [TagField(MinVersion = CacheVersion.Halo3ODST)]
                public short Unknown1_Odst = -1; // maybe "editor folder index"?
                [TagField(MinVersion = CacheVersion.Halo3ODST)]
                public short Unknown2_Odst;

                public short Unknown3;
                public short Unknown4;
                public int Unknown5;

                [TagField(MaxVersion = CacheVersion.Halo3Retail)]
                public uint Unknown6;

                public uint Unknown7;
                public uint Unknown8;
                public uint Unknown9;
                public uint Unknown10;
                public uint Unknown11;
                public short ManualReferenceFrame;
                public short Unknown12;
                public TagBlock<FlightHint> FlightHints;

                [TagField(MinVersion = CacheVersion.Halo3ODST)]
                public TagBlock<Point> Points;

                [TagField(MinVersion = CacheVersion.Halo3ODST)]
                public short RuntimeCarverInversion;

                [TagField(Padding = true, Length = 2, MinVersion = CacheVersion.Halo3ODST)]
                public byte[] Unused = new byte[2];

                [TagField(MinVersion = CacheVersion.Halo3ODST)]
                public AreaGenerationFlags GenerationFlags = AreaGenerationFlags.IgnoreExisting;

                [TagField(MinVersion = CacheVersion.Halo3ODST)] public float Unknown16 = 0.5f;
                [TagField(MinVersion = CacheVersion.Halo3ODST)] public float Unknown17 = 0.5f;
                [TagField(MinVersion = CacheVersion.Halo3ODST)] public float Unknown18 = 0.0f;
                [TagField(MinVersion = CacheVersion.Halo3ODST)] public float Unknown19 = 0.0f;
                [TagField(MinVersion = CacheVersion.Halo3ODST)] public float Unknown20 = 1.0f;
                [TagField(MinVersion = CacheVersion.Halo3ODST)] public float Unknown21 = 1.0f;
                [TagField(MinVersion = CacheVersion.Halo3ODST)] public float Unknown22 = 0.2f;
                [TagField(MinVersion = CacheVersion.Halo3ODST)] public float Unknown23 = 0.7f;
                [TagField(MinVersion = CacheVersion.Halo3ODST)] public float Unknown24 = 0.25f;
                [TagField(MinVersion = CacheVersion.Halo3ODST)] public float Unknown25 = 0.5f;

                [Flags]
                public enum AreaFlags : int
                {
                    None = 0,
                    VehicleArea = 1 << 0,
                    Perch = 1 << 1,
                    ManualReferenceFrame = 1 << 2
                }

                [Flags]
                public enum AreaGenerationFlags : int
                {
                    None = 0,
                    ExcludeCover = 1 << 0,
                    IgnoreExisting = 1 << 1,
                    GenerateRadial = 1 << 2,
                    DoNotStagger = 1 << 3,
                    Airborne = 1 << 4,
                    AirborneStagger = 1 << 5,
                    ContinueCasting = 1 << 6
                }

                [TagStructure(Size = 0x8)]
                public class FlightHint : TagStructure
				{
                    public short FlightHintIndex;
                    public short PointIndex;
                    public uint Unknown;
                }

                [TagStructure(Size = 0x18)]
                public class Point : TagStructure
				{
                    public RealPoint3d Position;
                    public short Unknown1 = -1;
                    public short Unknown2;
                    public RealEulerAngles2d Facing;
                }
            }
        }

        [TagStructure(Size = 0x2C)]
        public class SquadPatrol : TagStructure
		{
            [TagField(Label = true)]
            public StringId Name;
            public TagBlock<Squad> Squads;
            public TagBlock<Point> Points;
            public TagBlock<Transition> Transitions;
            public short EditorFolderIndex;
            [TagField(Padding = true, Length = 2)]
            public byte[] Unused;

            [TagStructure(Size = 0x4)]
            public class Squad : TagStructure
			{
                public short SquadIndex;
                [TagField(Padding = true, Length = 2)]
                public byte[] Unused;
            }

            [TagStructure(Size = 0x14)]
            public class Point : TagStructure
			{
                public short ObjectiveIndex;
                [TagField(Padding = true, Length = 2)]
                public byte[] Unused;
                public float HoldTime;
                public float SearchTime;
                public float PauseTime;
                public float CooldownTime;
            }

            [TagStructure(Size = 0x10)]
            public class Transition : TagStructure
			{
                public short Point1Index;
                public short Point2Index;
                public TagBlock<Waypoint> Waypoints;

                [TagStructure(Size = 0x14)]
                public class Waypoint : TagStructure
				{
                    public RealPoint3d Position;
                    public int PackedKeyOfFaceRefIndex;
                    public int NavMeshUidOfFaceRefIndex;
                }
            }
        }

        [TagStructure(Size = 0x20)]
        public class MissionScene : TagStructure
		{
            [TagField(Label = true)]
            public StringId Name;
            public FlagBits Flags;
            public TagBlock<TriggerCondition> TriggerConditions;
            public TagBlock<Role> Roles;

            [Flags]
            public enum FlagBits : int
            {
                None,
                SceneCanPlayMultipleTimes = 1 << 0,
                EnableCombatDialogue = 1 << 1
            }

            [TagStructure(Size = 0x4)]
            public class TriggerCondition : TagStructure
			{
                public RuleValue CombinationRule;
                [TagField(Padding = true, Length = 2)]
                public byte[] Unused;

                public enum RuleValue : short
                {
                    Or,
                    And
                }
            }

            [TagStructure(Size = 0x14)]
            public class Role : TagStructure
			{
                [TagField(Label = true)]
                public StringId Name;
                public GroupValue Group;
                [TagField(Padding = true, Length = 2)]
                public byte[] Unused;
                public TagBlock<Variant> Variants;

                public enum GroupValue : short
                {
                    Group1,
                    Group2,
                    Group3
                }

                [TagStructure(Size = 0x4)]
                public class Variant : TagStructure
				{
                    [TagField(Label = true)]
                    public StringId Name;
                }
            }
        }

        [TagStructure(Size = 0x6C)]
        public class AiPathfindingDatum : TagStructure
		{
            public TagBlock<LineSegment> LineSegments;
            public TagBlock<Parallelogram> Parallelograms;
            public TagBlock<JumpHint> JumpHints;
            public TagBlock<UnknownBlock4> Unknown4;
            public TagBlock<UnknownBlock5> Unknown5;
            public TagBlock<FlightHint> FlightHints;
            public TagBlock<CookieCutter> CookieCutters;
            public TagBlock<UnknownBlock8> Unknown8;
            public TagBlock<UnknownBlock9> Unknown9;

            [Flags]
            public enum UserHintFlags : int
            {
                None,
                Bidirectional = 1 << 0,
                Closed = 1 << 1
            }

            [TagStructure(Size = 0x24)]
            public class LineSegment : TagStructure
			{
                public UserHintFlags Flags;

                public RealPoint3d Point0;
                public short ReferenceUnknown0;
                public short ReferenceFrame0;

                public RealPoint3d Point1;
                public short ReferenceUnknown1;
                public short ReferenceFrame1;
            }

            [TagStructure(Size = 0x48)]
            public class Parallelogram : TagStructure
			{
                public UserHintFlags Flags;

                public RealPoint3d Point0;
                public short ReferenceUnknown0;
                public short ReferenceFrame0;

                public RealPoint3d Point1;
                public short ReferenceUnknown1;
                public short ReferenceFrame1;

                public RealPoint3d Point2;
                public short ReferenceUnknown2;
                public short ReferenceFrame2;

                public RealPoint3d Point3;
                public short ReferenceUnknown3;
                public short ReferenceFrame3;

                [TagField(Padding = true, Length = 4)]
                public byte[] Unused;
            }

            [TagStructure(Size = 0x8)]
            public class JumpHint : TagStructure
			{
                public FlagsValue Flags;
                public short GeometryIndex;
                public CharacterJumpHeight ForceJumpHeight;
                public ControlFlagsValue ControlFlags;

                [Flags]
                public enum FlagsValue : short
                {
                    None,
                    Bidirectional = 1 << 0,
                    Closed = 1 << 1
                }

                [Flags]
                public enum ControlFlagsValue : ushort
                {
                    None,
                    MagicLift = 1 << 0
                }
            }

            [TagStructure(Size = 0x8)]
            public class UnknownBlock4 : TagStructure
			{
                public int Unknown;
                public uint Unknown2;
            }

            [TagStructure(Size = 0x10, Align = 0x8)]
            public class UnknownBlock5 : TagStructure
			{
                public uint Unknown;
                public TagBlock<UnknownBlock> Unknown2;

                [TagStructure(Size = 0x1C)]
                public class UnknownBlock : TagStructure
				{
                    public uint Unknown1;
                    public uint Unknown2;
                    public uint Unknown3;
                    public uint Unknown4;
                    public uint Unknown5;
                    public uint Unknown6;
                    public uint Unknown7;
                }
            }

            [TagStructure(Size = 0xC)]
            public class FlightHint : TagStructure
			{
                public TagBlock<FlightPoint> FlightPoints;

                [TagStructure(Size = 0xC)]
                public class FlightPoint : TagStructure
				{
                    public RealPoint3d Point;
                }
            }

            [TagStructure(MaxVersion = CacheVersion.Halo3Retail, Size = 0x44)]
            [TagStructure(MinVersion = CacheVersion.Halo3ODST, Size = 0x7C)]
            public class CookieCutter : TagStructure
			{
                public StringId Unknown;
                public short Unknown2;
                public short Unknown3;

                [TagField(MinVersion = CacheVersion.Halo3ODST)]
                public float Unknown4;

                public float Unknown5;
                public float Unknown6;
                public float Unknown7;
                public float Unknown8;
                public float Unknown9;
                public float Unknown10;
                public float Unknown11;
                public float Unknown12;
                public float Unknown13;
                public float Unknown14;
                public float Unknown15;
                public float Unknown16;
                public float Unknown17;

                [TagField(MinVersion = CacheVersion.Halo3ODST)]
                public float Unknown18;

                [TagField(MinVersion = CacheVersion.Halo3ODST)]
                public TagBlock<Point> Points;

                [TagField(MinVersion = CacheVersion.Halo3ODST)]
                public int Unknown20;
                [TagField(MinVersion = CacheVersion.Halo3ODST)]
                public int Unknown21;
                [TagField(MinVersion = CacheVersion.Halo3ODST)]
                public int Unknown22;
                [TagField(MinVersion = CacheVersion.Halo3ODST)]
                public int Unknown23;
                [TagField(MinVersion = CacheVersion.Halo3ODST)]
                public int Unknown24;
                [TagField(MinVersion = CacheVersion.Halo3ODST)]
                public int Unknown25;
                [TagField(MinVersion = CacheVersion.Halo3ODST)]
                public int Unknown26;
                [TagField(MinVersion = CacheVersion.Halo3ODST)]
                public int Unknown27;
                [TagField(MinVersion = CacheVersion.Halo3ODST)]
                public int Unknown28;

                public float Unknown29;
                public short Unknown30;
                public short Unknown31;

                [TagStructure(Size = 0x14)]
                public class Point : TagStructure
				{
                    public float Unknown1;
                    public float Unknown2;
                    public float Unknown3;
                    public float Unknown4;
                    public float Unknown5;
                }
            }

            [TagStructure(MaxVersion = CacheVersion.Halo3Retail, Size = 0xC)]
            [TagStructure(MinVersion = CacheVersion.Halo3ODST, Size = 0x18)]
            public class UnknownBlock8 : TagStructure
			{
                [TagField(MinVersion = CacheVersion.Halo3ODST)]
                public int Unknown;
                [TagField(MinVersion = CacheVersion.Halo3ODST)]
                public int Unknown2;
                [TagField(MinVersion = CacheVersion.Halo3ODST)]
                public int Unknown3;

                public TagBlock<UnknownBlock> Unknown4;

                [TagStructure(MaxVersion = CacheVersion.Halo3Retail, Size = 0xC)]
                [TagStructure(MinVersion = CacheVersion.Halo3ODST, Size = 0x28)]
                public class UnknownBlock : TagStructure
				{
                    [TagField(MaxVersion = CacheVersion.Halo3Retail)]
                    public TagBlock<UnknownBlock2> Unknown;

                    [TagField(MinVersion = CacheVersion.Halo3ODST)]
                    public int Unknown2;
                    [TagField(MinVersion = CacheVersion.Halo3ODST)]
                    public int Unknown3;
                    [TagField(MinVersion = CacheVersion.Halo3ODST)]
                    public int Unknown4;
                    [TagField(MinVersion = CacheVersion.Halo3ODST)]
                    public int Unknown5;
                    [TagField(MinVersion = CacheVersion.Halo3ODST)]
                    public int Unknown6;
                    [TagField(MinVersion = CacheVersion.Halo3ODST)]
                    public int Unknown7;
                    [TagField(MinVersion = CacheVersion.Halo3ODST)]
                    public int Unknown8;
                    [TagField(MinVersion = CacheVersion.Halo3ODST)]
                    public int Unknown9;
                    [TagField(MinVersion = CacheVersion.Halo3ODST)]
                    public int Unknown10;
                    [TagField(MinVersion = CacheVersion.Halo3ODST)]
                    public int Unknown11;

                    [TagStructure(Size = 0x18)]
                    public class UnknownBlock2 : TagStructure
					{
                        public float Unknown;
                        public float Unknown2;
                        public float Unknown3;
                        public short Unknown4;
                        public short Unknown5;
                        public Angle Unknown6;
                        public Angle Unknown7;
                    }
                }
            }

            [TagStructure(MaxVersion = CacheVersion.Halo3Retail, Size = 0x2)]
            [TagStructure(MinVersion = CacheVersion.Halo3ODST, MaxVersion = CacheVersion.Halo3ODST, Size = 0x4)]
            [TagStructure(MinVersion = CacheVersion.HaloOnline106708, Size = 0xC)]
            public class UnknownBlock9 : TagStructure
			{
                [TagField(MinVersion = CacheVersion.Halo3Retail, MaxVersion = CacheVersion.Halo3Retail)]
                public short UnknownH3;
                [TagField(MinVersion = CacheVersion.Halo3ODST)]
                public int Unknown1;
                [TagField(MinVersion = CacheVersion.HaloOnline106708)]
                public int Unknown2;
                [TagField(MinVersion = CacheVersion.HaloOnline106708)]
                public int Unknown3;
            }
        }

        [TagStructure(Size = 0x84)]
        public class ScriptingDatum : TagStructure
		{
            public TagBlock<PointSet> PointSets;

            [TagField(Padding = true, Length = 120)]
            public byte[] Unused;

            [TagStructure(Size = 0x34, MaxVersion = CacheVersion.Halo3Retail)]
            [TagStructure(Size = 0x38, MinVersion = CacheVersion.Halo3ODST)]
            public class PointSet : TagStructure
			{
                [TagField(Label = true, Length = 32)]
                public string Name;
                public TagBlock<Point> Points;
                public short BspIndex;
                public short ManualReferenceFrame;
                public uint Flags;
                [TagField(MinVersion = CacheVersion.Halo3ODST)]
                public short EditorFolderIndex;
                [TagField(MinVersion = CacheVersion.Halo3ODST)]
                public short Unknown;

                [TagStructure(Size = 0x3C)]
                public class Point : TagStructure
				{
                    [TagField(Label = true, Length = 32)]
                    public string Name;
                    public RealPoint3d Position;
                    public short ReferenceFrame;
                    public short Unknown;
                    public int SurfaceIndex;
                    public RealEulerAngles2d FacingDirection;
                }
            }
        }

        [TagStructure(Size = 0x1C, MaxVersion = CacheVersion.Halo3Retail)]
        [TagStructure(Size = 0x20, MinVersion = CacheVersion.Halo3ODST)]
        public class CutsceneFlag : TagStructure
		{
            [TagField(Padding = true, Length = 4)]
            public byte[] Unused;
            [TagField(Label = true)]
            public StringId Name;
            public RealPoint3d Position;
            public RealEulerAngles2d Facing;
            [TagField(MinVersion = CacheVersion.Halo3ODST)]
            public short EditorFolderIndex;
            [TagField(MinVersion = CacheVersion.Halo3ODST)]
            public short SourceBspIndex;
        }

        public enum CutsceneCameraPointType : short
        {
            Normal,
            IgnoreTargetOrientation,
            Dolly,
            IgnoreTargetUpdates
        }

        [Flags]
        public enum CutsceneCameraPointFlags : ushort
        {
            None = 0,
            Bit0 = 1 << 0,
            PrematchCameraHack = 1 << 1,
            PodiumCameraHack = 1 << 2,
            Bit3 = 1 << 3,
            Bit4 = 1 << 4,
            Bit5 = 1 << 5,
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

        [TagStructure(Size = 0x40)]
        public class CutsceneCameraPoint : TagStructure
		{
            public CutsceneCameraPointFlags Flags;
            public CutsceneCameraPointType Type;
            [TagField(Label = true, Length = 32)]
            public string Name;
            [TagField(Padding = true, Length = 4)]
            public byte[] Unused;
            public RealPoint3d Position;
            public RealEulerAngles3d Orientation;
        }

        public enum CutsceneTitleHorizontalJustification : short
        {
            Left,
            Right,
            Center
        }

        public enum CutsceneTitleVerticalJustification : short
        {
            Bottom,
            Top,
            Middle,
            Bottom2,
            Top2
        }

        public enum CutsceneTitleFont : short
        {
            TerminalFont,
            SubtitleFont
        }

        [TagStructure(Size = 0x28)]
        public class CutsceneTitle : TagStructure
		{
            [TagField(Label = true)]
            public StringId Name;
            public Rectangle2d TextBounds;
            public CutsceneTitleHorizontalJustification HorizontalJustification;
            public CutsceneTitleVerticalJustification VerticalJustification;
            public CutsceneTitleFont Font;
            [TagField(Padding = true, Length = 2)]
            public byte[] Unused;
            public ArgbColor TextColor;
            public ArgbColor ShadowColor;
            public float FadeInTime;
            public float Uptime;
            public float FadeOutTime;
        }

        [TagStructure(Size = 0x28)]
        public class ScenarioResource : TagStructure
		{
            public int Unknown;
            public TagBlock<TagReferenceBlock> ScriptSource;
            public TagBlock<TagReferenceBlock> AiResources;
            public TagBlock<Reference> References;

            [TagStructure(Size = 0x130, MaxVersion = CacheVersion.Halo3Retail)]
            [TagStructure(Size = 0x16C, MinVersion = CacheVersion.Halo3ODST)]
            public class Reference : TagStructure
			{
                public CachedTagInstance SceneryResource;
                [TagField(MinVersion = CacheVersion.Halo3ODST)]
                public TagBlock<TagReferenceBlock> OtherScenery;
                public CachedTagInstance BipedsResource;
                [TagField(MinVersion = CacheVersion.Halo3ODST)]
                public TagBlock<TagReferenceBlock> OtherBipeds;
                public CachedTagInstance VehiclesResource;
                public CachedTagInstance EquipmentResource;
                public CachedTagInstance WeaponsResource;
                public CachedTagInstance SoundSceneryResource;
                public CachedTagInstance LightsResource;
                public CachedTagInstance DevicesResource;
                [TagField(MinVersion = CacheVersion.Halo3ODST)]
                public TagBlock<TagReferenceBlock> OtherDevices;
                public CachedTagInstance EffectSceneryResource;
                public CachedTagInstance DecalsResource;
                [TagField(MinVersion = CacheVersion.Halo3ODST)]
                public TagBlock<TagReferenceBlock> OtherDecals;
                public CachedTagInstance CinematicsResource;
                public CachedTagInstance TriggerVolumesResource;
                public CachedTagInstance ClusterDataResource;
                public CachedTagInstance CommentsResource;
                public CachedTagInstance CreatureResource;
                public CachedTagInstance StructureLightingResource;
                public CachedTagInstance DecoratorsResource;
                [TagField(MinVersion = CacheVersion.Halo3ODST)]
                public TagBlock<TagReferenceBlock> OtherDecorators;
                public CachedTagInstance SkyReferencesResource;
                public CachedTagInstance CubemapResource;
            }
        }

        [Flags]
        public enum UnitSeatFlags : int
        {
            None = 0,
            Seat0 = 1 << 0,
            Seat1 = 1 << 1,
            Seat2 = 1 << 2,
            Seat3 = 1 << 3,
            Seat4 = 1 << 4,
            Seat5 = 1 << 5,
            Seat6 = 1 << 6,
            Seat7 = 1 << 7,
            Seat8 = 1 << 8,
            Seat9 = 1 << 9,
            Seat10 = 1 << 10,
            Seat11 = 1 << 11,
            Seat12 = 1 << 12,
            Seat13 = 1 << 13,
            Seat14 = 1 << 14,
            Seat15 = 1 << 15,
            Seat16 = 1 << 16,
            Seat17 = 1 << 17,
            Seat18 = 1 << 18,
            Seat19 = 1 << 19,
            Seat20 = 1 << 20,
            Seat21 = 1 << 21,
            Seat22 = 1 << 22,
            Seat23 = 1 << 23,
            Seat24 = 1 << 24,
            Seat25 = 1 << 25,
            Seat26 = 1 << 26,
            Seat27 = 1 << 27,
            Seat28 = 1 << 28,
            Seat29 = 1 << 29,
            Seat30 = 1 << 30,
            Seat31 = 1 << 31
        }

        [TagStructure(Size = 0xC)]
        public class UnitSeatsMappingBlock : TagStructure
		{
            [TagField(Short = true)]
            public CachedTagInstance Unit;
            public UnitSeatFlags Seats1;
            public UnitSeatFlags Seats2;
        }

        [TagStructure(Size = 0x2)]
        public class ScenarioKillTrigger : TagStructure
		{
            public short TriggerVolume;
        }

        [TagStructure(Size = 0x2)]
        public class ScenarioSafeTrigger : TagStructure
		{
            public short TriggerVolume;
        }

        public enum SoundEnvironmentType : int
        {
            Default,
            InteriorNarrow,
            InteriorSmall,
            InteriorMedium,
            InteriorLarge,
            ExteriorSmall,
            ExteriorMedium,
            ExteriorLarge,
            ExteriorHalfOpen,
            ExteriorOpen
        }

        [Flags]
        public enum BackgroundSoundScaleFlags : int
        {
            None = 0,
            OverrideDefaultScale = 1 << 0,
            UseAdjacentClusterAsPortalScale = 1 << 1,
            UseAdjacentClusterAsExteriorScale = 1 << 2,
            ScaleWithWeatherIntensity = 1 << 3
        }

        [TagStructure(Size = 0x54, MaxVersion = CacheVersion.Halo3Retail)]
        [TagStructure(Size = 0x58, MinVersion = CacheVersion.Halo3ODST)]
        public class BackgroundSoundEnvironmentPaletteBlock : TagStructure
		{
            [TagField(Label = true)]
            public StringId Name;
            public CachedTagInstance SoundEnvironment;
            [TagField(MinVersion = CacheVersion.Halo3ODST)]
            public SoundEnvironmentType Type;
            public float ReverbCutoffDistance;
            public float ReverbInterpolationSpeed;
            public CachedTagInstance AmbienceBackgroundSound;
            public CachedTagInstance AmbienceInsideClusterSound;
            public float AmbienceCutoffDistance;
            public BackgroundSoundScaleFlags AmbienceScaleFlags;
            public float AmbienceInteriorScale;
            public float AmbiencePortalScale;
            public float AmbienceExteriorScale;
            public float AmbienceInterpolationSpeed;
        }

        [TagStructure(Size = 0x78)]
        public class UnknownBlock3 : TagStructure
		{
            [TagField(Label = true, Length = 32)]
            public string Name;
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
        }

        [TagStructure(Size = 0x8)]
        public class FogBlock : TagStructure
		{
            [TagField(Label = true)]
            public StringId Name;
            public short Unknown;
            public short Unknown2;
        }

        [TagStructure(Size = 0x30)]
        public class CameraFxBlock : TagStructure
		{
            [TagField(Label = true)]
            public StringId Name;
            public CachedTagInstance CameraFx;
            public byte Unknown;
            public byte Unknown2;
            public byte Unknown3;
            public byte Unknown4;
            public uint Unknown5;
            public float Unknown6;
            public float Unknown7;
            public float Unknown8;
            public uint Unknown9;
            public uint Unknown10;
        }

        [TagStructure(Size = 0x68, MaxVersion = CacheVersion.HaloOnline449175)]
        [TagStructure(Size = 0x74, MinVersion = CacheVersion.HaloOnline498295)]
        public class ScenarioClusterDatum : TagStructure
		{
            public CachedTagInstance Bsp;
            public TagBlock<BackgroundSoundEnvironment> BackgroundSoundEnvironments;
            public TagBlock<UnknownBlock> Unknown;
            public TagBlock<UnknownBlock2> Unknown2;
            public int BspChecksum;
            public TagBlock<ClusterCentroid> ClusterCentroids;
            public TagBlock<UnknownBlock3> Unknown3;
            public TagBlock<FogBlock> Fog;
            public TagBlock<CameraEffect> CameraEffects;
            [TagField(MinVersion = CacheVersion.HaloOnline498295)]
            public TagBlock<UnknownBlock4> Unknown4;

            [TagStructure(Size = 0x4)]
            public class BackgroundSoundEnvironment : TagStructure
			{
                public short BackgroundSoundEnvironmentIndex;
                public short Unknown;
            }

            [TagStructure(Size = 0x4)]
            public class UnknownBlock : TagStructure
			{
                public short Unknown;
                public short Unknown2;
            }

            [TagStructure(Size = 0x4)]
            public class UnknownBlock2 : TagStructure
			{
                public short Unknown;
                public short Unknown2;
            }

            [TagStructure(Size = 0xC)]
            public class ClusterCentroid : TagStructure
			{
                public RealPoint3d Centroid;
            }

            [TagStructure(Size = 0x4)]
            public class UnknownBlock3 : TagStructure
			{
                public short Unknown;
                public short Unknown2;
            }

            [TagStructure(Size = 0x4)]
            public class FogBlock : TagStructure
			{
                public short FogIndex;
                public short Unknown;
            }

            [TagStructure(Size = 0x4)]
            public class CameraEffect : TagStructure
			{
                public short CameraEffectIndex;
                public short Unknown;
            }

            [TagStructure(Size = 0x4)]
            public class UnknownBlock4 : TagStructure
			{
                public short Unknown;
                public short Unknown2;
            }
        }

        [TagStructure(Size = 0x6C)]
        public class SpawnDatum : TagStructure
		{
            public Bounds<float> DynamicSpawnHeightBounds;
            public float GameObjectResetHeight;
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
            public TagBlock<DynamicSpawnOverload> DynamicSpawnOverloads;
            public TagBlock<SpawnZone> StaticRespawnZones;
            public TagBlock<SpawnZone> StaticInitialSpawnZones;

            [TagStructure(Size = 0x10)]
            public class DynamicSpawnOverload : TagStructure
			{
                public short OverloadType;
                public short Unknown;
                public float InnerRadius;
                public float OuterRadius;
                public float Weight;
            }

            [Flags]
            public enum RelevantTeamFlags : int
            {
                None = 0,
                Red = 1 << 0,
                Blue = 1 << 1,
                Green = 1 << 2,
                Orange = 1 << 3,
                Purple = 1 << 4,
                Yellow = 1 << 5,
                Brown = 1 << 6,
                Pink = 1 << 7,
                Neutral = 1 << 8
            }

            [TagStructure(Size = 0x30)]
            public class SpawnZone : TagStructure
			{
                [TagField(Label = true)]
                public StringId Name;
                public RelevantTeamFlags RelevantTeams;
                public uint RelevantGames;
                public uint Flags;
                public RealPoint3d Position;
                public Bounds<float> HeightBounds;
                public Bounds<float> RadiusBounds;
                public float Weight;
            }
        }

        [TagStructure(Size = 0x44)]
        public class CrateInstance : PermutationInstance
        {
            public uint Unknown11;
            public TagBlock<UnknownBlock2> Unknown12;
            public SymmetryValue Symmetry;
            public ushort EngineFlags;
            public TeamValue Team;
            public sbyte SpawnSequence;
            public sbyte RuntimeMinimum;
            public sbyte RuntimeMaximum;
            public byte MultiplayerFlags;
            public short SpawnTime;
            public short UnknownSpawnTime;
            public sbyte Unknown13;
            public ShapeValue Shape;
            public sbyte TeleporterChannel;
            public sbyte Unknown14;
            public short Unknown15;
            public short AttachedNameIndex;
            public uint Unknown16;
            public uint Unknown17;
            public float WidthRadius;
            public float Depth;
            public float Top;
            public float Bottom;
            public uint Unknown18;

            [TagStructure]
            public class UnknownBlock2 : TagStructure
			{
                public uint Unknown;
            }

            public enum SymmetryValue : int
            {
                Both,
                Symmetric,
                Asymmetric
            }

            public enum TeamValue : short
            {
                Red,
                Blue,
                Green,
                Orange,
                Purple,
                Yellow,
                Brown,
                Pink,
                Neutral
            }

            public enum ShapeValue : sbyte
            {
                None,
                Sphere,
                Cylinder,
                Box
            }
        }

        [TagStructure(Size = 0x48)]
        public class Flock : TagStructure
		{
            [TagField(Label = true)]
            public StringId Name;
            public short FlockPaletteIndex;
            public short BspIndex;
            public short BoundingTriggerVolume;
            public ushort Flags;
            public float EcologyMargin;
            public TagBlock<Source> Sources;
            public TagBlock<Sink> Sinks;
            public Bounds<float> ProductionFrequencyBounds;
            public Bounds<float> ScaleBounds;
            public uint Unknown;
            public uint Unknown2;
            public short CreaturePaletteIndex;
            public Bounds<short> BoidCountBounds;
            public short Unknown3;

            [TagStructure(Size = 0x24)]
            public class Source : TagStructure
			{
                public int Unknown;
                public RealPoint3d Position;
                public RealEulerAngles2d Starting;
                public float Radius;
                public float Weight;
                public sbyte Unknown2;
                public sbyte Unknown3;
                public sbyte Unknown4;
                public sbyte Unknown5;
            }

            [TagStructure(Size = 0x10)]
            public class Sink : TagStructure
			{
                public RealPoint3d Position;
                public float Radius;
            }
        }

        [TagStructure(Size = 0x0)]
        public class CreatureInstance : PermutationInstance
        {
        }

        [TagStructure(Size = 0x104)]
        public class EditorFolder : TagStructure
		{
            public int ParentFolder;

            [TagField(Label = true, Length = 256)]
            public string Name;
        }

        [TagStructure(Size = 0x24)]
        public class Interpolator : TagStructure
		{
            [TagField(Label = true)]
            public StringId Name;
            public StringId AcceleratorName;
            public StringId MultiplierName;
            public byte[] Function;
            public short Unknown;
            public short Unknown2;
        }

        [TagStructure(Size = 0x4)]
        public class SimulationDefinitionTableBlock : TagStructure
		{
            [TagField(Short = true)]
            public CachedTagInstance Tag;
        }

        [TagStructure(Size = 0x10)]
        public class AiObjectId : TagStructure
		{
            public uint ObjectHandle;
            public short OriginBspIndex;
            public ScenarioObjectType ObjectType;
            public ScenarioInstance.SourceValue Source;
            public short Unknown3;
            public short Unknown4;
            public short Unknown5;
            public short Unknown6;
        }

        [Flags]
        public enum AiObjectiveFlags : ushort
        {
            None = 0,
            UseFrontAreaSelection = 1 << 0,
            UsePlayersAsFront = 1 << 1,
            InhibitVehicleEntry = 1 << 2
        }

        [TagStructure(Size = 0x14, MaxVersion = CacheVersion.Halo3Retail)]
        [TagStructure(Size = 0x24, MinVersion = CacheVersion.Halo3ODST)]
        public class AiObjective : TagStructure
		{
            [TagField(Label = true)]
            public StringId Name;

            [TagField(MinVersion = CacheVersion.Halo3ODST)]
            public TagBlock<OpposingObjective> OpposingObjectives;

            [TagField(MinVersion = CacheVersion.Halo3ODST)]
            public AiObjectiveFlags Flags;

            public short Zone;

            public short FirstTaskIndex;

            [TagField(MinVersion = CacheVersion.Halo3ODST)]
            public short EditorFolderIndex;

            public TagBlock<Task> Tasks;

            [TagStructure(Size = 0x4)]
            public class OpposingObjective : TagStructure
			{
                public short ObjectiveIndex;

                [TagField(Padding = true, Length = 2)]
                public byte[] Unused;
            }

            [Flags]
            public enum TaskFlags : ushort
            {
                None = 0,
                LatchOn = 1 << 0,
                LatchOff = 1 << 1,
                Gate = 1 << 2,
                SingleUse = 1 << 3,
                SuppressCombat = 1 << 4,
                SuppressActiveCamo = 1 << 5,
                Blind = 1 << 6,
                Deaf = 1 << 7,
                Braindead = 1 << 8,
                MagicPlayerSight = 1 << 9,
                Disable = 1 << 10,
                IgnoreFronts = 1 << 11,
                DonTGenerateFront = 1 << 12,
                ReverseDirection = 1 << 13,
                InvertFilterLogic = 1 << 14
            }

            [Flags]
            public enum TaskInhibitGroups : ushort
            {
                None = 0,
                Cover = 1 << 0,
                Retreat = 1 << 1,
                VehiclesAll = 1 << 2,
                Grenades = 1 << 3,
                Berserk = 1 << 4,
                Equipment = 1 << 5,
                ObjectInteraction = 1 << 6,
                Turrets = 1 << 7,
                VehiclesNonTurrets = 1 << 8
            }

            [TagStructure(Size = 0xCC, MaxVersion = CacheVersion.Halo3Retail)]
            [TagStructure(Size = 0xE8, MinVersion = CacheVersion.Halo3ODST)]
            public class Task : TagStructure
			{
                public TaskFlags Flags;
                public TaskInhibitGroups InhibitGroups;

                [TagField(MinVersion = CacheVersion.Halo3ODST)]
                public uint Unknown1;
                [TagField(MinVersion = CacheVersion.Halo3ODST)]
                public uint Unknown2;

                public SquadDifficultyFlags InhibitOnDifficulty;
                public MovementValue Movement;
                public FollowValue Follow;
                public short FollowSquadIndex;
                public float FollowRadius;

                [TagField(MinVersion = CacheVersion.Halo3ODST)]
                public FollowPlayerFlags FollowPlayers;

                [TagField(MinVersion = CacheVersion.Halo3ODST, Padding = true, Length = 2)]
                public byte[] Unused = new byte[2];

                [TagField(MinVersion = CacheVersion.Halo3ODST)]
                public TagBlock<FollowFiringPointQueryBlock> FollowFiringPointQuery;

                [TagField(Length = 32)]
                public string EntryScriptName;
                [TagField(Length = 32)]
                public string CommandScriptName;
                [TagField(Length = 32)]
                public string ExhaustionScriptName;

                public short EntryScriptIndex;
                public short CommandScriptIndex;
                public short ExhaustionScriptIndex;

                public short SquadGroupFilter;

                /// <summary>
                /// When someone enters this task for the first time, they play this type of dialogue.
                /// </summary>
                public DialogueTypeValue DialogueType;

                public RuntimeFlagBits RuntimeFlags;

                public TagBlock<Unknown84Block> Unknown84;

                [TagField(MinVersion = CacheVersion.Halo3ODST)]
                public short Unknown20;
                [TagField(MinVersion = CacheVersion.Halo3ODST)]
                public short Unknown21;

                public StringId Name;

                public short HierarchyLevelFrom100;
                public short PreviousRole;
                public short NextRole;
                public short ParentRole;
                public TagBlock<ActivationScriptBlock> ActivationScript;
                public short ScriptIndex;

                /// <summary>
                /// Task will never want to suck in more then N guys over lifetime (soft ceiling only applied when limit exceeded.
                /// </summary>
                public short LifetimeCount;

                public FilterFlagsValue FilterFlags;
                public FilterValue Filter;

                public Bounds<short> Capacity;
                
                /// <summary>
                /// Task becomes inactive after the given number of casualties.
                /// </summary>
                public short MaxBodyCount;

                public AttitudeValue Attitude;
                
                /// <summary>
                /// Task becomes inactive after the strength of the participants falls below the given level.
                /// </summary>
                [TagField(Format = "[0,1]")]
                public float MinStrength;

                public TagBlock<Area> Areas;
                public TagBlock<DirectionBlock> Direction;

                public enum MovementValue : short
                {
                    Run,
                    Walk,
                    Crouch
                }

                public enum FollowValue : short
                {
                    None,
                    Player,
                    Squad
                }

                [Flags]
                public enum FollowPlayerFlags : ushort
                {
                    None,
                    Player0 = 1 << 0,
                    Player1 = 1 << 1,
                    Player2 = 1 << 2,
                    Player3 = 1 << 3
                }

                [TagStructure(Size = 0x1C)]
                public class FollowFiringPointQueryBlock : TagStructure
				{
                    public ShapeTypeValue ShapeType;
                    public AnchorRelationshipValue AnchorRelationship;

                    [TagField(Padding = true, Length = 2)]
                    public byte[] Unused = new byte[2];

                    public float RelationshipOffset;
                    public float Scale;

                    /// <summary>
                    /// Don't include firing points outside of this vertical margin.
                    /// </summary>
                    [TagField(Format = "World Units")]  
                    public float ZThreshold;

                    public RealEulerAngles3d Angles;

                    public enum ShapeTypeValue : sbyte
                    {
                        Circle,
                        Triangle,
                        Square,
                        Bar
                    }

                    public enum AnchorRelationshipValue : sbyte
                    {
                        Center,
                        Front,
                        Back,
                        Left,
                        Right
                    }
                }

                public enum DialogueTypeValue : short
                {
                    None,
                    EnemyIsAdvancing,
                    EnemyIsCharging,
                    EnemyIsFallingBack,
                    Advance,
                    Charge,
                    FallBack,
                    MoveOnMoveone,
                    FollowPlayer,
                    ArrivingIntoCombat,
                    EndCombat,
                    Investigate,
                    SpreadOut,
                    HoldPositionHold,
                    FindCover,
                    CoveringFire
                }

                [Flags]
                public enum RuntimeFlagBits : ushort
                {
                    None,
                    AreaConnectivityValid = 1 << 0
                }

                [TagStructure(Size = 0x8)]
                public class Unknown84Block : TagStructure
				{
                    public uint Unknown;
                    public uint Unknown2;
                }

                [TagStructure(Size = 0x124)]
                public class ActivationScriptBlock : TagStructure
				{
                    [TagField(Label = true, Length = 32)]
                    public string ScriptName;

                    [TagField(Length = 256)]
                    public string ScriptSource;

                    public CompileStateValue CompileState;

                    [TagField(Padding = true, Length = 2)]
                    public byte[] Unused = new byte[2];

                    public enum CompileStateValue : short
                    {
                        Edited,
                        Success,
                        Error
                    }
                }

                [Flags]
                public enum FilterFlagsValue : ushort
                {
                    None,
                    Exclusive = 1 << 0
                }

                public enum FilterValue : short
                {
                    None,
                    Leader,
                    NoLeader,
                    Arbiter,
                    Player,
                    Infantry = 7,
                    Flood = 16,
                    Sentinel,
                    Jackal = 21,
                    Grunt,
                    Hunter,
                    Marine,
                    FloodCombat,
                    FloodCarrier,
                    Brute = 28,
                    Drone = 30,
                    FloodPureform,
                    Warthog = 34,
                    Wraith = 39,
                    Phantom,
                    BruteChopper = 44,
                }

                public enum AttitudeValue : short
                {
                    Normal,
                    Defensive,
                    Aggressive,
                    Playfighting,
                    Patrol,
                    ChcknShitRecon,
                    SpreadOut
                }

                public enum AreaType : short
                {
                    Normal,
                    Search,
                    Core
                }

                [Flags]
                public enum AreaFlags : byte
                {
                    None,
                    Goal = 1 << 0,
                    DirectionValid = 1 << 1
                }

                [TagStructure(Size = 0xA, MaxVersion = CacheVersion.Halo3Retail)]
                [TagStructure(Size = 0x10, MinVersion = CacheVersion.Halo3ODST)]
                public class Area : TagStructure
				{
                    public AreaType Type;

                    public AreaFlags Flags;

                    public byte CharacterFlags;

                    [TagField(MaxVersion = CacheVersion.Halo3Retail)]
                    public short Unknown3;

                    public short ZoneIndex;
                    public short AreaIndex;

                    [TagField(MinVersion = CacheVersion.Halo3ODST)]
                    public Angle Yaw;

                    [TagField(MinVersion = CacheVersion.Halo3ODST)]
                    public short Unknown7; // connectivity?
                    [TagField(MinVersion = CacheVersion.Halo3ODST)]
                    public short Unknown8; // connectivity?
                }

                [TagStructure(Size = 0x20, MaxVersion = CacheVersion.Halo3Retail)]
                [TagStructure(Size = 0xC, MinVersion = CacheVersion.Halo3ODST)]
                public class DirectionBlock : TagStructure
				{
                    [TagField(Length = 2, MaxVersion = CacheVersion.Halo3Retail)]
                    public Point[] Points_H3 = new Point[2];

                    [TagField(MinVersion = CacheVersion.Halo3ODST)]
                    public TagBlock<Point> Points;

                    [TagStructure(Size = 0x10)]
                    public class Point : TagStructure
					{
                        public RealPoint3d Position;
                        public short PackedKeyOfFaceRef;
                        public short NavMeshUidOfFaceRef;
                    }
                }
            }
        }

        [TagStructure(Size = 0x2)]
		public /*was_struct*/ class ObjectReference : TagStructure
		{
            public short Index;
        }

        [TagStructure(Size = 0xBC, MaxVersion = CacheVersion.Halo3Retail)]
        [TagStructure(Size = 0xC8, MaxVersion = CacheVersion.Halo3ODST)]
        [TagStructure(Size = 0xBC, MinVersion = CacheVersion.HaloOnline106708)]
        public class DesignerZoneSet : TagStructure
		{
            [TagField(Label = true)]
            public StringId Name;
            public uint Unknown;
            public TagBlock<ObjectReference> Bipeds;
            public TagBlock<ObjectReference> Vehicles;
            public TagBlock<ObjectReference> Weapons;
            public TagBlock<ObjectReference> Equipment;
            public TagBlock<ObjectReference> Scenery;
            public TagBlock<ObjectReference> Machines;
            public TagBlock<ObjectReference> Terminals;
            public TagBlock<ObjectReference> Controls;
            public TagBlock<ObjectReference> Unknown2;
            [TagField(MinVersion = CacheVersion.Halo3ODST, MaxVersion = CacheVersion.Halo3ODST)]
            public TagBlock<ObjectReference> Unknown3;
            public TagBlock<ObjectReference> Crates;
            public TagBlock<ObjectReference> Creatures;
            public TagBlock<ObjectReference> Giants;
            public TagBlock<ObjectReference> Unknown4;
            public TagBlock<ObjectReference> Characters;
            public uint Unknown5;
            public uint Unknown6;
            public uint Unknown7;
        }

        [TagStructure(Size = 0x4)]
        public class UnknownBlock5 : TagStructure
		{
            public short Unknown;
            public short Unknown2;
        }

        [TagStructure(Size = 0x14)]
        public class CinematicLightingBlock : TagStructure
		{
            [TagField(Label = true)]
            public StringId Name;
            public CachedTagInstance CinematicLight;
        }

        [TagStructure(Size = 0x10, MaxVersion = CacheVersion.Halo3Retail)]
        [TagStructure(Size = 0x1C, MinVersion = CacheVersion.Halo3ODST)]
        public class ScenarioMetagameBlock : TagStructure
		{
            public TagBlock<TimeMultiplier> TimeMultipliers;
            public float ParScore;
            [TagField(MinVersion = CacheVersion.Halo3ODST)]
            public TagBlock<SurvivalBlock> Survival;

            [TagStructure(Size = 0x8)]
            public class TimeMultiplier : TagStructure
			{
                public float Time;
                public float Multiplier;
            }

            [TagStructure(Size = 0x8)]
            public class SurvivalBlock : TagStructure
			{
                public short InsertionIndex;
                public short Unknown;
                public float ParScore;
            }
        }

        [TagStructure(Size = 0x8, MaxVersion = CacheVersion.Halo3Retail)]
        [TagStructure(Size = 0x18, MinVersion = CacheVersion.Halo3ODST)]
        public class UnknownBlock6 : TagStructure
		{
            public float Unknown;
            public float Unknown2;
            [TagField(MinVersion = CacheVersion.Halo3ODST)]
            public float Unknown3;
            [TagField(MinVersion = CacheVersion.Halo3ODST, MaxVersion = CacheVersion.Halo3ODST)]
            public TagBlock<UnknownBlock> Unknowns;
            [TagField(MinVersion = CacheVersion.HaloOnline106708)]
            public float Unknown4;
            [TagField(MinVersion = CacheVersion.HaloOnline106708)]
            public float Unknown5;
            [TagField(MinVersion = CacheVersion.HaloOnline106708)]
            public float Unknown6;

            [TagStructure(Size = 0x28)]
            public class UnknownBlock : TagStructure
			{
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
            }
        }

        [TagStructure(Size = 0x10)]
        public class UnknownBlock7 : TagStructure
		{
            public uint Unknown;
            public uint Unknown2;
            public uint Unknown3;
            public short Unknown4;
            public short Unknown5;
        }
        
        [TagStructure(Size = 0x14)]
        public class LightmapAirprobe : TagStructure
		{
            public uint Unknown;
            public uint Unknown2;
            public uint Unknown3;
            public StringId Unknown4;
            public short Unknown5;
            public short Unknown6;
        }
    }

    public enum ScenarioMapType : sbyte
    {
        SinglePlayer,
        Multiplayer,
        MainMenu
    }

    public enum ScenarioMapSubType : sbyte
    {
        None,
        Hub,
        Level,
        Scene,
        Cinematic
    }

    [Flags]
    public enum ScenarioFlags : ushort
    {
        None = 0,
        Bit0 = 1 << 0,
        Bit1 = 1 << 1,
        Bit2 = 1 << 2,
        Bit3 = 1 << 3,
        Bit4 = 1 << 4,
        CharactersUsePreviousMissionWeapons = 1 << 5,
    }
}