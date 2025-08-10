using AlarmTweaks.General;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AlarmTweaks.Items.Vanilla
{
    public class PutridScentUpgrades : GlobalItem
    {
        public override bool AppliesToEntity(Item item, bool lateInstatiation)
        {
            return item.type == ItemID.ArcaneFlower ||
                   item.type == ItemID.ReconScope   ||
                   item.type == ItemID.StalkersQuiver;
        }

        public override void UpdateEquip(Item item, Player player)
        {
            if (ModContent.GetInstance<AlarmConfig>().putridScentUpgrades)
            {
                player.GetDamage(DamageClass.Generic) += 0.05f;
                player.GetCritChance(DamageClass.Generic) += 0.05f;
            }
        }

        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            if (ModContent.GetInstance<AlarmConfig>().putridScentUpgrades)
            {
                if (item.type == ItemID.ReconScope && tooltips.Find(line => line.Name == "Tooltip1") != null)
                {
                    tooltips.Find(line => line.Name == "Tooltip1").Text += "\n5% increased damage and critical strike chance";
                }
                else if (tooltips.Find(line => line.Name == "Tooltip0") != null)
                {
                    tooltips.Find(line => line.Name == "Tooltip0").Text = "5% increased damage and critical strike chance\n" + tooltips.Find(line => line.Name == "Tooltip0").Text;
                }
            }
        }
    }
}
