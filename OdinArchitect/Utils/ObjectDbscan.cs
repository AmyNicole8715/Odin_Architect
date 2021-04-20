using HarmonyLib;
using OdinArchitect;
using JotunnLib;
using UnityEngine;

namespace OdinArchitect
{
    [HarmonyPatch(typeof(ObjectDB), "CopyOtherDB")]
    public static class ObjectDB_CopyOtherDB_Patch
    {
        public static void Postfix()
        {
            JotunnLib.Logger.LogInfo("Material Replacer loaded succesfully");
            OdinArchitect.ReplaceMats();
        }
    }

    [HarmonyPatch(typeof(ObjectDB), "Awake")]
    public static class ObjectDB_Awake_Patch
    {
        public static void Postfix()
        {
            JotunnLib.Logger.LogInfo("Material Replacer loaded succesfully");
            OdinArchitect.ReplaceMats();
        }
    }

}
