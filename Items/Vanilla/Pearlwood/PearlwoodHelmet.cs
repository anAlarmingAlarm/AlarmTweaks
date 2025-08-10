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
    public class PearlwoodHelmet : GlobalItem
    {
        public override bool AppliesToEntity(Item item, bool lateInstatiation)
        {
            return item.type == ItemID.PearlwoodHelmet;
        }

        public override void Update(Item item, ref float gravity, ref float maxFallSpeed)
        {
            if (ModContent.GetInstance<AlarmConfig>().pearlwoodSet)
            {
                ItemID.Sets.IsLavaImmuneRegardlessOfRarity[(item.type)] = true;
            }
            else
            {
                ItemID.Sets.IsLavaImmuneRegardlessOfRarity[(item.type)] = false;
            }
        }

        public override void UpdateEquip(Item item, Player player)
        {
            if (ModContent.GetInstance<AlarmConfig>().pearlwoodSet)
            {
                player.statDefense += 3;
                player.GetCritChance(DamageClass.Generic) += 0.07f;
            }
        }

        public override string IsArmorSet(Item head, Item body, Item legs)
        {
            if (ModContent.GetInstance<AlarmConfig>().pearlwoodSet)
            {
                return head.type == ItemID.PearlwoodHelmet
                && body.type == ItemID.PearlwoodBreastplate
                && legs.type == ItemID.PearlwoodGreaves
                ? "AlarmTweaksPearlwood" : "";
            }
            return "";
        }

        public override void UpdateArmorSet(Player player, string set)
        {
            if (set == "AlarmTweaksPearlwood" && ModContent.GetInstance<AlarmConfig>().pearlwoodSet)
            {
                player.setBonus = "4 defense";
                player.statDefense += 3; // Base Pearlwood set bonus already has 1 defense
                if (Main.GameUpdateCount % 3 == 0)
                    Dust.NewDust(player.position, player.width, player.height, DustID.TeleportationPotion, 0, 0, 75, default, 0.5f);
            }
        }

        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            if (tooltips.Find(line => line.Name == "ItemName") != null)
            {
                if (ModContent.GetInstance<AlarmConfig>().pearlwoodSet)
                {
                    tooltips.Find(line => line.Name == "ItemName").OverrideColor = new Color(255, 150, 150);
                }
                else
                {
                    tooltips.Find(line => line.Name == "ItemName").OverrideColor = null;
                }
            }
            if (tooltips.Find(line => line.Name == "Defense") != null)
            {
                if (ModContent.GetInstance<AlarmConfig>().pearlwoodSet)
                {
                    tooltips.Find(line => line.Name == "Defense").Text = (item.defense + 3) + " defense\n7% increased critical strike chance";
                }
                else
                {
                    tooltips.Find(line => line.Name == "Defense").Text = item.defense + " defense";
                }
            }
        }
    }
}
