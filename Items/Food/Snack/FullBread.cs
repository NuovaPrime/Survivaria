using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Survivaria.Items.Food.BiomeSpecific.Purity;
using Survivaria.Items.Materials;
using Survivaria.Tiles.Stations;

namespace Survivaria.Items.Food.Snack
{
    public class FullBread : FoodItem
    {
        public FullBread() : base("Full Bread", "A solid addition to any dish.", 24, 30, Item.buyPrice(0, 0, 1, 0), ItemRarityID.Blue, 12, -1, SoundID.Item2, BuffID.Ironskin, 60 * 30)
        {
        }

        public override void SetDefaults()
        {
            base.SetDefaults();
            item.UseSound = mod.GetLegacySoundSlot(SoundType.Custom, "Sounds/Eating/CrunchEating");
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddRecipeGroup("Survivaria:Seeds", 3);
            recipe.AddIngredient(ModContent.ItemType<BlossomWheat>());
            recipe.AddTile(TileID.Furnaces);
			recipe.AddTile(ModContent.TileType<GrindStoneTile>());
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}