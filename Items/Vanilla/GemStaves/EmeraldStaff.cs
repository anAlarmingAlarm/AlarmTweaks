using AlarmTweaks.General;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace AlarmTweaks.Items.Vanilla.GemStaves
{
    public class EmeraldStaff : GlobalItem
    {
        public override bool AppliesToEntity(Item item, bool lateInstatiation)
        {
            return item.type == ItemID.EmeraldStaff;
        }
        
        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            if (ModContent.GetInstance<AlarmConfig>().gemStaves)
            {
                string newTooltip = "\nBolts have slight homing";
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

    public class EmeraldStaffProjectile : GlobalProjectile
    {
        public override bool InstancePerEntity => true;
        public bool isStaff = false;

        public override void OnSpawn(Projectile projectile, IEntitySource source)
        {
            if (projectile.TryGetOwner(out Player player))
            {
                if (player.HeldItem.type == ItemID.EmeraldStaff && ModContent.GetInstance<AlarmConfig>().gemStaves && projectile.friendly)
                {
                    isStaff = true;
                }
            }
        }

        public override void PostAI(Projectile projectile)
        {
            if (!isStaff) return;

            float maxDetectRadius = 400f; // The maximum radius at which a projectile can detect a target

            NPC closestNPC = null;

            // Using squared values in distance checks will let us skip square root calculations, drastically improving this method's speed.
            float sqrMaxDetectDistance = maxDetectRadius * maxDetectRadius;

            // Loop through all NPCs
            foreach (var target in Main.ActiveNPCs)
            {
                // Check if NPC able to be targeted (collision check is to make sure the projectile can actually see them)
                if (target.CanBeChasedBy() && Collision.CanHit(projectile.Center, 1, 1, target.position, target.width, target.height))
                {
                    // The DistanceSquared function returns a squared distance between 2 points, skipping relatively expensive square root calculations
                    float sqrDistanceToTarget = Vector2.DistanceSquared(target.Center, projectile.Center);

                    // Check if it is within the radius
                    if (sqrDistanceToTarget < sqrMaxDetectDistance)
                    {
                        sqrMaxDetectDistance = sqrDistanceToTarget;
                        closestNPC = target;
                    }
                }
            }
            if (closestNPC == null) return;

            float length = projectile.velocity.Length();
            float targetAngle = projectile.AngleTo(closestNPC.Center);
            projectile.velocity = projectile.velocity.ToRotation().AngleTowards(targetAngle, MathHelper.ToRadians(0.5f)).ToRotationVector2() * length;
            projectile.rotation = projectile.velocity.ToRotation();

            return;
        }
    }
}
