using AlarmTweaks.General;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AlarmTweaks.Items.Vanilla.Repeaters
{
    public class WandOfFrosting : GlobalItem
    {
        public override bool AppliesToEntity(Item item, bool lateInstatiation)
        {
            return item.type == ItemID.WandofFrosting;
        }

        public override void ModifyWeaponDamage(Item item, Player player, ref StatModifier damage)
        {
            if (ModContent.GetInstance<AlarmConfig>().wandOfFrosting)
            {
                damage.Base = 5;
            }
            else
            {
                damage.Base = 0;
            }
        }

        public override void UpdateInventory(Item item, Player player)
        {
            if (ModContent.GetInstance<AlarmConfig>().wandOfFrosting)
            {
                item.shootSpeed = 9f;
            }
            else
            {
                item.shootSpeed = 7f;
            }
        }
    }
}
