using AlarmTweaks.General;
using log4net.Core;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace AlarmTweaks.Items.Vanilla
{
    public class SummonerEmblem : GlobalItem
    {
        public override bool AppliesToEntity(Item item, bool lateInstatiation)
        {
            return (item.type == ItemID.SummonerEmblem) ||
                   (item.type == ItemID.AvengerEmblem) ||
                   (item.type == ItemID.DestroyerEmblem);
        }

        public override void UpdateEquip(Item item, Player player)
        {
            if (ModContent.GetInstance<AlarmConfig>().bewitchedEffect)
            {
                player.buffImmune[BuffID.Bewitched] = true;
                player.GetModPlayer<SummonerEmblemPlayer>().bewitched = true;
            }
        }

        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            int l = item.type == ItemID.DestroyerEmblem ? 1 : 0;
            if (ModContent.GetInstance<AlarmConfig>().bewitchedEffect)
            {
                if (tooltips.Find(line => line.Name == "Tooltip" + l) != null)
                {
                    tooltips.Find(line => line.Name == "Tooltip" + l).Text += "\nGrants the Bewitched effect";
                }
            }
        }
    }

    public class SummonerEmblemPlayer : ModPlayer
    {
        public bool bewitched = false;

        public override void PostUpdateEquips()
        {
            if (bewitched)
            {
                Player.maxMinions++;
                bewitched = false;
            }
        }
    }
}
