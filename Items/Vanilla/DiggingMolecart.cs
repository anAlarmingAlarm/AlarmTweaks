using AlarmTweaks.General;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AlarmTweaks.Items.Vanilla
{
    public class DiggingMolecart : GlobalItem
    {
        public override bool AppliesToEntity(Item item, bool lateInstatiation)
        {
            // no need to use a dynamic globalitem for this, since it's attached to an option that requires a reload on change anyway
            return item.type == ItemID.DiggingMoleMinecart && ModContent.GetInstance<AlarmConfig>().molecart;
        }

        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            if (tooltips.Find(line => line.Name == "Tooltip1") != null && tooltips.Find(line => line.Name == "Tooltip1").Text.ToLower().Contains("only digs when underground"))
            {
                tooltips.Remove(tooltips.Find(line => line.Name == "Tooltip1"));
            }
        }
    }
}
