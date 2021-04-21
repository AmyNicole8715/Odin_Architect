using BepInEx;
using UnityEngine;
using BepInEx.Configuration;
using System;
using System.Collections.Generic;
using System.Reflection;
using JotunnLib;
using JotunnLib.Managers;
using System.IO;
using JotunnLib.Utils;
using JotunnLib.Entities;
using JotunnLib.Configs;
using HarmonyLib;

namespace OdinArchitect
{
    [BepInPlugin(PluginGUID, PluginName, PluginVersion)]
    [BepInDependency(JotunnLib.Main.ModGuid)]
    //[NetworkCompatibilty(CompatibilityLevel.EveryoneMustHaveMod, VersionStrictness.Minor)]
    internal class OdinArchitect : BaseUnityPlugin
    {
        public const string PluginGUID = "com.raelaziel";
        public const string PluginName = "OdinArchitect";
        public const string PluginVersion = "0.0.1";
        public static new JotunnLib.Logger Logger;

        public static AssetBundle OdinArchitectBundle;

        public static GameObject Create_wooden_gate_1_prefab { get; private set; }
        public static GameObject Create_wooden_window_small_prefab { get; private set; }
        public static GameObject Create_wooden_window_big_prefab { get; private set; }
        public static GameObject Create_thin_wood_beam_1_prefab { get; private set; }
        public static GameObject Create_thin_wood_beam_2_prefab { get; private set; }
        public static GameObject Create_thin_wood_pole_1_prefab { get; private set; }
        public static GameObject Create_thin_wood_pole_2_prefab { get; private set; }
        public static GameObject Create_wooden_fence_1_prefab { get; private set; }
        public static GameObject Create_wooden_fence_2_prefab { get; private set; }
        public static GameObject Create_wooden_fence_1_gate_prefab { get; private set; }
        public static GameObject Create_wooden_fence_2_gate_prefab { get; private set; }
        public static GameObject Create_wooden_arch_0_prefab { get; private set; }
        public static GameObject Create_wooden_arch_1_prefab { get; private set; }
        public static GameObject Create_refined_stakewall_1_prefab { get; private set; }
        public static GameObject Create_refined_sharpstakes_prefab { get; private set; }
        public static GameObject Create_surtling_lantern_1_prefab { get; private set; }
        public static GameObject Create_surtling_lantern_2_prefab { get; private set; }
        public static GameObject Create_surtling_lantern_3_prefab { get; private set; }
        public static GameObject Create_surtling_lantern_4_prefab { get; private set; }

        private void Awake()
        {
            LoadAssets();
            CreateCustomPieces();
            AddLocalizations();
        }

        private void LoadAssets()
        {
            OdinArchitectBundle = AssetUtils.LoadAssetBundle("OdinArchitect/Assets/odinarchitect");
            JotunnLib.Logger.LogInfo("Assets [" + OdinArchitectBundle + "] loaded succesfully");
        }

        public static void CreateCustomPieces()
        {
            Harmony.CreateAndPatchAll(Assembly.GetExecutingAssembly(), "com.raelaziel");

            // Piece: wooden_gate_1 //
            OdinArchitect.Create_wooden_gate_1_prefab = OdinArchitectBundle.LoadAsset<GameObject>("wooden_gate_1");
            var Create_wooden_gate_1 = new CustomPiece(Create_wooden_gate_1_prefab, new PieceConfig
                {
                    PieceTable = "_HammerPieceTable",
                    AllowedInDungeons = true,
                    CraftingStation = "piece_workbench",
                    Requirements = new[]
                    {
                        new RequirementConfig { Item = "Wood", Amount = 24 },
                        new RequirementConfig { Item = "FineWood", Amount = 10 }
                    }});
            // Piece end //

            // Piece: wooden_window_small //
            OdinArchitect.Create_wooden_window_small_prefab = OdinArchitectBundle.LoadAsset<GameObject>("wooden_window_small");
            var Create_wooden_window_small = new CustomPiece(Create_wooden_window_small_prefab, new PieceConfig
                {
                    PieceTable = "_HammerPieceTable",
                    AllowedInDungeons = true,
                    CraftingStation = "piece_workbench",
                    Requirements = new[]
                    {
                        new RequirementConfig { Item = "Wood", Amount = 3 }
                    }});
            // Piece end //

            // Piece: wooden_window_big //
            OdinArchitect.Create_wooden_window_big_prefab = OdinArchitectBundle.LoadAsset<GameObject>("wooden_window_big");
            var Create_wooden_window_big = new CustomPiece(Create_wooden_window_big_prefab, new PieceConfig
            {
                PieceTable = "_HammerPieceTable",
                AllowedInDungeons = true,
                CraftingStation = "piece_workbench",
                Requirements = new[]
                    {
                        new RequirementConfig { Item = "Wood", Amount = 6 }
                    }
            });
            // Piece end //

            // Piece: thin_wood_beam_1 //
            OdinArchitect.Create_thin_wood_beam_1_prefab = OdinArchitectBundle.LoadAsset<GameObject>("thin_wood_beam_1");
            var Create_thin_wood_beam_1 = new CustomPiece(Create_thin_wood_beam_1_prefab, new PieceConfig
            {
                PieceTable = "_HammerPieceTable",
                AllowedInDungeons = true,
                CraftingStation = "piece_workbench",
                Requirements = new[]
                    {
                        new RequirementConfig { Item = "Wood", Amount = 2 }
                    }
            });
            // Piece end //

            // Piece: thin_wood_beam_2 //
            OdinArchitect.Create_thin_wood_beam_2_prefab = OdinArchitectBundle.LoadAsset<GameObject>("thin_wood_beam_2");
            var Create_thin_wood_beam_2 = new CustomPiece(Create_thin_wood_beam_2_prefab, new PieceConfig
            {
                PieceTable = "_HammerPieceTable",
                AllowedInDungeons = true,
                CraftingStation = "piece_workbench",
                Requirements = new[]
                    {
                        new RequirementConfig { Item = "Wood", Amount = 1 }
                    }
            });
            // Piece end //

            // Piece: thin_wood_pole_1 //
            OdinArchitect.Create_thin_wood_pole_1_prefab = OdinArchitectBundle.LoadAsset<GameObject>("thin_wood_pole_1");
            var Create_thin_wood_pole_1 = new CustomPiece(Create_thin_wood_pole_1_prefab, new PieceConfig
            {
                PieceTable = "_HammerPieceTable",
                AllowedInDungeons = true,
                CraftingStation = "piece_workbench",
                Requirements = new[]
                    {
                        new RequirementConfig { Item = "Wood", Amount = 1 }
                    }
            });
            // Piece end //

            // Piece: thin_wood_pole_2 //
            OdinArchitect.Create_thin_wood_pole_2_prefab = OdinArchitectBundle.LoadAsset<GameObject>("thin_wood_pole_2");
            var Create_thin_wood_pole_2 = new CustomPiece(Create_thin_wood_pole_2_prefab, new PieceConfig
            {
                PieceTable = "_HammerPieceTable",
                AllowedInDungeons = true,
                CraftingStation = "piece_workbench",
                Requirements = new[]
                    {
                        new RequirementConfig { Item = "Wood", Amount = 2 }
                    }
            });
            // Piece end //

            // Piece: wooden_fence_1 //
            OdinArchitect.Create_wooden_fence_1_prefab = OdinArchitectBundle.LoadAsset<GameObject>("wooden_fence_1");
            var Create_wooden_fence_1 = new CustomPiece(Create_wooden_fence_1_prefab, new PieceConfig
            {
                PieceTable = "_HammerPieceTable",
                AllowedInDungeons = true,
                CraftingStation = "piece_workbench",
                Requirements = new[]
                    {
                        new RequirementConfig { Item = "RoundLog", Amount = 3 }
                    }
            });
            // Piece end //

            // Piece: wooden_fence_2 //
            OdinArchitect.Create_wooden_fence_2_prefab = OdinArchitectBundle.LoadAsset<GameObject>("wooden_fence_2");
            var Create_wooden_fence_2 = new CustomPiece(Create_wooden_fence_2_prefab, new PieceConfig
            {
                PieceTable = "_HammerPieceTable",
                AllowedInDungeons = true,
                CraftingStation = "piece_workbench",
                Requirements = new[]
                    {
                        new RequirementConfig { Item = "Wood", Amount = 2 }
                    }
            });
            // Piece end //

            // Piece: wooden_fence_1_gate //
            OdinArchitect.Create_wooden_fence_1_gate_prefab = OdinArchitectBundle.LoadAsset<GameObject>("wooden_fence_1_gate");
            var Create_wooden_fence_1_gate = new CustomPiece(Create_wooden_fence_1_gate_prefab, new PieceConfig
            {
                PieceTable = "_HammerPieceTable",
                AllowedInDungeons = true,
                CraftingStation = "piece_workbench",
                Requirements = new[]
                    {
                        new RequirementConfig { Item = "RoundLog", Amount = 5 }
                    }
            });
            // Piece end //

            // Piece: wooden_fence_2_gate //
            OdinArchitect.Create_wooden_fence_2_gate_prefab = OdinArchitectBundle.LoadAsset<GameObject>("wooden_fence_2_gate");
            var Create_wooden_fence_2_gate = new CustomPiece(Create_wooden_fence_2_gate_prefab, new PieceConfig
            {
                PieceTable = "_HammerPieceTable",
                AllowedInDungeons = true,
                CraftingStation = "piece_workbench",
                Requirements = new[]
                    {
                        new RequirementConfig { Item = "Wood", Amount = 4 }
                    }
            });
            // Piece end //

            // Piece: wooden_arch_0 //
            OdinArchitect.Create_wooden_arch_0_prefab = OdinArchitectBundle.LoadAsset<GameObject>("wooden_arch_0");
            var Create_wooden_arch_0 = new CustomPiece(Create_wooden_arch_0_prefab, new PieceConfig
            {
                PieceTable = "_HammerPieceTable",
                AllowedInDungeons = true,
                CraftingStation = "piece_workbench",
                Requirements = new[]
                    {
                        new RequirementConfig { Item = "Wood", Amount = 30 },
                        new RequirementConfig { Item = "RoundLog", Amount = 14 },
                        new RequirementConfig { Item = "Iron", Amount = 10 }
                    }
            });
            // Piece end //

            // Piece: wooden_arch_1 //
            OdinArchitect.Create_wooden_arch_1_prefab = OdinArchitectBundle.LoadAsset<GameObject>("wooden_arch_1");
            var Create_wooden_arch_1 = new CustomPiece(Create_wooden_arch_1_prefab, new PieceConfig
            {
                PieceTable = "_HammerPieceTable",
                AllowedInDungeons = true,
                CraftingStation = "piece_workbench",
                Requirements = new[]
                    {
                        new RequirementConfig { Item = "Wood", Amount = 10 },
                        new RequirementConfig { Item = "RoundLog", Amount = 4 }
                    }
            });
            // Piece end //

            // Piece: refined_stakewall_1 //
            OdinArchitect.Create_refined_stakewall_1_prefab = OdinArchitectBundle.LoadAsset<GameObject>("refined_stakewall_1");
            var Create_refined_stakewall_1 = new CustomPiece(Create_refined_stakewall_1_prefab, new PieceConfig
            {
                PieceTable = "_HammerPieceTable",
                AllowedInDungeons = true,
                CraftingStation = "piece_workbench",
                Requirements = new[]
                    {
                        new RequirementConfig { Item = "Wood", Amount = 4 },
                        new RequirementConfig { Item = "RoundLog", Amount = 6 }
                    }
            });
            // Piece end //

            // Piece: refined_sharpstakes //
            OdinArchitect.Create_refined_sharpstakes_prefab = OdinArchitectBundle.LoadAsset<GameObject>("refined_sharpstakes");
            var Create_refined_sharpstakes = new CustomPiece(Create_refined_sharpstakes_prefab, new PieceConfig
            {
                PieceTable = "_HammerPieceTable",
                AllowedInDungeons = true,
                CraftingStation = "piece_workbench",
                Requirements = new[]
                    {
                        new RequirementConfig { Item = "Wood", Amount = 10 },
                        new RequirementConfig { Item = "RoundLog", Amount = 8 }
                    }
            });
            // Piece end //

            // Piece: surtling_lantern_1 //
            OdinArchitect.Create_surtling_lantern_1_prefab = OdinArchitectBundle.LoadAsset<GameObject>("surtling_lantern_1");
            var Create_surtling_lantern_1 = new CustomPiece(Create_surtling_lantern_1_prefab, new PieceConfig
            {
                PieceTable = "_HammerPieceTable",
                AllowedInDungeons = true,
                CraftingStation = "piece_workbench",
                Requirements = new[]
                    {
                        new RequirementConfig { Item = "Iron", Amount = 3 },
                        new RequirementConfig { Item = "SurtlingCore", Amount = 1 }
                    }
            });
            // Piece end //

            // Piece: surtling_lantern_2 //
            OdinArchitect.Create_surtling_lantern_2_prefab = OdinArchitectBundle.LoadAsset<GameObject>("surtling_lantern_2");
            var Create_surtling_lantern_2 = new CustomPiece(Create_surtling_lantern_2_prefab, new PieceConfig
            {
                PieceTable = "_HammerPieceTable",
                AllowedInDungeons = true,
                CraftingStation = "piece_workbench",
                Requirements = new[]
                    {
                        new RequirementConfig { Item = "FineWood", Amount = 10 },
                        new RequirementConfig { Item = "Iron", Amount = 4 },
                        new RequirementConfig { Item = "SurtlingCore", Amount = 1 }
                    }
            });
            // Piece end //

            // Piece: surtling_lantern_3 //
            OdinArchitect.Create_surtling_lantern_3_prefab = OdinArchitectBundle.LoadAsset<GameObject>("surtling_lantern_3");
            var Create_surtling_lantern_3 = new CustomPiece(Create_surtling_lantern_3_prefab, new PieceConfig
            {
                PieceTable = "_HammerPieceTable",
                AllowedInDungeons = true,
                CraftingStation = "piece_workbench",
                Requirements = new[]
                    {
                        new RequirementConfig { Item = "FineWood", Amount = 15 },
                        new RequirementConfig { Item = "Iron", Amount = 6 },
                        new RequirementConfig { Item = "SurtlingCore", Amount = 2 }
                    }
            });
            // Piece end //

            // Piece: surtling_lantern_4 //
            OdinArchitect.Create_surtling_lantern_4_prefab = OdinArchitectBundle.LoadAsset<GameObject>("surtling_lantern_4");
            var Create_surtling_lantern_4 = new CustomPiece(Create_surtling_lantern_4_prefab, new PieceConfig
            {
                PieceTable = "_HammerPieceTable",
                AllowedInDungeons = true,
                CraftingStation = "piece_workbench",
                Requirements = new[]
                    {
                        new RequirementConfig { Item = "FineWood", Amount = 5 },
                        new RequirementConfig { Item = "Iron", Amount = 3 },
                        new RequirementConfig { Item = "SurtlingCore", Amount = 1 }
                    }
            });
            // Piece end //

            // Piece Manager //
            // Buildings //
            PieceManager.Instance.AddPiece(Create_wooden_window_small);
            PieceManager.Instance.AddPiece(Create_wooden_window_big);
            PieceManager.Instance.AddPiece(Create_thin_wood_beam_2);
            PieceManager.Instance.AddPiece(Create_thin_wood_beam_1);
            PieceManager.Instance.AddPiece(Create_thin_wood_pole_1);
            PieceManager.Instance.AddPiece(Create_thin_wood_pole_2);
            PieceManager.Instance.AddPiece(Create_wooden_fence_1);
            PieceManager.Instance.AddPiece(Create_wooden_fence_1_gate);
            PieceManager.Instance.AddPiece(Create_wooden_fence_2);
            PieceManager.Instance.AddPiece(Create_wooden_fence_2_gate);
            PieceManager.Instance.AddPiece(Create_refined_stakewall_1);
            PieceManager.Instance.AddPiece(Create_refined_sharpstakes);
            PieceManager.Instance.AddPiece(Create_wooden_gate_1);
            PieceManager.Instance.AddPiece(Create_wooden_arch_1);
            PieceManager.Instance.AddPiece(Create_wooden_arch_0);

            // Furnitures //
            PieceManager.Instance.AddPiece(Create_surtling_lantern_1);
            PieceManager.Instance.AddPiece(Create_surtling_lantern_2);
            PieceManager.Instance.AddPiece(Create_surtling_lantern_3);
            PieceManager.Instance.AddPiece(Create_surtling_lantern_4);
            // Manager end //

            // Utils //
            AddLocalizations();
            OdinArchitectBundle.Unload(false);
        }

        public static void ReplaceMats()
        {
            JotunnLib.Logger.LogInfo("Material Replacer loaded succesfully");
            MaterialReplacer.GetAllMaterials();

            // Prefabs - GameObjects for MaterialReplacer //
            MaterialReplacer.ReplaceAllMaterialsWithOriginal(OdinArchitect.Create_wooden_gate_1_prefab);
            MaterialReplacer.ReplaceAllMaterialsWithOriginal(OdinArchitect.Create_wooden_gate_1_prefab);
            MaterialReplacer.ReplaceAllMaterialsWithOriginal(OdinArchitect.Create_wooden_window_small_prefab);
            MaterialReplacer.ReplaceAllMaterialsWithOriginal(OdinArchitect.Create_wooden_window_big_prefab);
            MaterialReplacer.ReplaceAllMaterialsWithOriginal(OdinArchitect.Create_thin_wood_beam_1_prefab);
            MaterialReplacer.ReplaceAllMaterialsWithOriginal(OdinArchitect.Create_thin_wood_beam_2_prefab);
            MaterialReplacer.ReplaceAllMaterialsWithOriginal(OdinArchitect.Create_thin_wood_pole_1_prefab);
            MaterialReplacer.ReplaceAllMaterialsWithOriginal(OdinArchitect.Create_thin_wood_pole_2_prefab);
            MaterialReplacer.ReplaceAllMaterialsWithOriginal(OdinArchitect.Create_wooden_fence_1_prefab);
            MaterialReplacer.ReplaceAllMaterialsWithOriginal(OdinArchitect.Create_wooden_fence_2_prefab);
            MaterialReplacer.ReplaceAllMaterialsWithOriginal(OdinArchitect.Create_wooden_fence_1_gate_prefab);
            MaterialReplacer.ReplaceAllMaterialsWithOriginal(OdinArchitect.Create_wooden_fence_2_gate_prefab);
            MaterialReplacer.ReplaceAllMaterialsWithOriginal(OdinArchitect.Create_wooden_arch_0_prefab);
            MaterialReplacer.ReplaceAllMaterialsWithOriginal(OdinArchitect.Create_wooden_arch_1_prefab);
            MaterialReplacer.ReplaceAllMaterialsWithOriginal(OdinArchitect.Create_refined_stakewall_1_prefab);
            MaterialReplacer.ReplaceAllMaterialsWithOriginal(OdinArchitect.Create_refined_sharpstakes_prefab);
            MaterialReplacer.ReplaceAllMaterialsWithOriginal(OdinArchitect.Create_surtling_lantern_1_prefab);
            MaterialReplacer.ReplaceAllMaterialsWithOriginal(OdinArchitect.Create_surtling_lantern_2_prefab);
            MaterialReplacer.ReplaceAllMaterialsWithOriginal(OdinArchitect.Create_surtling_lantern_3_prefab);
            MaterialReplacer.ReplaceAllMaterialsWithOriginal(OdinArchitect.Create_surtling_lantern_4_prefab);
        }

        private static void AddLocalizations()
        {
            LocalizationManager.Instance.AddLocalization(new LocalizationConfig("English")
            {
                Translations =
                    {
                        { "odin_hammer", "Builder Hammer" },
                        { "odin_hammer_desc", "Stronk" },

                        { "wooden_gate_1", "Big Gate" },
                        { "wooden_gate_1_desc", "Big and heavy wooden gate" },

                        { "wooden_window_small", "Small window" },
                        { "wooden_window_small_desc", "Small wooden window" },

                        { "thin_wood_beam_1", "Long and thin wooden beam" },
                        { "thin_wood_beam_1_desc", "Thin wooden beam" },

                        { "thin_wood_beam_2", "Short and thin wooden beam" },
                        { "thin_wood_beam_2_desc", "Thin wooden beam" },

                        { "thin_wood_pole_1", "Short and thin wooden pole" },
                        { "thin_wood_pole_1_desc", "Thin wooden pole" },

                        { "thin_wood_pole_2", "Long and thin wooden pole" },
                        { "thin_wood_pole_2_desc", "Thin wooden pole" },

                        { "wooden_fence_1", "Strengthened fence" },
                        { "wooden_fence_1_desc", "Wooden strengthened fence" },

                        { "wooden_fence_1_gate", "Strengthened fence - gate" },
                        { "wooden_fence_1_gate_desc", "Wooden strengthened fence" },

                        { "wooden_fence_2", "Alternative fence" },
                        { "wooden_fence_2_desc", "Wooden fence" },

                        { "wooden_fence_2_gate", "Alternative fence - gate" },
                        { "wooden_fence_2_gate_desc", "Wooden fence" },

                        { "wooden_arch_1", "Wooden Arch" },
                        { "wooden_arch_1_desc", "Good base for your village gate" },

                        { "wooden_arch_0", "Big Wooden Arch" },
                        { "wooden_arch_0_desc", "Good base for your village gate" },

                        { "refined_stakewall_1", "Heavy stakewall" },
                        { "refined_stakewall_1_desc", "Improved stakewall" },

                        { "refined_sharpstakes", "Heavy sharp stakes" },
                        { "refined_sharpstakes_desc", "Improved sharp stakes" },

                        { "surtling_lantern_1", "Surtling Torch" },
                        { "surtling_lantern_1_desc", "Basic and simple surtling core torch" },

                        { "surtling_lantern_2", "Surtling Core Lantern" },
                        { "surtling_lantern_2_desc", "One sided surtling core lantern" },

                        { "surtling_lantern_3", "Double Surtling Core Lantern" },
                        { "surtling_lantern_3_desc", "Double sided surtling core lantern" },

                        { "surtling_lantern_4", "Wall mounted Surtling Core Lantern" },
                        { "surtling_lantern_4_desc", "Wall mounted surtling core lantern" },

                        { "wooden_window_big", "Big window" },
                        { "wooden_window_big_desc", "Big wooden window" }
                    }
            });
            LocalizationManager.Instance.AddLocalization(new LocalizationConfig("Polish")
            {
                Translations =
                    {
                        { "wooden_gate_1", "Drewniana brama" },
                        { "wooden_gate_1_desc", "Wielka i ciężka drewniana brama" },

                        { "wooden_window_small", "Małe okno" },
                        { "wooden_window_small_desc", "Małe drewniane okno" },

                        { "wooden_window_big", "Duże okno" },
                        { "wooden_window_big_desc", "Duże drewniane okno" },

                        { "thin_wood_beam_1", "Wąska i długa poprzeczka" },
                        { "thin_wood_beam_1_desc", "Wąska drewniana poprzeczka" },

                        { "thin_wood_beam_2", "Wąska i krótka poprzeczka" },
                        { "thin_wood_beam_2_desc", "Wąska drewniana poprzeczka" },

                        { "wooden_fence_1", "Wzmocniony płot" },
                        { "wooden_fence_1_desc", "Drewniany wzmocniony płot" },

                        { "wooden_fence_1_gate", "Wzmocniony płot - furtka" },
                        { "wooden_fence_1_gate_desc", "Drewniany wzmocniony płot" },

                        { "wooden_fence_2", "Alternatywny płot" },
                        { "wooden_fence_2_desc", "Drewniany płot" },

                        { "wooden_fence_2_gate", "Alternatywny płot - furtka" },
                        { "wooden_fence_2_gate_desc", "Drewniany płot" },

                        { "thin_wood_pole_1", "Wąski i krótki słupek" },
                        { "thin_wood_pole_1_desc", "Wąski dewniany słupek" },

                        { "thin_wood_pole_2", "Wąski i długi słupek" },
                        { "thin_wood_pole_2_desc", "Wąski dewniany słupek" },

                        { "wooden_arch_1", "Drewniany łuk" },
                        { "wooden_arch_1_desc", "Solidna baza pod obsadzenie bramy" },

                        { "wooden_arch_0", "Wielki drewniany łuk" },
                        { "wooden_arch_0_desc", "Solidna baza pod obsadzenie bramy" },

                        { "refined_stakewall_1", "Ciężka palisada" },
                        { "refined_stakewall_1_desc", "Wytrzymalsza palisada" },

                        { "refined_sharpstakes", "Ciężki ostrokół" },
                        { "refined_sharpstakes_desc", "Wytrzymalszy ostrokół" },

                        { "odin_hammer", "Precyzyjny młot" },
                        { "odin_hammer_desc", "Młot dzięki któremu wybudujesz unikatowe, wcześniej niedostępne elementy budownictwa" }
                    }
            });
        }

#if DEBUG
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.F6))
            { // Set a breakpoint here to break on F6 key press
            }
        }
#endif
    }
}