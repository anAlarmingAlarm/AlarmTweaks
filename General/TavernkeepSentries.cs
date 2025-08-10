using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AlarmTweaks.General
{
    public class TavernkeepSentries : ModPlayer
    {
        bool alreadyHasEvent = false;
        bool hadCreativeShock = false;
        int timer = -1;

        public override void OnEnterWorld()
        {
            alreadyHasEvent = Player.downedDD2EventAnyDifficulty;
        }

        public override void PostUpdate()
        {
            if (!alreadyHasEvent)
            {
                if (hadCreativeShock)
                {
                    alreadyHasEvent = !Player.HasBuff(BuffID.NoBuilding);
                }
                hadCreativeShock = Player.HasBuff(BuffID.NoBuilding);

                if (timer >= 0)
                {
                    if (timer-- == 0)
                    {
                        Player.downedDD2EventAnyDifficulty = false;
                    }
                }
            }
        }

        public override void PreSavePlayer()
        {
            Player.downedDD2EventAnyDifficulty = alreadyHasEvent;
        }

        public override bool CanUseItem(Item item)
        {
            if (ModContent.GetInstance<AlarmConfig>().tavernkeepSentries)
            {
                Player.downedDD2EventAnyDifficulty = true;
                timer = Player.HeldItem.useAnimation + 1;
            }
            return base.CanUseItem(item);
        }
    }
}
