using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Survivaria.Items.Materials;

namespace Survivaria.Items.Food.Snack
{
    public class MysteriousTablette : FoodItem
    {
        public MysteriousTablette() : base("Mysterious Tablette", "Some say you could predict the end of the world after eating one.", 24, 30, Item.buyPrice(0, 0, 60, 0), ItemRarityID.Green, 8, -2, SoundID.Item2, BuffID.Hunter, 60 * 180)
        {
        }

		public override bool UseItem(Player player)
        {
            player.AddBuff(BuffID.Sonar, 60 * 180);
            return true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<EnigmaticRoot>());
            recipe.AddIngredient(ModContent.ItemType<Cocolate>());
            recipe.AddTile(TileID.CookingPots);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}