using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Survivaria.Items.Food.Meal
{
    public class HoneyPartridge : FoodItem
    {
        public HoneyPartridge() : base("Honey Partridge", "A refined dish that not many can claim being able to cook.", 24, 30, Item.buyPrice(0, 0, 30, 0), ItemRarityID.Green, 21, -2, SoundID.Item2, BuffID.AmmoReservation, 60 * 180)
        {
        }

        public override void SetDefaults()
        {
            base.SetDefaults();
            item.UseSound = mod.GetLegacySoundSlot(SoundType.Custom, "Sounds/Drinking/MeatEating");
        }

		public override bool UseItem(Player player)
        {
            player.AddBuff(BuffID.Archery, 60 * 180);
            return base.UseItem(player);
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddRecipeGroup("Survivaria:Birds");
            recipe.AddIngredient(ItemID.BottledHoney);
            recipe.AddTile(TileID.CookingPots);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}