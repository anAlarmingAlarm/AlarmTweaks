using Terraria;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;

namespace AlarmTweaks.General
{
    public class AlarmPylon : GlobalPylon
    {
        public override bool? ValidTeleportCheck_PreNPCCount(TeleportPylonInfo pylonInfo, ref int defaultNecessaryNPCCount)
        {
            if (ModContent.GetInstance<AlarmConfig>().noNPCs)
                defaultNecessaryNPCCount = 0;

            return null;
        }

        public override bool? ValidTeleportCheck_PreAnyDanger(TeleportPylonInfo pylonInfo)
        {
            return ModContent.GetInstance<AlarmConfig>().noDanger ? true : null;
        }

        public override bool? PreCanPlacePylon(int x, int y, int tileType, TeleportPylonType pylonType)
        {
            if (ModContent.GetInstance<AlarmConfig>().unlimitedPylons == "All" ||
                (pylonType == TeleportPylonType.Victory && ModContent.GetInstance<AlarmConfig>().unlimitedPylons == "Universal only"))
            {
                return true;
            }

            return null;
        }
    }
}