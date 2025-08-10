using AlarmTweaks.General;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AlarmTweaks.Items.Vanilla
{
    // This file shows a very simple example of a GlobalItem class. GlobalItem hooks are called on all items in the game and are suitable for sweeping changes like
    // adding additional data to all items in the game. Here we simply adjust the damage of one item, as it is simple to understand.
    // See other GlobalItem classes in ExampleMod to see other ways that GlobalItem can be used.
    public class ObsidianRose : GlobalItem
    {
        public override bool AppliesToEntity(Item item, bool lateInstatiation)
        {
            return (item.type == ItemID.ObsidianRose) ||
                   (item.type == ItemID.ObsidianSkullRose) ||
                   (item.type == ItemID.LavaWaders) ||
                   (item.type == ItemID.TerrasparkBoots);
        }

        public override void UpdateEquip(Item item, Player player)
        {
            if (ModContent.GetInstance<AlarmConfig>().obsidianRose)
            {
                player.buffImmune[BuffID.OnFire] = true;
            }
        }

        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            if (tooltips.Find(line => line.Name == "Tooltip0") != null && ModContent.GetInstance<AlarmConfig>().obsidianRose)
            {
                tooltips.Find(line => line.Name == "Tooltip0").Text += "\nImmunity to On Fire!";
            }
        }
    }
}
