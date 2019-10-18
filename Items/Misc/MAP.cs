using Survivaria.Tiles.Stations;
using System.Threading.Tasks;
using Terraria;

using Terraria.ID;
using Terraria.ModLoader;

namespace Survivaria.Items.Misc
{
    public class MAP : SurvivariaItem
    {
        public MAP() : base("Mortar and Pestle", "A commonly used pair of wooden tools used to grind down plants and small foods.", 28, 26, Item.buyPrice(0, 1, 0, 0), ItemRarityID.Green)
        {
        }

        public override void SetDefaults()
        {
            item.consumable = true;
            item.createTile = ModContent.TileType<MAPTile>();
            base.SetDefaults();
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Wood, 50);
            recipe.AddIngredient(ItemID.Chain, 1);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
