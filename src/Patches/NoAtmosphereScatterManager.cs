using HarmonyLib;
using KSP.Rendering.Planets;
using System.Reflection;

namespace KOPMod.Patches
{
    class NoAtmosphereScatterManager : BasePatch
    {
        public NoAtmosphereScatterManager()
        {
            this.originalMethod = typeof(AtmosphereScatterManager).GetMethod("LateUpdate", BindingFlags.NonPublic | BindingFlags.Instance);
        }

        protected override void DoPatch()
        {
            var transpiler = typeof(CodeGen).GetMethod("GetRet");
            KOPMod.harmony.Patch(originalMethod, transpiler: new HarmonyMethod(transpiler));
        }

        public override string GetName()
        {
            return "NoAtmosphereScatterManager";
        }
    }
}
