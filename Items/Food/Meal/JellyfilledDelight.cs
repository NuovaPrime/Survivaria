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
    public class JellyfilledDelight : FoodItem
    {
        public JellyfilledDelight() : base("Jellyfilled Delight", "It doesn't hold very well when exposed to heat.", 24, 30, Item.buyPrice(0, 0, 20, 0), ItemRarityID.Blue, 20, 0, SoundID.Item2, BuffID.Invisibility, 60 * 180)
        {
        }

        public override void SetDefaults()
        {
            base.SetDefaults();
            item.UseSound = mod.GetLegacySoundSlot(SoundType.Custom, "Sounds/Eating/MeatEating");
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<PearlBerry>());
            recipe.AddIngredient(ItemID.Gel, 5);
            recipe.AddIngredient(ItemID.SnowBlock);
            recipe.AddTile(TileID.CookingPots);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}