using AlarmTweaks.General;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AlarmTweaks.Items.Vanilla
{
    // This file shows a very simple example of a GlobalItem class. GlobalItem hooks are called on all items in the game and are suitable for sweeping changes like
    // adding additional data to all items in the game. Here we simply adjust the damage of one item, as it is simple to understand.
    // See other GlobalItem classes in ExampleMod to see other ways that GlobalItem can be used.
    public class WoodGreaves : GlobalItem
    {
        public override bool AppliesToEntity(Item item, bool lateInstatiation)
        {
            return item.type == ItemID.WoodGreaves;
        }

        public override void UpdateEquip(Item item, Player player)
        {
            if (ModContent.GetInstance<AlarmConfig>().woodGreaves)
            {
                player.statDefense += 1;
            }
        }

        public override string IsArmorSet(Item head, Item body, Item legs)
        {
            if (ModContent.GetInstance<AlarmConfig>().woodGreaves)
            {
                return head.type == ItemID.WoodHelmet
                && body.type == ItemID.WoodBreastplate
                && legs.type == ItemID.WoodGreaves
                ? "AlarmTweaksWood" : "";
            }
            return "";
        }

        public override void UpdateArmorSet(Player player, string set)
        {
            if (set == "AlarmTweaksWood" && ModContent.GetInstance<AlarmConfig>().woodGreaves)
            {
                player.setBonus = "0 defense\nHow helpful!";
                player.statDefense -= 1; // Base set bonus has 1 defense
            }
        }

        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            if (tooltips.Find(line => line.Name == "Equipable") != null)
            {
                if (ModContent.GetInstance<AlarmConfig>().woodGreaves)
                {
                    tooltips.Find(line => line.Name == "Equipable").Text = "Equipable\n" + (item.defense + 1) + " defense";
                }
                else
                {
                    tooltips.Find(line => line.Name == "Equipable").Text = "Equipable";
                }
            }
        }
    }
}
