using System.Threading.Tasks;
using HarmonyLib;
using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Creatures;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Models;
using MegaCrit.Sts2.Core.Models.Monsters;
using MegaCrit.Sts2.Core.Models.Powers;
using MegaCrit.Sts2.Core.ValueProps;

namespace OstyDamageDetectionMod.Patches;

public static class ImbalancedPowerAfterDamageGivenPatch
{
    public static bool Prefix(PlayerChoiceContext choiceContext, Creature? dealer, DamageResult result, ValueProp props, Creature target, CardModel? cardSource, ImbalancedPower __instance, ref Task __result)
    {
        __result = PatchedAfterDamageGiven(choiceContext, dealer, result, props, target, cardSource, __instance);
        return false;
    }

    private static async Task PatchedAfterDamageGiven(PlayerChoiceContext choiceContext, Creature? dealer, DamageResult result, ValueProp props, Creature target, CardModel? cardSource, ImbalancedPower instance)
    {
        // 原版条件 + 新增：宠物结果未格挡伤害>0 且未击穿（Overkill==0）视作完全格挡
        bool fullyBlocked = result.WasFullyBlocked
            || (result.Receiver.IsPet && result.UnblockedDamage > 0 && result.OverkillDamage == 0);

        if (dealer == instance.Owner && fullyBlocked)
        {
            instance.FlashSafely();
            if (!(instance.Owner.Monster is BowlbugRock bowlbugRock))
            {
                await CreatureCmd.Stun(instance.Owner);
            }
            else
            {
                bowlbugRock.IsOffBalance = true;
            }
        }
    }
}