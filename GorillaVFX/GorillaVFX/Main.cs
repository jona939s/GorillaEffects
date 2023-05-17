﻿using BepInEx;
using BepInEx.Logging;
using GorillaVFX.Util;
using HarmonyLib;

namespace GorillaVFX
{
    [BepInPlugin(GUID, NAME, VERSION), BepInDependency("tonimacaroni.computerinterface"), BepInDependency("dev.auros.bepinex.bepinject")]
    internal class Main : BaseUnityPlugin
    {
        internal const string
            GUID = "jjoecrafterbot.gorillatag.gorillaeffects",
            NAME = "Gorilla Effects",
            VERSION = "0.0.1";
        internal static ManualLogSource manualLogSource;
        private void Awake()
        {
            manualLogSource = Logger; // Allows it to be accessible outside of this type
            $"Init : {GUID}".Log(); // formatted logging

            Bepinject.Zenjector.Install<computerInterface.MainInstaller>().OnProject();
            new Harmony(GUID).PatchAll();
        }
    }
}