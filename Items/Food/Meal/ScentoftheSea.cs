using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Survivaria.Items.Food.BiomeSpecific.Corruption;

namespace Survivaria.Items.Food.Meal
{
    public class ScentoftheSea : FoodItem
    {
        public ScentoftheSea() : base("Scent of the Sea", "It has a nice fumet that lures out only wanted attention.", 24, 30, Item.buyPrice(0, 0, 40, 0), ItemRarityID.Green, 22, 2, SoundID.Item2, BuffID.Calm, 60 * 180)
        {
        }

        public override void SetDefaults()
        {
            base.SetDefaults();
            item.UseSound = mod.GetLegacySoundSlot(SoundType.Custom, "Sounds/Drinking/MeatEating");
        }

		public override bool UseItem(Player player)
        {
            player.AddBuff(BuffID.Fishing, 60 * 180);
            player.AddBuff(BuffID.Stinky, 60 * 180);
            return base.UseItem(player);
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddRecipeGroup("Survivaria:OceanFish");
            recipe.AddIngredient(ModContent.ItemType<PutridOlives>());
            recipe.AddIngredient(ItemID.Bowl);
            recipe.AddTile(TileID.CookingPots);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}