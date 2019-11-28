using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Survivaria.Items.Food.BiomeSpecific.Underground;
using Survivaria.Items.Food.Snack;
using Survivaria.Items.Materials;

namespace Survivaria.Items.Food.Buffet
{
    public class SerpentineBurger : FoodItem
    {
        public SerpentineBurger() : base("Serpentine Burger", "The trend is to try to swallow it in one swoop, no one managed to do it.", 24, 30, Item.buyPrice(0, 4, 0, 0), ItemRarityID.LightRed, 68, -5, SoundID.Item2, BuffID.Bewitched, 60 * 420)
        {
        }

        public override void SetDefaults()
        {
            base.SetDefaults();
            item.UseSound = mod.GetLegacySoundSlot(SoundType.Custom, "Sounds/Eating/MeatEating");
        }

		public override bool UseItem(Player player)
        {
            player.AddBuff(BuffID.Summoning, 60 * 420);
            player.AddBuff(BuffID.Dangersense, 60 * 420);
            return base.UseItem(player);
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Pumpkin, 5);
            recipe.AddIngredient(ModContent.ItemType<SnakeMeat>());
            recipe.AddIngredient(ModContent.ItemType<Salt>());
            recipe.AddIngredient(ModContent.ItemType<FullBread>());
            recipe.AddTile(TileID.Furnaces);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}