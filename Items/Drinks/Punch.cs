using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Survivaria.Items.Food.BiomeSpecific.Snow;
using Survivaria.Items.Food.BiomeSpecific.Underground;

namespace Survivaria.Items.Drinks
{
    public class Punch : DrinkItem
    {
        public Punch() : base("Punch", "A lot of it was packed in.", 20, 26, Item.buyPrice(0, 0, 70, 0), ItemRarityID.Orange, 3, 6, SoundID.Item1, BuffID.Thorns, 60 * 300)
        {
        }

		public override bool UseItem(Player player)
        {
            player.AddBuff(BuffID.Chilled, 60 * 180);
            player.AddBuff(BuffID.Tipsy, 60 * 240);
            return true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddRecipeGroup("Survivaria:Pears");
            recipe.AddIngredient(ModContent.ItemType<Frambosia>());
            recipe.AddIngredient(ModContent.ItemType<FrostPlum>());
            recipe.AddIngredient(ItemID.Bowl);
            recipe.AddTile(TileID.Kegs);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}