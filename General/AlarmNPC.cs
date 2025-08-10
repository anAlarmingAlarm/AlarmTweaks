using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;
using AlarmTweaks.General.DropConditions;
using System.Collections.Generic;
using Terraria.DataStructures;
using System;

namespace AlarmTweaks.General
{
    public class AlarmNPC : GlobalNPC
    {
        /* commenting this because it doesn't seem to be working right
        public override void SetDefaults(NPC npc)
        {
            if (npc.type == NPCID.WyvernHead)
            {
                npc.damage = 120;
            } else if (npc.type == NPCID.WyvernBody ||
                       npc.type == NPCID.WyvernBody2 ||
                       npc.type == NPCID.WyvernBody3 ||
                       npc.type == NPCID.WyvernLegs ||
                       npc.type == NPCID.WyvernTail)
            {
                npc.damage = 60;
            }
        }*/

        // apparently this doesn't work bc EditSpawnPool only affects modded NPCs??
        /*public override void EditSpawnPool(IDictionary<int, float> pool, NPCSpawnInfo spawnInfo)
        {
            if (ModContent.GetInstance<AlarmConfig>().oldChest && !spawnInfo.Player.ZoneDungeon && !spawnInfo.Player.HasItemInInventoryOrOpenVoidBag(ItemID.GoldenKey))
            {
                pool.Remove(NPCID.BoundTownSlimeOld);
            }
        }*/

        public override void OnSpawn(NPC npc, IEntitySource source)
        {
            if (ModContent.GetInstance<AlarmConfig>().oldChest && npc.type == NPCID.BoundTownSlimeOld)
            {
                foreach (Player player in Main.ActivePlayers)
                {
                    if (Math.Abs(player.Center.X - npc.Center.X) > 90 * 16) continue; // if player is more than 90 tiles away, skip them

                    if (player.ZoneDungeon || player.HasItemInAnyInventory(ItemID.GoldenKey)) return; // otherwise if the player is in the dungeon or has a key, stop checking
                }
                npc.active = false; // no one in range with a key or in the dungeon
            }
        }

        public override void ModifyNPCLoot(NPC npc, NPCLoot npcLoot)
        {

            if (npc.type == NPCID.Guide && ModContent.GetInstance<AlarmConfig>().guide)
            {
                npcLoot.RemoveWhere(
                    rule => rule is ItemDropWithConditionRule drop
                        && drop.itemId == ItemID.GreenCap
                ); 

                npcLoot.Add(ItemDropRule.Common(ItemID.GreenCap));
            }
            else if (npc.type == NPCID.Steampunker && ModContent.GetInstance<AlarmConfig>().steampunker)
            {
                npcLoot.RemoveWhere(
                    rule => rule is ItemDropWithConditionRule drop
                        && drop.itemId == ItemID.IvyGuitar
                );

                npcLoot.Add(ItemDropRule.Common(ItemID.IvyGuitar));
            }
            else if (npc.type == NPCID.Painter && ModContent.GetInstance<AlarmConfig>().painter)
            {
                npcLoot.RemoveWhere(
                    rule => rule is ItemDropWithConditionRule drop
                        && drop.itemId == ItemID.JimsCap
                );

                npcLoot.Add(ItemDropRule.Common(ItemID.JimsCap));
            }
            else if (ModContent.GetInstance<AlarmConfig>().townNPCDrops)
            {
                if (npc.type == NPCID.DyeTrader)
                {
                    npcLoot.RemoveWhere(
                    rule => rule is CommonDrop drop
                        && drop.itemId == ItemID.DyeTradersScimitar
                    );

                    npcLoot.Add(ItemDropRule.Common(ItemID.DyeTradersScimitar));
                }
                if (npc.type == NPCID.Painter)
                {
                    npcLoot.RemoveWhere(
                    rule => rule is CommonDrop drop
                        && drop.itemId == ItemID.PainterPaintballGun
                    );

                    npcLoot.Add(ItemDropRule.Common(ItemID.PainterPaintballGun));
                }
                if (npc.type == NPCID.DD2Bartender)
                {
                    npcLoot.RemoveWhere(
                    rule => rule is CommonDrop drop
                        && drop.itemId == ItemID.AleThrowingGlove
                    );

                    npcLoot.Add(ItemDropRule.Common(ItemID.AleThrowingGlove));
                }
                if (npc.type == NPCID.Stylist)
                {
                    npcLoot.RemoveWhere(
                    rule => rule is CommonDrop drop
                        && drop.itemId == ItemID.StylistKilLaKillScissorsIWish
                    );

                    npcLoot.Add(ItemDropRule.Common(ItemID.StylistKilLaKillScissorsIWish));
                }
                if (npc.type == NPCID.Mechanic)
                {
                    npcLoot.RemoveWhere(
                    rule => rule is CommonDrop drop
                        && drop.itemId == ItemID.CombatWrench
                    );

                    npcLoot.Add(ItemDropRule.Common(ItemID.CombatWrench));
                }
                if (npc.type == NPCID.PartyGirl)
                {
                    npcLoot.RemoveWhere(
                    rule => rule is CommonDrop drop
                        && drop.itemId == ItemID.PartyGirlGrenade
                    );

                    npcLoot.Add(ItemDropRule.Common(ItemID.PartyGirlGrenade));
                }
                if (npc.type == NPCID.TaxCollector)
                {
                    npcLoot.RemoveWhere(
                    rule => rule is CommonDrop drop
                        && drop.itemId == ItemID.TaxCollectorsStickOfDoom
                    );

                    npcLoot.Add(ItemDropRule.Common(ItemID.TaxCollectorsStickOfDoom));
                }
                if (npc.type == NPCID.Princess)
                {
                    npcLoot.RemoveWhere(
                    rule => rule is CommonDrop drop
                        && drop.itemId == ItemID.PrincessWeapon
                    );

                    npcLoot.Add(ItemDropRule.ByCondition(Condition.Hardmode.ToDropCondition(ShowItemDropInUI.Always), ItemID.PrincessWeapon));
                }
            }
            else if (npc.type == NPCID.WyvernHead)
            {
                if (ModContent.GetInstance<AlarmConfig>().wyvernSouls)
                {
                    npcLoot.RemoveWhere(
                        rule => rule is DropBasedOnExpertMode drop //should catch Souls of Flight, hopefully it only gets that
                    );

                    npcLoot.Add(ItemDropRule.Common(ItemID.SoulofFlight, 1, 4, 5));
                }

                if (ModContent.GetInstance<AlarmConfig>().wyvernLightNight)
                {
                    //Soul of Light/Night drops
                    DaytimeDropCondition dayCond = new();
                    IItemDropRule wyvernDayRule = new LeadingConditionRule(dayCond);
                    wyvernDayRule.OnSuccess(ItemDropRule.Common(ItemID.SoulofLight, 1, 1, 4));
                    wyvernDayRule.OnSuccess(ItemDropRule.Common(ItemID.LightShard, 4));
                    npcLoot.Add(wyvernDayRule);

                    NighttimeDropCondition nightCond = new();
                    IItemDropRule wyvernNightRule = new LeadingConditionRule(nightCond);
                    wyvernNightRule.OnSuccess(ItemDropRule.Common(ItemID.SoulofNight, 1, 1, 4));
                    wyvernNightRule.OnSuccess(ItemDropRule.Common(ItemID.DarkShard, 4));
                    npcLoot.Add(wyvernNightRule);
                }
            } else if ((npc.type == NPCID.Crawdad ||
                       npc.type == NPCID.Crawdad2 ||
                       npc.type == NPCID.GiantShelly ||
                       npc.type == NPCID.GiantShelly2 ||
                       npc.type == NPCID.Salamander ||
                       npc.type == NPCID.Salamander2 ||
                       npc.type == NPCID.Salamander3 ||
                       npc.type == NPCID.Salamander4 ||
                       npc.type == NPCID.Salamander5 ||
                       npc.type == NPCID.Salamander6 ||
                       npc.type == NPCID.Salamander7 ||
                       npc.type == NPCID.Salamander8 ||
                       npc.type == NPCID.Salamander9)
                       && ModContent.GetInstance<AlarmConfig>().rally)
            {
                npcLoot.RemoveWhere(
                    rule => rule is CommonDrop drop
                        && drop.itemId == ItemID.Rally
                );

                npcLoot.Add(ItemDropRule.Common(ItemID.Rally, 15));
            }
            else if ((npc.type == NPCID.Skeleton ||
                      npc.type == NPCID.HeadacheSkeleton ||
                      npc.type == NPCID.MisassembledSkeleton ||
                      npc.type == NPCID.PantlessSkeleton ||
                      npc.type == NPCID.SkeletonTopHat ||
                      npc.type == NPCID.SkeletonAstonaut ||
                      npc.type == NPCID.SkeletonAlien ||
                      npc.type == NPCID.SporeSkeleton ||
                      npc.type == NPCID.BoneThrowingSkeleton ||
                      npc.type == NPCID.BoneThrowingSkeleton2 ||
                      npc.type == NPCID.BoneThrowingSkeleton3 ||
                      npc.type == NPCID.BoneThrowingSkeleton4)
                     && ModContent.GetInstance<AlarmConfig>().boneSword)
            {
                npcLoot.RemoveWhere(
                    rule => rule is CommonDrop drop
                        && drop.itemId == ItemID.BoneSword
                );

                npcLoot.Add(ItemDropRule.Common(ItemID.BoneSword, 50));
            }
            else if (npc.type == NPCID.FireImp && ModContent.GetInstance<AlarmConfig>().obsidianRoseDrop)
            {
                npcLoot.RemoveWhere(
                    rule => rule is CommonDrop drop
                        && drop.itemId == ItemID.ObsidianRose
                );

                npcLoot.Add(ItemDropRule.Common(ItemID.ObsidianRose, 12));
            }
        }

        public override void ModifyShop(NPCShop shop)
        {
            if (shop.NpcType == NPCID.PartyGirl && ModContent.GetInstance<AlarmConfig>().happyGrenade)
            {
                foreach (NPCShop.Entry entry in shop.Entries)
                {
                    if (entry.Item.type == ItemID.PartyGirlGrenade)
                    {
                        entry.Disable();
                        shop.Add(ItemID.PartyGirlGrenade);
                        break;
                    }
                }
            }
        }

        public override void ModifyActiveShop(NPC npc, string shopName, Item[] items)
        {
            if (items == null || items.Length == 0) return;
            if (npc.type == NPCID.TravellingMerchant && !ModContent.GetInstance<AlarmConfig>().travelingMerchantBlocks.Equals("None"))
            {
                for (int i = 0; i < items.Length; i++)
                {
                    if (items[i] == null) continue;
                    if (items[i].type == ItemID.DynastyWood
                     || items[i].type == ItemID.RedDynastyShingles
                     || items[i].type == ItemID.BlueDynastyShingles)
                    {
                        for (int j = i; j < items.Length - 1; j++)
                        {
                            items[j] = items[j + 1];
                        }
                        items[items.Length - 1] = null;
                        i--;
                    }
                }

                for (int i = items.Length - 1 - 3; i >= 0; i--)
                {
                    items[i + 3] = items[i];
                }
                items[0] = new Item(ItemID.DynastyWood);
                items[1] = new Item(ItemID.RedDynastyShingles);
                items[2] = new Item(ItemID.BlueDynastyShingles);

                if (ModContent.GetInstance<AlarmConfig>().travelingMerchantBlocks.Equals("All"))
                {
                    for (int i = 0; i < items.Length; i++)
                    {
                        if (items[i] == null) continue;
                        if (items[i].type == ItemID.TeamBlockRed
                         || items[i].type == ItemID.TeamBlockRedPlatform
                         || items[i].type == ItemID.TeamBlockGreen
                         || items[i].type == ItemID.TeamBlockGreenPlatform
                         || items[i].type == ItemID.TeamBlockBlue
                         || items[i].type == ItemID.TeamBlockBluePlatform
                         || items[i].type == ItemID.TeamBlockYellow
                         || items[i].type == ItemID.TeamBlockYellowPlatform
                         || items[i].type == ItemID.TeamBlockPink
                         || items[i].type == ItemID.TeamBlockPinkPlatform
                         || items[i].type == ItemID.TeamBlockWhite
                         || items[i].type == ItemID.TeamBlockWhitePlatform
                         || items[i].type == ItemID.AntiPortalBlock)
                        {
                            for (int j = i; j < items.Length - 1; j++)
                            {
                                items[j] = items[j + 1];
                            }
                            items[items.Length - 1] = null;
                            i--;
                        }
                    }

                    int offset = Main.hardMode ? 13 : 12;
                    for (int i = items.Length - 1 - offset; i >= 3; i--)
                    {
                        items[i + offset] = items[i];
                    }
                    items[3] = new Item(ItemID.TeamBlockRed);
                    items[4] = new Item(ItemID.TeamBlockRedPlatform);
                    items[5] = new Item(ItemID.TeamBlockGreen);
                    items[6] = new Item(ItemID.TeamBlockGreenPlatform);
                    items[7] = new Item(ItemID.TeamBlockBlue);
                    items[8] = new Item(ItemID.TeamBlockBluePlatform);
                    items[9] = new Item(ItemID.TeamBlockYellow);
                    items[10] = new Item(ItemID.TeamBlockYellowPlatform);
                    items[11] = new Item(ItemID.TeamBlockPink);
                    items[12] = new Item(ItemID.TeamBlockPinkPlatform);
                    items[13] = new Item(ItemID.TeamBlockWhite);
                    items[14] = new Item(ItemID.TeamBlockWhitePlatform);
                    if (Main.hardMode) items[15] = new Item(ItemID.AntiPortalBlock);
                }
            }
        }
    }
}