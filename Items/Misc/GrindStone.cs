using Survivaria.Tiles.Stations;
using System.Threading.Tasks;
using Terraria;

using Terraria.ID;
using Terraria.ModLoader;

namespace Survivaria.Items.Misc
{
    public class GrindStone : SurvivariaItem
    {
        public GrindStone() : base("Grinding Stone", "A commonly used pair of stone tools used to grind down plants and small foods.", 28, 26, Item.buyPrice(0, 0, 0, 50), ItemRarityID.Green)
        {
        }

        public override void SetDefaults()
        {
            base.SetDefaults();
            item.consumable = true;
            item.createTile = ModContent.TileType<GrindStoneTile>();
            item.useStyle = ItemUseStyleID.SwingThrow;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.StoneBlock, 20);
            recipe.AddIngredient(ItemID.Wood, 7);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
