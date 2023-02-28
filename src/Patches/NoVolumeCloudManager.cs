using HarmonyLib;
using KSP.Rendering.Planets;
using System.Reflection;

namespace KOPMod.Patches
{
    public class NoVolumeCloudManager : BasePatch
    {
        public NoVolumeCloudManager()
        {
            this.originalMethod = typeof(VolumeCloudManager).GetMethod("LateUpdate", BindingFlags.NonPublic | BindingFlags.Instance);
        }

        public override void DoPatch()
        {
            var transpiler = typeof(CodeGen).GetMethod("GetRet");
            KOPMod.harmony.Patch(originalMethod, transpiler: new HarmonyMethod(transpiler));
        }

        public override string GetName()
        {
            return "NoVolumeCloudManager";
        }
    }
}
