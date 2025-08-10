using AlarmTweaks.General;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AlarmTweaks.Items.Vanilla
{
    public class HeroShield : GlobalItem
    {
        public override bool AppliesToEntity(Item item, bool lateInstatiation)
        {
            return item.type == ItemID.HeroShield;
        }

        public override void UpdateEquip(Item item, Player player)
        {
            if (ModContent.GetInstance<AlarmConfig>().heroShield)
            {
                player.statDefense += 4;
            }
        }

        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            if (tooltips.Find(line => line.Name == "Defense") != null)
            {
                if (ModContent.GetInstance<AlarmConfig>().heroShield)
                {
                    tooltips.Find(line => line.Name == "Defense").Text = (item.defense + 4) + " defense";
                }
                else
                {
                    tooltips.Find(line => line.Name == "Defense").Text = item.defense + " defense";
                }
            }
        }
    }
}
