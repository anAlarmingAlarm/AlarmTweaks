using AlarmTweaks.General;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace AlarmTweaks.Items.Vanilla.GemStaves
{
    public class DiamondStaff : GlobalItem
    {
        public override bool AppliesToEntity(Item item, bool lateInstatiation)
        {
            return item.type == ItemID.DiamondStaff;
        }
        
        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            if (ModContent.GetInstance<AlarmConfig>().gemStaves)
            {
                string newTooltip = "\nPierces through enemies\nDamage reduced after each pierce";
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

    public class DiamondStaffProjectile : GlobalProjectile
    {
        public override bool InstancePerEntity => true;
        public bool isStaff = false;
        public int hits = 0;

        public override void OnSpawn(Projectile projectile, IEntitySource source)
        {
            if (projectile.TryGetOwner(out Player player))
            {
                if (player.HeldItem.type == ItemID.DiamondStaff && ModContent.GetInstance<AlarmConfig>().gemStaves && projectile.friendly)
                {
                    projectile.penetrate = -1;
                }
            }
        }

        public override void OnHitNPC(Projectile projectile, NPC target, NPC.HitInfo hit, int damageDone)
        {
            if (isStaff)
            {
                projectile.damage = (int)Math.Floor(projectile.damage * 0.65f);
                if (projectile.damage <= 1) projectile.Kill();
            }
        }
    }
}
