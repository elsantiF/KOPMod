using AwesomeTechnologies.VegetationSystem;
using HarmonyLib;
using KSP.Rendering;
using KSP.Rendering.Planets;
using KSP.VFX;
using KSP.VolumeCloud;

namespace KOPMod.Patches
{
    internal class DisablePatches
    {
        //WIP: Future use
    }

    [HarmonyPatch(typeof(ScaledCloudDataModelComponent), "LateUpdate")]
    public static class NoScaledCloudDataModelComponent
    {
        static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) => CodeGen.GetRet(instructions);
    }

    [HarmonyPatch(typeof(VegetationSystemPro), "Update")]
    public static class NoVegetationSystemPro
    {
        static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) => CodeGen.GetRet(instructions);
    }

    [HarmonyPatch(typeof(VolumeCloudRenderer), "LateUpdate")]
    public static class NoVolumeCloudRenderer
    {
        static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) => CodeGen.GetRet(instructions);
    }

    [HarmonyPatch(typeof(ThrottleVFXManager), "Update")]
    public static class NoThrottleVFXManager
    {
        static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) => CodeGen.GetRet(instructions);
    }

    [HarmonyPatch(typeof(ShadowMapRenderer), "LateUpdate")]
    public static class NoShadowMapRenderer
    {
        static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) => CodeGen.GetRet(instructions);
    }

    [HarmonyPatch(typeof(VolumeCloudManager), "LateUpdate")]
    public static class NoVolumeCloudManager
    {
        static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) => CodeGen.GetRet(instructions);
    }

    [HarmonyPatch(typeof(AtmosphereScatterManager), "LateUpdate")]
    public static class NoAtmosphereScatterManager
    {
        static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) => CodeGen.GetRet(instructions);
    }
}
