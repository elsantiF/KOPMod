using AwesomeTechnologies.VegetationSystem;
using HarmonyLib;
using System.Reflection;

namespace KOPMod.Patches
{
    public class NoVegetationSystemPro : BasePatch
    {
        public NoVegetationSystemPro() 
        {
            this.originalMethod = typeof(VegetationSystemPro).GetMethod("Update", BindingFlags.NonPublic | BindingFlags.Instance);
        }

        protected override void DoPatch()
        {
            var transpiler = typeof(CodeGen).GetMethod("GetRet");
            KOPMod.harmony.Patch(originalMethod, transpiler: new HarmonyMethod(transpiler));
        }

        public override string GetName()
        {
            return "NoVegetationSystemPro";
        }
    }
}
