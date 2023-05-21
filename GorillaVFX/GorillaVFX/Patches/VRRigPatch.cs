using GorillaVFX.Util;
using HarmonyLib;

namespace GorillaVFX.Patches
{
    [HarmonyPatch(typeof(VRRig))]
    internal class VRRigPatch
    {
        [HarmonyPostfix]
        [HarmonyPatch("Start")]
        private static void HookStart(VRRig __instance)
        {
            ParticleCreator.BasicParticle(__instance.transform.position, false, 5, 5, 1, 0.25f, 1, 5, 50, __instance.materialsToChangeTo[0].color);
        }
    }
}
