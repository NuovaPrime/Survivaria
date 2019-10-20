using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Survivaria.Items.Food.BiomeSpecific.Hell;

namespace Survivaria.Items.Food.Meal
{
    public class PenguWings : FoodItem
    {
        public PenguWings() : base("Pengu Wings", "Fingers licking food.", 24, 30, Item.buyPrice(0, 0, 50, 0), ItemRarityID.Orange, 26, -6, SoundID.Item2, BuffID.WaterWalking, 60 * 300)
        {
        }

        public override void SetDefaults()
        {
            base.SetDefaults();
            item.UseSound = mod.GetLegacySoundSlot(SoundType.Custom, "Sounds/Drinking/MeatEating");
        }

		public override bool UseItem(Player player)
        {
            player.AddBuff(BuffID.Warmth, 60 * 300);
            return true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Penguin);
            recipe.AddIngredient(ModContent.ItemType<FieryTuber>());
            recipe.AddTile(TileID.Furnaces);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}