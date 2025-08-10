using AlarmTweaks.General;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AlarmTweaks.Items.Vanilla
{
    public class Revolver : GlobalItem
    {
        public override bool AppliesToEntity(Item item, bool lateInstatiation)
        {
            return item.type == ItemID.Revolver;
        }

        public override void ModifyShootStats(Item item, Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
            if (ModContent.GetInstance<AlarmConfig>().revolver && (type == ProjectileID.Bullet || type == ProjectileID.SilverBullet))
            {
                type = ProjectileID.BulletHighVelocity;
            }
        }

        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            if (ModContent.GetInstance<AlarmConfig>().revolver)
            {
                string newTooltip = "\nShoots a powerful, high velocity bullet";
                if (tooltips.Find(line => line.Name == "Material") != null)
                {
                    tooltips.Find(line => line.Name == "Material").Text += newTooltip;
                }
                else if (tooltips.Find(line => line.Name == "Knockback") != null)
                {
                    tooltips.Find(line => line.Name == "Knockback").Text += newTooltip;
                }
            }
        }
    }
}
