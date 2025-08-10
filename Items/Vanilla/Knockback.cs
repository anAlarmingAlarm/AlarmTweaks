using AlarmTweaks.General;
using Terraria;
using Terraria.ModLoader;

namespace AlarmTweaks.Items.Vanilla
{
    public class Knockback : GlobalItem
    {
        public override bool AppliesToEntity(Item item, bool lateInstatiation)
        {
            return item.knockBack <= 0 && item.damage > 0
                 && ModContent.GetInstance<AlarmConfig>().knockback;
        }

        public override void SetDefaults(Item entity)
        {
            entity.knockBack += 1;
        }

        public override void ModifyWeaponKnockback(Item item, Player player, ref StatModifier knockback)
        {
            knockback.Base -= 1;
        }
    }
}
