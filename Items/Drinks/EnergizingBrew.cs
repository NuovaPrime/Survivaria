﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Survivaria.Items.Food.BiomeSpecific.Hell;
using Survivaria.Items.Food.BiomeSpecific.Snow;

namespace Survivaria.Items.Drinks
{
    public class EnergizingBrew : DrinkItem
    {
        public EnergizingBrew() : base("Energizing Brew", "A strong balance for a stable harmony.", 20, 26, Item.buyPrice(0, 0, 50, 0), ItemRarityID.Orange, 4, 8, SoundID.Item1, BuffID.Warmth, 60 * 300)
        {
        }

		public override bool UseItem(Player player)
        {
            player.AddBuff(BuffID.Chilled, 60 * 300);
            return true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<FrostPlum>());
            recipe.AddIngredient(ModContent.ItemType<FieryTuber>());
            recipe.AddIngredient(ItemID.Bottle);
            recipe.AddTile(TileID.Kegs);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}