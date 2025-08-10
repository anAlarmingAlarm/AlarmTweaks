using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AlarmTweaks.Buffs
{
    public class RubyStaffBuff : ModBuff
    {
        private int stacks = 0;

        public override bool ReApply(Player player, int time, int buffIndex)
        {
            if (player.TryGetModPlayer(out RubyStaffPlayer result))
            {
                if (result.stacks < 4)
                {
                    result.stacks++;
                    stacks = result.stacks;
                }
            }
            return false;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            if (player.TryGetModPlayer(out RubyStaffPlayer result))
            {
                if (result.stacks == 0)
                {
                    result.stacks++;
                    stacks = result.stacks;
                }
            }
        }

        public override void ModifyBuffText(ref string buffName, ref string tip, ref int rare)
        {
            tip = (5 * stacks) + "% increased attack speed";
        }
    }

    public class RubyStaffPlayer : ModPlayer
    {
        public int stacks = 0;

        public override void PostUpdateBuffs()
        {
            if (Player.HeldItem.type != ItemID.RubyStaff) Player.ClearBuff(ModContent.BuffType<RubyStaffBuff>());
            if (!Player.HasBuff<RubyStaffBuff>()) stacks = 0;
            else Player.GetAttackSpeed<MagicDamageClass>() += 0.05f * stacks;
        }
    }
}