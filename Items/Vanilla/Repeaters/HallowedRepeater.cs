using AlarmTweaks.General;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AlarmTweaks.Items.Vanilla.Repeaters
{
    public class HallowedRepeater : GlobalItem
    {
        public override bool AppliesToEntity(Item item, bool lateInstatiation)
        {
            return item.type == ItemID.HallowedRepeater;
        }

        public override void ModifyWeaponDamage(Item item, Player player, ref StatModifier damage)
        {
            if (ModContent.GetInstance<AlarmConfig>().repeaters)
            {
                damage.Base = -11;
            }
            else
            {
                damage.Base = 0;
            }
        }

        public override void UpdateInventory(Item item, Player player)
        {
            if (ModContent.GetInstance<AlarmConfig>().repeaters)
            {
                item.useTime = 12;
                item.useAnimation = 12;
            }
            else
            {
                item.useTime = 17;
                item.useAnimation = 17;
            }
        }
    }
}
