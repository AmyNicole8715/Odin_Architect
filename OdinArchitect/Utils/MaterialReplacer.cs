﻿using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace OdinArchitect
{
    static class MaterialReplacer
    {
        static Dictionary<string, Material> originalMaterials;

        public static void GetAllMaterials()
        {
            var allmats = Resources.FindObjectsOfTypeAll<Material>();
            originalMaterials = new Dictionary<string, Material>();
            foreach (var item in allmats)
            {
                originalMaterials[item.name] = item;
            }
        }

        public static void ReplaceAllMaterialsWithOriginal(GameObject go)
        {
            if (originalMaterials == null) GetAllMaterials();

            foreach (Renderer renderer in go.GetComponentsInChildren<Renderer>(true))
            {
                for (int i = 0; i < renderer.materials.Length; i++)
                {
                    if (renderer.materials[i].name.StartsWith("_REPLACE_"))
                    {
                        var matName = renderer.material.name.Replace(" (Instance)", string.Empty).Replace("_REPLACE_", "");

                        if (originalMaterials.ContainsKey(matName))
                        {
                            renderer.material = originalMaterials[matName];
                        }
                        else
                        {
                            Jotunn.Logger.LogInfo("No replacement for meterial: " + matName + ".Using custom material.");
                            originalMaterials[matName] = renderer.material;
                        }
                    }
                }
            }
        }
    }
}