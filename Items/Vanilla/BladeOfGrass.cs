using AlarmTweaks.General;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AlarmTweaks.Items.Vanilla
{
    public class BladeOfGrass : GlobalItem
    {
        public override bool AppliesToEntity(Item item, bool lateInstatiation)
        {
            return item.type == ItemID.BladeofGrass;
        }

        public override void ModifyWeaponDamage(Item item, Player player, ref StatModifier damage)
        {
            if (ModContent.GetInstance<AlarmConfig>().bladeOfGrass)
            {
                damage.Base = 4;
            }
            else
            {
                damage.Base = 0;
            }
        }

        public override void ModifyShootStats(Item item, Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
            if (ModContent.GetInstance<AlarmConfig>().bladeOfGrass)
            {
                damage *= 2;
            }
        }
    }
}
