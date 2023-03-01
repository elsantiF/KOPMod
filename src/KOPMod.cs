using SpaceWarp.API.Mods;
using HarmonyLib;
using System.Reflection;
using UnityEngine;
using KOPMod.Patches;

namespace KOPMod
{
    [MainMod]
    public class KOPMod : Mod
    {

        public static SpaceWarp.API.Logging.BaseModLogger logger;
        public static Harmony harmony;

        private bool openSettings = false;
        private Rect window = new Rect(new Vector2(Screen.width, Screen.height) / 2, new Vector2(250, 350));

        private static List<BasePatch> patchList = new List<BasePatch>();

        public override void OnInitialized()
        {
            logger = Logger;
            logger.Info("KOPMod is initialized");

            harmony = new Harmony("santif.kopmod");

            patchList.AddRange(new List<BasePatch>()
            {
                new NoAtmosphereScatterManager(),
                new NoClouds(),
                new NoShadowMapRenderer(),
                new NoThrottleVFXManager(),
                new NoVegetationSystemPro(),
                new PQSPatch()
            });

            patchList.ForEach(patch => patch.Enabled = true);

            ApplyPatches();

			//WIP: Make this optional
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

        private void OnGUI()
        {
            if(openSettings) window = GUI.Window(0, window, DrawWindow, "KOP Settings");
        }

        private void DrawWindow(int id)
        {
            GUILayout.BeginVertical();
            
            foreach(var patch in patchList)
            {
                patch.Enabled = GUILayout.Toggle(patch.Enabled, patch.GetName());
            }

            if(GUILayout.Button("Apply Patches"))
            {
                ApplyPatches();
            }

            GUILayout.EndVertical();

            GUI.DragWindow(new Rect(0, 0, 1000, 20));
        }

        private void ApplyPatches()
        {
            patchList.ForEach(patch => { 
                if(patch.Enabled)
                {
                    patch.DoPatch();
                }else
                {
                    patch.DoUnpatch();
                }
            });

            logger.Info("Patches Applied");
        }

        private void Update()
        {
            if(Input.GetKeyDown(KeyCode.F1)) {
                openSettings = !openSettings;
            }
        }
    }
}