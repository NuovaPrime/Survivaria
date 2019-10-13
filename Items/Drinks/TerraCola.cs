using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Survivaria.Items.Drinks
{
    public class TerraCola : DrinkItem
    {
        public TerraCola() : base("Terra-Cola", "No one knows the true recipe.", 20, 26, Item.buyPrice(0, 1, 0, 0), ItemRarityID.Pink, -4, 6, BuffID.ManaRegeneration, 60 * 420)
        {
        }

		public override bool UseItem(Player player)
        {
            player.AddBuff(BuffID.MagicPower, 60 * 420);
            player.AddBuff(BuffID.Lovestruck, 60 * 420);
            return true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemType<SparklingWater>());
            recipe.AddIngredient(ItemType<Frambosia>());
            recipe.AddIngredient(ItemType<Starfruit>());
            recipe.AddTile(TileID.Bottles);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}