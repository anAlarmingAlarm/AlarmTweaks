using AlarmTweaks.General;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AlarmTweaks.Items.Vanilla.Pearlwood
{
    public class PearlwoodBow : GlobalItem
    {
        public override bool AppliesToEntity(Item item, bool lateInstatiation)
        {
            return item.type == ItemID.PearlwoodBow;
        }

        public override void Update(Item item, ref float gravity, ref float maxFallSpeed)
        {
            if (ModContent.GetInstance<AlarmConfig>().pearlwoodBow)
            {
                ItemID.Sets.IsLavaImmuneRegardlessOfRarity[(item.type)] = true;
            }
            else
            {
                ItemID.Sets.IsLavaImmuneRegardlessOfRarity[(item.type)] = false;
            }
        }

        public override void ModifyWeaponDamage(Item item, Player player, ref StatModifier damage)
        {
            if (ModContent.GetInstance<AlarmConfig>().pearlwoodBow)
            {
                damage.Base = 18;
            }
            else
            {
                damage.Base = 0;
            }
        }

        public override void ModifyWeaponKnockback(Item item, Player player, ref StatModifier knockback)
        {
            if (ModContent.GetInstance<AlarmConfig>().pearlwoodBow)
            {
                knockback.Base = 4;
            }
            else
            {
                knockback.Base = 0;
            }
        }

        public override void UpdateInventory(Item item, Player player)
        {
            if (ModContent.GetInstance<AlarmConfig>().pearlwoodBow)
            {
                item.useTime = 18;
                item.useAnimation = 18;
            }
            else
            {
                item.useTime = 20;
                item.useAnimation = 20;
            }
        }

        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            if (tooltips.Find(line => line.Name == "ItemName") != null)
            {
                if (ModContent.GetInstance<AlarmConfig>().pearlwoodBow)
                {
                    tooltips.Find(line => line.Name == "ItemName").OverrideColor = new Color(255, 150, 150);
                }
                else
                {
                    tooltips.Find(line => line.Name == "ItemName").OverrideColor = null;
                }
            }
            if (tooltips.Find(line => line.Name == "Knockback") != null)
            {
                if (ModContent.GetInstance<AlarmConfig>().pearlwoodBow)
                {
                    tooltips.Find(line => line.Name == "Knockback").Text += "\nEnchants wooden arrows";
                }
            }
        }

        public override void ModifyShootStats(Item item, Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback) {
			if (type == ProjectileID.WoodenArrowFriendly && ModContent.GetInstance<AlarmConfig>().pearlwoodBow) {
				type = ProjectileID.JestersArrow;
			}
		}
    }
}
