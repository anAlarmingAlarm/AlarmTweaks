using AlarmTweaks.General;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AlarmTweaks.Items.Vanilla.Repeaters
{
    public class Repeaters : GlobalItem
    {
        public override bool AppliesToEntity(Item item, bool lateInstatiation)
        {
            return item.type == ItemID.CobaltRepeater
                || item.type == ItemID.PalladiumRepeater
                || item.type == ItemID.MythrilRepeater
                || item.type == ItemID.OrichalcumRepeater
                || item.type == ItemID.AdamantiteRepeater
                || item.type == ItemID.TitaniumRepeater
                || item.type == ItemID.HallowedRepeater
                || item.type == ItemID.ChlorophyteShotbow;
        }

        public override void UpdateInventory(Item item, Player player)
        {
            if (ModContent.GetInstance<AlarmConfig>().repeaters)
            {
                item.ArmorPenetration = 5;
            }
            else
            {
                item.ArmorPenetration = 0;
            }
        }

        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            if (tooltips.Find(line => line.Name == "Knockback") != null && ModContent.GetInstance<AlarmConfig>().repeaters)
                tooltips.Find(line => line.Name == "Knockback").Text += "\nIgnores a small amount of enemy defense";
        }
    }
}
