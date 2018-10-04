using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TagTool.Audio;
using TagTool.Cache;
using TagTool.Common;
using TagTool.Damage;
using TagTool.Geometry;
using TagTool.Havok;
using TagTool.Tags;
using TagTool.Shaders;
using TagTool.Tags.Definitions;
using TagTool.Serialization;

namespace TagTool.Commands.Porting
{
    public partial class PortTagCommand : Command
	{
		private HaloOnlineCacheContext CacheContext { get; }
		private CacheFile BlamCache;
		private RenderGeometryConverter GeometryConverter { get; }

		private Dictionary<Tag, List<string>> ReplacedTags = new Dictionary<Tag, List<string>>();

		private List<Tag> RenderMethodTagGroups = new List<Tag> { new Tag("rmbk"), new Tag("rmcs"), new Tag("rmd "), new Tag("rmfl"), new Tag("rmhg"), new Tag("rmsh"), new Tag("rmss"), new Tag("rmtr"), new Tag("rmw "), new Tag("rmrd"), new Tag("rmct") };
		private List<Tag> EffectTagGroups = new List<Tag> { new Tag("beam"), new Tag("cntl"), new Tag("ltvl"), new Tag("decs"), new Tag("prt3") };

		private static readonly string[] DoNotReplaceGroups = new[]
		{
			"glps",
			"glvs",
			"vtsh",
			"pixl",
			"rmdf",
			"rmt2"
		};

		private readonly Dictionary<Tag, CachedTagInstance> DefaultTags = new Dictionary<Tag, CachedTagInstance> { };

		public PortTagCommand(HaloOnlineCacheContext cacheContext, CacheFile blamCache) :
			base(true,

				"PortTag",
				PortTagCommand.GetPortingFlagsDescription(),
				"PortTag [Options] <Tag>",
				"")
		{
			CacheContext = cacheContext;
			BlamCache = blamCache;
			GeometryConverter = new RenderGeometryConverter(cacheContext, blamCache);

			foreach (var tagType in TagDefinition.Types.Keys)
                DefaultTags[tagType] = CacheContext.TagCache.Index.FindFirstInGroup(tagType);
		}

		public override object Execute(List<string> args)
		{
			if (args.Count < 1)
				return false;

			var portingOptions = args.Take(args.Count - 1).ToList();
			ParsePortingOptions(portingOptions);

			var initialStringIdCount = CacheContext.StringIdCache.Strings.Count;

			//
			// Convert Blam data to ElDorado data
			//

			var resourceStreams = new Dictionary<ResourceLocation, Stream>();

			using (var cacheStream = FlagIsSet(PortingFlags.Memory) ? new MemoryStream() : (Stream)CacheContext.OpenTagCacheReadWrite())
			{
				if (FlagIsSet(PortingFlags.Memory))
					using (var cacheFileStream = CacheContext.OpenTagCacheRead())
						cacheFileStream.CopyTo(cacheStream);

				var oldFlags = Flags;

				foreach (var blamTag in ParseLegacyTag(args.Last()))
				{
					ConvertTag(cacheStream, resourceStreams, blamTag);
					Flags = oldFlags;
				}

				if (FlagIsSet(PortingFlags.Memory))
					using (var cacheFileStream = CacheContext.OpenTagCacheReadWrite())
					{
						cacheFileStream.Seek(0, SeekOrigin.Begin);
						cacheFileStream.SetLength(cacheFileStream.Position);

						cacheStream.Seek(0, SeekOrigin.Begin);
						cacheStream.CopyTo(cacheFileStream);
					}
			}

			if (initialStringIdCount != CacheContext.StringIdCache.Strings.Count)
				using (var stringIdCacheStream = CacheContext.OpenStringIdCacheReadWrite())
					CacheContext.StringIdCache.Save(stringIdCacheStream);

			CacheContext.SaveTagNames();

			foreach (var entry in resourceStreams)
			{
				if (FlagIsSet(PortingFlags.Memory))
					using (var resourceFileStream = CacheContext.OpenResourceCacheReadWrite(entry.Key))
					{
						resourceFileStream.Seek(0, SeekOrigin.Begin);
						resourceFileStream.SetLength(resourceFileStream.Position);

						entry.Value.Seek(0, SeekOrigin.Begin);
						entry.Value.CopyTo(resourceFileStream);
					}

				entry.Value.Close();
			}

			return true;
		}

		private List<CacheFile.IndexItem> ParseLegacyTag(string tagSpecifier)
		{
			if (tagSpecifier.Length == 0 || (!char.IsLetter(tagSpecifier[0]) && !tagSpecifier.Contains('*')) || !tagSpecifier.Contains('.'))
				throw new Exception($"Invalid tag name: {tagSpecifier}");

			var tagIdentifiers = tagSpecifier.Split('.');

			if (!CacheContext.TryParseGroupTag(tagIdentifiers[1], out var groupTag))
				throw new Exception($"Invalid tag name: {tagSpecifier}");

			var tagName = tagIdentifiers[0];

			List<CacheFile.IndexItem> result = new List<CacheFile.IndexItem>();

			// find the CacheFile.IndexItem(s)
			if (tagName == "*") result = BlamCache.IndexItems.FindAll(
				item => item != null && groupTag == item.GroupTag);
			else result.Add(BlamCache.IndexItems.Find(
				item => item != null && groupTag == item.GroupTag && tagName == item.Name));

			if (result.Count == 0)
				throw new Exception($"Invalid tag name: {tagSpecifier}");

			return result;
		}

		public CachedTagInstance ConvertTag(Stream cacheStream, Dictionary<ResourceLocation, Stream> resourceStreams, CacheFile.IndexItem blamTag)
		{
			CachedTagInstance result = null;
#if !DEBUG
            try
            {
#endif
			var oldFlags = Flags;
			result = ConvertTagInternal(cacheStream, resourceStreams, blamTag);
			Flags = oldFlags;
#if !DEBUG
            }
            catch (Exception e)
            {
                Console.WriteLine();
                Console.WriteLine($"{e.GetType().Name} while porting '{blamTag.Name}.{blamTag.GroupName}':");
                Console.WriteLine($"\t{e.Message}");
                Console.WriteLine();
                throw e;
            }
#endif
			return result;
		}

		public CachedTagInstance ConvertTagInternal(Stream cacheStream, Dictionary<ResourceLocation, Stream> resourceStreams, CacheFile.IndexItem blamTag)
		{
			if (blamTag == null)
				return null;

			var groupTag = blamTag.GroupTag;

			//
			// Handle tags that are not ready to be ported
			//

			switch (groupTag.ToString())
			{
				case "shit": // use the global shit tag until shit tags are port-able
					return CacheContext.GetTag<ShieldImpact>(@"globals\global_shield_impact_settings");

				case "sncl": // always use the default sncl tag
					return CacheContext.GetTag<SoundClasses>(@"sound\sound_classes");

				case "rmw ": // Until water vertices port, always null water shaders to prevent the screen from turning blue. Can return 0x400F when fixed
					return CacheContext.GetTag<ShaderWater>(@"levels\multi\riverworld\shaders\riverworld_water_rough");

				case "rmcs": // there are no rmcs tags in ms23, disable completely for now

				case "rmbk": // Unknown, black shaders don't exist in HO, only in ODST, might be just complete blackness
					return CacheContext.GetTag<Shader>(@"shaders\invalid");

				//TODO: Someday we might be able to generate these, but for now lets just use the standard vertex shaders
				case "glvs":
					return CacheContext.GetTag<GlobalVertexShader>(@"shaders\shader_shared_vertex_shaders");
				case "glps":
					return CacheContext.GetTag<GlobalPixelShader>(@"shaders\shader_shared_pixel_shaders");
				case "rmct":
					if (!HaloShaderGenerator.HaloShaderGenerator.LibraryLoaded)
					{
						return CacheContext.GetTag<Shader>(@"shaders\invalid");
					}
					break;
				case "rmt2":
					if (HaloShaderGenerator.HaloShaderGenerator.LibraryLoaded)
					{
						// discard cortana shaders
						if (blamTag.Name.ToLower().Contains("cortana_template"))
						{
							if (CacheContext.TryGetTag<RenderMethodTemplate>(blamTag.Name, out var rmt2Instance))
								return rmt2Instance;

							return null; // This will be generated in the shader post
						}
					}
					// unsupported shaders use default behavior
					break;

				case "rmhg" when !FlagIsSet(PortingFlags.Rmhg): // rmhg have register indexing issues currently
					if (CacheContext.TryGetTag<ShaderHalogram>(blamTag.Name, out var rmhgInstance))
						return rmhgInstance;
					return CacheContext.GetTag<ShaderHalogram>(@"objects\ui\shaders\editor_gizmo");

				// Don't port rmdf tags when using ShaderTest (MatchShaders doesn't port either but that's handled elsewhere).
				//case "rmdf" when FlagIsSet(PortingFlags.ShaderTest) && CacheContext.TagNames.ContainsValue(blamTag.Name) && BlamCache.Version >= CacheVersion.Halo3Retail:
					//return CacheContext.GetTag<RenderMethodDefinition>(blamTag.Name);
				//case "rmdf" when FlagIsSet(PortingFlags.ShaderTest) && !CacheContext.TagNames.ContainsValue(blamTag.Name) && BlamCache.Version >= CacheVersion.Halo3Retail:
					//Console.WriteLine($"WARNING: Unable to locate `{blamTag.Name}.rmdf`; using `shaders\\shader.rmdf` instead.");
					//return CacheContext.GetTag<RenderMethodDefinition>(@"shaders\shader");
			}

			//
			// Handle shader tags when not porting or matching shaders
			//

			if (!FlagsAnySet(/*PortingFlags.ShaderTest | */PortingFlags.MatchShaders) &&
				(RenderMethodTagGroups.Contains(groupTag) || EffectTagGroups.Contains(groupTag)))
			{
				switch (groupTag.ToString())
				{
					case "beam":
						return CacheContext.GetTag<BeamSystem>(@"objects\weapons\support_high\spartan_laser\fx\firing_3p");

					case "cntl":
						return CacheContext.GetTag<ContrailSystem>(@"objects\weapons\pistol\needler\fx\projectile");

					case "decs":
						return CacheContext.GetTag<DecalSystem>(@"fx\decals\impact_plasma\impact_plasma_medium\hard");

					case "ltvl":
						return CacheContext.GetTag<LightVolumeSystem>(@"objects\weapons\pistol\plasma_pistol\fx\charged\projectile");

					case "prt3":
						return CacheContext.GetTag<Particle>(@"fx\particles\energy\sparks\impact_spark_orange");

					case "rmd ":
						return CacheContext.GetTag<ShaderDecal>(@"objects\gear\human\military\shaders\human_military_decals");

					case "rmfl":
						return CacheContext.GetTag<ShaderFoliage>(@"levels\multi\riverworld\shaders\riverworld_tree_leafa");

					case "rmtr":
						return CacheContext.GetTag<ShaderTerrain>(@"levels\multi\riverworld\shaders\riverworld_ground");

					case "rmrd":
					case "rmsh":
					case "rmss":
						return CacheContext.GetTag<Shader>(@"shaders\invalid");
				}
			}

			//
			// Check to see if the ElDorado tag exists
			//

			CachedTagInstance edTag = null;

			TagGroup edGroup = null;

			if (TagGroup.Instances.ContainsKey(groupTag))
			{
				edGroup = TagGroup.Instances[groupTag];
			}
			else
			{
				edGroup = new TagGroup(
					blamTag.GroupTag,
					blamTag.ParentGroupTag,
					blamTag.GrandparentGroupTag,
					CacheContext.GetStringId(blamTag.GroupName));
			}

			if ((groupTag == "snd!") && !FlagIsSet(PortingFlags.Audio))
			{
				PortingConstants.DefaultTagNames.TryGetValue(groupTag, out string defaultSoundName);
				CacheContext.TryGetTag($"{defaultSoundName}.{groupTag}", out CachedTagInstance result);
				return result;
			}

			var wasReplacing = FlagIsSet(PortingFlags.Replace);
			var wasNew = FlagIsSet(PortingFlags.New);
			var wasSingle = FlagIsSet(PortingFlags.Recursive);

			if (!FlagIsSet(PortingFlags.Elites) && groupTag == "bipd" && (blamTag.Name.Contains("elite") || blamTag.Name.Contains("dervish")))
				return null;

			if (ReplacedTags.ContainsKey(groupTag) && ReplacedTags[groupTag].Contains(blamTag.Name))
			{
				foreach (var instance in CacheContext.TagCache.Index)
				{
                    if (instance == null || !instance.IsInGroup(blamTag.GroupTag) || instance.Name == null || instance.Name != blamTag.Name)
                        continue;

					if (instance.IsInGroup("rm  ") && !FlagIsSet(PortingFlags.Ms30))
					{
						var rm = CacheContext.Deserialize<RenderMethod>(cacheStream, instance);
						var rmt2 = CacheContext.Deserialize<RenderMethodTemplateFast>(cacheStream, rm.ShaderProperties[0].Template);

						if (rmt2.VertexShader?.Index >= 0x4455 || rmt2.PixelShader?.Index >= 0x4455)
							continue;
					}

					if (instance.Group.Tag == groupTag)
						return edTag = instance;
				}
			}
			else if (!FlagIsSet(PortingFlags.New))
			{
				foreach (var instance in CacheContext.TagCache.Index)
				{
					if (instance == null || !instance.IsInGroup(groupTag) || instance.Name == null || instance.Name != blamTag.Name)
						continue;

					if (instance.IsInGroup("rm  ") && !FlagIsSet(PortingFlags.Ms30))
					{
						var rm = CacheContext.Deserialize<RenderMethod>(cacheStream, instance);
						var rmt2 = CacheContext.Deserialize<RenderMethodTemplateFast>(cacheStream, rm.ShaderProperties[0].Template);

						if (rmt2.VertexShader?.Index >= 0x4455 || rmt2.PixelShader?.Index >= 0x4455)
							continue;
                    }

                    if (FlagIsSet(PortingFlags.Replace) && !DoNotReplaceGroups.Contains(instance.Group.Tag.ToString()))
                    {
                        if (!FlagIsSet(PortingFlags.Recursive) && wasSingle)
                            ToggleFlags(PortingFlags.Replace | PortingFlags.Recursive);

                        edTag = instance;
                        break;
                    }

                    return edTag = instance;
                }
			}

			if (FlagIsSet(PortingFlags.New) && !FlagIsSet(PortingFlags.Recursive) && wasSingle)
				ToggleFlags(PortingFlags.New | PortingFlags.Recursive);

			//
			// If isReplacing is true, check current tags if there is an existing instance to replace
			//

			var replacedTags = ReplacedTags.ContainsKey(groupTag) ?
				(ReplacedTags[groupTag] ?? new List<string>()) :
				new List<string>();

			replacedTags.Add(blamTag.Name);
			ReplacedTags[groupTag] = replacedTags;

			//
			// Allocate Eldorado Tag
			//

			if (edTag == null)
			{
				if (FlagIsSet(PortingFlags.UseNull))
				{
					var i = CacheContext.TagCache.Index.ToList().FindIndex(n => n == null);

					if (i >= 0)
						CacheContext.TagCache.Index[i] = edTag = new CachedTagInstance(i, edGroup);
				}
				else
				{
					edTag = CacheContext.TagCache.AllocateTag(edGroup);
				}
			}

			edTag.Name = blamTag.Name;

			//
			// Load the Blam tag definition
			//

			var blamContext = new CacheSerializationContext(ref BlamCache, blamTag);
			var blamDefinition = BlamCache.Deserializer.Deserialize(blamContext, TagDefinition.Find(groupTag));

			//
			// Perform pre-conversion fixups to the Blam tag definition
			//

			switch (blamDefinition)
			{
				case RenderModel mode when BlamCache.Version < CacheVersion.Halo3Retail:
					foreach (var material in mode.Materials)
						material.RenderMethod = null;
					break;

				case Scenario scenario when !FlagIsSet(PortingFlags.Squads):
					scenario.Squads = new TagBlock<Scenario.Squad>();
					break;
				case Scenario scenario when !FlagIsSet(PortingFlags.ForgePalette):
					scenario.SandboxEquipment.Clear();
					scenario.SandboxGoalObjects.Clear();
					scenario.SandboxScenery.Clear();
					scenario.SandboxSpawning.Clear();
					scenario.SandboxTeleporters.Clear();
					scenario.SandboxVehicles.Clear();
					scenario.SandboxWeapons.Clear();
					break;

				case ScenarioStructureBsp bsp: // named instanced geometry instances, useless unless we decompile bsp's
					foreach (var instance in bsp.InstancedGeometryInstances)
						instance.Name = StringId.Invalid;
					break;
			}

			//
			// Perform automatic conversion on the Blam tag definition
			//

			blamDefinition = ConvertData(cacheStream, resourceStreams, blamDefinition, blamDefinition, blamTag.Name);

			//
			// Perform post-conversion fixups to Blam data
			//

			switch (blamDefinition)
			{
				case AreaScreenEffect sefc:
					if (BlamCache.Version < CacheVersion.Halo3ODST)
					{
						sefc.GlobalHiddenFlags = AreaScreenEffect.HiddenFlagBits.UpdateThread | AreaScreenEffect.HiddenFlagBits.RenderThread;

						foreach (var screenEffect in sefc.ScreenEffects)
							screenEffect.HiddenFlags = AreaScreenEffect.HiddenFlagBits.UpdateThread | AreaScreenEffect.HiddenFlagBits.RenderThread;
					}
					if (blamTag.Name == @"levels\ui\mainmenu\sky\ui")
					{
						sefc.ScreenEffects[0].Unknown4 = 1E-19f;
						sefc.ScreenEffects[0].Duration = 1E-19f;
					}
					break;

				case Bitmap bitm:
					blamDefinition = ConvertBitmap(resourceStreams, blamTag, bitm);
					break;

				case CameraFxSettings cfxs:
					blamDefinition = ConvertCameraFxSettings(cfxs);
					break;

				case Character character:
					blamDefinition = ConvertCharacter(character);
					break;

				case ChudDefinition chdt:
					blamDefinition = ConvertChudDefinition(chdt);
					break;

				case ChudGlobalsDefinition chudGlobals:
					blamDefinition = ConvertChudGlobalsDefinition(chudGlobals);
					break;

				case Cinematic cine:
					blamDefinition = ConvertCinematic(cine);
					break;

				case CinematicScene cisc:
					blamDefinition = ConvertCinematicScene(cisc);
					break;

				case Dialogue udlg:
					blamDefinition = ConvertDialogue(cacheStream, udlg);
					break;

				case Effect effect when BlamCache.Version == CacheVersion.Halo3Retail:
					//foreach (var even in effect.Events)
					//foreach (var particleSystem in even.ParticleSystems)
					//particleSystem.Unknown7 = 1.0f / particleSystem.Unknown7;
					break;

				case Globals matg:
					blamDefinition = ConvertGlobals(cacheStream, matg);
					break;

				case LensFlare lens:
					blamDefinition = ConvertLensFlare(lens);
					break;

				case ModelAnimationGraph jmad:
					blamDefinition = ConvertModelAnimationGraph(resourceStreams, jmad);
					break;

				case MultilingualUnicodeStringList unic:
					blamDefinition = ConvertMultilingualUnicodeStringList(unic);
					break;

				case Particle particle when BlamCache.Version == CacheVersion.Halo3Retail:
					// Shift all flags above 2 by 1.
					particle.Flags = (particle.Flags & 0x3) + ((int)(particle.Flags & 0xFFFFFFFC) << 1);
					break;

				// If there is no valid resource in the prtm tag, null the mode itself to prevent crashes
				case ParticleModel particleModel when BlamCache.Version >= CacheVersion.Halo3Retail && particleModel.Geometry.Resource.Page.Index == -1:
					blamDefinition = null;
					break;

				case PhysicsModel phmo:
					blamDefinition = ConvertPhysicsModel(phmo);
					break;

				case Projectile proj:
					blamDefinition = ConvertProjectile(proj);
					break;

				case RasterizerGlobals rasg:
					blamDefinition = ConvertRasterizerGlobals(rasg);
					break;

				// If there is no valid resource in the mode tag, null the mode itself to prevent crashes (engineer head, harness)
				case RenderModel mode when BlamCache.Version >= CacheVersion.Halo3Retail && mode.Geometry.Resource.Page.Index == -1:
					blamDefinition = null;
					break;

				case RenderModel mode when blamTag.Name == @"levels\multi\snowbound\sky\sky":
					mode.Materials[11].RenderMethod = CacheContext.GetTag<Shader>(@"levels\multi\snowbound\sky\shaders\dust_clouds");
					break;

				case RenderModel renderModel when BlamCache.Version < CacheVersion.Halo3Retail:
					blamDefinition = ConvertGen2RenderModel(resourceStreams, renderModel);
					break;

				case Scenario scnr:
					blamDefinition = ConvertScenario(cacheStream, resourceStreams, scnr, blamTag.Name);
					break;

				case ScenarioLightmap sLdT:
					blamDefinition = ConvertScenarioLightmap(cacheStream, resourceStreams, blamTag.Name, sLdT);
					break;

				case ScenarioLightmapBspData Lbsp:
					blamDefinition = ConvertScenarioLightmapBspData(Lbsp);
					break;

				case ScenarioStructureBsp sbsp:
					blamDefinition = ConvertScenarioStructureBsp(resourceStreams, sbsp, edTag);
					break;

				case SkyAtmParameters skya:
					// Decrease secondary fog intensity (it's quite sickening in ms23)
					// foreach (var atmosphere in skya.AtmosphereProperties)
					// atmosphere.FogIntensity2 /= 36.0f;
					break;

				case Sound sound:
					blamDefinition = ConvertSound(resourceStreams, sound, blamTag.Name);
					break;

				case SoundLooping lsnd:
					blamDefinition = ConvertSoundLooping(lsnd);
					break;

				case SoundMix snmx:
					blamDefinition = ConvertSoundMix(snmx);
					break;

				case StructureDesign sddt:
					blamDefinition = ConvertStructureDesign(sddt);
					break;

				case Style style:
					blamDefinition = ConvertStyle(style);
					break;

				// Fix shotgun reloading
				case Weapon weapon when blamTag.Name == "objects\\weapons\\rifle\\shotgun\\shotgun":
					weapon.Unknown24 = 1 << 16;
					break;
				case Weapon weapon when blamTag.Name.EndsWith("\\weapon\\warthog_horn"):
					foreach (var attach in weapon.Attachments)
						attach.PrimaryScale = CacheContext.GetStringId("primary_rate_of_fire");
					break;

				case ShaderCortana shader_cortana:
					ConvertShaderCortana(cacheStream, shader_cortana);
					break;
			}

			//
			// Finalize and serialize the new ElDorado tag definition
			//

			if (blamDefinition == null) //If blamDefinition is null, return null tag.
			{
				CacheContext.TagCache.Index[edTag.Index] = null;
				return null;
			}

			CacheContext.Serialize(cacheStream, edTag, blamDefinition);

			if (FlagIsSet(PortingFlags.Print))
				Console.WriteLine($"['{edTag.Group.Tag}', 0x{edTag.Index:X4}] {edTag.Name}.{CacheContext.GetString(edTag.Group.Name)}");

			return edTag;
		}

		private object ConvertData(Stream cacheStream, Dictionary<ResourceLocation, Stream> resourceStreams, object data, object definition, string blamTagName)
		{
			switch (data)
			{
				case StringId stringId:
					stringId = ConvertStringId(stringId);
					return stringId;

				case null:  // no conversion necessary
				case ValueType _:   // no conversion necessary
				case string _:  // no conversion necessary
					return data;

				case TagFunction tagFunction:
					return ConvertTagFunction(tagFunction);

				case CachedTagInstance tag:
					{
						if (!FlagIsSet(PortingFlags.Recursive))
						{
							foreach (var instance in CacheContext.TagCache.Index.FindAllInGroup(tag.Group))
							{
								if (instance == null || instance.Name == null)
									continue;

								if (instance.Name == blamTagName)
									return instance;
							}

							return null;
						}

						tag = PortTagReference(tag.Index);

						if (tag != null && !(FlagsAnySet(PortingFlags.New | PortingFlags.Replace)))
							return tag;

						return ConvertTag(cacheStream, resourceStreams, BlamCache.IndexItems.Find(i => i.ID == ((CachedTagInstance)data).Index));
					}

				case CollisionMoppCode collisionMopp:
					collisionMopp.Data = ConvertCollisionMoppData(collisionMopp.Data);
					return collisionMopp;

				case DamageReportingType damageReportingType:
					return ConvertDamageReportingType(damageReportingType);

				case GameObjectType gameObjectType:
					return ConvertGameObjectType(gameObjectType);

				case ObjectTypeFlags objectTypeFlags:
					return ConvertObjectTypeFlags(objectTypeFlags);

				case BipedPhysicsFlags bipedPhysicsFlags:
					return ConvertBipedPhysicsFlags(bipedPhysicsFlags);

				case WeaponFlags weaponFlags:
					return ConvertWeaponFlags(weaponFlags);

				case RenderMaterial.PropertyType propertyType when BlamCache.Version < CacheVersion.Halo3Retail:
					if (!Enum.TryParse(propertyType.Halo2.ToString(), out propertyType.Halo3))
						throw new NotSupportedException(propertyType.Halo2.ToString());
					return propertyType;

				case RenderMethod renderMethod when FlagIsSet(PortingFlags.MatchShaders):
					ConvertTagBlock(cacheStream, resourceStreams, renderMethod.ShaderProperties[0].ShaderMaps, renderMethod.ShaderProperties[0].ShaderMaps, blamTagName);
					return ConvertRenderMethod(cacheStream, resourceStreams, renderMethod, blamTagName);

				case ScenarioObjectType scenarioObjectType:
					return ConvertScenarioObjectType(scenarioObjectType);

				case SoundClass soundClass:
					return soundClass.ConvertSoundClass(BlamCache.Version);

				case TagBlock tagBlock:
					tagBlock = ConvertTagBlock(cacheStream, resourceStreams, tagBlock, definition, blamTagName);
					return tagBlock;

				// Inline-arrays/tag-data
				case Array _:
				case IList _:
					data = ConvertCollection(cacheStream, resourceStreams, data as IList, definition, blamTagName);
					return data;

				case RenderGeometry renderGeometry when BlamCache.Version >= CacheVersion.Halo3Retail:
					renderGeometry = ConvertStructure(cacheStream, resourceStreams, renderGeometry, definition, blamTagName);
					renderGeometry = GeometryConverter.Convert(renderGeometry, resourceStreams, Flags);
					return renderGeometry;

				case Mesh.Part part when BlamCache.Version < CacheVersion.Halo3Retail:
					part = ConvertStructure(cacheStream, resourceStreams, part, definition, blamTagName);
					if (!Enum.TryParse(part.TypeOld.ToString(), out part.TypeNew))
						throw new NotSupportedException(part.TypeOld.ToString());
					return part;

				case RenderMaterial.Property property when BlamCache.Version < CacheVersion.Halo3Retail:
					property = ConvertStructure(cacheStream, resourceStreams, property, definition, blamTagName);
					property.IntValue = property.ShortValue;
					return property;

				case Model.GlobalDamageInfoBlock newDamageInfo:
					newDamageInfo = ConvertStructure(cacheStream, resourceStreams, newDamageInfo, definition, blamTagName);
					newDamageInfo = ConvertNewDamageInfo(newDamageInfo);
					return newDamageInfo;

				case TagStructure tagStructure: // much faster to pattern match a type than to check for custom attributes.
					tagStructure = ConvertStructure(cacheStream, resourceStreams, tagStructure, definition, blamTagName);
					return data;

				case PixelShaderReference _:
				case VertexShaderReference _:
					return null;

				default:
					Console.WriteLine($"WARNING: Unhandled type in `ConvertData`: {data.GetType().Name} (probably harmless).");
					break;
			}

			return data;
		}

		private IList ConvertCollection(Stream cacheStream, Dictionary<ResourceLocation, Stream> resourceStreams, IList data, object definition, string blamTagName)
		{
			// return early where possible
			if (data is null || data.Count == 0)
				return data;
			var type = data[0].GetType();
			if ((type.IsValueType && type != typeof(StringId)) ||
				type == typeof(string))
				return data;

			// convert each element
			for (var i = 0; i < data.Count; i++)
			{
				var oldValue = data[i];
				var newValue = ConvertData(cacheStream, resourceStreams, oldValue, definition, blamTagName);
				data[i] = newValue;
			}

			return data;
		}

		private TagBlock ConvertTagBlock(Stream cacheStream, Dictionary<ResourceLocation, Stream> resourceStreams, TagBlock block, object definition, string blamTagName)
		{
			// return early where possible
			if (block is null || block.Count == 0)
				return block;
			var type = block[0].GetType();
			if ((type.IsValueType && type != typeof(StringId)) ||
				type == typeof(string))
				return block;

			// convert each element
			for (var i = 0; i < block.Count; i++)
			{
				var oldValue = block[i];
				var newValue = ConvertData(cacheStream, resourceStreams, oldValue, definition, blamTagName);
				block[i] = newValue as TagStructure;
			}

			return block;
		}

		private T ConvertStructure<T>(Stream cacheStream, Dictionary<ResourceLocation, Stream> resourceStreams, T data, object definition, string blamTagName) where T : TagStructure
		{
			foreach (var tagFieldInfo in TagStructure.GetTagFieldEnumerable(data.GetType(), CacheContext.Version))
			{
				// skip the field if no conversion is needed
				if ((tagFieldInfo.FieldType.IsValueType && tagFieldInfo.FieldType != typeof(StringId)) ||
					tagFieldInfo.FieldType == typeof(string))
					continue;
				var oldValue = tagFieldInfo.GetValue(data);
				if (oldValue is null)
					continue;

				// convert the field
				var newValue = ConvertData(cacheStream, resourceStreams, oldValue, definition, blamTagName);
				tagFieldInfo.SetValue(data, newValue);
			}

			return data;
		}

		private Model.GlobalDamageInfoBlock ConvertNewDamageInfo(Model.GlobalDamageInfoBlock newDamageInfo)
		{
			if (!Enum.TryParse(newDamageInfo.CollisionDamageReportingTypeOld.HaloOnline.ToString(), out newDamageInfo.CollisionDamageReportingTypeNew))
				newDamageInfo.CollisionDamageReportingTypeNew = Model.GlobalDamageInfoBlock.DamageReportingTypeNew.Guardians;

			if (!Enum.TryParse(newDamageInfo.ResponseDamageReportingTypeOld.HaloOnline.ToString(), out newDamageInfo.ResponseDamageReportingTypeNew))
				newDamageInfo.ResponseDamageReportingTypeNew = Model.GlobalDamageInfoBlock.DamageReportingTypeNew.Guardians;

			return newDamageInfo;
		}

		private ObjectTypeFlags ConvertObjectTypeFlags(ObjectTypeFlags objectTypeFlags)
		{
			if (BlamCache.Version == CacheVersion.Halo3Retail)
			{
				if (!Enum.TryParse(objectTypeFlags.Halo3Retail.ToString(), out objectTypeFlags.Halo3ODST))
					throw new FormatException(BlamCache.Version.ToString());
			}

			return objectTypeFlags;
		}

		private BipedPhysicsFlags ConvertBipedPhysicsFlags(BipedPhysicsFlags bipedPhysicsFlags)
		{
			if (!Enum.TryParse(bipedPhysicsFlags.Halo3Retail.ToString(), out bipedPhysicsFlags.Halo3Odst))
				throw new FormatException(BlamCache.Version.ToString());

			return bipedPhysicsFlags;
		}

		private WeaponFlags ConvertWeaponFlags(WeaponFlags weaponFlags)
		{
			if (weaponFlags.OldFlags.HasFlag(WeaponFlags.OldWeaponFlags.WeaponUsesOldDualFireErrorCode))
				weaponFlags.OldFlags &= ~WeaponFlags.OldWeaponFlags.WeaponUsesOldDualFireErrorCode;

			if (!Enum.TryParse(weaponFlags.OldFlags.ToString(), out weaponFlags.NewFlags))
				throw new FormatException(BlamCache.Version.ToString());

			return weaponFlags;
		}

		private DamageReportingType ConvertDamageReportingType(DamageReportingType damageReportingType)
		{
			string value = null;

			switch (BlamCache.Version)
			{
				case CacheVersion.Halo2Vista:
				case CacheVersion.Halo2Xbox:
					value = damageReportingType.Halo2Retail.ToString();
					break;

				case CacheVersion.Halo3ODST:
					value = damageReportingType.Halo3ODST.ToString();
					break;

				case CacheVersion.Halo3Retail:
					value = damageReportingType.Halo3Retail.ToString();
					break;
			}

			if (value == null || !Enum.TryParse(value, out damageReportingType.HaloOnline))
				throw new NotSupportedException(value ?? CacheContext.Version.ToString());

			return damageReportingType;
		}

		private TagFunction ConvertTagFunction(TagFunction function)
		{
			return TagFunction.ConvertTagFunction(function);
		}

		private GameObjectType ConvertGameObjectType(GameObjectType objectType)
		{
			if (BlamCache.Version == CacheVersion.Halo3Retail)
				if (!Enum.TryParse(objectType.Halo3Retail.ToString(), out objectType.Halo3ODST))
					throw new FormatException(BlamCache.Version.ToString());

			return objectType;
		}

		private ScenarioObjectType ConvertScenarioObjectType(ScenarioObjectType objectType)
		{
			if (BlamCache.Version == CacheVersion.Halo3Retail)
				if (!Enum.TryParse(objectType.Halo3Retail.ToString(), out objectType.Halo3ODST))
					throw new FormatException(BlamCache.Version.ToString());

			return objectType;
		}

		private StringId ConvertStringId(StringId stringId)
		{
			if (stringId == StringId.Invalid)
				return stringId;

			var value = BlamCache.Version < CacheVersion.Halo3Retail ?
				BlamCache.Strings.GetItemByID((int)(stringId.Value & 0xFFFF)) :
				BlamCache.Strings.GetString(stringId);

			var edStringId = BlamCache.Version < CacheVersion.Halo3Retail ?
				CacheContext.GetStringId(value) :
				CacheContext.StringIdCache.GetStringId(stringId.Set, value);

			if ((stringId != StringId.Invalid) && (edStringId != StringId.Invalid))
				return edStringId;

			if (((stringId != StringId.Invalid) && (edStringId == StringId.Invalid)) || !CacheContext.StringIdCache.Contains(value))
				return CacheContext.StringIdCache.AddString(value);

			return StringId.Invalid;
		}

		private CachedTagInstance PortTagReference(int index, int maxIndex = 0xFFFF)
		{
			if (index == -1)
				return null;

			var blamTag = BlamCache.IndexItems.Find(i => i.ID == index);

            if (blamTag == null)
            {
                foreach (var instance in CacheContext.TagCache.Index)
                {
                    if (instance == null || !instance.IsInGroup(blamTag.GroupTag) || instance.Name == null || instance.Name != blamTag.Name || instance.Index >= maxIndex)
                        continue;

                    return instance;
                }
            }

			return null;
		}
	}
}