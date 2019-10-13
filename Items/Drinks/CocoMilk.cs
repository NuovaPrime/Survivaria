using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Survivaria.Items.Food.BiomeSpecific.Ocean;
using Survivaria.Items.Food.BiomeSpecific.Snow;

namespace Survivaria.Items.Drinks
{
    public class CocoMilk : DrinkItem
    {
        public CocoMilk() : base("Coco Milk", "Nothing is better than this when waking up.", 20, 26, Item.buyPrice(0, 0, 10, 0), ItemRarityID.Blue, 4, 6, SoundID.Item1, BuffID.Regeneration, 60 * 180)
        {
        }

		public override bool UseItem(Player player)
        {
            player.AddBuff(BuffID.Sunflower, 60 * 180);
            return true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType<Cocolate>());
            recipe.AddIngredient(mod.ItemType<PearlBerry>());
            recipe.AddTile(TileID.Bottles);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}