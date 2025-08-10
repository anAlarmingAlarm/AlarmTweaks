using AlarmTweaks.General;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AlarmTweaks.Buffs
{
    public class Buffs : GlobalBuff
    {
        public override void Update(int type, Player player, ref int buffIndex)
        {
            if (type == BuffID.Chilled && ModContent.GetInstance<AlarmConfig>().chilled)
            {
                player.moveSpeed *= 0.85f / 0.75f;
            }
        }
    }
}