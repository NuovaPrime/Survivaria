using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Survivaria.Items.Food.BiomeSpecific.Corruption;
using Survivaria.Items.Materials;

namespace Survivaria.Items.Food.Feast
{
    public class DiscPizza : FoodItem
    {
        public DiscPizza() : base("Disc Pizza", "It contains a world on its own.", 24, 30, Item.buyPrice(0, 20, 0, 0), ItemRarityID.Pink, 76, -4, SoundID.Item2, BuffID.Calm, 60 * 420)
        {
        }

        public override void SetDefaults()
        {
            base.SetDefaults();
            item.UseSound = mod.GetLegacySoundSlot(SoundType.Custom, "Sounds/Drinking/MeatEating");
        }

		public override bool UseItem(Player player)
        {
            player.AddBuff(BuffID.Shine, 60 * 420);
            player.AddBuff(BuffID.Builder, 60 * 420);
            player.AddBuff(BuffID.Titan, 60 * 420);
            return base.UseItem(player);
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<TurtleMeat>());
            recipe.AddIngredient(ModContent.ItemType<BlossomWheat>(), 2);
            recipe.AddIngredient(ModContent.ItemType<PutridOlives>());
            recipe.AddIngredient(ItemID.GlowingMushroom);
            recipe.AddTile(TileID.Furnaces);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}