# Kerbal Optimization Program (KOP)

## Summary

KOP is a simple mod that optimizes[^1] KSP2 in order to increase the FPS. This is accomplished disabling effects and adjusting the game settings.
KOP v0.4 uses [SpaceWarp 0.4.0](https://github.com/SpaceWarpDev/SpaceWarp/releases/tag/spacewarp-0.4.0).

Note: If your computer struggles a lot trying to run the game, possibly the mod can't do it better.
Note: This is an **alpha** mod is aimed to semi-advanced users and modders.

[^1]: Actually, there is no optimization, only patches that disable some effects in game

---------------------

## Features

The mod changes some Unity graphic's settings, so if you want to remove it check the [Uninstall](#uninstall) section.

Actually, the mod have the next patches:

- No Atmosphere &rarr; Disables the atmosphere of the planets. Permanent night.
- NoClouds &rarr; Disables the volumetric clouds.
- No Shadows Map &rarr; Disables some laggy shadows.
- No Engine Flames &rarr; Disables the engines flames effect.
- No Vegetation &rarr; Disables all the vegetation.
- Low Quality Terrain &rarr; Reduces the terrain quality, can produce some artifact on it.

Also there is a FPS Limiter that can help to reduce the GPU usage.
All these patches and the FPS Limiter can be accessed via <kbd>LCtrl</kbd> + <kbd>F1</kbd> key.

---------------------

## Uninstall

1. Go to `%appdata%\..\LocalLow\Intercept Games\Kerbal Space Program 2`
2. Delete everything in this folder except for "Saves"
3. Go to your KSP2 installation folder
4. Open a CMD or PowerShell and execute `.\KSP2_x64.exe -screen-quality Fantastic`

All modified settings are gone, the game is set to `High`
