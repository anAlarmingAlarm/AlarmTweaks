using AlarmTweaks.Buffs;
using AlarmTweaks.General;
using System.Collections.Generic;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace AlarmTweaks.Items.Vanilla.GemStaves
{
    public class RubyStaff : GlobalItem
    {
        public override bool AppliesToEntity(Item item, bool lateInstatiation)
        {
            return item.type == ItemID.RubyStaff;
        }
        
        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            if (ModContent.GetInstance<AlarmConfig>().gemStaves)
            {
                string newTooltip = "\nSuccessive hits increase attack speed";
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

    public class RubyStaffProjectile : GlobalProjectile
    {
        public override bool InstancePerEntity => true;
        public bool isStaff = false;

        public override void OnSpawn(Projectile projectile, IEntitySource source)
        {
            if (projectile.TryGetOwner(out Player player))
            {
                if (player.HeldItem.type == ItemID.RubyStaff && ModContent.GetInstance<AlarmConfig>().gemStaves && projectile.friendly)
                {
                    isStaff = true;
                }
            }
        }

        public override void OnHitNPC(Projectile projectile, NPC target, NPC.HitInfo hit, int damageDone)
        {
            OnHit(projectile);
        }

        public override void OnHitPlayer(Projectile projectile, Player target, Player.HurtInfo info)
        {
            OnHit(projectile);
        }

        private void OnHit(Projectile projectile)
        {
            if (isStaff && projectile.TryGetOwner(out Player player) && player.HeldItem.type == ItemID.RubyStaff)
            {
                player.AddBuff(ModContent.BuffType<RubyStaffBuff>(), 119);
            }
        }
    }
}
