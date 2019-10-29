using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Survivaria.Items.Food.BiomeSpecific.Snow;

namespace Survivaria.Items.Food.Meal
{
    public class CoolDuck : FoodItem
    {
        public CoolDuck() : base("Cool Duck", "The perfect dish for a revenge.", 24, 30, Item.buyPrice(0, 0, 30, 0), ItemRarityID.Green, 28, 0, SoundID.Item2, BuffID.AmmoReservation, 60 * 180)
        {
        }

        public override void SetDefaults()
        {
            base.SetDefaults();
            item.UseSound = mod.GetLegacySoundSlot(SoundType.Custom, "Sounds/Drinking/MeatEating");
        }

		public override bool UseItem(Player player)
        {
            player.AddBuff(BuffID.Chilled, 30 * 180);
            return base.UseItem(player);
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddRecipeGroup("Survivaria:Ducks");
            recipe.AddIngredient(ModContent.ItemType<FrostPlum>());
            recipe.AddTile(TileID.CookingPots);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}