using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Survivaria.Items.Food.Meal
{
    public class Terrine : FoodItem
    {
        public Terrine() : base("Terrine", "The gel allows for a good conservation, but it's rarely lasting long enough to matter.", 24, 30, Item.buyPrice(0, 0, 20, 0), ItemRarityID.Blue, 20, 0, SoundID.Item2, BuffID.AmmoReservation, 60 * 60)
        {
        }

        public override void SetDefaults()
        {
            base.SetDefaults();
            item.UseSound = mod.GetLegacySoundSlot(SoundType.Custom, "Sounds/Eating/MeatEating");
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddRecipeGroup("Survivaria:Ducks");
            recipe.AddIngredient(ItemID.Gel, 3);
            recipe.AddTile(TileID.CookingPots);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
