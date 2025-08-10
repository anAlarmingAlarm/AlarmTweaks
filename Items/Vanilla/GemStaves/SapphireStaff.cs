using AlarmTweaks.General;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace AlarmTweaks.Items.Vanilla.GemStaves
{
    public class SapphireStaff : GlobalItem
    {
        public override bool AppliesToEntity(Item item, bool lateInstatiation)
        {
            return item.type == ItemID.SapphireStaff;
        }
        
        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            if (ModContent.GetInstance<AlarmConfig>().gemStaves)
            {
                string newTooltip = "\nBounces up to 3 times";
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

    public class SapphireStaffProjectile : GlobalProjectile
    {
        public override bool InstancePerEntity => true;
        public bool isStaff = false;

        public override void OnSpawn(Projectile projectile, IEntitySource source)
        {
            if (projectile.TryGetOwner(out Player player))
            {
                if (player.HeldItem.type == ItemID.SapphireStaff && ModContent.GetInstance<AlarmConfig>().gemStaves && projectile.friendly)
                {
                    isStaff = true;
                    projectile.penetrate = 3;
                }
            }
        }

        public override bool OnTileCollide(Projectile projectile, Vector2 oldVelocity)
        {
            if (!isStaff) return true;

            projectile.penetrate--;
            if (projectile.penetrate <= 0)
            {
                projectile.Kill();
            }
            else
            {
                Collision.HitTiles(projectile.position, projectile.velocity, projectile.width, projectile.height);
                SoundEngine.PlaySound(SoundID.Item10, projectile.position);

                // If the projectile hits the left or right side of the tile, reverse the X velocity
                if (Math.Abs(projectile.velocity.X - oldVelocity.X) > float.Epsilon)
                {
                    projectile.velocity.X = -oldVelocity.X;
                }

                // If the projectile hits the top or bottom side of the tile, reverse the Y velocity
                if (Math.Abs(projectile.velocity.Y - oldVelocity.Y) > float.Epsilon)
                {
                    projectile.velocity.Y = -oldVelocity.Y;
                }
            }

            return false;
        }

        public override void OnHitNPC(Projectile projectile, NPC target, NPC.HitInfo hit, int damageDone)
        {
            if (isStaff) projectile.penetrate = 0;
        }

        public override void OnHitPlayer(Projectile projectile, Player target, Player.HurtInfo info)
        {
            if (isStaff) projectile.penetrate = 0;
        }
    }
}
