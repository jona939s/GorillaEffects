using HarmonyLib;
using Photon.Realtime;
using System.Linq;
using UnityEngine;

namespace GorillaVFX.Patches
{
    [HarmonyPatch(typeof(GorillaTagManager))]
    internal class GorillaGameManagerPatch
    {
        [HarmonyPostfix]
        [HarmonyWrapSafe]
        [HarmonyPatch("AddInfectedPlayer")]
        private static void HookTag(GorillaTagManager instance, Player TaggedPlayer)
        {
            Transform taggedTransform = GameObject.FindObjectsOfType<VRRig>().First(x => x.photonView.Owner == TaggedPlayer).transform;

            GameObject ps = Util.ParticleCreator.Basic3DParticle(
                Util.ParticleCreator.getMesh(PrimitiveType.Sphere), // The mesh used
                ParticleSystemShapeType.Sphere, // The emission shape (Basically the direction particles can go in the shape of a mesh)
                false, // looping
                0.5f, // duration
                100, // lifetime (should be seconds, but I think its a lie
                1, //lifetime multiplier (should just be 1 for most the the time)
                0.25f, // Size
                1, // Speed
                20, // emission
                40, // max amount
                Color.red); // mesh color

            ps.transform.position = taggedTransform.position;
            ps.GetComponent<ParticleSystem>().Play();
        }
    }
}
