﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Survivaria.Items.Materials;

namespace Survivaria.Items.Drinks
{
    public class CactusJuiceMagenta : DrinkItem
    {
        public CactusJuiceMagenta() : base("Cactus Juice", "Some concentrated and refreshing cactus juice.", 20, 26, Item.buyPrice(0, 0, 2, 5), ItemRarityID.Blue, 4, 16, SoundID.Item1, BuffID.Thorns, 60 * 45)
        {
        }

        public override void SetDefaults()
        {
            base.SetDefaults();
            item.UseSound = mod.GetLegacySoundSlot(SoundType.Custom, "Sounds/Drinking/LightDrink");
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<PricklyPearMagenta>());
            recipe.AddIngredient(ItemID.Cactus);
            recipe.AddIngredient(ItemID.Bottle);
            recipe.AddTile(TileID.Bottles);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}