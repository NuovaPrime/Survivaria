using Survivaria.Tiles.Stations;
using System.Threading.Tasks;
using Terraria;

using Terraria.ID;
using Terraria.ModLoader;

namespace Survivaria.Items.Misc
{
    public class WaterFilter : SurvivariaItem
    {
        public WaterFilter() : base("Water Filter", "A small machine used to filter out unwanted minerals from water.", 28, 26, Item.buyPrice(0, 1, 0, 0), ItemRarityID.Green)
        {
        }

        public override void SetDefaults()
        {
            item.consumable = true;
            item.createTile = ModContent.TileType<WaterFilterTile>();
            item.useStyle = ItemUseStyleID.SwingThrow;
            base.SetDefaults();
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Wood, 30);
            recipe.AddIngredient(ItemID.Chain, 3);
            recipe.AddIngredient(ItemID.SandBlock, 20);
            recipe.AddIngredient(ItemID.SiltBlock, 20);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
