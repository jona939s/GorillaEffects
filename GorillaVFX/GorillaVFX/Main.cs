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
        internal static ConfigEntry<float> ParticleMultiplier;
        internal static ConfigEntry<float> Emission;
        internal static ConfigEntry<float> Speed;
        internal static ConfigEntry<float> Size;
        internal static ConfigEntry<int> Max;
        #endregion

        private void Awake()
        {
            manualLogSource = Logger; // Allows it to be accessible outside of this type
            $"AWAKE Init : {GUID}".Log(); // formatted logging

            ParticleMultiplier = Config.Bind<float>("General", "Particle Multiplier", 1.0f, "The amount of particles will be multiplied by this number.");
            Emission = Config.Bind<float>("General", "Particle Emission", 15.0f, "The amount of particle allowed to be spawned every second");
            Speed = Config.Bind<float>("General", "Particle Speed", 15.0f, "The amount of speed the particles can move at");
            Size = Config.Bind<float>("General", "Particle Size", 0.15f, "The size of each particle");
            Max = Config.Bind<int>("General", "Max Particles", 75, "The max amount of particles allowed to exist at once for eac individual particle system");

            Bepinject.Zenjector.Install<computerInterface.MainInstaller>().OnProject();
            new Harmony(GUID).PatchAll();
        }

        private void Start()
        {
            GameObject p = ParticleCreator.Basic3DParticle(ParticleCreator.getMesh(PrimitiveType.Sphere), ParticleSystemShapeType.Sphere, // THIS IS AN EXAMPLE AND TEST PS
                true,
                20,
                1000,
                1,
                Size.Value,
                Speed.Value,
                Emission.Value * ParticleMultiplier.Value,
                Max.Value,
                Color.blue);

            p.GetComponent<ParticleSystem>().Play();

            p.transform.position = new Vector3(-62.1642f, 2.4259f, -70.5596f);
        }
    }
}
