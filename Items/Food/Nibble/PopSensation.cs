using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Survivaria.Items.Food.BiomeSpecific.Jungle;
using Survivaria.Items.Food.BiomeSpecific.Underground;

namespace Survivaria.Items.Food.Nibble
{
    public class PopSensation : FoodItem
    {
        public PopSensation() : base("Pop Sensation", "The delicious sweetness mixed in with the salt makes for the absolute dish whenever there's something spicy.", 24, 30, Item.buyPrice(0, 0, 50, 0), ItemRarityID.Green, 8, -2, SoundID.Item2, BuffID.Spelunker, 60 * 120)
        {
        }

        public override void SetDefaults()
        {
            base.SetDefaults();
            item.UseSound = mod.GetLegacySoundSlot(SoundType.Custom, "Sounds/Eating/CrunchEating");
        }

		public override bool UseItem(Player player)
        {
            player.AddBuff(BuffID.Honey, 60 * 120);
            return base.UseItem(player);
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Corney>());
            recipe.AddIngredient(ModContent.ItemType<Salt>());
            recipe.AddTile(TileID.Furnaces);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}