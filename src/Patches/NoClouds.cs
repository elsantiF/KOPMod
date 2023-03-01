using HarmonyLib;
using KSP.Rendering;
using KSP.Rendering.Planets;
using KSP.VolumeCloud;
using System.Reflection;

namespace KOPMod.Patches
{
    public class NoClouds : BasePatch
    {
        public NoClouds()
        {
            originalMethods.AddRange(new List<MethodInfo> 
            { 
                typeof(VolumeCloudManager).GetMethod("LateUpdate", BindingFlags.NonPublic | BindingFlags.Instance),
                typeof(VolumeCloudRenderer).GetMethod("LateUpdate", BindingFlags.NonPublic | BindingFlags.Instance),
                typeof(ScaledCloudDataModelComponent).GetMethod("LateUpdate", BindingFlags.NonPublic | BindingFlags.Instance)
            });
        }

        public override void DoPatch()
        {
            var transpiler = typeof(CodeGen).GetMethod("GetRet");
            foreach (var method in originalMethods)
            {
                KOPMod.harmony.Patch(method, transpiler: new HarmonyMethod(transpiler));
            }
            
        }

        public override string GetName() => "No Clouds";
    }
}
