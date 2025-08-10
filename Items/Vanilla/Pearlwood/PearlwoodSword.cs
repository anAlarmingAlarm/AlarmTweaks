using AlarmTweaks.General;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AlarmTweaks.Items.Vanilla.Pearlwood
{
    // This file shows a very simple example of a GlobalItem class. GlobalItem hooks are called on all items in the game and are suitable for sweeping changes like
    // adding additional data to all items in the game. Here we simply adjust the damage of one item, as it is simple to understand.
    // See other GlobalItem classes in ExampleMod to see other ways that GlobalItem can be used.
    public class PearlwoodSword : GlobalItem
    {
        public override bool AppliesToEntity(Item item, bool lateInstatiation)
        {
            return item.type == ItemID.PearlwoodSword;
        }

        public override void Update(Item item, ref float gravity, ref float maxFallSpeed)
        {
            if (ModContent.GetInstance<AlarmConfig>().pearlwoodSword)
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
            if (ModContent.GetInstance<AlarmConfig>().pearlwoodSword)
            {
                damage.Base = 18;
            }
            else
            {
                damage.Base = 0;
            }
        }

        public override void MeleeEffects(Item item, Player player, Rectangle hitbox)
        {
            if (Main.rand.NextBool(2) && ModContent.GetInstance<AlarmConfig>().pearlwoodSword) {
                Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, DustID.TeleportationPotion, 0, 0, 0, default, 0.5f);
            }
        }

        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            if (tooltips.Find(line => line.Name == "ItemName") != null)
            {
                if (ModContent.GetInstance<AlarmConfig>().pearlwoodSword)
                {
                    tooltips.Find(line => line.Name == "ItemName").OverrideColor = new Color(255, 150, 150);
                }
                else
                {
                    tooltips.Find(line => line.Name == "ItemName").OverrideColor = null;
                }
            }
        }
    }
}