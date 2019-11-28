using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Survivaria.Items.Food.Nibble
{
    public class RoastedSeeds : FoodItem
    {
        public RoastedSeeds() : base("Roasted Seeds", "A handful of treats to wait inbetween meals.", 24, 30, Item.buyPrice(0, 0, 1, 0), ItemRarityID.White, 3, -1, SoundID.Item2)
        {
        }

        public override void SetDefaults()
        {
            base.SetDefaults();
            item.UseSound = mod.GetLegacySoundSlot(SoundType.Custom, "Sounds/Eating/CrunchEating");
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
			recipe.AddRecipeGroup("Survivaria:Seeds");
            recipe.AddTile(TileID.Furnaces);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}