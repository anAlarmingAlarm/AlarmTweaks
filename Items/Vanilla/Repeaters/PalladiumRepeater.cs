using AlarmTweaks.General;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AlarmTweaks.Items.Vanilla.Repeaters
{
    public class PalladiumRepeater : GlobalItem
    {
        public override bool AppliesToEntity(Item item, bool lateInstatiation)
        {
            return item.type == ItemID.PalladiumRepeater;
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
                item.useTime = 16;
                item.useAnimation = 16;
            }
            else
            {
                item.useTime = 22;
                item.useAnimation = 22;
            }
        }
    }
}
