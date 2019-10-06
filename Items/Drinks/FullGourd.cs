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
    public class FullGourd : SurvivariaItem
    {
        public FullGourd() : base("Full Gourd", "A weathered gourd, full of unfiltered water.", 20, 26, Item.buyPrice(0, 1, 50, 0), ItemRarityID.Green, 0, 8)
        {
        }

        public override void SetDefaults()
        {
            base.SetDefaults();
            item.consumable = false;
            item.UseSound = mod.GetLegacySoundSlot(SoundType.Custom, "Sounds/Drinking/GourdDrink");
            item.maxStack = 1;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType<EmptyGourd>());
            recipe.needWater = true;
            recipe.SetResult(this);
            recipe.AddRecipe();

            ModRecipe recipe2 = new ModRecipe(mod);
            recipe2.AddIngredient(mod.ItemType<HalfGourd>());
            recipe2.needWater = true;
            recipe2.SetResult(this);
            recipe2.AddRecipe();
        }

        public override bool UseItem(Player player)
        {
            item.TurnToAir();
            player.PutItemInInventory(mod.ItemType<HalfGourd>());
            return true;
        }
    }
}
