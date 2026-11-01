using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HarmonyLib;
using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Commands.Builders;
using MegaCrit.Sts2.Core.Entities.Creatures;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Models.Powers;
using MegaCrit.Sts2.Core.ValueProps;

namespace OstyDamageDetectionMod.Patches;

public static class SuckPowerAfterAttackPatch
{
    public static bool Prefix(PlayerChoiceContext choiceContext, AttackCommand command, SuckPower __instance, ref Task __result)
    {
        __result = PatchedAfterAttack(choiceContext, command, __instance);
        return false;
    }

    private static async Task PatchedAfterAttack(PlayerChoiceContext choiceContext, AttackCommand command, SuckPower instance)
    {
        if (command.Attacker != instance.Owner || command.TargetSide == instance.Owner.Side || !command.DamageProps.IsPoweredAttack())
        {
            return;
        }

        List<List<DamageResult>> hits = command.Results.ToList();
        int hitCount = 0;
        foreach (List<DamageResult> hit in hits)
        {
            // 反转原版移除方向：奥斯提等宠物吸收的伤害不再视为玩家掉血
            hit.RemoveAll(r => r.Receiver.IsPet);
            if (hit.Any(r => r.UnblockedDamage > 0))
            {
                hitCount++;
            }
        }

        if (hitCount > 0)
        {
            instance.FlashSafely();
            await PowerCmd.Apply<StrengthPower>(choiceContext, instance.Owner, instance.Amount * hitCount, instance.Owner, null);
        }
    }
}