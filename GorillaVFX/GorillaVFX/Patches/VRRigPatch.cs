/*
    I may switch to bananahook. I just need to see if it does everything needed here
 */

/*using HarmonyLib;
using Photon.Pun;
using UnityEngine;

namespace GorillaVFX.Patches
{
    [HarmonyPatch(typeof(VRRig))]
    internal class VRRigPatch
    {
        [HarmonyPostfix]
        [HarmonyPatch("PlayHandTap")]
        private static void HookStep(int soundIndex, bool isLeftHand, float tapVolume, PhotonMessageInfo info)
        {
            Transform taggedTransform = 
            //__instance.
            ParticleSystem ps = Util.ParticleCreator.Basic3DParticle(PrimitiveType.Sphere, false, 0.5f, 1, 1, 0.1f, 10, Color.red);
            ps.transform.position = taggedTransform.position;
            ps.Play();
        }
    }
}*/
