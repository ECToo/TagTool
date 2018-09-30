﻿using System.Collections.Generic;
using System.Linq;
using TagTool.Cache;
using TagTool.Tags.Definitions;

namespace TagTool.Commands.ModelAnimationGraphs
{
    class SortModesCommand : Command
    {
        private HaloOnlineCacheContext CacheContext { get; }
        private ModelAnimationGraph Definition { get; }

        public SortModesCommand(HaloOnlineCacheContext cacheContext, ModelAnimationGraph definition) :
            base(false,
                
                "SortModes",
                "Sorts all \"modes\" block elements in the current model_animation_graph based on their name's string_id set and index.",
                
                "SortModes",

                "Sorts all \"modes\" block elements in the current model_animation_graph based on their name's string_id set and index.")
        {
            CacheContext = cacheContext;
            Definition = definition;
        }

        public override object Execute(List<string> args)
        {
            if (args.Count != 0)
                return false;

            Definition.Modes = Definition.Modes.OrderBy(a => a.Label.Set).ThenBy(a => a.Label.Index).ToBlock();

            foreach (var mode in Definition.Modes)
            {
                mode.WeaponClass = mode.WeaponClass.OrderBy(a => a.Label.Set).ThenBy(a => a.Label.Index).ToBlock();

                foreach (var weaponClass in mode.WeaponClass)
                {
                    weaponClass.WeaponType = weaponClass.WeaponType.OrderBy(a => a.Label.Set).ThenBy(a => a.Label.Index).ToBlock();

                    foreach (var weaponType in weaponClass.WeaponType)
                    {
                        weaponType.Actions = weaponType.Actions.OrderBy(a => a.Label.Set).ThenBy(a => a.Label.Index).ToBlock();
                        weaponType.Overlays = weaponType.Overlays.OrderBy(a => a.Label.Set).ThenBy(a => a.Label.Index).ToBlock();
                        weaponType.DeathAndDamage = weaponType.DeathAndDamage.OrderBy(a => a.Label.Set).ThenBy(a => a.Label.Index).ToBlock();
                        weaponType.Transitions = weaponType.Transitions.OrderBy(a => a.FullName.Set).ThenBy(a => a.FullName.Index).ToBlock();

                        foreach (var transition in weaponType.Transitions)
                            transition.Destinations = transition.Destinations.OrderBy(a => a.FullName.Set).ThenBy(a => a.FullName.Index).ToBlock();
                    }
                }
            }

            return true;
        }
    }
}