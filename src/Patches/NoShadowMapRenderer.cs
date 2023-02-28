using HarmonyLib;
using KSP.Rendering;
using System.Reflection;

namespace KOPMod.Patches
{
    public class NoShadowMapRenderer : BasePatch
    {
        public NoShadowMapRenderer()
        {
            this.originalMethod = typeof(ShadowMapRenderer).GetMethod("LateUpdate", BindingFlags.NonPublic | BindingFlags.Instance);
        }

        protected override void DoPatch()
        {
            var transpiler = typeof(CodeGen).GetMethod("GetRet");
            KOPMod.harmony.Patch(originalMethod, transpiler: new HarmonyMethod(transpiler));
        }

        public override string GetName()
        {
            return "NoShadowMapRenderer";
        }
    }
}
