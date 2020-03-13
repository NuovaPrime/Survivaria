using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Survivaria.Items.Food.BiomeSpecific.Snow;
using Survivaria.Items.Food.BiomeSpecific.Hell;
using Survivaria.Items.Materials;
using Survivaria.Tiles.Stations;

namespace Survivaria
{
		public static class RecipeHelper
		{
				public static void AddVanillaRecipes(Mod mod)
				{
						ModRecipe recipe = new ModRecipe(mod);
			      recipe.AddRecipeGroup("Survivaria:Seeds", 3);
			      recipe.AddIngredient(ModContent.ItemType<Reece>());
						recipe.AddTile(TileID.CookingPots);
						recipe.AddTile(ModContent.TileType<GrindStoneTile>());
						recipe.SetResult(ItemID.Pho);
						recipe.AddRecipe();

						ModRecipe recipe2 = new ModRecipe(mod);
			      recipe2.AddIngredient(ModContent.ItemType<Reece>());
						recipe2.AddTile(TileID.Kegs);
						recipe2.SetResult(ItemID.Sake);
						recipe2.AddRecipe();

						ModRecipe recipe3 = new ModRecipe(mod);
			      recipe3.AddIngredient(ItemID.Shrimp);
			      recipe3.AddIngredient(ModContent.ItemType<Reece>());
						recipe3.AddTile(TileID.CookingPots);
						recipe3.SetResult(ItemID.PadThai);
						recipe3.AddRecipe();

						ModRecipe recipe4 = new ModRecipe(mod);
			      recipe4.AddIngredient(ModContent.ItemType<PearlBerry>());
			      recipe4.AddIngredient(ModContent.ItemType<BlossomWheat>());
						recipe4.AddTile(TileID.Furnaces);
						recipe4.AddTile(ModContent.TileType<GrindStoneTile>());
						recipe4.SetResult(ItemID.ChristmasPudding);
						recipe4.AddRecipe();

						ModRecipe recipe5 = new ModRecipe(mod);
			      recipe5.AddIngredient(ItemID.BottledHoney);
			      recipe5.AddIngredient(ModContent.ItemType<BlossomWheat>());
						recipe5.AddTile(TileID.Furnaces);
						recipe5.AddTile(ModContent.TileType<GrindStoneTile>());
						recipe5.SetResult(ItemID.SugarCookie);
						recipe5.AddRecipe();

						ModRecipe recipe6 = new ModRecipe(mod);
			      recipe6.AddIngredient(ItemID.BottledHoney);
			      recipe6.AddIngredient(ModContent.ItemType<PearlBerry>());
						recipe6.AddTile(TileID.CookingPots);
						recipe6.SetResult(ItemID.Eggnog);
						recipe6.AddRecipe();

						ModRecipe recipe7 = new ModRecipe(mod);
			      recipe7.AddIngredient(ModContent.ItemType<FieryTuber>());
			      recipe7.AddIngredient(ModContent.ItemType<BlossomWheat>());
						recipe7.AddTile(TileID.Furnaces);
						recipe7.AddTile(ModContent.TileType<GrindStoneTile>());
						recipe7.AddTile(ModContent.TileType<MAPTile>());
						recipe7.SetResult(ItemID.GingerbreadCookie);
						recipe7.AddRecipe();

						ModRecipe recipe8 = new ModRecipe(mod);
			      recipe8.AddIngredient(ItemID.Feather);
			      recipe8.AddIngredient(ItemID.BlackInk);
			      recipe8.AddIngredient(ModContent.ItemType<Reece>(), 5);
						recipe8.AddTile(TileID.WorkBenches);
						recipe8.SetResult(ItemID.Book, 3);
						recipe8.AddRecipe();

				}
		}
}
