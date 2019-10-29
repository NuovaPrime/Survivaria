using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Survivaria.Items.Food.BiomeSpecific.Jungle;
using Survivaria.Items.Food.BiomeSpecific.Space;

namespace Survivaria.Items.Food.Meal
{
    public class FluffyTaco : FoodItem
    {
        public FluffyTaco() : base("Fluffy Taco", "The softness melts your heart like a cloud.", 24, 30, Item.buyPrice(0, 0, 60, 0), ItemRarityID.Orange, 23, -2, SoundID.Item2, BuffID.Honey, 60 * 180)
        {
        }

        public override void SetDefaults()
        {
            base.SetDefaults();
            item.UseSound = mod.GetLegacySoundSlot(SoundType.Custom, "Sounds/Drinking/CrunchEating");
        }

		public override bool UseItem(Player player)
        {
            player.AddBuff(BuffID.Featherfall, 60 * 180);
            return base.UseItem(player);
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Corney>());
            recipe.AddIngredient(ModContent.ItemType<Cloudstalk>());
            recipe.AddTile(TileID.Furnaces);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}