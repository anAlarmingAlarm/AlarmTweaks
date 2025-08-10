using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AlarmTweaks.Items
{
	public class JourneyTicket : ModItem
	{
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 0; //disable researching this to prevent cheese
        }

        public override void SetDefaults()
		{
			Item.width = 30;
			Item.height = 20;
            Item.value = 50000; //sells for 1 gold
			Item.rare = ItemRarityID.Blue;
            Item.maxStack = Item.CommonMaxStack;
        }

		public override void AddRecipes()
        {
            Recipe.Create(ItemID.Spear)
                .AddIngredient(this)
                .Register();

            Recipe.Create(ItemID.IronBow)
                .AddIngredient(this)
                .Register();

            Recipe.Create(ItemID.FlintlockPistol)
                .AddIngredient(this)
                .Register();

            Recipe.Create(ItemID.MusketBall, 200)
                .AddIngredient(this)
                .Register();

            Recipe.Create(ItemID.BoneArrow, 150)
                .AddIngredient(this)
                .Register();

            Recipe.Create(ItemID.AmethystStaff)
                .AddIngredient(this)
                .Register();

            Recipe.Create(ItemID.BabyBirdStaff)
                .AddIngredient(this)
                .Register();

            Recipe.Create(ItemID.LifeCrystal, 2)
                .AddIngredient(this)
                .Register();

            Recipe.Create(ItemID.GoldCoin)
                .AddIngredient(this)
                .Register();

            Recipe.Create(ItemID.HermesBoots)
                .AddIngredient(this)
                .Register();

            Recipe.Create(ItemID.Wood, 600)
                .AddIngredient(this)
                .Register();

            Recipe.Create(ItemID.StoneBlock, 400)
                .AddIngredient(this)
                .Register();

            Recipe.Create(ItemID.CanOfWorms, 15)
                .AddIngredient(this)
                .Register();

            Recipe.Create(ItemID.WoodenCrate, 5)
                .AddIngredient(this)
                .Register();

            Recipe.Create(ItemID.GoodieBag, 5)
                .AddIngredient(this)
                .Register();

            Recipe.Create(ItemID.Present, 5)
                .AddIngredient(this)
                .Register();
        }
	}
}