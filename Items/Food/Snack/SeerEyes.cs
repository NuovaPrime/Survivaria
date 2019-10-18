using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Survivaria.Items.Food.BiomeSpecific.Desert;

namespace Survivaria.Items.Food.Snack
{
    public class SeerEyes : FoodItem
    {
        public SeerEyes() : base("Seer Eyes", "Looking at these eyes is like seeing through the universe.", 24, 30, Item.buyPrice(0, 0, 80, 0), ItemRarityID.Orange, 18, -7, SoundID.Item2, BuffID.Summoning, 60 * 300)
        {
        }

        public override void SetDefaults()
        {
            base.SetDefaults();
            item.UseSound = mod.GetLegacySoundSlot(SoundType.Custom, "Sounds/Drinking/CrunchEating");
        }

		public override bool UseItem(Player player)
        {
            player.AddBuff(BuffID.Clairvoyance, 60 * 300);
            return true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Date>());
            recipe.AddIngredient(ModContent.ItemType<GranutButter>());
            recipe.AddTile(TileID.Furnaces);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}