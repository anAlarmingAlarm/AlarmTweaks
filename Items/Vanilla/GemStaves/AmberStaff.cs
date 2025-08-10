using AlarmTweaks.General;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace AlarmTweaks.Items.Vanilla.GemStaves
{
    public class AmberStaff : GlobalItem
    {
        public override bool AppliesToEntity(Item item, bool lateInstatiation)
        {
            return item.type == ItemID.AmberStaff;
        }
        
        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            if (ModContent.GetInstance<AlarmConfig>().gemStaves)
            {
                string newTooltip = "\nDamage is reduced to 1\nInflicts Hellfire and Oiled based on the original damage";
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

    public class AmberStaffProjectile : GlobalProjectile
    {
        public override bool InstancePerEntity => true;
        public bool isStaff = false;

        public override void OnSpawn(Projectile projectile, IEntitySource source)
        {
            if (projectile.TryGetOwner(out Player player))
            {
                if (player.HeldItem.type == ItemID.AmberStaff && ModContent.GetInstance<AlarmConfig>().gemStaves)
                {
                    isStaff = true;
                }
            }
        }

        public override void ModifyHitNPC(Projectile projectile, NPC target, ref NPC.HitModifiers modifiers)
        {
            if (!isStaff) return;

            modifiers.SetMaxDamage(1);
            int time = (int)Math.Round(projectile.damage * 1.5f);
            target.AddBuff(BuffID.OnFire3, time);
            target.AddBuff(BuffID.Oiled, time);
        }

        public override void ModifyHitPlayer(Projectile projectile, Player target, ref Player.HurtModifiers modifiers)
        {
            if (!isStaff) return;

            modifiers.SetMaxDamage(1);
            int time = (int)Math.Round(projectile.damage * 1.5f);
            target.AddBuff(BuffID.OnFire3, time);
            target.AddBuff(BuffID.Oiled, time);
        }
    }
}
