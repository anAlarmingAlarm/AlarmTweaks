using AlarmTweaks.General;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AlarmTweaks.Items.Vanilla
{
    public class VineRope : GlobalItem
    {
        public override bool AppliesToEntity(Item item, bool lateInstatiation)
        {
            return item.type == ItemID.VineRope;
        }

        public override void UpdateInventory(Item item, Player player)
        {
            if (ModContent.GetInstance<AlarmConfig>().vineRope)
            {
                item.value = Item.sellPrice(copper: 1);
            }
            else
            {
                item.value = 0;
            }
        }
    }

    public class VineRopeCoil : GlobalItem
    {
        public override bool AppliesToEntity(Item item, bool lateInstatiation)
        {
            return item.type == ItemID.VineRopeCoil;
        }

        public override void UpdateInventory(Item item, Player player)
        {
            if (ModContent.GetInstance<AlarmConfig>().vineRope)
            {
                item.value = Item.sellPrice(copper: 10);
            }
            else
            {
                item.value = 0;
            }
        }
    }
}
