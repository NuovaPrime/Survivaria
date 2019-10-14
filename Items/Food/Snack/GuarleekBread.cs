using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Survivaria.Items.Food.BiomeSpecific.Purity;
using Survivaria.Items.Food.BiomeSpecific.Jungle;

namespace Survivaria.Items.Food.Snack
{
    public class GuarleekBread : FoodItem
    {
        public GuarleekBread() : base("Guarleek Bread", "A staple food that not many would refuse, even with hesitation.", 24, 30, Item.buyPrice(0, 1, 0, 0), ItemRarityID.Lime, 16, -2, SoundID.Item2, BuffID.Stinky, 60 * 420)
        {
        }

		public override bool UseItem(Player player)
        {
            player.AddBuff(BuffID.Ironskin, 60 * 420);
            player.AddBuff(BuffID.Lifeforce, 60 * 420);
            return true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType<Guarleek>());
            recipe.AddIngredient(mod.ItemType<BlossomWheat>());
            recipe.AddTile(TileID.Furnaces);
			recipe.AddTile(mod.TileType<GrindStoneTile>());
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}