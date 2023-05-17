using HarmonyLib;
using Photon.Realtime;
using System.Linq;
using UnityEngine;

namespace GorillaVFX.Patches
{
    /*[HarmonyPatch(typeof(GorillaGameManager))]
    internal class GorillaGameManagerPatch
    {
        [HarmonyPostfix]
        [HarmonyPatch("ReportTag")]
        private static void HookTag(GorillaGameManager __instance, Player TaggedPlayer)
        {
            Transform taggedTransform = GameObject.FindObjectsOfType<VRRig>().First(x => x.photonView.Owner == TaggedPlayer).transform;
            //__instance.
            ParticleSystem ps = Util.ParticleCreator.Basic3DParticle(PrimitiveType.Sphere, false, 0.5f, 1, 1, 0.1f, 10, Color.red);
            ps.transform.position = taggedTransform.position;
            ps.Play();
        }
    }*/
}
