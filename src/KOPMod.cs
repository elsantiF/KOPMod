using SpaceWarp.API.Mods;
using HarmonyLib;
using System.Reflection;
using UnityEngine;

namespace KOPMod
{
    [MainMod]
    public class KOPMod : Mod
    {

        public static SpaceWarp.API.Logging.BaseModLogger logger;

        public override void OnInitialized()
        {
            logger = Logger;
            logger.Info("KOPMod is initialized");
            Harmony.CreateAndPatchAll(Assembly.GetExecutingAssembly());
            logger.Info("Patches Applied");

            ChangeUnitySettings();
        }

        private void ChangeUnitySettings()
        {
            QualitySettings.SetQualityLevel(0);
            QualitySettings.antiAliasing = 0;
            QualitySettings.softParticles = false;
            QualitySettings.pixelLightCount = 1;
            QualitySettings.shadows = ShadowQuality.Disable;
            QualitySettings.realtimeReflectionProbes = false;
            QualitySettings.anisotropicFiltering = AnisotropicFiltering.Disable;
            QualitySettings.masterTextureLimit = 2;

            RenderSettings.defaultReflectionResolution = 0;
            logger.Info("Changed Settings");
        }
    }
}