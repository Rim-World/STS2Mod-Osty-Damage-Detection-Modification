using System;
using System.Reflection;
using HarmonyLib;
using MegaCrit.Sts2.Core.Logging;
using MegaCrit.Sts2.Core.Modding;
using MegaCrit.Sts2.Core.Models.Powers;
using OstyDamageDetectionMod.Patches;

namespace OstyDamageDetectionMod;

[ModInitializer("ModLoaded")]
public static class ModEntry
{
    public const string ModId = "OstyDamageDetectionMod";

    private static Harmony? _harmony;

    public static void ModLoaded()
    {
        try
        {
            Log.Info($"{ModId}: loading...");
            _harmony = new Harmony(ModId);

            int patched = 0;

            var suck = typeof(SuckPower).GetMethod(nameof(SuckPower.AfterAttack), BindingFlags.Public | BindingFlags.Instance);
            if (suck != null)
            {
                _harmony.Patch(suck, prefix: new HarmonyMethod(typeof(SuckPowerAfterAttackPatch), nameof(SuckPowerAfterAttackPatch.Prefix)));
                patched++;
                Log.Info($"{ModId}: SuckPower.AfterAttack patched");
            }
            else
            {
                Log.Warn($"{ModId}: SuckPower.AfterAttack not found on this game version, patch skipped");
            }

            var imbalanced = typeof(ImbalancedPower).GetMethod(nameof(ImbalancedPower.AfterDamageGiven), BindingFlags.Public | BindingFlags.Instance);
            if (imbalanced != null)
            {
                _harmony.Patch(imbalanced, prefix: new HarmonyMethod(typeof(ImbalancedPowerAfterDamageGivenPatch), nameof(ImbalancedPowerAfterDamageGivenPatch.Prefix)));
                patched++;
                Log.Info($"{ModId}: ImbalancedPower.AfterDamageGiven patched");
            }
            else
            {
                Log.Warn($"{ModId}: ImbalancedPower.AfterDamageGiven not found on this game version, patch skipped");
            }

            Log.Info($"{ModId}: applied {patched}/2 patches");
        }
        catch (Exception e)
        {
            Log.Error($"{ModId}: failed to apply patches: {e}");
        }
    }
}