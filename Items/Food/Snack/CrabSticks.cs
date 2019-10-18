using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Survivaria.Items.Materials;
using Survivaria.Tiles.Stations;

namespace Survivaria.Items.Food.Snack
{
    public class CrabSticks : FoodItem
    {
        public CrabSticks() : base("Crab Sticks", "A pretty fishy food!", 24, 30, Item.buyPrice(0, 0, 30, 0), ItemRarityID.Blue, 12, -2, SoundID.Item2, BuffID.Fishing, 60 * 180)
        {
        }


        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddRecipeGroup("Survivaria:OceanFish");
            recipe.AddIngredient(ModContent.ItemType<CrabMeat>());
            recipe.AddTile(TileID.CookingPots);
			recipe.AddTile(ModContent.TileType<MAPTile>());
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}