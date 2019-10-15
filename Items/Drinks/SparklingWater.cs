using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Survivaria.Items.Food.BiomeSpecific.Hallow;

namespace Survivaria.Items.Drinks
{
    public class SparklingWater : DrinkItem
    {
        public SparklingWater() : base("Sparkling Water", "The bubbles make for a pretty fancy drink.", 20, 26, Item.buyPrice(0, 0, 2, 5), ItemRarityID.LightRed, 4, 16, SoundID.Item1, BuffID.MagicPower, 60 * 180)
        {
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<SparklingBerry>());
            recipe.AddIngredient(ItemID.Bottle);
            recipe.AddTile(TileID.Bottles);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}