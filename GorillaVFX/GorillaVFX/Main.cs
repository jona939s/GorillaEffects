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
            $"AWAKE Init : {GUID}".Log(); // formatted logging

            ParticleMultiplier = Config.Bind<int>("General", "Particle Multiplier", 1, "The amount of particles will be multiplied by this number.");

            Bepinject.Zenjector.Install<computerInterface.MainInstaller>().OnProject();
            new Harmony(GUID).PatchAll();
        }

        private void Start()
        {
            $"-----===== START OF START FUNC =====-----".Log(LogLevel.Debug);

            Mesh mesh = ParticleCreator.getMesh(PrimitiveType.Capsule);
            GameObject p = ParticleCreator.Basic3DParticle(mesh, ParticleSystemShapeType.Sphere, true, 1000, 10, 2, 10, 1000, Color.red);
            //GameObject go = GameObject.CreatePrimitive(PrimitiveType.Cube);
            //go.name = "go";
            GameObject gogo = GameObject.CreatePrimitive(PrimitiveType.Cube);
            gogo.transform.position = new Vector3(-62.1642f, 2.4259f, -70.5596f);
            gogo.GetComponent<MeshFilter>().mesh = mesh;

            //p.GetComponent<ParticleSystemRenderer>().mesh = go.GetComponent<Mesh>();
            p.GetComponent<ParticleSystem>().Play();

            p.transform.position = new Vector3(-62.1642f, 2.4259f, -70.5596f);

            "-----===== END OF START FUNC =====-----".Log(LogLevel.Debug);
        }
    }
}
