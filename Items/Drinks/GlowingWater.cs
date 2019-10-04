﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Survivaria.Items.Drinks
{
    public class GlowingWater : DrinkItem
    {
        public GlowingWater() : base("Glowing Water", "A jar filled with a mysterious and rejuvenating glowing liquid.", 20, 26, Item.buyPrice(0, 0, 5, 0), ItemRarityID.Green, 0, 15)
        {
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.BottledWater);
            recipe.needWater = true;
            recipe.SetResult(this);
            if (recipe.RecipeAvailable())
            {
                recipe.AddRecipe();
            }
        }
    }
}