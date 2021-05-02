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

        private AssetBundle OdinEmbedded;
        private GameObject placebp_prefab;

        private void Awake()
        {
            LoadAssets();
            AddCustomPieces();
            AddLocalizations();
        }

        private void LoadAssets()
        {
            Jotunn.Logger.LogInfo($"Embedded resources: {string.Join(",", Assembly.GetExecutingAssembly().GetManifestResourceNames())}");
            OdinEmbedded = AssetUtils.LoadAssetBundleFromResources("odinarchitect", Assembly.GetExecutingAssembly());
            placebp_prefab = OdinEmbedded.LoadAsset<GameObject>("Assets/CustomStructures/wooden_gate_1.prefab");
        }

        private void AddCustomPieces()

            var placebp = new CustomPiece(placebp_prefab,
                new PieceConfig
                {
                    PieceTable = "Hammer",
                    AllowedInDungeons = true,
                    Requirements = new[]
                    {
                        new RequirementConfig { Item = "Wood", Amount = 20 }
                    }
                }));
        PieceManager.Instance.AddPiece(placebp);
            }

        private void AddLocalizations()
        {
            LocalizationManager.Instance.AddLocalization(new LocalizationConfig("English")
            {
                Translations =
                    {
                        { "wooden_gate_1", "Big Gate" },
                        { "wooden_gate_1_desc", "Big and heavy wooden gate" }
                    }
            });
            LocalizationManager.Instance.AddLocalization(new LocalizationConfig("Polish")
            {
                Translations =
                    {
                        { "wooden_gate_1", "Drewniana brama" },
                        { "wooden_gate_1_desc", "Wielka i ciężka drewniana brama" }
                    }
            });
        }
    }
}