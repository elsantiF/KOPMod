using HarmonyLib;
using KSP.Rendering;
using System.Reflection;

namespace KOPMod.Patches
{
    public class NoShadowMapRenderer : BasePatch
    {
        public NoShadowMapRenderer()
        {
            this.originalMethods.Add(typeof(ShadowMapRenderer).GetMethod("LateUpdate", BindingFlags.NonPublic | BindingFlags.Instance));
        }

        public override void DoPatch()
        {
            var transpiler = typeof(CodeGen).GetMethod("GetRet");
            KOPMod.harmony.Patch(originalMethods.ElementAt(0), transpiler: new HarmonyMethod(transpiler));
        }

        public override string GetName() => "NoShadowMapRenderer";
    }
}
