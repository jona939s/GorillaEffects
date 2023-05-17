using GorillaVFX.Util;
using HarmonyLib;

namespace GorillaVFX.Patches
{
    [HarmonyPatch(typeof(GorillaLocomotion.Player))]
    internal class PlayerPatch
    {
        [HarmonyPostfix]
        [HarmonyPatch("Awake")]
        private static void HookAwake()
        {
            "Game loaded".Log(BepInEx.Logging.LogLevel.Message);
        }
    }
}
