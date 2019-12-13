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
    public class RoastedRabbit : FoodItem
    {
        public RoastedRabbit() : base("Roasted Rabbit", "A simple yet delicious dish to fill your needs.", 24, 30, Item.buyPrice(0, 0, 20, 0), ItemRarityID.Blue, 22, -2, SoundID.Item2, BuffID.Swiftness, 60 * 60)
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
            recipe.AddIngredient(ItemID.Bunny);
            recipe.AddIngredient(ItemID.Mushroom);
            recipe.AddTile(TileID.Furnaces);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
