using BepInEx;
using BepInEx.Configuration;
using BepInEx.Logging;
using GorillaVFX.Util;
using HarmonyLib;
using UnityEngine;

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

        #region Configuration
        internal static ConfigEntry<int> ParticleMultiplier;
        #endregion

        private void Awake()
        {
            manualLogSource = Logger; // Allows it to be accessible outside of this type
            $"Init : {GUID}".Log(); // formatted logging

            ParticleMultiplier = Config.Bind<int>("General", "Particle Multiplier", 1, "The amount of particles will be multiplied by this number.");

            Bepinject.Zenjector.Install<computerInterface.MainInstaller>().OnProject();
            new Harmony(GUID).PatchAll();
        }
    }
}
