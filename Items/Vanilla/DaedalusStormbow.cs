using AlarmTweaks.General;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AlarmTweaks.Items.Vanilla
{
    public class DaedalusStormbow : GlobalItem
    {
        public override bool AppliesToEntity(Item item, bool lateInstatiation)
        {
            return item.type == ItemID.DaedalusStormbow;
        }

        public override void UpdateInventory(Item item, Player player)
        {
            if (ModContent.GetInstance<AlarmConfig>().daedalusStormbow)
            {
                item.useTime = 15;
                item.useAnimation = 15;
            }
            else
            {
                item.useTime = 19;
                item.useAnimation = 19;
            }
        }
    }
}
