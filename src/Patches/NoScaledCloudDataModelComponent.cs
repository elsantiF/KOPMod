using HarmonyLib;
using KSP.Rendering;
using System.Reflection;

namespace KOPMod.Patches
{
    public class NoScaledCloudDataModelComponent : BasePatch
    {
        public NoScaledCloudDataModelComponent()
        {
            this.originalMethod = typeof(ScaledCloudDataModelComponent).GetMethod("LateUpdate", BindingFlags.NonPublic | BindingFlags.Instance);
        }

        public override void DoPatch()
        {
            var transpiler = typeof(CodeGen).GetMethod("GetRet");
            KOPMod.harmony.Patch(originalMethod, transpiler: new HarmonyMethod(transpiler));
        }

        public override string GetName()
        {
            return "NoScaledCloudDataModelComponent";
        }
    }
}
