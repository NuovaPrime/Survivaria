using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Survivaria.Items.Food.BiomeSpecific.Jungle;
using Survivaria.Items.Materials;

namespace Survivaria.Items.Drinks
{
    public class PuzzlingConcoction : DrinkItem
    {
        public PuzzlingConcoction() : base("Puzzling Concoction", "It was used to enter a deep state of concentration.", 20, 26, Item.buyPrice(0, 0, 40, 0), ItemRarityID.Green, 6, 6, SoundID.Item1, BuffID.Spelunker, 60 * 180)
        {
        }

		public override bool UseItem(Player player)
        {
            player.AddBuff(BuffID.Hunter, 60 * 180);
            return true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Corney>());
            recipe.AddIngredient(ModContent.ItemType<EnigmaticRoot>());
            recipe.AddIngredient(ItemID.Bottle);
            recipe.AddTile(TileID.Kegs);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}