using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Survivaria.Tiles.Stations;

namespace Survivaria.Items.Drinks
{
    public class FilteredWater : DrinkItem
    {
        public FilteredWater() : base("Filtered Water", "Cleaned of all impurities, it is now safe to drink.", 20, 26, Item.buyPrice(0, 0, 0, 20), ItemRarityID.Blue, 0, 16, SoundID.Item1, BuffID.ManaRegeneration, 60 * 30)
        {
        }

        public override void SetDefaults()
        {
            base.SetDefaults();
            item.UseSound = mod.GetLegacySoundSlot(SoundType.Custom, "Sounds/Drinking/LightDrink");
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.BottledWater);
            recipe.AddIngredient(ItemID.SandBlock);
			recipe.AddTile(ModContent.TileType<WaterFilterTile>());
            recipe.SetResult(this);
            recipe.AddRecipe();
			
			ModRecipe recipe2 = new ModRecipe(mod);
            recipe2.AddIngredient(ItemID.Bottle);
            recipe2.needWater = true;
            recipe2.SetResult(this);
            if (recipe2.RecipeAvailable())
            {
                recipe2.AddRecipe();
            }
        }
    }
}