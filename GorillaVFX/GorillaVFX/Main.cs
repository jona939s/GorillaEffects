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

        private void Start()
        {
            ParticleSystem test2D = ParticleCreator.BasicParticle(true, 5, 1, 0.5f, 1.5f, 20, Color.red);
            ParticleSystem test3D = ParticleCreator.Basic3DParticle(PrimitiveType.Sphere, true, 1, 1, 0.5f, 0.5f, 20, Color.green);

            test2D.transform.position = new Vector3(-62.1642f, 2.4259f, -70.5596f);
            test3D.transform.position = new Vector3(-63.1642f, 2.4259f, -70.5596f);

            test2D.Play();
            test3D.Play();
        }
    }
}
