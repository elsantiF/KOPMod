using BepInEx;
using BepInEx.Logging;
using SpaceWarp;
using SpaceWarp.API.Mods;
using HarmonyLib;
using UnityEngine;
using KOPMod.Patches;
using SpaceWarp.API.UI;

namespace KOPMod
{
    [BepInPlugin("me.santif.kop_mod", "kop_mod", "0.3.6")]
    [BepInDependency(SpaceWarpPlugin.ModGuid, SpaceWarpPlugin.ModVer)]
    public class KOPMod : BaseSpaceWarpPlugin
    {

        public static KOPMod Instance { get; set; }
        public static Harmony harmony;
        public static ManualLogSource logger;

        private bool openSettings = false;
        private Rect window = new Rect(new Vector2(Screen.width, Screen.height) / 2, new Vector2(250, 350));

        private static List<BasePatch> patchList = new List<BasePatch>();

        //WIP: Extract
        private static int targetFPS = 60;

        public override void OnInitialized()
        {
            base.OnInitialized();
            Instance = this;
            logger = Logger;
            Logger.LogInfo("KOPMod is initialized");

            harmony = new Harmony(GetType().FullName);

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

        private void OnGUI()
        {
            GUI.skin = Skins.ConsoleSkin;
            if(openSettings) window = GUI.Window(0, window, DrawWindow, "KOP Settings");
        }

        private void DrawWindow(int id)
        {
            GUILayout.BeginVertical();
            GUILayout.Label("Patches");
            foreach(var patch in patchList)
            {
                patch.Enabled = GUILayout.Toggle(patch.Enabled, patch.GetName());
            }

            //WIP: Extract
            GUILayout.Label("Unity Settings");
            GUILayout.BeginHorizontal();
            GUILayout.Label("FPS Limit:");
            try
            {
                targetFPS = int.Parse(GUILayout.TextArea(targetFPS.ToString()));
                targetFPS = Mathf.Clamp(targetFPS, 10, 360);
            }catch(Exception e)
            {
                targetFPS = 60;
            }
            GUILayout.EndHorizontal();

            if (GUILayout.Button("Apply"))
            {
                harmony.UnpatchSelf();
                ApplyPatches();
                ChangeUnitySettings();
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
                }
            });

            Logger.LogInfo("Patches Applied");
        }

        //WIP: Extract
        private void ChangeUnitySettings()
        {
            QualitySettings.SetQualityLevel(0);
            QualitySettings.antiAliasing = 0;
            QualitySettings.softParticles = false;
            QualitySettings.pixelLightCount = 1;
            QualitySettings.maximumLODLevel = 2;
            QualitySettings.shadows = ShadowQuality.Disable;
            QualitySettings.realtimeReflectionProbes = false;
            QualitySettings.anisotropicFiltering = AnisotropicFiltering.Disable;
            QualitySettings.masterTextureLimit = 2;
            QualitySettings.vSyncCount = 0;

            RenderSettings.defaultReflectionResolution = 0;
            RenderSettings.defaultReflectionMode = 0;

            Application.targetFrameRate = targetFPS;

            Logger.LogInfo("Changed Settings");
        }

        private void Update()
        {
            if(Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.F1)) {
                openSettings = !openSettings;
            }
        }
    }
}