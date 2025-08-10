using AlarmTweaks.General;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AlarmTweaks.Items.Vanilla
{
    public class Tabi : GlobalItem
    {
        public override bool AppliesToEntity(Item item, bool lateInstatiation)
        {
            return item.type == ItemID.Tabi;
        }

        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            if (tooltips.Find(line => line.Name == "Tooltip1") != null && ModContent.GetInstance<AlarmConfig>().dashDamageReduction)
            {
                tooltips.Find(line => line.Name == "Tooltip1").Text += "\nDashing grants knockback immunity and decreases damage taken";
            }
        }
    }
}
