using BepInEx;
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
        private void Awake()
        {
            manualLogSource = Logger; // Allows it to be accessible outside of this type
            $"Init : {GUID}".Log(); // formatted logging

            ParticleSystem ps = ParticleCreator.BasicParticle(false, 2, 1, 10, 10, Color.red);
            ParticleSystem ps3d = ParticleCreator.Basic3DParticle(PrimitiveType.Sphere, false, 2, 1, 10, 10, Color.black);
            ps.Play();
            ps3d.Play();

            Bepinject.Zenjector.Install<computerInterface.MainInstaller>().OnProject();
            new Harmony(GUID).PatchAll();
        }
    }
}
