using AlarmTweaks.General;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AlarmTweaks.Items.Vanilla
{
    public class EmpressFlightBooster : GlobalItem
    {
        public override bool AppliesToEntity(Item item, bool lateInstatiation)
        {
            return item.type == ItemID.EmpressFlightBooster;
        }

        public override void UpdateEquip(Item item, Player player)
        {
            if (ModContent.GetInstance<AlarmConfig>().soaringInsignia)
            {
                player.noFallDmg = true;
            }
        }

        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            if (tooltips.Find(line => line.Name == "Tooltip1") != null && ModContent.GetInstance<AlarmConfig>().soaringInsignia)
            {
                tooltips.Find(line => line.Name == "Tooltip1").Text += "\nNegates fall damage";
            }
        }
    }
}
