using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Survivaria.Items.Food.BiomeSpecific.Space;
using Survivaria.Items.Food.BiomeSpecific.Underground;

namespace Survivaria.Items.Drinks
{
    public class BlueHarpy : DrinkItem
    {
        public BlueHarpy() : base("Blue Harpy", "Love gives you wings.", 20, 26, Item.buyPrice(0, 0, 60, 0), ItemRarityID.Orange, 2, 8, SoundID.Item1, BuffID.Featherfall, 60 * 180)
        {
        }

		public override bool UseItem(Player player)
        {
            player.AddBuff(BuffID.Gravitation, 60 * 180);
            return true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Cloudstalk>());
            recipe.AddIngredient(ModContent.ItemType<Frambosia>());
            recipe.AddIngredient(ItemID.Bottle);
            recipe.AddTile(TileID.Bottles);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}