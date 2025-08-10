using AlarmTweaks.General;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AlarmTweaks.Projectiles
{
    public class Tombstones : GlobalProjectile
    {
        public override bool AppliesToEntity(Projectile entity, bool lateInstantiation)
        {
            return entity.type == ProjectileID.Tombstone        ||
                   entity.type == ProjectileID.GraveMarker      ||
                   entity.type == ProjectileID.Gravestone       ||
                   entity.type == ProjectileID.CrossGraveMarker ||
                   entity.type == ProjectileID.Obelisk          ||
                   entity.type == ProjectileID.RichGravestone1  ||
                   entity.type == ProjectileID.RichGravestone2  ||
                   entity.type == ProjectileID.RichGravestone3  ||
                   entity.type == ProjectileID.RichGravestone4  ||
                   entity.type == ProjectileID.RichGravestone5;
        }

        public override bool PreAI(Projectile projectile)
        {
            if (ModContent.GetInstance<AlarmConfig>().noTombstones)
            {
                projectile.active = false;
                return false;
            }
            return true;
        }
    }
}
