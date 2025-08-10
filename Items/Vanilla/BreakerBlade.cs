using AlarmTweaks.General;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace AlarmTweaks.Items.Vanilla
{
    public class BreakerBlade : GlobalItem
    {
        public override bool AppliesToEntity(Item item, bool lateInstatiation)
        {
            return item.type == ItemID.BreakerBlade;
        }

        public override void ModifyWeaponDamage(Item item, Player player, ref StatModifier damage)
        {
            if (ModContent.GetInstance<AlarmConfig>().breakerBlade)
            {
                damage.Base = -10;
            }
            else
            {
                damage.Base = 0;
            }
        }

        public override void ModifyHitNPC(Item item, Player player, NPC target, ref NPC.HitModifiers modifiers)
        {
            if (target.life > target.lifeMax * 0.9 && ModContent.GetInstance<AlarmConfig>().breakerBlade)
                modifiers.SourceDamage = modifiers.SourceDamage.Scale(0.5f);
        }
    }
}
