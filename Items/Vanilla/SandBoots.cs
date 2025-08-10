using AlarmTweaks.General;
using log4net.Core;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AlarmTweaks.Items.Vanilla
{
    public class SandBoots : GlobalItem
    {
        public override bool AppliesToEntity(Item item, bool lateInstatiation)
        {
            return item.type == ItemID.SandBoots;
        }

        public override void UpdateEquip(Item item, Player player)
        {
            if (ModContent.GetInstance<AlarmConfig>().duneriderBoots)
            {
                player.buffImmune[BuffID.WindPushed] = true;
            }
        }

        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            if (tooltips.Find(line => line.Name == "Tooltip0") != null && ModContent.GetInstance<AlarmConfig>().duneriderBoots)
            {
                tooltips.Find(line => line.Name == "Tooltip0").Text += "\nImmunity to Mighty Wind";
            }
        }
    }
    public class TerrasparkBoots : GlobalItem
    {
        public override bool AppliesToEntity(Item item, bool lateInstatiation)
        {
            return item.type == ItemID.TerrasparkBoots;
        }

        public override void UpdateEquip(Item item, Player player)
        {
            if (ModContent.GetInstance<AlarmConfig>().terrasparkDunerider)
            {
                player.desertBoots = true;
                if (ModContent.GetInstance<AlarmConfig>().duneriderBoots)
                    player.buffImmune[BuffID.WindPushed] = true;
            }
        }

        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            if (tooltips.Find(line => line.Name == "Tooltip0") != null && tooltips.Find(line => line.Name == "Tooltip4") != null && ModContent.GetInstance<AlarmConfig>().terrasparkDunerider)
            {
                tooltips.Find(line => line.Name == "Tooltip0").Text = "Allows flight, super fast running, even faster running on sand, and extra mobility on ice";
                tooltips.Find(line => line.Name == "Tooltip4").Text += "\nImmunity to Mighty Wind" +
                                                                       "\nNegates fall damage";
            }
        }
    }
}
