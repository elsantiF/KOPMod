using HarmonyLib;
using KSP.Rendering.Planets;
using System.Reflection;

namespace KOPMod.Patches
{
    class NoAtmosphereScatterManager : BasePatch
    {
        public NoAtmosphereScatterManager()
        {
            this.originalMethods.Add(typeof(AtmosphereScatterManager).GetMethod("LateUpdate", BindingFlags.NonPublic | BindingFlags.Instance));
        }

        public override void DoPatch()
        {
            var transpiler = typeof(CodeGen).GetMethod("GetRet");
            KOPMod.harmony.Patch(originalMethods.ElementAt(0), transpiler: new HarmonyMethod(transpiler));
        }

        public override string GetName() => "No Atmosphere";
    }
}
