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
    public class CactusJuice : DrinkItem
    {
        public CactusJuice() : base("Cactus Juice", "A jar of concentrated and refreshing cactus juice.", 20, 26, Item.buyPrice(0, 0, 2, 5), ItemRarityID.Blue, 0, 12)
        {
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Cactus, 2);
            recipe.AddIngredient(ItemID.Bottle);
            recipe.AddTile(TileID.Bottles);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}