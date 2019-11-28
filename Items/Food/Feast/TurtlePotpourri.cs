using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Survivaria.Items.Food.BiomeSpecific.Snow;
using Survivaria.Items.Materials;

namespace Survivaria.Items.Food.Feast
{
    public class TurtlePotpourri : FoodItem
    {
        public TurtlePotpourri() : base("Turtle Potpourri", "The smell is heavy enough to be called a meal.", 24, 30, Item.buyPrice(0, 20, 0, 0), ItemRarityID.LightRed, 88, -2, SoundID.Item2, BuffID.IceBarrier, 60 * 300)
        {
        }

        public override void SetDefaults()
        {
            base.SetDefaults();
            item.UseSound = mod.GetLegacySoundSlot(SoundType.Custom, "Sounds/Eating/MeatEating");
        }

		public override bool UseItem(Player player)
        {
            player.AddBuff(BuffID.Chilled, 60 * 300);
            player.AddBuff(BuffID.Titan, 60 * 300);
            return base.UseItem(player);
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddRecipeGroup("Survivaria:Squirrels");
            recipe.AddIngredient(ModContent.ItemType<TurtleMeat>());
            recipe.AddIngredient(ModContent.ItemType<FrostPlum>(), 2);
            recipe.AddIngredient(ItemID.Penguin);
            recipe.AddIngredient(ItemID.Bowl);
            recipe.AddTile(TileID.CookingPots);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}