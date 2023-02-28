using HarmonyLib;
using KSP.VolumeCloud;
using System.Reflection;

namespace KOPMod.Patches
{
    public class NoVolumeCloudRenderer : BasePatch
    {
        public NoVolumeCloudRenderer()
        {
            this.originalMethod = typeof(VolumeCloudRenderer).GetMethod("LateUpdate", BindingFlags.NonPublic | BindingFlags.Instance);
        }

        protected override void DoPatch()
        {
            var transpiler = typeof(CodeGen).GetMethod("GetRet");
            KOPMod.harmony.Patch(originalMethod, transpiler: new HarmonyMethod(transpiler));
        }

        public override string GetName()
        {
            return "NoVolumeCloudRenderer";
        }
    }
}
