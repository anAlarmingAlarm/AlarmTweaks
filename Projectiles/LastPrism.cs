using AlarmTweaks.General;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AlarmTweaks.Projectiles
{
    public class LastPrism : GlobalProjectile
    {
        public override bool AppliesToEntity(Projectile entity, bool lateInstantiation)
        {
            return (entity.type == ProjectileID.LastPrism || entity.type == ProjectileID.LastPrismLaser);
        }

        public override bool PreAI(Projectile projectile)
        {
            if (projectile.timeLeft < 2 && ModContent.GetInstance<AlarmConfig>().lastPrism)
                projectile.timeLeft = 6969;

            return true;
        }
    }
}
