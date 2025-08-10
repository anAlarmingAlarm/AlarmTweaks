using AlarmTweaks.General;
using System.Collections.Generic;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace AlarmTweaks.Items.Vanilla
{
    public class MagicQuiver : GlobalItem
    {
        public override bool AppliesToEntity(Item entity, bool lateInstantiation)
        {
            return entity.type == ItemID.MagicQuiver || entity.type == ItemID.MoltenQuiver || entity.type == ItemID.StalkersQuiver;
        }

        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            if (tooltips.Find(line => line.Name == "Tooltip0") != null && ModContent.GetInstance<AlarmConfig>().magicQuiverTooltip)
            {
                tooltips.Find(line => line.Name == "Tooltip0").Text = "Increases arrow damage and knockback by 10%\nGreatly increases arrow speed";
            }
        }
    }

    public class MagicQuiverProjectile : GlobalProjectile
    {
        public override void OnSpawn(Projectile projectile, IEntitySource source)
        {
            if (projectile.TryGetOwner(out Player player))
            {
                if (projectile.arrow && projectile.friendly && projectile.extraUpdates > 0 && player.magicQuiver && ModContent.GetInstance<AlarmConfig>().magicQuiver)
                {
                    projectile.extraUpdates++;
                }
            }
        }
    }
}
