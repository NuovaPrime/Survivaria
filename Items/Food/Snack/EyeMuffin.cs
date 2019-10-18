using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Survivaria.Items.Food.BiomeSpecific.Purity;
using Survivaria.Items.Food.BiomeSpecific.Crimson;

namespace Survivaria.Items.Food.Snack
{
    public class EyeMuffin : FoodItem
    {
        public EyeMuffin() : base("Eye Muffin", "Paranoia has its advantages, but it takes a toll on the mind.", 24, 30, Item.buyPrice(0, 0, 60, 0), ItemRarityID.Green, 14, -1, SoundID.Item2, BuffID.Battle, 60 * 180)
        {
        }

        public override void SetDefaults()
        {
            base.SetDefaults();
            item.UseSound = mod.GetLegacySoundSlot(SoundType.Custom, "Sounds/Drinking/CrunchEating");
        }

		public override bool UseItem(Player player)
        {
            player.AddBuff(BuffID.Panic, 60 * 180);
            return true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Guavado>());
            recipe.AddIngredient(ModContent.ItemType<Greneyede>());
            recipe.AddTile(TileID.Furnaces);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}