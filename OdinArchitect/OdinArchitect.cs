using BepInEx;
using UnityEngine;
using BepInEx.Configuration;
using System;
using System.Collections.Generic;
using Jotunn;
using Jotunn.Managers;
using System.IO;
using Jotunn.Utils;
using Jotunn.Entities;
using Jotunn.Configs;
using HarmonyLib;
using System.Reflection;

namespace OdinArchitect
{
    [BepInPlugin(PluginGUID, PluginName, PluginVersion)]
    [BepInDependency(Jotunn.Main.ModGuid)]
    internal class OdinArchitect : BaseUnityPlugin
    {
        public const string PluginGUID = "com.raelaziel";
        public const string PluginName = "OdinArchitect";
        public const string PluginVersion = "0.0.5";

        private AssetBundle OdinArchitectBundle;
        private static GameObject OA_wooden_gate_1_prefab;
        private CustomPiece OA_wooden_gate_1;
        private static GameObject OA_wooden_window_small_prefab;
        private CustomPiece OA_wooden_window_small;
        private static GameObject OA_wooden_window_big_prefab;
        private CustomPiece OA_wooden_window_big;
        private static GameObject OA_wooden_fence_1_prefab;
        private CustomPiece OA_wooden_fence_1_big;
        private static GameObject OA_wooden_fence_1_gate_prefab;
        private CustomPiece OA_wooden_fence_1_gate_big;
        private static GameObject OA_wooden_fence_2_prefab;
        private CustomPiece OA_wooden_fence_2_big;
        private static GameObject OA_wooden_fence_2_gate_prefab;
        private CustomPiece OA_wooden_fence_2_gate_big;
        private static GameObject OA_thin_wood_beam_1_prefab;
        private CustomPiece OA_thin_wood_beam_1;
        private static GameObject OA_thin_wood_beam_2_prefab;
        private CustomPiece OA_thin_wood_beam_2;
        private static GameObject OA_thin_wood_pole_1_prefab;
        private CustomPiece OA_thin_wood_pole_1;
        private static GameObject OA_thin_wood_pole_2_prefab;
        private CustomPiece OA_thin_wood_pole_2;
        private static GameObject OA_wooden_drawbridge_1_prefab;
        private CustomPiece OA_wooden_drawbridge_1;
        private static GameObject OA_wooden_arch_1_prefab;
        private CustomPiece OA_wooden_arch_1;
        private static GameObject OA_refined_stakewall_1_prefab;
        private CustomPiece OA_refined_stakewall_1;
        private static GameObject OA_refined_sharpstakes_prefab;
        private CustomPiece OA_refined_sharpstakes;
        private static GameObject OA_food_smelter_prefab;
        private CustomPiece OA_food_smelter;
        private static GameObject OA_surtling_lantern_4_prefab;
        private CustomPiece OA_surtling_lantern_4;
        private CustomPiece OA_surtling_lantern_3;
        private static GameObject OA_surtling_lantern_3_prefab;
        private CustomPiece OA_surtling_lantern_2;
        private static GameObject OA_surtling_lantern_2_prefab;
        private CustomPiece OA_surtling_lantern_1;
        private static GameObject OA_surtling_lantern_1_prefab;
        private static GameObject OA_stone_beam_short_prefab;
        private CustomPiece OA_stone_beam_short;
        private static GameObject OA_stone_beam_long_prefab;
        private CustomPiece OA_stone_beam_long;
        private static GameObject OA_stone_pole_short_prefab;
        private CustomPiece OA_stone_pole_short;
        private static GameObject OA_stone_pole_long_prefab;
        private CustomPiece OA_stone_pole_long;
        private static GameObject OA_stone_window_small_prefab;
        private CustomPiece OA_stone_window_small;
        private static GameObject OA_stone_window_big_prefab;
        private CustomPiece OA_stone_window_big;
        private static GameObject OA_stone_arch_1_prefab;
        private CustomPiece OA_stone_arch_1;
        private static GameObject OA_stone_arch_2_small_prefab;
        private CustomPiece OA_stone_arch_2_small;
        private static GameObject OA_stone_table_1_prefab;
        private CustomPiece OA_stone_table_1;
        private static GameObject OA_stone_throne_1_prefab;
        private CustomPiece OA_stone_throne_1;
        private static GameObject OA_stonewall_hardrock_1x1_prefab;
        private CustomPiece OA_stonewall_hardrock_1x1;
        private static GameObject OA_stonewall_hardrock_2x1_prefab;
        private CustomPiece OA_stonewall_hardrock_2x1;
        private static GameObject OA_stonewall_hardrock_4x2_prefab;
        private CustomPiece OA_stonewall_hardrock_4x2;
        private static GameObject OA_stonewall_hardrock_arch_prefab;
        private CustomPiece OA_stonewall_hardrock_arch;
        private static GameObject OA_stonewall_hardrock_pillar_prefab;
        private CustomPiece OA_stonewall_hardrock_pillar;
        private static GameObject OA_stonewall_hardrock_stairs_prefab;
        private CustomPiece OA_stonewall_hardrock_stairs;
        private static GameObject OA_big_pillar_prefab;
        private CustomPiece OA_big_pillar;
        private static GameObject OA_iron_dragon_prefab;
        private CustomPiece OA_iron_dragon;
        private static GameObject OA_iron_gate_big_prefab;
        private CustomPiece OA_iron_gate_big;
        private static GameObject OA_iron_gate_small_prefab;
        private CustomPiece OA_iron_gate_small;
        private static GameObject OA_piece_woodbeam_25_thin_prefab;
        private CustomPiece OA_piece_woodbeam_25_thin;
        private static GameObject OA_piece_woodbeam_45_thin_prefab;
        private CustomPiece OA_piece_woodbeam_45_thin;
        private static GameObject OA_iron_beam_short_prefab;
        private static GameObject OA_iron_beam_long_prefab;
        private static GameObject OA_iron_pole_short_prefab;
        private static GameObject OA_iron_pole_long_prefab;
        private CustomPiece OA_iron_beam_short;
        private CustomPiece OA_iron_beam_long;
        private CustomPiece OA_iron_pole_short;
        private CustomPiece OA_iron_pole_long;
        private static GameObject OA_thin_iron_beam_1_prefab;
        private CustomPiece OA_thin_iron_beam_1;
        private static GameObject OA_thin_iron_beam_2_prefab;
        private CustomPiece OA_thin_iron_beam_2;
        private static GameObject OA_thin_iron_pole_1_prefab;
        private CustomPiece OA_thin_iron_pole_1;
        private static GameObject OA_thin_iron_pole_2_prefab;
        private CustomPiece OA_thin_iron_pole_2;
        private static GameObject OA_piece_ironbeam_45_thin_prefab;
        private static GameObject OA_piece_ironbeam_25_thin_prefab;
        private CustomPiece OA_piece_ironbeam_25_thin;
        private CustomPiece OA_piece_ironbeam_45_thin;
        private static GameObject OA_stone_floor_1_new_prefab;
        private CustomPiece OA_stone_floor_1_new;
        private static GameObject OA_rae_woodwall_1_prefab;
        private CustomPiece OA_rae_woodwall_1;
        private static GameObject OA_rae_woodwall_2_prefab;
        private static GameObject OA_rae_woodwall_3_prefab;
        private static GameObject OA_rae_woodwall_4_prefab;
        private CustomPiece OA_rae_woodwall_2;
        private CustomPiece OA_rae_woodwall_3;
        private CustomPiece OA_rae_woodwall_4;
        private static GameObject OA_rae_woodwall_half_prefab;
        private CustomPiece OA_rae_woodwall_half;
        private static GameObject OA_rae_woodwall_3_half_prefab;
        private CustomPiece OA_rae_woodwall_3_half;
        private static GameObject OA_rae_woodwall_1_half_prefab;
        private CustomPiece OA_rae_woodwall_1_half;
        private static GameObject OA_rae_woodwall_2_half_prefab;
        private CustomPiece OA_rae_woodwall_2_half;
        private static GameObject OA_rae_woodwall_4_half_prefab;
        private CustomPiece OA_rae_woodwall_4_half;

        private void Awake()
        {
            OA_LoadAssets();
            OA_AddCustomPieces();
        }

        private void OA_LoadAssets()
        {
            OdinArchitectBundle = AssetUtils.LoadAssetBundleFromResources("odinarchitect", typeof(OdinArchitect).Assembly);
            Jotunn.Logger.LogInfo($"Embedded resources: {string.Join(",", typeof(OdinArchitect).Assembly.GetManifestResourceNames())}");
        }

        private void OA_AddCustomPieces()
        {
            Harmony.CreateAndPatchAll(Assembly.GetExecutingAssembly(), "com.raelaziel");
            PieceManager PieMan = PieceManager.Instance;

            OdinArchitect.OA_rae_woodwall_half_prefab = OdinArchitectBundle.LoadAsset<GameObject>("rae_woodwall_half");
            PieMan.AddPiece(OA_rae_woodwall_half = new CustomPiece(OA_rae_woodwall_half_prefab,
                new PieceConfig
                {
                    PieceTable = "Hammer",
                    AllowedInDungeons = true,
                    CraftingStation = "piece_workbench",
                    Requirements = new[]
                    {
                        new RequirementConfig { Item = "Wood", Amount = 1, Recover = true }
                    }
                }));

            OdinArchitect.OA_rae_woodwall_3_prefab = OdinArchitectBundle.LoadAsset<GameObject>("rae_woodwall_3");
            PieMan.AddPiece(OA_rae_woodwall_3 = new CustomPiece(OA_rae_woodwall_3_prefab,
                new PieceConfig
                {
                    PieceTable = "Hammer",
                    AllowedInDungeons = true,
                    CraftingStation = "piece_workbench",
                    Requirements = new[]
                    {
                        new RequirementConfig { Item = "Wood", Amount = 2, Recover = true }
                    }
                }));

            OdinArchitect.OA_rae_woodwall_3_half_prefab = OdinArchitectBundle.LoadAsset<GameObject>("rae_woodwall_3_half");
            PieMan.AddPiece(OA_rae_woodwall_3_half = new CustomPiece(OA_rae_woodwall_3_half_prefab,
                new PieceConfig
                {
                    PieceTable = "Hammer",
                    AllowedInDungeons = true,
                    CraftingStation = "piece_workbench",
                    Requirements = new[]
                    {
                        new RequirementConfig { Item = "Wood", Amount = 1, Recover = true }
                    }
                }));

            OdinArchitect.OA_rae_woodwall_1_prefab = OdinArchitectBundle.LoadAsset<GameObject>("rae_woodwall_1");
            PieMan.AddPiece(OA_rae_woodwall_1 = new CustomPiece(OA_rae_woodwall_1_prefab,
                new PieceConfig
                {
                    PieceTable = "Hammer",
                    AllowedInDungeons = true,
                    CraftingStation = "piece_workbench",
                    Requirements = new[]
                    {
                        new RequirementConfig { Item = "RoundLog", Amount = 2, Recover = true },
                        new RequirementConfig { Item = "Wood", Amount = 1, Recover = true }
                    }
                }));

            OdinArchitect.OA_rae_woodwall_1_half_prefab = OdinArchitectBundle.LoadAsset<GameObject>("rae_woodwall_1_half");
            PieMan.AddPiece(OA_rae_woodwall_1_half = new CustomPiece(OA_rae_woodwall_1_half_prefab,
                new PieceConfig
                {
                    PieceTable = "Hammer",
                    AllowedInDungeons = true,
                    CraftingStation = "piece_workbench",
                    Requirements = new[]
                    {
                        new RequirementConfig { Item = "RoundLog", Amount = 1, Recover = true },
                        new RequirementConfig { Item = "Wood", Amount = 1, Recover = true }
                    }
                }));

            OdinArchitect.OA_rae_woodwall_2_prefab = OdinArchitectBundle.LoadAsset<GameObject>("rae_woodwall_2");
            PieMan.AddPiece(OA_rae_woodwall_2 = new CustomPiece(OA_rae_woodwall_2_prefab,
                new PieceConfig
                {
                    PieceTable = "Hammer",
                    AllowedInDungeons = true,
                    CraftingStation = "piece_workbench",
                    Requirements = new[]
                    {
                        new RequirementConfig { Item = "RoundLog", Amount = 2, Recover = true },
                        new RequirementConfig { Item = "Wood", Amount = 1, Recover = true }
                    }
                }));

            OdinArchitect.OA_rae_woodwall_2_half_prefab = OdinArchitectBundle.LoadAsset<GameObject>("rae_woodwall_2_half");
            PieMan.AddPiece(OA_rae_woodwall_2_half = new CustomPiece(OA_rae_woodwall_2_half_prefab,
                new PieceConfig
                {
                    PieceTable = "Hammer",
                    AllowedInDungeons = true,
                    CraftingStation = "piece_workbench",
                    Requirements = new[]
                    {
                        new RequirementConfig { Item = "RoundLog", Amount = 1, Recover = true },
                        new RequirementConfig { Item = "Wood", Amount = 1, Recover = true }
                    }
                }));

            OdinArchitect.OA_rae_woodwall_4_prefab = OdinArchitectBundle.LoadAsset<GameObject>("rae_woodwall_4");
            PieMan.AddPiece(OA_rae_woodwall_4 = new CustomPiece(OA_rae_woodwall_4_prefab,
                new PieceConfig
                {
                    PieceTable = "Hammer",
                    AllowedInDungeons = true,
                    CraftingStation = "piece_workbench",
                    Requirements = new[]
                    {
                        new RequirementConfig { Item = "ElderBark", Amount = 1, Recover = true }
                    }
                }));

            OdinArchitect.OA_rae_woodwall_4_half_prefab = OdinArchitectBundle.LoadAsset<GameObject>("rae_woodwall_4_half");
            PieMan.AddPiece(OA_rae_woodwall_4_half = new CustomPiece(OA_rae_woodwall_4_half_prefab,
                new PieceConfig
                {
                    PieceTable = "Hammer",
                    AllowedInDungeons = true,
                    CraftingStation = "piece_workbench",
                    Requirements = new[]
                    {
                        new RequirementConfig { Item = "ElderBark", Amount = 1, Recover = true }
                    }
                }));

            OdinArchitect.OA_wooden_gate_1_prefab = OdinArchitectBundle.LoadAsset<GameObject>("wooden_gate_1");
            PieMan.AddPiece(OA_wooden_gate_1 = new CustomPiece(OA_wooden_gate_1_prefab,
                new PieceConfig
                {
                    PieceTable = "Hammer",
                    AllowedInDungeons = true,
                    CraftingStation = "piece_workbench",
                    Requirements = new[]
                    {
                        new RequirementConfig { Item = "Wood", Amount = 20, Recover = true }
                    }
                })); 

            OdinArchitect.OA_wooden_window_small_prefab = OdinArchitectBundle.LoadAsset<GameObject>("wooden_window_small");
            PieMan.AddPiece(OA_wooden_window_small = new CustomPiece(OA_wooden_window_small_prefab,
                new PieceConfig
                {
                    PieceTable = "Hammer",
                    AllowedInDungeons = true,
                    CraftingStation = "piece_workbench",
                    Requirements = new[]
                    {
                        new RequirementConfig { Item = "Wood", Amount = 3, Recover = true }
                    }
                }));

            OdinArchitect.OA_wooden_window_big_prefab = OdinArchitectBundle.LoadAsset<GameObject>("wooden_window_big");
            PieMan.AddPiece(OA_wooden_window_big = new CustomPiece(OA_wooden_window_big_prefab,
                new PieceConfig
                {
                    PieceTable = "Hammer",
                    AllowedInDungeons = true,
                    CraftingStation = "piece_workbench",
                    Requirements = new[]
                    {
                        new RequirementConfig { Item = "Wood", Amount = 6, Recover = true }
                    }
                }));

            OdinArchitect.OA_wooden_fence_1_prefab = OdinArchitectBundle.LoadAsset<GameObject>("wooden_fence_1");
            PieMan.AddPiece(OA_wooden_fence_1_big = new CustomPiece(OA_wooden_fence_1_prefab,
                new PieceConfig
                {
                    PieceTable = "Hammer",
                    AllowedInDungeons = true,
                    CraftingStation = "piece_workbench",
                    Requirements = new[]
                    {
                        new RequirementConfig { Item = "Wood", Amount = 2, Recover = true }
                    }
                }));

            OdinArchitect.OA_wooden_fence_1_gate_prefab = OdinArchitectBundle.LoadAsset<GameObject>("wooden_fence_1_gate");
            PieMan.AddPiece(OA_wooden_fence_1_gate_big = new CustomPiece(OA_wooden_fence_1_gate_prefab,
                new PieceConfig
                {
                    PieceTable = "Hammer",
                    AllowedInDungeons = true,
                    CraftingStation = "piece_workbench",
                    Requirements = new[]
                    {
                        new RequirementConfig { Item = "Wood", Amount = 3, Recover = true }
                    }
                }));

            OdinArchitect.OA_wooden_fence_2_prefab = OdinArchitectBundle.LoadAsset<GameObject>("wooden_fence_2");
            PieMan.AddPiece(OA_wooden_fence_2_big = new CustomPiece(OA_wooden_fence_2_prefab,
                new PieceConfig
                {
                    PieceTable = "Hammer",
                    AllowedInDungeons = true,
                    CraftingStation = "piece_workbench",
                    Requirements = new[]
                    {
                        new RequirementConfig { Item = "Wood", Amount = 3, Recover = true }
                    }
                }));

            OdinArchitect.OA_wooden_fence_2_gate_prefab = OdinArchitectBundle.LoadAsset<GameObject>("wooden_fence_2_gate");
            PieMan.AddPiece(OA_wooden_fence_2_gate_big = new CustomPiece(OA_wooden_fence_2_gate_prefab,
                new PieceConfig
                {
                    PieceTable = "Hammer",
                    AllowedInDungeons = true,
                    CraftingStation = "piece_workbench",
                    Requirements = new[]
                    {
                        new RequirementConfig { Item = "Wood", Amount = 4, Recover = true }
                    }
                }));

            OdinArchitect.OA_thin_wood_beam_1_prefab = OdinArchitectBundle.LoadAsset<GameObject>("thin_wood_beam_1");
            PieMan.AddPiece(OA_thin_wood_beam_1 = new CustomPiece(OA_thin_wood_beam_1_prefab,
                new PieceConfig
                {
                    PieceTable = "Hammer",
                    AllowedInDungeons = true,
                    CraftingStation = "piece_workbench",
                    Requirements = new[]
                    {
                        new RequirementConfig { Item = "FineWood", Amount = 2, Recover = true }
                    }
                }));

            OdinArchitect.OA_thin_wood_beam_2_prefab = OdinArchitectBundle.LoadAsset<GameObject>("thin_wood_beam_2");
            PieMan.AddPiece(OA_thin_wood_beam_2 = new CustomPiece(OA_thin_wood_beam_2_prefab,
                new PieceConfig
                {
                    PieceTable = "Hammer",
                    AllowedInDungeons = true,
                    CraftingStation = "piece_workbench",
                    Requirements = new[]
                    {
                        new RequirementConfig { Item = "FineWood", Amount = 1, Recover = true }
                    }
                }));

            OdinArchitect.OA_thin_wood_pole_1_prefab = OdinArchitectBundle.LoadAsset<GameObject>("thin_wood_pole_1");
            PieMan.AddPiece(OA_thin_wood_pole_1 = new CustomPiece(OA_thin_wood_pole_1_prefab,
                new PieceConfig
                {
                    PieceTable = "Hammer",
                    AllowedInDungeons = true,
                    CraftingStation = "piece_workbench",
                    Requirements = new[]
                    {
                        new RequirementConfig { Item = "FineWood", Amount = 1, Recover = true }
                    }
                }));

            OdinArchitect.OA_thin_wood_pole_2_prefab = OdinArchitectBundle.LoadAsset<GameObject>("thin_wood_pole_2");
            PieMan.AddPiece(OA_thin_wood_pole_2 = new CustomPiece(OA_thin_wood_pole_2_prefab,
                new PieceConfig
                {
                    PieceTable = "Hammer",
                    AllowedInDungeons = true,
                    CraftingStation = "piece_workbench",
                    Requirements = new[]
                    {
                        new RequirementConfig { Item = "FineWood", Amount = 2, Recover = true }
                    }
                }));

            OdinArchitect.OA_piece_woodbeam_25_thin_prefab = OdinArchitectBundle.LoadAsset<GameObject>("piece_woodbeam_25_thin");
            PieMan.AddPiece(OA_piece_woodbeam_25_thin = new CustomPiece(OA_piece_woodbeam_25_thin_prefab,
                new PieceConfig
                {
                    PieceTable = "Hammer",
                    AllowedInDungeons = true,
                    CraftingStation = "piece_workbench",
                    Requirements = new[]
                    {
                        new RequirementConfig { Item = "FineWood", Amount = 1, Recover = true }
                    }
                }));

            OdinArchitect.OA_piece_woodbeam_45_thin_prefab = OdinArchitectBundle.LoadAsset<GameObject>("piece_woodbeam_45_thin");
            PieMan.AddPiece(OA_piece_woodbeam_45_thin = new CustomPiece(OA_piece_woodbeam_45_thin_prefab,
                new PieceConfig
                {
                    PieceTable = "Hammer",
                    AllowedInDungeons = true,
                    CraftingStation = "piece_workbench",
                    Requirements = new[]
                    {
                        new RequirementConfig { Item = "FineWood", Amount = 1, Recover = true }
                    }
                }));

            OdinArchitect.OA_thin_iron_beam_1_prefab = OdinArchitectBundle.LoadAsset<GameObject>("thin_iron_beam_1");
            PieMan.AddPiece(OA_thin_iron_beam_1 = new CustomPiece(OA_thin_iron_beam_1_prefab,
                new PieceConfig
                {
                    PieceTable = "Hammer",
                    AllowedInDungeons = true,
                    CraftingStation = "forge",
                    Requirements = new[]
                    {
                        new RequirementConfig { Item = "Iron", Amount = 2, Recover = true }
                    }
                }));

            OdinArchitect.OA_thin_iron_beam_2_prefab = OdinArchitectBundle.LoadAsset<GameObject>("thin_iron_beam_2");
            PieMan.AddPiece(OA_thin_iron_beam_2 = new CustomPiece(OA_thin_iron_beam_2_prefab,
                new PieceConfig
                {
                    PieceTable = "Hammer",
                    AllowedInDungeons = true,
                    CraftingStation = "forge",
                    Requirements = new[]
                    {
                        new RequirementConfig { Item = "Iron", Amount = 1, Recover = true }
                    }
                }));

            OdinArchitect.OA_thin_iron_pole_1_prefab = OdinArchitectBundle.LoadAsset<GameObject>("thin_iron_pole_1");
            PieMan.AddPiece(OA_thin_iron_pole_1 = new CustomPiece(OA_thin_iron_pole_1_prefab,
                new PieceConfig
                {
                    PieceTable = "Hammer",
                    AllowedInDungeons = true,
                    CraftingStation = "forge",
                    Requirements = new[]
                    {
                        new RequirementConfig { Item = "Iron", Amount = 1, Recover = true }
                    }
                }));

            OdinArchitect.OA_thin_iron_pole_2_prefab = OdinArchitectBundle.LoadAsset<GameObject>("thin_iron_pole_2");
            PieMan.AddPiece(OA_thin_iron_pole_2 = new CustomPiece(OA_thin_iron_pole_2_prefab,
                new PieceConfig
                {
                    PieceTable = "Hammer",
                    AllowedInDungeons = true,
                    CraftingStation = "forge",
                    Requirements = new[]
                    {
                        new RequirementConfig { Item = "Iron", Amount = 2, Recover = true }
                    }
                }));

            OdinArchitect.OA_piece_ironbeam_25_thin_prefab = OdinArchitectBundle.LoadAsset<GameObject>("piece_ironbeam_25_thin");
            PieMan.AddPiece(OA_piece_ironbeam_25_thin = new CustomPiece(OA_piece_ironbeam_25_thin_prefab,
                new PieceConfig
                {
                    PieceTable = "Hammer",
                    AllowedInDungeons = true,
                    CraftingStation = "forge",
                    Requirements = new[]
                    {
                        new RequirementConfig { Item = "Iron", Amount = 1, Recover = true }
                    }
                }));

            OdinArchitect.OA_piece_ironbeam_45_thin_prefab = OdinArchitectBundle.LoadAsset<GameObject>("piece_ironbeam_45_thin");
            PieMan.AddPiece(OA_piece_ironbeam_45_thin = new CustomPiece(OA_piece_ironbeam_45_thin_prefab,
                new PieceConfig
                {
                    PieceTable = "Hammer",
                    AllowedInDungeons = true,
                    CraftingStation = "forge",
                    Requirements = new[]
                    {
                        new RequirementConfig { Item = "Iron", Amount = 1, Recover = true }
                    }
                }));

            OdinArchitect.OA_wooden_drawbridge_1_prefab = OdinArchitectBundle.LoadAsset<GameObject>("wooden_drawbridge_1");
            PieMan.AddPiece(OA_wooden_drawbridge_1 = new CustomPiece(OA_wooden_drawbridge_1_prefab,
                new PieceConfig
                {
                    PieceTable = "Hammer",
                    AllowedInDungeons = true,
                    CraftingStation = "piece_workbench",
                    Requirements = new[]
                    {
                        new RequirementConfig { Item = "Wood", Amount = 12, Recover = true },
                        new RequirementConfig { Item = "Iron", Amount = 6, Recover = true },
                        new RequirementConfig { Item = "SurtlingCore", Amount = 1, Recover = true }
                    }
                }));

            OdinArchitect.OA_wooden_arch_1_prefab = OdinArchitectBundle.LoadAsset<GameObject>("wooden_arch_1");
            PieMan.AddPiece(OA_wooden_arch_1 = new CustomPiece(OA_wooden_arch_1_prefab,
                new PieceConfig
                {
                    PieceTable = "Hammer",
                    AllowedInDungeons = true,
                    CraftingStation = "piece_workbench",
                    Requirements = new[]
                    {
                        new RequirementConfig { Item = "RoundLog", Amount = 3, Recover = true },
                        new RequirementConfig { Item = "Resin", Amount = 4, Recover = true }
                    }
                }));

            OdinArchitect.OA_refined_stakewall_1_prefab = OdinArchitectBundle.LoadAsset<GameObject>("refined_stakewall_1");
            PieMan.AddPiece(OA_refined_stakewall_1 = new CustomPiece(OA_refined_stakewall_1_prefab,
                new PieceConfig
                {
                    PieceTable = "Hammer",
                    AllowedInDungeons = true,
                    CraftingStation = "piece_workbench",
                    Requirements = new[]
                    {
                        new RequirementConfig { Item = "RoundLog", Amount = 5, Recover = true },
                        new RequirementConfig { Item = "BronzeNails", Amount = 2, Recover = true }
                    }
                }));

            OdinArchitect.OA_refined_sharpstakes_prefab = OdinArchitectBundle.LoadAsset<GameObject>("refined_sharpstakes");
            PieMan.AddPiece(OA_refined_sharpstakes = new CustomPiece(OA_refined_sharpstakes_prefab,
                new PieceConfig
                {
                    PieceTable = "Hammer",
                    AllowedInDungeons = true,
                    CraftingStation = "piece_workbench",
                    Requirements = new[]
                    {
                        new RequirementConfig { Item = "RoundLog", Amount = 8, Recover = true },
                        new RequirementConfig { Item = "BronzeNails", Amount = 5, Recover = true }
                    }
                }));

            OdinArchitect.OA_food_smelter_prefab = OdinArchitectBundle.LoadAsset<GameObject>("food_smelter");
            PieMan.AddPiece(OA_food_smelter = new CustomPiece(OA_food_smelter_prefab,
                new PieceConfig
                {
                    PieceTable = "Hammer",
                    AllowedInDungeons = true,
                    CraftingStation = "piece_workbench",
                    Requirements = new[]
                    {
                        new RequirementConfig { Item = "Coal", Amount = 20, Recover = true },
                        new RequirementConfig { Item = "SurtlingCore", Amount = 4, Recover = true },
                        new RequirementConfig { Item = "Iron", Amount = 5, Recover = true }
                    }
                }));

            OdinArchitect.OA_surtling_lantern_1_prefab = OdinArchitectBundle.LoadAsset<GameObject>("surtling_lantern_1");
            PieMan.AddPiece(OA_surtling_lantern_1 = new CustomPiece(OA_surtling_lantern_1_prefab,
                new PieceConfig
                {
                    PieceTable = "Hammer",
                    AllowedInDungeons = true,
                    CraftingStation = "forge",
                    Requirements = new[]
                    {
                        new RequirementConfig { Item = "Wood", Amount = 1, Recover = true },
                        new RequirementConfig { Item = "SurtlingCore", Amount = 1, Recover = true },
                        new RequirementConfig { Item = "Iron", Amount = 3, Recover = true }
                    }
                }));

            OdinArchitect.OA_surtling_lantern_2_prefab = OdinArchitectBundle.LoadAsset<GameObject>("surtling_lantern_2");
            PieMan.AddPiece(OA_surtling_lantern_2 = new CustomPiece(OA_surtling_lantern_2_prefab,
                new PieceConfig
                {
                    PieceTable = "Hammer",
                    AllowedInDungeons = true,
                    CraftingStation = "forge",
                    Requirements = new[]
                    {
                        new RequirementConfig { Item = "Wood", Amount = 10, Recover = true },
                        new RequirementConfig { Item = "SurtlingCore", Amount = 1, Recover = true },
                        new RequirementConfig { Item = "Iron", Amount = 5, Recover = true }
                    }
                }));

            OdinArchitect.OA_surtling_lantern_3_prefab = OdinArchitectBundle.LoadAsset<GameObject>("surtling_lantern_3");
            PieMan.AddPiece(OA_surtling_lantern_3 = new CustomPiece(OA_surtling_lantern_3_prefab,
                new PieceConfig
                {
                    PieceTable = "Hammer",
                    AllowedInDungeons = true,
                    CraftingStation = "forge",
                    Requirements = new[]
                    {
                        new RequirementConfig { Item = "Wood", Amount = 14, Recover = true },
                        new RequirementConfig { Item = "SurtlingCore", Amount = 2, Recover = true },
                        new RequirementConfig { Item = "Iron", Amount = 7, Recover = true }
                    }
                }));

            OdinArchitect.OA_surtling_lantern_4_prefab = OdinArchitectBundle.LoadAsset<GameObject>("surtling_lantern_4");
            PieMan.AddPiece(OA_surtling_lantern_4 = new CustomPiece(OA_surtling_lantern_4_prefab,
                new PieceConfig
                {
                    PieceTable = "Hammer",
                    AllowedInDungeons = true,
                    CraftingStation = "forge",
                    Requirements = new[]
                    {
                        new RequirementConfig { Item = "Wood", Amount = 5, Recover = true },
                        new RequirementConfig { Item = "SurtlingCore", Amount = 1, Recover = true },
                        new RequirementConfig { Item = "Iron", Amount = 3, Recover = true }
                    }
                }));

            OdinArchitect.OA_stone_beam_short_prefab = OdinArchitectBundle.LoadAsset<GameObject>("stone_beam_short");
            PieMan.AddPiece(OA_stone_beam_short = new CustomPiece(OA_stone_beam_short_prefab,
                new PieceConfig
                {
                    PieceTable = "Hammer",
                    AllowedInDungeons = true,
                    CraftingStation = "piece_stonecutter",
                    Requirements = new[]
                    {
                        new RequirementConfig { Item = "Stone", Amount = 1, Recover = true }
                    }
                }));

            OdinArchitect.OA_stone_beam_long_prefab = OdinArchitectBundle.LoadAsset<GameObject>("stone_beam_long");
            PieMan.AddPiece(OA_stone_beam_long = new CustomPiece(OA_stone_beam_long_prefab,
                new PieceConfig
                {
                    PieceTable = "Hammer",
                    AllowedInDungeons = true,
                    CraftingStation = "piece_stonecutter",
                    Requirements = new[]
                    {
                        new RequirementConfig { Item = "Stone", Amount = 2, Recover = true }
                    }
                }));

            OdinArchitect.OA_stone_pole_short_prefab = OdinArchitectBundle.LoadAsset<GameObject>("stone_pole_short");
            PieMan.AddPiece(OA_stone_pole_short = new CustomPiece(OA_stone_pole_short_prefab,
                new PieceConfig
                {
                    PieceTable = "Hammer",
                    AllowedInDungeons = true,
                    CraftingStation = "piece_stonecutter",
                    Requirements = new[]
                    {
                        new RequirementConfig { Item = "Stone", Amount = 1, Recover = true }
                    }
                }));

            OdinArchitect.OA_stone_pole_long_prefab = OdinArchitectBundle.LoadAsset<GameObject>("stone_pole_long");
            PieMan.AddPiece(OA_stone_pole_long = new CustomPiece(OA_stone_pole_long_prefab,
                new PieceConfig
                {
                    PieceTable = "Hammer",
                    AllowedInDungeons = true,
                    CraftingStation = "piece_stonecutter",
                    Requirements = new[]
                    {
                        new RequirementConfig { Item = "Stone", Amount = 2, Recover = true }
                    }
                }));

            OdinArchitect.OA_iron_beam_short_prefab = OdinArchitectBundle.LoadAsset<GameObject>("iron_beam_short");
            PieMan.AddPiece(OA_iron_beam_short = new CustomPiece(OA_iron_beam_short_prefab,
                new PieceConfig
                {
                    PieceTable = "Hammer",
                    AllowedInDungeons = true,
                    CraftingStation = "forge",
                    Requirements = new[]
                    {
                        new RequirementConfig { Item = "Iron", Amount = 1, Recover = true }
                    }
                }));

            OdinArchitect.OA_iron_beam_long_prefab = OdinArchitectBundle.LoadAsset<GameObject>("iron_beam_long");
            PieMan.AddPiece(OA_iron_beam_long = new CustomPiece(OA_iron_beam_long_prefab,
                new PieceConfig
                {
                    PieceTable = "Hammer",
                    AllowedInDungeons = true,
                    CraftingStation = "forge",
                    Requirements = new[]
                    {
                        new RequirementConfig { Item = "Iron", Amount = 2, Recover = true }
                    }
                }));

            OdinArchitect.OA_iron_pole_short_prefab = OdinArchitectBundle.LoadAsset<GameObject>("iron_pole_short");
            PieMan.AddPiece(OA_iron_pole_short = new CustomPiece(OA_iron_pole_short_prefab,
                new PieceConfig
                {
                    PieceTable = "Hammer",
                    AllowedInDungeons = true,
                    CraftingStation = "forge",
                    Requirements = new[]
                    {
                        new RequirementConfig { Item = "Iron", Amount = 1, Recover = true }
                    }
                }));

            OdinArchitect.OA_iron_pole_long_prefab = OdinArchitectBundle.LoadAsset<GameObject>("iron_pole_long");
            PieMan.AddPiece(OA_iron_pole_long = new CustomPiece(OA_iron_pole_long_prefab,
                new PieceConfig
                {
                    PieceTable = "Hammer",
                    AllowedInDungeons = true,
                    CraftingStation = "forge",
                    Requirements = new[]
                    {
                        new RequirementConfig { Item = "Iron", Amount = 2, Recover = true }
                    }
                }));

            OdinArchitect.OA_stone_window_small_prefab = OdinArchitectBundle.LoadAsset<GameObject>("stone_window_small");
            PieMan.AddPiece(OA_stone_window_small = new CustomPiece(OA_stone_window_small_prefab,
                new PieceConfig
                {
                    PieceTable = "Hammer",
                    AllowedInDungeons = true,
                    CraftingStation = "piece_stonecutter",
                    Requirements = new[]
                    {
                        new RequirementConfig { Item = "Wood", Amount = 2, Recover = true },
                        new RequirementConfig { Item = "Stone", Amount = 5, Recover = true }
                    }
                }));

            OdinArchitect.OA_stone_window_big_prefab = OdinArchitectBundle.LoadAsset<GameObject>("stone_window_big");
            PieMan.AddPiece(OA_stone_window_big = new CustomPiece(OA_stone_window_big_prefab,
                new PieceConfig
                {
                    PieceTable = "Hammer",
                    AllowedInDungeons = true,
                    CraftingStation = "piece_stonecutter",
                    Requirements = new[]
                    {
                        new RequirementConfig { Item = "Wood", Amount = 4, Recover = true },
                        new RequirementConfig { Item = "Stone", Amount = 10, Recover = true }
                    }
                }));

            OdinArchitect.OA_stone_arch_1_prefab = OdinArchitectBundle.LoadAsset<GameObject>("stone_arch_1");
            PieMan.AddPiece(OA_stone_arch_1 = new CustomPiece(OA_stone_arch_1_prefab,
                new PieceConfig
                {
                    PieceTable = "Hammer",
                    AllowedInDungeons = true,
                    CraftingStation = "piece_stonecutter",
                    Requirements = new[]
                    {
                        new RequirementConfig { Item = "Stone", Amount = 40, Recover = true }
                    }
                }));

            OdinArchitect.OA_stone_arch_2_small_prefab = OdinArchitectBundle.LoadAsset<GameObject>("stone_arch_2_small");
            PieMan.AddPiece(OA_stone_arch_2_small = new CustomPiece(OA_stone_arch_2_small_prefab,
                new PieceConfig
                {
                    PieceTable = "Hammer",
                    AllowedInDungeons = true,
                    CraftingStation = "piece_stonecutter",
                    Requirements = new[]
                    {
                        new RequirementConfig { Item = "Stone", Amount = 15, Recover = true }
                    }
                }));

            OdinArchitect.OA_stone_table_1_prefab = OdinArchitectBundle.LoadAsset<GameObject>("stone_table_1");
            PieMan.AddPiece(OA_stone_table_1 = new CustomPiece(OA_stone_table_1_prefab,
                new PieceConfig
                {
                    PieceTable = "Hammer",
                    AllowedInDungeons = true,
                    CraftingStation = "piece_stonecutter",
                    Requirements = new[]
                    {
                        new RequirementConfig { Item = "Stone", Amount = 12, Recover = true }
                    }
                }));

            OdinArchitect.OA_stone_throne_1_prefab = OdinArchitectBundle.LoadAsset<GameObject>("stone_throne_1");
            PieMan.AddPiece(OA_stone_throne_1 = new CustomPiece(OA_stone_throne_1_prefab,
                new PieceConfig
                {
                    PieceTable = "Hammer",
                    AllowedInDungeons = true,
                    CraftingStation = "piece_stonecutter",
                    Requirements = new[]
                    {
                            new RequirementConfig { Item = "Stone", Amount = 15, Recover = true },
                            new RequirementConfig { Item = "Iron", Amount = 10, Recover = true },
                            new RequirementConfig { Item = "Silver", Amount = 10, Recover = true }
                    }
                }));

            OdinArchitect.OA_stone_floor_1_new_prefab = OdinArchitectBundle.LoadAsset<GameObject>("stone_floor_1_new");
            PieMan.AddPiece(OA_stone_floor_1_new = new CustomPiece(OA_stone_floor_1_new_prefab,
                new PieceConfig
                {
                    PieceTable = "Hammer",
                    AllowedInDungeons = true,
                    CraftingStation = "piece_stonecutter",
                    Requirements = new[]
                    {
                        new RequirementConfig { Item = "Stone", Amount = 6, Recover = true }
                    }
                }));

            OdinArchitect.OA_stonewall_hardrock_1x1_prefab = OdinArchitectBundle.LoadAsset<GameObject>("stonewall_hardrock_1x1");
            PieMan.AddPiece(OA_stonewall_hardrock_1x1 = new CustomPiece(OA_stonewall_hardrock_1x1_prefab,
                new PieceConfig
                {
                    PieceTable = "Hammer",
                    AllowedInDungeons = true,
                    CraftingStation = "piece_stonecutter",
                    Requirements = new[]
                    {
                        new RequirementConfig { Item = "Stone", Amount = 2, Recover = true }
                    }
                }));

            OdinArchitect.OA_stonewall_hardrock_2x1_prefab = OdinArchitectBundle.LoadAsset<GameObject>("stonewall_hardrock_2x1");
            PieMan.AddPiece(OA_stonewall_hardrock_2x1 = new CustomPiece(OA_stonewall_hardrock_2x1_prefab,
                new PieceConfig
                {
                    PieceTable = "Hammer",
                    AllowedInDungeons = true,
                    CraftingStation = "piece_stonecutter",
                    Requirements = new[]
                    {
                        new RequirementConfig { Item = "Stone", Amount = 4, Recover = true }
                    }
                }));

            OdinArchitect.OA_stonewall_hardrock_4x2_prefab = OdinArchitectBundle.LoadAsset<GameObject>("stonewall_hardrock_4x2");
            PieMan.AddPiece(OA_stonewall_hardrock_4x2 = new CustomPiece(OA_stonewall_hardrock_4x2_prefab,
                new PieceConfig
                {
                    PieceTable = "Hammer",
                    AllowedInDungeons = true,
                    CraftingStation = "piece_stonecutter",
                    Requirements = new[]
                    {
                        new RequirementConfig { Item = "Stone", Amount = 12, Recover = true }
                    }
                }));

            OdinArchitect.OA_stonewall_hardrock_arch_prefab = OdinArchitectBundle.LoadAsset<GameObject>("stonewall_hardrock_arch");
            PieMan.AddPiece(OA_stonewall_hardrock_arch = new CustomPiece(OA_stonewall_hardrock_arch_prefab,
                new PieceConfig
                {
                    PieceTable = "Hammer",
                    AllowedInDungeons = true,
                    CraftingStation = "piece_stonecutter",
                    Requirements = new[]
                    {
                        new RequirementConfig { Item = "Stone", Amount = 2, Recover = true }
                    }
                }));

            OdinArchitect.OA_stonewall_hardrock_pillar_prefab = OdinArchitectBundle.LoadAsset<GameObject>("stonewall_hardrock_pillar");
            PieMan.AddPiece(OA_stonewall_hardrock_pillar = new CustomPiece(OA_stonewall_hardrock_pillar_prefab,
                new PieceConfig
                {
                    PieceTable = "Hammer",
                    AllowedInDungeons = true,
                    CraftingStation = "piece_stonecutter",
                    Requirements = new[]
                    {
                        new RequirementConfig { Item = "Stone", Amount = 6, Recover = true }
                    }
                }));

            OdinArchitect.OA_stonewall_hardrock_stairs_prefab = OdinArchitectBundle.LoadAsset<GameObject>("stonewall_hardrock_stairs");
            PieMan.AddPiece(OA_stonewall_hardrock_stairs = new CustomPiece(OA_stonewall_hardrock_stairs_prefab,
                new PieceConfig
                {
                    PieceTable = "Hammer",
                    AllowedInDungeons = true,
                    CraftingStation = "piece_stonecutter",
                    Requirements = new[]
                    {
                        new RequirementConfig { Item = "Stone", Amount = 6, Recover = true }
                    }
                }));

            OdinArchitect.OA_big_pillar_prefab = OdinArchitectBundle.LoadAsset<GameObject>("big_pillar");
            PieMan.AddPiece(OA_big_pillar = new CustomPiece(OA_big_pillar_prefab,
                new PieceConfig
                {
                    PieceTable = "Hammer",
                    AllowedInDungeons = true,
                    CraftingStation = "piece_stonecutter",
                    Requirements = new[]
                    {
                        new RequirementConfig { Item = "Stone", Amount = 24, Recover = true }
                    }
                }));

            OdinArchitect.OA_iron_dragon_prefab = OdinArchitectBundle.LoadAsset<GameObject>("iron_dragon");
            PieMan.AddPiece(OA_iron_dragon = new CustomPiece(OA_iron_dragon_prefab,
                new PieceConfig
                {
                    PieceTable = "Hammer",
                    AllowedInDungeons = true,
                    CraftingStation = "forge",
                    Requirements = new[]
                    {
                        new RequirementConfig { Item = "Iron", Amount = 35, Recover = true }
                    }
                }));

            OdinArchitect.OA_iron_gate_big_prefab = OdinArchitectBundle.LoadAsset<GameObject>("iron_gate_big");
            PieMan.AddPiece(OA_iron_gate_big = new CustomPiece(OA_iron_gate_big_prefab,
                new PieceConfig
                {
                    PieceTable = "Hammer",
                    AllowedInDungeons = true,
                    CraftingStation = "forge",
                    Requirements = new[]
                    {
                        new RequirementConfig { Item = "Iron", Amount = 35, Recover = true }
                    }
                }));

            OdinArchitect.OA_iron_gate_small_prefab = OdinArchitectBundle.LoadAsset<GameObject>("iron_gate_small");
            PieMan.AddPiece(OA_iron_gate_small = new CustomPiece(OA_iron_gate_small_prefab,
                new PieceConfig
                {
                    PieceTable = "Hammer",
                    AllowedInDungeons = true,
                    CraftingStation = "forge",
                    Requirements = new[]
                    {
                        new RequirementConfig { Item = "Iron", Amount = 5, Recover = true }
                    }
                }));

            // OdinArchitect.OA__prefab = OdinArchitectBundle.LoadAsset<GameObject>("");
            // PieMan.AddPiece(OA_ = new CustomPiece(OA__prefab,
            //     new PieceConfig
            //     {
            //         PieceTable = "Hammer",
            //         AllowedInDungeons = true,
            //         CraftingStation = "piece_stonecutter",
            //         Requirements = new[]
            //         {
            //             new RequirementConfig { Item = "Wood", Amount = 5, Recover = true }
            //         }
            //     }));

            OA_AddLocales();
            OdinArchitectBundle.Unload(false);
        }

        public static void ReplaceMats()
        {
            MaterialReplacer.GetAllMaterials();
            MaterialReplacer.ReplaceAllMaterialsWithOriginal(OdinArchitect.OA_wooden_gate_1_prefab);
            MaterialReplacer.ReplaceAllMaterialsWithOriginal(OdinArchitect.OA_wooden_window_small_prefab);
            MaterialReplacer.ReplaceAllMaterialsWithOriginal(OdinArchitect.OA_wooden_window_big_prefab);
            MaterialReplacer.ReplaceAllMaterialsWithOriginal(OdinArchitect.OA_wooden_fence_1_prefab);
            MaterialReplacer.ReplaceAllMaterialsWithOriginal(OdinArchitect.OA_wooden_fence_1_gate_prefab);
            MaterialReplacer.ReplaceAllMaterialsWithOriginal(OdinArchitect.OA_wooden_fence_2_prefab);
            MaterialReplacer.ReplaceAllMaterialsWithOriginal(OdinArchitect.OA_wooden_fence_2_gate_prefab);
            MaterialReplacer.ReplaceAllMaterialsWithOriginal(OdinArchitect.OA_thin_wood_beam_1_prefab);
            MaterialReplacer.ReplaceAllMaterialsWithOriginal(OdinArchitect.OA_thin_wood_beam_2_prefab);
            MaterialReplacer.ReplaceAllMaterialsWithOriginal(OdinArchitect.OA_thin_wood_pole_1_prefab);
            MaterialReplacer.ReplaceAllMaterialsWithOriginal(OdinArchitect.OA_thin_wood_pole_2_prefab);
            MaterialReplacer.ReplaceAllMaterialsWithOriginal(OdinArchitect.OA_thin_iron_beam_1_prefab);
            MaterialReplacer.ReplaceAllMaterialsWithOriginal(OdinArchitect.OA_thin_iron_beam_2_prefab);
            MaterialReplacer.ReplaceAllMaterialsWithOriginal(OdinArchitect.OA_thin_iron_pole_1_prefab);
            MaterialReplacer.ReplaceAllMaterialsWithOriginal(OdinArchitect.OA_thin_iron_pole_2_prefab);
            MaterialReplacer.ReplaceAllMaterialsWithOriginal(OdinArchitect.OA_wooden_drawbridge_1_prefab);
            MaterialReplacer.ReplaceAllMaterialsWithOriginal(OdinArchitect.OA_wooden_arch_1_prefab);
            MaterialReplacer.ReplaceAllMaterialsWithOriginal(OdinArchitect.OA_refined_stakewall_1_prefab);
            MaterialReplacer.ReplaceAllMaterialsWithOriginal(OdinArchitect.OA_refined_sharpstakes_prefab);
            MaterialReplacer.ReplaceAllMaterialsWithOriginal(OdinArchitect.OA_food_smelter_prefab);
            MaterialReplacer.ReplaceAllMaterialsWithOriginal(OdinArchitect.OA_surtling_lantern_4_prefab);
            MaterialReplacer.ReplaceAllMaterialsWithOriginal(OdinArchitect.OA_surtling_lantern_3_prefab);
            MaterialReplacer.ReplaceAllMaterialsWithOriginal(OdinArchitect.OA_surtling_lantern_2_prefab);
            MaterialReplacer.ReplaceAllMaterialsWithOriginal(OdinArchitect.OA_surtling_lantern_1_prefab);
            MaterialReplacer.ReplaceAllMaterialsWithOriginal(OdinArchitect.OA_stone_beam_short_prefab);
            MaterialReplacer.ReplaceAllMaterialsWithOriginal(OdinArchitect.OA_stone_beam_long_prefab);
            MaterialReplacer.ReplaceAllMaterialsWithOriginal(OdinArchitect.OA_stone_pole_short_prefab);
            MaterialReplacer.ReplaceAllMaterialsWithOriginal(OdinArchitect.OA_stone_pole_long_prefab);
            MaterialReplacer.ReplaceAllMaterialsWithOriginal(OdinArchitect.OA_stone_window_small_prefab);
            MaterialReplacer.ReplaceAllMaterialsWithOriginal(OdinArchitect.OA_stone_window_big_prefab);
            MaterialReplacer.ReplaceAllMaterialsWithOriginal(OdinArchitect.OA_stone_arch_1_prefab);
            MaterialReplacer.ReplaceAllMaterialsWithOriginal(OdinArchitect.OA_stone_arch_2_small_prefab);
            MaterialReplacer.ReplaceAllMaterialsWithOriginal(OdinArchitect.OA_stone_table_1_prefab);
            MaterialReplacer.ReplaceAllMaterialsWithOriginal(OdinArchitect.OA_stone_throne_1_prefab);
            MaterialReplacer.ReplaceAllMaterialsWithOriginal(OdinArchitect.OA_stonewall_hardrock_1x1_prefab);
            MaterialReplacer.ReplaceAllMaterialsWithOriginal(OdinArchitect.OA_stonewall_hardrock_2x1_prefab);
            MaterialReplacer.ReplaceAllMaterialsWithOriginal(OdinArchitect.OA_stonewall_hardrock_4x2_prefab);
            MaterialReplacer.ReplaceAllMaterialsWithOriginal(OdinArchitect.OA_stonewall_hardrock_arch_prefab);
            MaterialReplacer.ReplaceAllMaterialsWithOriginal(OdinArchitect.OA_stonewall_hardrock_pillar_prefab);
            MaterialReplacer.ReplaceAllMaterialsWithOriginal(OdinArchitect.OA_stonewall_hardrock_stairs_prefab);
            MaterialReplacer.ReplaceAllMaterialsWithOriginal(OdinArchitect.OA_big_pillar_prefab);
            MaterialReplacer.ReplaceAllMaterialsWithOriginal(OdinArchitect.OA_iron_dragon_prefab);
            MaterialReplacer.ReplaceAllMaterialsWithOriginal(OdinArchitect.OA_iron_gate_big_prefab);
            MaterialReplacer.ReplaceAllMaterialsWithOriginal(OdinArchitect.OA_iron_gate_small_prefab);
            MaterialReplacer.ReplaceAllMaterialsWithOriginal(OdinArchitect.OA_piece_woodbeam_25_thin_prefab);
            MaterialReplacer.ReplaceAllMaterialsWithOriginal(OdinArchitect.OA_piece_woodbeam_45_thin_prefab);
            MaterialReplacer.ReplaceAllMaterialsWithOriginal(OdinArchitect.OA_piece_ironbeam_25_thin_prefab);
            MaterialReplacer.ReplaceAllMaterialsWithOriginal(OdinArchitect.OA_piece_ironbeam_45_thin_prefab);
            MaterialReplacer.ReplaceAllMaterialsWithOriginal(OdinArchitect.OA_iron_beam_short_prefab);
            MaterialReplacer.ReplaceAllMaterialsWithOriginal(OdinArchitect.OA_iron_beam_long_prefab);
            MaterialReplacer.ReplaceAllMaterialsWithOriginal(OdinArchitect.OA_iron_pole_short_prefab);
            MaterialReplacer.ReplaceAllMaterialsWithOriginal(OdinArchitect.OA_iron_pole_long_prefab);
            MaterialReplacer.ReplaceAllMaterialsWithOriginal(OdinArchitect.OA_stone_floor_1_new_prefab);
            MaterialReplacer.ReplaceAllMaterialsWithOriginal(OdinArchitect.OA_rae_woodwall_half_prefab);
            MaterialReplacer.ReplaceAllMaterialsWithOriginal(OdinArchitect.OA_rae_woodwall_1_prefab);
            MaterialReplacer.ReplaceAllMaterialsWithOriginal(OdinArchitect.OA_rae_woodwall_2_prefab);
            MaterialReplacer.ReplaceAllMaterialsWithOriginal(OdinArchitect.OA_rae_woodwall_3_prefab);
            MaterialReplacer.ReplaceAllMaterialsWithOriginal(OdinArchitect.OA_rae_woodwall_4_prefab);
            MaterialReplacer.ReplaceAllMaterialsWithOriginal(OdinArchitect.OA_rae_woodwall_1_half_prefab);
            MaterialReplacer.ReplaceAllMaterialsWithOriginal(OdinArchitect.OA_rae_woodwall_2_half_prefab);
            MaterialReplacer.ReplaceAllMaterialsWithOriginal(OdinArchitect.OA_rae_woodwall_3_half_prefab);
            MaterialReplacer.ReplaceAllMaterialsWithOriginal(OdinArchitect.OA_rae_woodwall_4_half_prefab);
        }

        private void OA_AddLocales()
        {
            foreach (TextAsset textAsset in OdinArchitectBundle.LoadAllAssets<TextAsset>())
            {
                string text = textAsset.name.Replace(".json", null);
                LocalizationManager.Instance.AddJson(text, textAsset.ToString());
            }
            Jotunn.Logger.LogInfo("Locales from .json file loaded succesfully");
        }
    }
}
