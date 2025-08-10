using AlarmTweaks.General;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AlarmTweaks.Items.Vanilla
{
    public class Coal : GlobalItem
    {
        public override bool AppliesToEntity(Item item, bool lateInstatiation)
        {
            return item.type == ItemID.Coal;
        }

        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            if (tooltips.Find(line => line.Name == "ItemName") != null)
            {
                if (ModContent.GetInstance<AlarmConfig>().coalRarity)
                {
                    tooltips.Find(line => line.Name == "ItemName").OverrideColor = new Color(130, 130, 130);
                }
                else
                {
                    tooltips.Find(line => line.Name == "ItemName").OverrideColor = null;
                }
            }
        }

        public override void Update(Item item, ref float gravity, ref float maxFallSpeed)
        {
            if (ModContent.GetInstance<AlarmConfig>().coalRarity)
            {
                ItemID.Sets.IsLavaImmuneRegardlessOfRarity[(item.type)] = true;
            }
            else
            {
                ItemID.Sets.IsLavaImmuneRegardlessOfRarity[(item.type)] = false;
            }

            UpdateItem(item);
        }

        public override void UpdateInventory(Item item, Player player)
        {
            UpdateItem(item);
        }

        private void UpdateItem(Item item)
        {
            if (ModContent.GetInstance<AlarmConfig>().coalStack)
            {
                item.maxStack = 9999;
            }
            else
            {
                item.maxStack = 1;
            }
        }
    }
}
