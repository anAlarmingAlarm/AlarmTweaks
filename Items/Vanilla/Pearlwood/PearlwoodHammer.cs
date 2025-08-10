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
    public class PearlwoodHammer : GlobalItem
    {
        public override bool AppliesToEntity(Item item, bool lateInstatiation)
        {
            return item.type == ItemID.PearlwoodHammer;
        }

        public override void Update(Item item, ref float gravity, ref float maxFallSpeed)
        {
            if (ModContent.GetInstance<AlarmConfig>().pearlwoodHammer)
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
            if (ModContent.GetInstance<AlarmConfig>().pearlwoodHammer)
            {
                damage.Base = 15;
            }
            else
            {
                damage.Base = 0;
            }
        }

        public override float UseSpeedMultiplier(Item item, Player player)
        {
            return base.UseSpeedMultiplier(item, player);
        }

        public override void SetDefaults(Item item)
        {
            if (ModContent.GetInstance<AlarmConfig>().pearlwoodHammer)
            {
                item.hammer = 80;
                item.useTime = 23;
                item.useAnimation = 23;
            }
        }

        public override void UpdateInventory(Item item, Player player)
        {
            if (ModContent.GetInstance<AlarmConfig>().pearlwoodHammer)
            {
                item.hammer = 80;
                item.useTime = 23;
                item.useAnimation = 23;
            }
            else
            {
                item.hammer = 55;
                item.useTime = 29;
                item.useAnimation = 29;
            }
        }

        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            if (tooltips.Find(line => line.Name == "ItemName") != null)
            {
                if (ModContent.GetInstance<AlarmConfig>().pearlwoodHammer)
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
