using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Survivaria.Items.Food.Snack
{
    public class Jellife : FoodItem
    {
        public Jellife() : base("Jellife", "Quintessential, not many can live without it once they tasted it.", 24, 30, Item.buyPrice(0, 5, 0, 0), ItemRarityID.Lime, 12, 2, SoundID.Item2, BuffID.DryadsWard, 60 * 300)
        {
        }

        public override void SetDefaults()
        {
            base.SetDefaults();
            item.UseSound = mod.GetLegacySoundSlot(SoundType.Custom, "Sounds/Drinking/MeatEating");
        }

		public override bool UseItem(Player player)
        {
            player.AddBuff(BuffID.Regeneration, 60 * 300);
            return base.UseItem(player);
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.LifeFruit);
            recipe.AddIngredient(ItemID.PinkGel, 3);
            recipe.AddTile(TileID.CookingPots);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}