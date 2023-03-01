using HarmonyLib;
using KSP.VFX;
using System.Reflection;

namespace KOPMod.Patches
{
    public class NoThrottleVFXManager : BasePatch
    {
        public NoThrottleVFXManager()
        {
            this.originalMethods.Add(typeof(ThrottleVFXManager).GetMethod("Update", BindingFlags.NonPublic | BindingFlags.Instance));
        }

        public override void DoPatch()
        {
            var transpiler = typeof(CodeGen).GetMethod("GetRet");
            KOPMod.harmony.Patch(originalMethods.ElementAt(0), transpiler: new HarmonyMethod(transpiler));
        }

        public override string GetName() => "No Engine Flames";
    }
}
