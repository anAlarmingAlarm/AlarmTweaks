using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using System;
using AlarmTweaks.Items.Vanilla;

namespace AlarmTweaks.General
{
    public class AlarmSystem : ModSystem
    {
        internal static AlarmSystem instance;

        int stoneBlock;
        int copperBar;
        int silverBar;
        int goldBar;
        int torch;

        public override void Load()
        {
            instance = this;
        }

        public override void AddRecipeGroups()
        {
            stoneBlock = RecipeGroup.RegisterGroup(nameof(ItemID.StoneBlock), new RecipeGroup(() => $"{Language.GetTextValue("LegacyMisc.37")} {Lang.GetItemNameValue(ItemID.StoneBlock)}", ItemID.StoneBlock, ItemID.EbonstoneBlock, ItemID.CrimstoneBlock, ItemID.PearlstoneBlock));
            copperBar = RecipeGroup.RegisterGroup(nameof(ItemID.CopperBar), new RecipeGroup(() => $"{Language.GetTextValue("LegacyMisc.37")} {Lang.GetItemNameValue(ItemID.CopperBar)}", ItemID.CopperBar, ItemID.TinBar));
            silverBar = RecipeGroup.RegisterGroup(nameof(ItemID.SilverBar), new RecipeGroup(() => $"{Language.GetTextValue("LegacyMisc.37")} {Lang.GetItemNameValue(ItemID.SilverBar)}", ItemID.SilverBar, ItemID.TungstenBar));
            goldBar = RecipeGroup.RegisterGroup(nameof(ItemID.GoldBar), new RecipeGroup(() => $"{Language.GetTextValue("LegacyMisc.37")} {Lang.GetItemNameValue(ItemID.GoldBar)}", ItemID.GoldBar, ItemID.PlatinumBar));
            torch = RecipeGroup.RegisterGroup(nameof(ItemID.Torch), new RecipeGroup(() => $"{Language.GetTextValue("LegacyMisc.37")} {Lang.GetItemNameValue(ItemID.Torch)}", ItemID.Torch, ItemID.PurpleTorch, ItemID.YellowTorch, ItemID.BlueTorch, ItemID.GreenTorch, ItemID.RedTorch, ItemID.OrangeTorch, ItemID.WhiteTorch, ItemID.IceTorch, ItemID.PinkTorch, ItemID.BoneTorch, ItemID.UltrabrightTorch, ItemID.DemonTorch, ItemID.CursedTorch, ItemID.IchorTorch, ItemID.RainbowTorch, ItemID.DesertTorch, ItemID.CoralTorch, ItemID.CorruptTorch, ItemID.CrimsonTorch, ItemID.HallowedTorch, ItemID.JungleTorch, ItemID.MushroomTorch, ItemID.ShimmerTorch));
        }

        public override void AddRecipes()
        {
            if (ModContent.GetInstance<AlarmConfig>().terragrim)
            {
                Recipe terragrimRecipe = Recipe.Create(ItemID.Terragrim)
                    .AddIngredient(ItemID.EnchantedSword)
                    .AddIngredient(ItemID.Ruby, 5)
                    .AddIngredient(ItemID.Amber, 5)
                    .AddIngredient(ItemID.Topaz, 5)
                    .AddIngredient(ItemID.Emerald, 5)
                    .AddIngredient(ItemID.Sapphire, 5)
                    .AddIngredient(ItemID.Amethyst, 5)
                    .AddIngredient(ItemID.Diamond, 5)
                    .AddIngredient(ItemID.DirtBlock, 25)
                    .AddIngredient(ItemID.MudBlock, 25)
                    .AddRecipeGroup(RecipeGroupID.Sand, 25)
                    .AddIngredient(ItemID.SnowBlock, 25)
                    .AddRecipeGroup(RecipeGroupID.Wood, 50)
                    .AddRecipeGroup(stoneBlock, 50)
                    .AddTile(TileID.Anvils)
                    .Register();
            }

            if (ModContent.GetInstance<AlarmConfig>().bottledWater)
            {
                Recipe bottleRecipe = Recipe.Create(ItemID.BottledWater)
                    .AddIngredient(ItemID.Bottle)
                    .AddCondition(new Condition("Mods.AlarmTweaks.Conditions.Raining", () => Main.raining))
                    .Register();
            }

            if (ModContent.GetInstance<AlarmConfig>().shadowChest)
            {
                Recipe shadowChestRecipe = Recipe.Create(ItemID.ShadowChest)
                    .AddIngredient(ItemID.Obsidian, 8)
                    .AddRecipeGroup(RecipeGroupID.IronBar, 2)
                    .AddTile(TileID.WorkBenches)
                    .AddCondition(new Condition("While in Hardmode", () => Main.hardMode))
                    .Register();
            }

            if (ModContent.GetInstance<AlarmConfig>().tombstones)
            {
                Recipe tombRecipe1 = Recipe.Create(ItemID.Tombstone)
                    .AddRecipeGroup(stoneBlock, 25)
                    .AddTile(TileID.HeavyWorkBench)
                    .Register();

                Recipe tombRecipe2 = Recipe.Create(ItemID.GraveMarker)
                    .AddRecipeGroup(stoneBlock, 25)
                    .AddTile(TileID.HeavyWorkBench)
                    .Register();

                Recipe tombRecipe3 = Recipe.Create(ItemID.CrossGraveMarker)
                    .AddRecipeGroup(stoneBlock, 25)
                    .AddTile(TileID.HeavyWorkBench)
                    .Register();

                Recipe tombRecipe4 = Recipe.Create(ItemID.Headstone)
                    .AddRecipeGroup(stoneBlock, 25)
                    .AddTile(TileID.HeavyWorkBench)
                    .Register();

                Recipe tombRecipe5 = Recipe.Create(ItemID.Gravestone)
                    .AddRecipeGroup(stoneBlock, 25)
                    .AddTile(TileID.HeavyWorkBench)
                    .Register();

                Recipe tombRecipe6 = Recipe.Create(ItemID.Obelisk)
                    .AddRecipeGroup(stoneBlock, 25)
                    .AddTile(TileID.HeavyWorkBench)
                    .Register();

                Recipe tombRecipe7 = Recipe.Create(ItemID.RichGravestone1)
                    .AddRecipeGroup(stoneBlock, 25)
                    .AddIngredient(ItemID.GoldCoin)
                    .AddTile(TileID.HeavyWorkBench)
                    .Register();

                Recipe tombRecipe8 = Recipe.Create(ItemID.RichGravestone2)
                    .AddRecipeGroup(stoneBlock, 25)
                    .AddIngredient(ItemID.GoldCoin)
                    .AddTile(TileID.HeavyWorkBench)
                    .Register();

                Recipe tombRecipe9 = Recipe.Create(ItemID.RichGravestone3)
                    .AddRecipeGroup(stoneBlock, 25)
                    .AddIngredient(ItemID.GoldCoin)
                    .AddTile(TileID.HeavyWorkBench)
                    .Register();

                Recipe tombRecipe10 = Recipe.Create(ItemID.RichGravestone4)
                    .AddRecipeGroup(stoneBlock, 25)
                    .AddIngredient(ItemID.GoldCoin)
                    .AddTile(TileID.HeavyWorkBench)
                    .Register();

                Recipe tombRecipe11 = Recipe.Create(ItemID.RichGravestone5)
                    .AddRecipeGroup(stoneBlock, 25)
                    .AddIngredient(ItemID.GoldCoin)
                    .AddTile(TileID.HeavyWorkBench)
                    .Register();
            }

            //Crate recipes, putting this in curly brackets so it can be collapsed because it's f***off long
            //(now commented since 1.4.4 made it so you can shimmer pre-hm crates to hardmode versions)
            {/*
                Recipe wCrate = Recipe.Create(ItemID.WoodenCrate)
                                .AddIngredient(ItemID.WoodenCrateHard)
                                .AddTile(TileID.DemonAltar)
                                .Register();
                Recipe wCrateHM = Recipe.Create(ItemID.WoodenCrateHard)
                                .AddIngredient(ItemID.WoodenCrate)
                                .AddTile(TileID.DemonAltar)
                                .AddCondition(new Condition("While in Hardmode", () => Main.hardMode))
                                .Register();

                Recipe iCrate = Recipe.Create(ItemID.IronCrate)
                                .AddIngredient(ItemID.IronCrateHard)
                                .AddTile(TileID.DemonAltar)
                                .Register();
                Recipe iCrateHM = Recipe.Create(ItemID.IronCrateHard)
                                .AddIngredient(ItemID.IronCrate)
                                .AddTile(TileID.DemonAltar)
                                .AddCondition(new Condition("While in Hardmode", () => Main.hardMode))
                                .Register();

                Recipe gCrate = Recipe.Create(ItemID.GoldenCrate)
                                .AddIngredient(ItemID.GoldenCrateHard)
                                .AddTile(TileID.DemonAltar)
                                .Register();
                Recipe gCrateHM = Recipe.Create(ItemID.GoldenCrateHard)
                                .AddIngredient(ItemID.GoldenCrate)
                                .AddTile(TileID.DemonAltar)
                                .AddCondition(new Condition("While in Hardmode", () => Main.hardMode))
                                .Register();

                Recipe jCrate = Recipe.Create(ItemID.JungleFishingCrate)
                                .AddIngredient(ItemID.JungleFishingCrateHard)
                                .AddTile(TileID.DemonAltar)
                                .Register();
                Recipe jCrateHM = Recipe.Create(ItemID.JungleFishingCrateHard)
                                .AddIngredient(ItemID.JungleFishingCrate)
                                .AddTile(TileID.DemonAltar)
                                .AddCondition(new Condition("While in Hardmode", () => Main.hardMode))
                                .Register();

                Recipe sCrate = Recipe.Create(ItemID.FloatingIslandFishingCrate)
                                .AddIngredient(ItemID.FloatingIslandFishingCrateHard)
                                .AddTile(TileID.DemonAltar)
                                .Register();
                Recipe sCrateHM = Recipe.Create(ItemID.FloatingIslandFishingCrateHard)
                                .AddIngredient(ItemID.FloatingIslandFishingCrate)
                                .AddTile(TileID.DemonAltar)
                                .AddCondition(new Condition("While in Hardmode", () => Main.hardMode))
                                .Register();

                Recipe coCrate = Recipe.Create(ItemID.CorruptFishingCrate)
                                .AddIngredient(ItemID.CorruptFishingCrateHard)
                                .AddTile(TileID.DemonAltar)
                                .Register();
                Recipe coCrateHM = Recipe.Create(ItemID.CorruptFishingCrateHard)
                                .AddIngredient(ItemID.CorruptFishingCrate)
                                .AddTile(TileID.DemonAltar)
                                .AddCondition(new Condition("While in Hardmode", () => Main.hardMode))
                                .Register();

                Recipe crCrate = Recipe.Create(ItemID.CrimsonFishingCrate)
                                .AddIngredient(ItemID.CrimsonFishingCrateHard)
                                .AddTile(TileID.DemonAltar)
                                .Register();
                Recipe crCrateHM = Recipe.Create(ItemID.CrimsonFishingCrateHard)
                                .AddIngredient(ItemID.CrimsonFishingCrate)
                                .AddTile(TileID.DemonAltar)
                                .AddCondition(new Condition("While in Hardmode", () => Main.hardMode))
                                .Register();

                Recipe hCrate = Recipe.Create(ItemID.HallowedFishingCrate)
                                .AddIngredient(ItemID.HallowedFishingCrateHard)
                                .AddTile(TileID.DemonAltar)
                                .Register();
                Recipe hCrateHM = Recipe.Create(ItemID.HallowedFishingCrateHard)
                                .AddIngredient(ItemID.HallowedFishingCrate)
                                .AddTile(TileID.DemonAltar)
                                .AddCondition(new Condition("While in Hardmode", () => Main.hardMode))
                                .Register();

                Recipe dCrate = Recipe.Create(ItemID.DungeonFishingCrate)
                                .AddIngredient(ItemID.DungeonFishingCrateHard)
                                .AddTile(TileID.DemonAltar)
                                .Register();
                Recipe dCrateHM = Recipe.Create(ItemID.DungeonFishingCrateHard)
                                .AddIngredient(ItemID.DungeonFishingCrate)
                                .AddTile(TileID.DemonAltar)
                                .AddCondition(new Condition("While in Hardmode", () => Main.hardMode))
                                .Register();

                Recipe fCrate = Recipe.Create(ItemID.FrozenCrate)
                                .AddIngredient(ItemID.FrozenCrateHard)
                                .AddTile(TileID.DemonAltar)
                                .Register();
                Recipe fCrateHM = Recipe.Create(ItemID.FrozenCrateHard)
                                .AddIngredient(ItemID.FrozenCrate)
                                .AddTile(TileID.DemonAltar)
                                .AddCondition(new Condition("While in Hardmode", () => Main.hardMode))
                                .Register();

                Recipe oaCrate = Recipe.Create(ItemID.OasisCrate)
                                .AddIngredient(ItemID.OasisCrateHard)
                                .AddTile(TileID.DemonAltar)
                                .Register();
                Recipe oaCrateHM = Recipe.Create(ItemID.OasisCrateHard)
                                .AddIngredient(ItemID.OasisCrate)
                                .AddTile(TileID.DemonAltar)
                                .AddCondition(new Condition("While in Hardmode", () => Main.hardMode))
                                .Register();

                Recipe obCrate = Recipe.Create(ItemID.LavaCrate)
                                .AddIngredient(ItemID.LavaCrateHard)
                                .AddTile(TileID.DemonAltar)
                                .Register();
                Recipe obCrateHM = Recipe.Create(ItemID.LavaCrateHard)
                                .AddIngredient(ItemID.LavaCrate)
                                .AddTile(TileID.DemonAltar)
                                .AddCondition(new Condition("While in Hardmode", () => Main.hardMode))
                                .Register();

                Recipe ocCrate = Recipe.Create(ItemID.OceanCrate)
                                .AddIngredient(ItemID.OceanCrateHard)
                                .AddTile(TileID.DemonAltar)
                                .Register();
                Recipe ocCrateHM = Recipe.Create(ItemID.OceanCrateHard)
                                .AddIngredient(ItemID.OceanCrate)
                                .AddTile(TileID.DemonAltar)
                                .AddCondition(new Condition("While in Hardmode", () => Main.hardMode))
                                .Register();*/
            }

            if (ModContent.GetInstance<AlarmConfig>().coalRecipe)
            {
                Recipe coalTorchRecipe = Recipe.Create(ItemID.Torch, 9)
                    .AddIngredient(ItemID.Coal)
                    .AddRecipeGroup(RecipeGroupID.Wood, 3)
                    .Register();
            }

            if (ModContent.GetInstance<AlarmConfig>().dirtRecipe)
            {
                Recipe dirtRecipe = Recipe.Create(ItemID.DirtiestBlock)
                    .AddIngredient(ItemID.DirtBlock, 499950)
                    .Register();
            }

            if (ModContent.GetInstance<AlarmConfig>().teamBlocksRecipe)
            {
                Recipe teamRedBlock = Recipe.Create(ItemID.TeamBlockRed)
                    .AddIngredient(ItemID.TeamBlockRedPlatform, 2)
                    .Register();
                Recipe teamGreenBlock = Recipe.Create(ItemID.TeamBlockGreen)
                    .AddIngredient(ItemID.TeamBlockGreenPlatform, 2)
                    .Register();
                Recipe teamBlueBlock = Recipe.Create(ItemID.TeamBlockBlue)
                    .AddIngredient(ItemID.TeamBlockBluePlatform, 2)
                    .Register();
                Recipe teamYellowBlock = Recipe.Create(ItemID.TeamBlockYellow)
                    .AddIngredient(ItemID.TeamBlockYellowPlatform, 2)
                    .Register();
                Recipe teamPinkBlock = Recipe.Create(ItemID.TeamBlockPink)
                    .AddIngredient(ItemID.TeamBlockPinkPlatform, 2)
                    .Register();
                Recipe teamWhiteBlock = Recipe.Create(ItemID.TeamBlockWhite)
                    .AddIngredient(ItemID.TeamBlockWhitePlatform, 2)
                    .Register();

                Recipe teamRedPlatform = Recipe.Create(ItemID.TeamBlockRedPlatform, 2)
                    .AddIngredient(ItemID.TeamBlockRed)
                    .Register();
                Recipe teamGreenPlatform = Recipe.Create(ItemID.TeamBlockGreenPlatform, 2)
                    .AddIngredient(ItemID.TeamBlockGreen)
                    .Register();
                Recipe teamBluePlatform = Recipe.Create(ItemID.TeamBlockBluePlatform, 2)
                    .AddIngredient(ItemID.TeamBlockBlue)
                    .Register();
                Recipe teamYellowPlatform = Recipe.Create(ItemID.TeamBlockYellowPlatform, 2)
                    .AddIngredient(ItemID.TeamBlockYellow)
                    .Register();
                Recipe teamPinkPlatform = Recipe.Create(ItemID.TeamBlockPinkPlatform, 2)
                    .AddIngredient(ItemID.TeamBlockPink)
                    .Register();
                Recipe teamWhitePlatform = Recipe.Create(ItemID.TeamBlockWhitePlatform, 2)
                    .AddIngredient(ItemID.TeamBlockWhite)
                    .Register();
            }
        }

        public override void PostAddRecipes()
        {
            for (int i = 0; i < Recipe.numRecipes; i++)
            {
                Recipe recipe = Main.recipe[i];

                if (ModContent.GetInstance<AlarmConfig>().terrasparkDunerider)
                {
                    //Add the Dunerider Boots to the Terraspark recipe
                    if (recipe.HasIngredient(ItemID.FrostsparkBoots) && recipe.HasIngredient(ItemID.LavaWaders) && recipe.HasTile(TileID.TinkerersWorkbench) && recipe.HasResult(ItemID.TerrasparkBoots))
                    {
                        recipe.AddIngredient(ItemID.SandBoots);
                    }
                    //Disable the Spectre Boots recipe that uses the Dunerider Boots since we're combining them into the Terraspark boots
                    else if (recipe.HasIngredient(ItemID.SandBoots) && recipe.HasIngredient(ItemID.RocketBoots) && recipe.HasTile(TileID.TinkerersWorkbench) && recipe.HasResult(ItemID.SpectreBoots))
                    {
                        recipe.DisableRecipe();
                    }
                }
                if (ModContent.GetInstance<AlarmConfig>().gemStaffRecipe)
                {
                    //Replace unique bars in staff recipes with recipe groups created earlier
                    if (recipe.HasIngredient(ItemID.CopperBar) && recipe.HasIngredient(ItemID.Amethyst) && recipe.HasTile(TileID.Anvils) && recipe.HasResult(ItemID.AmethystStaff))
                    {
                        recipe.RemoveIngredient(ItemID.CopperBar);
                        recipe.RemoveIngredient(ItemID.Amethyst);
                        recipe.AddRecipeGroup(copperBar, 10);
                        recipe.AddIngredient(ItemID.Amethyst, 8);
                    }
                    else if (recipe.HasIngredient(ItemID.TinBar) && recipe.HasIngredient(ItemID.Topaz) && recipe.HasTile(TileID.Anvils) && recipe.HasResult(ItemID.TopazStaff))
                    {
                        recipe.RemoveIngredient(ItemID.TinBar);
                        recipe.RemoveIngredient(ItemID.Topaz);
                        recipe.AddRecipeGroup(copperBar, 10);
                        recipe.AddIngredient(ItemID.Topaz, 8);
                    }
                    else if (recipe.HasIngredient(ItemID.SilverBar) && recipe.HasIngredient(ItemID.Sapphire) && recipe.HasTile(TileID.Anvils) && recipe.HasResult(ItemID.SapphireStaff))
                    {
                        recipe.RemoveIngredient(ItemID.SilverBar);
                        recipe.RemoveIngredient(ItemID.Sapphire);
                        recipe.AddRecipeGroup(silverBar, 10);
                        recipe.AddIngredient(ItemID.Sapphire, 8);
                    }
                    else if (recipe.HasIngredient(ItemID.TungstenBar) && recipe.HasIngredient(ItemID.Emerald) && recipe.HasTile(TileID.Anvils) && recipe.HasResult(ItemID.EmeraldStaff))
                    {
                        recipe.RemoveIngredient(ItemID.TungstenBar);
                        recipe.RemoveIngredient(ItemID.Emerald);
                        recipe.AddRecipeGroup(silverBar, 10);
                        recipe.AddIngredient(ItemID.Emerald, 8);
                    }
                    else if (recipe.HasIngredient(ItemID.GoldBar) && recipe.HasIngredient(ItemID.Ruby) && recipe.HasTile(TileID.Anvils) && recipe.HasResult(ItemID.RubyStaff))
                    {
                        recipe.RemoveIngredient(ItemID.GoldBar);
                        recipe.RemoveIngredient(ItemID.Ruby);
                        recipe.AddRecipeGroup(goldBar, 10);
                        recipe.AddIngredient(ItemID.Ruby, 8);
                    }
                    else if (recipe.HasIngredient(ItemID.PlatinumBar) && recipe.HasIngredient(ItemID.Diamond) && recipe.HasTile(TileID.Anvils) && recipe.HasResult(ItemID.DiamondStaff))
                    {
                        recipe.RemoveIngredient(ItemID.PlatinumBar);
                        recipe.RemoveIngredient(ItemID.Diamond);
                        recipe.AddRecipeGroup(goldBar, 10);
                        recipe.AddIngredient(ItemID.Diamond, 8);
                    }
                }

                if (ModContent.GetInstance<AlarmConfig>().torchRecipe)
                {
                    //Replace normal torches in recipes with torch recipe group created earlier
                    if (recipe.TryGetIngredient(ItemID.Torch, out Item ing)
                     && !recipe.HasResult(ItemID.Torch)
                     && !recipe.HasResult(ItemID.PurpleTorch)
                     && !recipe.HasResult(ItemID.YellowTorch)
                     && !recipe.HasResult(ItemID.BlueTorch)
                     && !recipe.HasResult(ItemID.GreenTorch)
                     && !recipe.HasResult(ItemID.RedTorch)
                     && !recipe.HasResult(ItemID.OrangeTorch)
                     && !recipe.HasResult(ItemID.WhiteTorch)
                     && !recipe.HasResult(ItemID.IceTorch)
                     && !recipe.HasResult(ItemID.PinkTorch)
                     && !recipe.HasResult(ItemID.BoneTorch)
                     && !recipe.HasResult(ItemID.UltrabrightTorch)
                     && !recipe.HasResult(ItemID.DemonTorch)
                     && !recipe.HasResult(ItemID.CursedTorch)
                     && !recipe.HasResult(ItemID.IchorTorch)
                     && !recipe.HasResult(ItemID.RainbowTorch)
                     && !recipe.HasResult(ItemID.DesertTorch)
                     && !recipe.HasResult(ItemID.CoralTorch)
                     && !recipe.HasResult(ItemID.CorruptTorch)
                     && !recipe.HasResult(ItemID.CrimsonTorch)
                     && !recipe.HasResult(ItemID.HallowedTorch)
                     && !recipe.HasResult(ItemID.JungleTorch)
                     && !recipe.HasResult(ItemID.MushroomTorch)
                     && !recipe.HasResult(ItemID.ShimmerTorch))
                    {
                        recipe.RemoveIngredient(ItemID.Torch);
                        recipe.AddRecipeGroup(torch, ing.stack);
                    }
                }

                if (ModContent.GetInstance<AlarmConfig>().shroomiteRecipe)
                {
                    //Replace normal torches in recipes with torch recipe group created earlier
                    if (recipe.HasIngredient(ItemID.ChlorophyteBar) && recipe.HasIngredient(ItemID.GlowingMushroom) && recipe.HasTile(TileID.Autohammer) && recipe.HasResult(ItemID.ShroomiteBar))
                    {
                        recipe.RemoveIngredient(ItemID.GlowingMushroom);
                        recipe.AddIngredient(ItemID.GlowingMushroom, 8);
                    }
                }
            }
        }

        public object Call(params object[] args)
        {
            try
            {
                // Where should other mods call? They could call at end of Load?
                string message = args[0] as string;
                if (message == "bewitched")
                {
                    Player target = args[1] as Player;
                    if (target != null && target.active)
                    {
                        target.GetModPlayer<SummonerEmblemPlayer>().bewitched = true;
                    }
                    return "Success";
                }
                else
                {
                    Mod.Logger.Error("AlarmTweaks Call Error: Unknown Message: " + message);
                }
            }
            catch (Exception e)
            {
                Mod.Logger.Error("AlarmTweaks Call Error: " + e.StackTrace + e.Message);
            }
            return "Failure";
        }
    }
}