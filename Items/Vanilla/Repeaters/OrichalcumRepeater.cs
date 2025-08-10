using AlarmTweaks.General;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AlarmTweaks.Items.Vanilla.Repeaters
{
    public class OrichalcumRepeater : GlobalItem
    {
        public override bool AppliesToEntity(Item item, bool lateInstatiation)
        {
            return item.type == ItemID.OrichalcumRepeater;
        }

        public override void ModifyWeaponDamage(Item item, Player player, ref StatModifier damage)
        {
            if (ModContent.GetInstance<AlarmConfig>().repeaters)
            {
                damage.Base = -7;
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
