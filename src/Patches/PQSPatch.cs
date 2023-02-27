using HarmonyLib;
using KSP.Rendering.Planets;

namespace KOPMod.Patches
{
    [HarmonyPatch(typeof(PQS), "OnEnable")]
    public static class KSPReconfig
    {
        [HarmonyPostfix]
        static void Postfix(PQS __instance)
        {
            PQSGlobalSettings.SubdivData subdivData = new PQSGlobalSettings.SubdivData();
            subdivData.minLevel = 1;
            subdivData.maxLevel = 4;
            subdivData.minDetailMultiplier = 6;
            subdivData.numTesselationSteps = 2;

            PQSGlobalSettings.SubdivisionInfo subdivisionInfo = new PQSGlobalSettings.SubdivisionInfo();
            subdivisionInfo.subdivData = subdivData;
            __instance.settings.subdivisionInfo = subdivisionInfo;

            KOPMod.logger.Info("Executed PQS.OnEnable");
        }
    }
}
