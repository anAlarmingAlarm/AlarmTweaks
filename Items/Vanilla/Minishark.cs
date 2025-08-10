using AlarmTweaks.General;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AlarmTweaks.Items.Vanilla
{
    public class Minishark : GlobalItem
    {
        public override bool AppliesToEntity(Item item, bool lateInstatiation)
        {
            return item.type == ItemID.Minishark;
        }

        public override void SetDefaults(Item item)
        {
            item.ArmorPenetration = 10;
        }

        public override void UpdateInventory(Item item, Player player)
        {
            if (ModContent.GetInstance<AlarmConfig>().minishark)
            {
                item.ArmorPenetration = 10;
            }
            else
            {
                item.ArmorPenetration = 0;
            }
        }

        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            if (tooltips.Find(line => line.Name == "Tooltip0") != null && ModContent.GetInstance<AlarmConfig>().minishark)
            {
                tooltips.Find(line => line.Name == "Tooltip0").Text += "\nIgnores a moderate amount of enemy defense";
            }
        }
    }
}
