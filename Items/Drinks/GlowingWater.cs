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
    public class GlowingWater : DrinkItem
    {
        public GlowingWater() : base("Glowing Water", "It's filled with a mysterious and rejuvenating glowing liquid.", 20, 26, Item.buyPrice(0, 0, 5, 0), ItemRarityID.Green, 0, 20, SoundID.Item1, BuffID.Shine, 60 * 60)
        {
        }

        public override void SetDefaults()
        {
            base.SetDefaults();
            item.UseSound = mod.GetLegacySoundSlot(SoundType.Custom, "Sounds/Drinking/LightDrink");
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Bottle);
            recipe.needWater = true;
            recipe.SetResult(this);
            if (recipe.RecipeAvailable())
            {
                recipe.AddRecipe();
            }
        }
    }
}
