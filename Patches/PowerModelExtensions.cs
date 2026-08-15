using System.Reflection;
using MegaCrit.Sts2.Core.Models;

namespace OstyDamageDetectionMod.Patches;

internal static class PowerModelExtensions
{
    private static readonly MethodInfo? FlashMethod =
        typeof(PowerModel).GetMethod("Flash", BindingFlags.Instance | BindingFlags.NonPublic);

    public static void FlashSafely(this PowerModel power)
    {
        try
        {
            FlashMethod?.Invoke(power, null);
        }
        catch
        {
            // 视觉闪烁失败不影响功能
        }
    }
}