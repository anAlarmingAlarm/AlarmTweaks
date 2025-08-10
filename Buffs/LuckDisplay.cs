using AlarmTweaks.General;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AlarmTweaks.Buffs
{
    public class NegativeLuck : ModBuff
    {
        public override void ModifyBuffText(ref string buffName, ref string tip, ref int rare)
        {
            tip = "You have negative luck (" + Math.Round(Main.LocalPlayer.luck, 3) + ")";
        }
    }

    public class PositiveLuck : ModBuff
    {
        public override void ModifyBuffText(ref string buffName, ref string tip, ref int rare)
        {
            tip = "You have positive luck (" + Math.Round(Main.LocalPlayer.luck, 3) + ")";
        }
    }

    public class LuckPlayer : ModPlayer
    {
        public override void PreUpdateBuffs()
        {
            if (!Player.HasBuff(BuffID.Lucky) && ModContent.GetInstance<AlarmConfigClient>().luck)
            {
                if (Player.luck > 0)
                {
                    Player.AddBuff(ModContent.BuffType<PositiveLuck>(), 2);
                }
                else if (Player.luck < 0)
                {
                    Player.AddBuff(ModContent.BuffType<NegativeLuck>(), 2);
                }
            }
        }
    }

    public class Lucky : GlobalBuff
    {
        public override void ModifyBuffText(int type, ref string buffName, ref string tip, ref int rare)
        {
            if (type == BuffID.Lucky)
            {
                if (Main.LocalPlayer.luck > 0)
                {
                    tip = "You have positive luck (" + Math.Round(Main.LocalPlayer.luck, 3) + ") with a Luck Potion active";
                } else
                {
                    buffName = "Lucky..?";

                    if (Main.LocalPlayer.luck < 0)
                    {
                        tip = "You have negative luck (" + Math.Round(Main.LocalPlayer.luck, 3) + ")\n...despite having a Luck potion active";
                    } 
                    else
                    {
                        tip = "Your luck is neutral\n...despite having a Luck potion active";
                    }
                    
                }
            }
        }
    }
}