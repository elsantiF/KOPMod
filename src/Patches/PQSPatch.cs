using HarmonyLib;
using KSP.Rendering.Planets;
using System.Reflection;

namespace KOPMod.Patches
{
    public class PQSPatch : BasePatch
    {
        public PQSPatch()
        {
            this.originalMethod = typeof(PQS).GetMethod("OnEnable", BindingFlags.NonPublic | BindingFlags.Instance);
        }

        public override void DoPatch()
        {
            var postfix = typeof(PQSPatch).GetMethod("Postfix");
            KOPMod.harmony.Patch(originalMethod, postfix: new HarmonyMethod(postfix));
        }

        public static void Postfix(PQS __instance)
        {
            PQSGlobalSettings.SubdivData subdivData = new PQSGlobalSettings.SubdivData();
            subdivData.minLevel = 1;
            subdivData.maxLevel = 4;
            subdivData.minDetailMultiplier = 6;
            subdivData.numTesselationSteps = 2;

            PQSGlobalSettings.SubdivisionInfo subdivisionInfo = new PQSGlobalSettings.SubdivisionInfo();
            subdivisionInfo.subdivData = subdivData;
            __instance.settings.subdivisionInfo = subdivisionInfo;
        }

        public override string GetName()
        {
            return "PQSPatch";
        }
    }
}
