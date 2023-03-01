using AwesomeTechnologies.VegetationSystem;
using HarmonyLib;
using System.Reflection;

namespace KOPMod.Patches
{
    public class NoVegetationSystemPro : BasePatch
    {
        public NoVegetationSystemPro() 
        {
            this.originalMethods.Add(typeof(VegetationSystemPro).GetMethod("Update", BindingFlags.NonPublic | BindingFlags.Instance));
        }

        public override void DoPatch()
        {
            var transpiler = typeof(CodeGen).GetMethod("GetRet");
            KOPMod.harmony.Patch(originalMethods.ElementAt(0), transpiler: new HarmonyMethod(transpiler));
        }

        public override string GetName() => "No Vegetation";
    }
}
