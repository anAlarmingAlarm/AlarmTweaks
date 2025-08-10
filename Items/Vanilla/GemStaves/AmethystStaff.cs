using AlarmTweaks.General;
using System.Collections.Generic;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace AlarmTweaks.Items.Vanilla.GemStaves
{
    public class AmethystStaff : GlobalItem
    {
        public override bool AppliesToEntity(Item item, bool lateInstatiation)
        {
            return item.type == ItemID.AmethystStaff;
        }
        
        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            if (ModContent.GetInstance<AlarmConfig>().gemStaves)
            {
                string newTooltip = "\nKnocks enemies upward";
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

    public class AmethystStaffProjectile : GlobalProjectile
    {
        public override bool InstancePerEntity => true;
        public bool isStaff = false;
        public float knockback = 0;

        public override void OnSpawn(Projectile projectile, IEntitySource source)
        {
            if (projectile.TryGetOwner(out Player player))
            {
                if (player.HeldItem.type == ItemID.AmethystStaff && ModContent.GetInstance<AlarmConfig>().gemStaves && projectile.friendly)
                {
                    isStaff = true;
                    knockback = projectile.knockBack;
                    projectile.knockBack = 0;
                }
            }
        }

        public override void OnHitNPC(Projectile projectile, NPC target, NPC.HitInfo hit, int damageDone)
        {
            if (target.knockBackResist == 0f || !isStaff) return;
            target.velocity.X -= target.velocity.X * (0.5f + target.knockBackResist / 2);
            target.velocity.Y -= (0.3f + 0.7f * target.knockBackResist) * knockback;
        }

        public override void OnHitPlayer(Projectile projectile, Player target, Player.HurtInfo info)
        {
            if (target.noKnockback || !isStaff) return;
            target.velocity.X *= 0.5f * knockback;
            target.velocity.Y -= knockback;
        }
    }
}
