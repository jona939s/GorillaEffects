using GorillaVFX.Util;
using HarmonyLib;
using Photon.Realtime;
using UnityEngine;

namespace GorillaVFX.Patches
{
    [HarmonyPatch(typeof(GorillaTagManager))]
    internal class GorillaTagManagerPatch
    {
        [HarmonyPostfix]
        [HarmonyWrapSafe]
        [HarmonyPatch("ReportTag", MethodType.Normal)]
        private static void HookTag(GorillaTagManager __instance, Player taggedPlayer, Player taggingPlayer)
        {
            /*if (GorillaGameManager.instance is )
            {*/
                (GameObject go, ParticleSystem ps) Particle = ParticleCreator.BasicParticle(false, 0.25f, 5, 1, 0.1f, 1, 5, 50, Color.red);
                //Particle.go.transform.position = GorillaGameManager.instance.FindVRRigForPlayer(TaggedPlayer).transform.position;
                Particle.ps.Play();
            //}
        }
    }
}
