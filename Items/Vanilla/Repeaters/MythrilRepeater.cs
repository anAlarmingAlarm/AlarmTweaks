using AlarmTweaks.General;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AlarmTweaks.Items.Vanilla.Repeaters
{
    public class MythrilRepeater : GlobalItem
    {
        public override bool AppliesToEntity(Item item, bool lateInstatiation)
        {
            return item.type == ItemID.MythrilRepeater;
        }

        public override void ModifyWeaponDamage(Item item, Player player, ref StatModifier damage)
        {
            if (ModContent.GetInstance<AlarmConfig>().repeaters)
            {
                damage.Base = -8;
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
                item.useTime = 14;
                item.useAnimation = 14;
            }
            else
            {
                item.useTime = 20;
                item.useAnimation = 20;
            }
        }
    }
}
