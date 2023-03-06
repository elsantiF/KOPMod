using HarmonyLib;
using KSP.Rendering.Planets;
using System.Reflection;

namespace KOPMod.Patches
{
    public class PQSPatch : BasePatch
    {
        public PQSPatch()
        {
            this.originalMethods.Add(typeof(PQS).GetMethod("OnEnable", BindingFlags.NonPublic | BindingFlags.Instance));
        }

        public override void DoPatch()
        {
            var postfix = typeof(PQSPatch).GetMethod("Postfix");
            KOPMod.harmony.Patch(originalMethods.ElementAt(0), postfix: new HarmonyMethod(postfix));
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
            __instance.isSubdivisionEnabled = false;

            __instance.PQSRenderer.MaxSubdivision = 0;
            __instance.PQSRenderer.OceanQualitySetting = 0;
            __instance.PQSRenderer.EnableLowQualityLocal = true;
        }

        public override string GetName() => "Low Quality Terrain";
    }
}
