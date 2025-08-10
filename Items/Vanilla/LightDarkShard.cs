using AlarmTweaks.General;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AlarmTweaks.Items.Vanilla
{
    public class LightDarkShard : GlobalItem
    {
        public override bool AppliesToEntity(Item item, bool lateInstatiation)
        {
            return item.type == ItemID.LightShard || item.type == ItemID.DarkShard;
        }

        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            if (tooltips.Find(line => line.Name == "Tooltip0") != null && ModContent.GetInstance<AlarmConfig>().wyvernLightNight)
            {
                string text = tooltips.Find(line => line.Name == "Tooltip0").Text;
                string time = (item.type == ItemID.LightShard) ? "sun" : "night";
                tooltips.Find(line => line.Name == "Tooltip0").Text = text.Substring(0, text.Length - 1) + ", and by Wyverns of the " + time + "'";
            }
        }
    }
}
