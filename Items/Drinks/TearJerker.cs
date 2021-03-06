﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Survivaria.Items.Food.BiomeSpecific.Purity;
using Survivaria.Items.Food.BiomeSpecific.Jungle;

namespace Survivaria.Items.Drinks
{
    public class TearJerker : DrinkItem
    {
        public TearJerker() : base("Tear Jerker", "Still strong enough to make you cry when drinking it.", 20, 26, Item.buyPrice(0, 3, 0, 0), ItemRarityID.LightRed, 0, 6, SoundID.Item1, BuffID.ObsidianSkin, 60 * 300)
        {
        }

        public override void SetDefaults()
        {
            base.SetDefaults();
            item.UseSound = mod.GetLegacySoundSlot(SoundType.Custom, "Sounds/Drinking/LightDrink");
        }

		public override bool UseItem(Player player)
        {
            player.AddBuff(BuffID.Panic, 60 * 240);
            return base.UseItem(player);
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Peppermint>());
            recipe.AddIngredient(ModContent.ItemType<DragonFruit>());
            recipe.AddIngredient(ItemID.Bottle);
            recipe.AddTile(TileID.Bottles);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
