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
        public const string PluginVersion = "0.0.1";

        private AssetBundle OdinArchitectBundle;
        private static GameObject OA_wooden_gate_1_prefab;
        private CustomPiece OA_wooden_gate_1;

        private void Awake()
        {
            OA_LoadAssets();
            OA_AddCustomPieces();
            OA_AddLocales();
        }

        private void OA_LoadAssets()
        {
            OdinArchitectBundle = AssetUtils.LoadAssetBundle("OdinArchitect/Assets/odinarchitect");
            Jotunn.Logger.LogInfo("Assets [" + OdinArchitectBundle + "] loaded succesfully");
        }

        private void OA_AddCustomPieces() 
        {
            Harmony.CreateAndPatchAll(Assembly.GetExecutingAssembly(), "com.raelaziel");
            PieceManager PieMan = PieceManager.Instance;

            OdinArchitect.OA_wooden_gate_1_prefab = OdinArchitectBundle.LoadAsset<GameObject>("wooden_gate_1");
            PieMan.AddPiece(OA_wooden_gate_1 = new CustomPiece(OA_wooden_gate_1_prefab,
                new PieceConfig
                {
                    PieceTable = "Hammer",
                    AllowedInDungeons = true,
                    CraftingStation = "piece_workbench",
                    Requirements = new[]
                    {
                        new RequirementConfig { Item = "Wood", Amount = 20 }
                    }
                }));

            OdinArchitectBundle.Unload(false);
        }

        public static void ReplaceMats()
        {
            Jotunn.Logger.LogInfo("Material Replacer loaded succesfully");
            MaterialReplacer.GetAllMaterials();

            MaterialReplacer.ReplaceAllMaterialsWithOriginal(OdinArchitect.OA_wooden_gate_1_prefab);
        }

        private void OA_AddLocales()
        {
            foreach (TextAsset textAsset in OdinArchitectBundle.LoadAllAssets<TextAsset>())
            {
                string text = textAsset.name.Replace(".json", null);
                LocalizationManager.Instance.AddJson(text, textAsset.ToString());
            }
        }
    }
}