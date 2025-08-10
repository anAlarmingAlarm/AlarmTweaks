using AlarmTweaks.General;
using System.Collections.Generic;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace AlarmTweaks.Items.Vanilla.GemStaves
{
    public class TopazStaff : GlobalItem
    {
        public override bool AppliesToEntity(Item item, bool lateInstatiation)
        {
            return item.type == ItemID.TopazStaff;
        }
        
        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            if (ModContent.GetInstance<AlarmConfig>().gemStaves)
            {
                string newTooltip = "\nAccelerates over time";
                if (tooltips.Find(line => line.Name == "Material") != null)
                {
                    tooltips.Find(line => line.Name == "Material").Text += newTooltip;
                }
                else if (tooltips.Find(line => line.Name == "UseMana") != null)
                {
                    tooltips.Find(line => line.Name == "UseMana").Text += newTooltip;
                }
            }
        }
    }

    public class TopazStaffProjectile : GlobalProjectile
    {
        public override bool InstancePerEntity => true;
        public bool isStaff = false;

        public override void OnSpawn(Projectile projectile, IEntitySource source)
        {
            if (projectile.TryGetOwner(out Player player) && true)
            {
                if (player.HeldItem.type == ItemID.TopazStaff && ModContent.GetInstance<AlarmConfig>().gemStaves && projectile.friendly)
                {
                    isStaff = true;
                    projectile.velocity *= 0.7f;
                }
            }
        }

        public override void PostAI(Projectile projectile)
        {
            if (isStaff) projectile.velocity *= 1.01f;
        }
    }
}
