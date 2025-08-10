using AlarmTweaks.General;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AlarmTweaks.Items.Vanilla
{
    public class MasterNinjaGear : GlobalItem
    {
        public override bool AppliesToEntity(Item item, bool lateInstatiation)
        {
            return item.type == ItemID.MasterNinjaGear;
        }

        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            if (tooltips.Find(line => line.Name == "Tooltip0") != null && ModContent.GetInstance<AlarmConfig>().dashDamageReduction)
            {
                tooltips.Find(line => line.Name == "Tooltip0").Text += "\nDashing grants knockback immunity and decreases damage taken";
            }
        }
    }
}
