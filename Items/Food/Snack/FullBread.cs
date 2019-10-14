using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Survivaria.Items.Food.BiomeSpecific.Purity;

namespace Survivaria.Items.Food.Snack
{
    public class FullBread : FoodItem
    {
        public FullBread() : base("Full Bread", "A solid addition to any dish.", 24, 30, Item.buyPrice(0, 0, 1, 0), ItemRarityID.Blue, 12, -1, SoundID.Item2, BuffID.Ironskin, 60 * 30)
        {
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
			recipe.AddRecipeGroup(Add allseeds recipe group here, 3);
            recipe.AddIngredient(mod.ItemType<BlossomWheat>());
            recipe.AddTile(TileID.Furnaces);
			recipe.AddTile(mod.TileType<GrindStoneTile>());
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}