using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Survivaria.Items.Materials;

namespace Survivaria.Items.Food.Buffet
{
    public class LivingLegend : FoodItem
    {
        public LivingLegend() : base("Living Legend", "The tenderness from being soaked in life juice makes it melt on the tongue.", 24, 30, Item.buyPrice(0, 15, 0, 0), ItemRarityID.Lime, 56, 0, SoundID.Item2, BuffID.Lifeforce, 60 * 300)
        {
        }

        public override void SetDefaults()
        {
            base.SetDefaults();
            item.UseSound = mod.GetLegacySoundSlot(SoundType.Custom, "Sounds/Eating/MeatEating");
        }

		public override bool UseItem(Player player)
        {
            player.AddBuff(BuffID.DryadsWard, 60 * 300);
            return base.UseItem(player);
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<UnicornMeat>());
            recipe.AddIngredient(ItemID.LifeFruit, 2);
            recipe.AddTile(TileID.CookingPots);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}