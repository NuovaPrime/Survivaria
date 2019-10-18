using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Survivaria.Items.Food.BiomeSpecific.Space;
using Survivaria.Items.Food.BiomeSpecific.Underground;

namespace Survivaria.Items.Drinks
{
    public class ShimmeringDrink : DrinkItem
    {
        public ShimmeringDrink() : base("Shimmering Drink", "It's brimming with starlight projecting swirling light through the glass.", 20, 26, Item.buyPrice(0, 0, 40, 0), ItemRarityID.Orange, 4, 8, SoundID.Item1, BuffID.Shine, 60 * 180)
        {
        }

        public override void SetDefaults()
        {
            base.SetDefaults();
            item.UseSound = mod.GetLegacySoundSlot(SoundType.Custom, "Sounds/Drinking/LightDrink");
        }

		public override bool UseItem(Player player)
        {
            player.AddBuff(BuffID.ManaRegeneration, 60 * 180);
            return true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Starfruit>());
            recipe.AddIngredient(ModContent.ItemType<MushyCarrot>());
            recipe.AddIngredient(ItemID.Bottle);
            recipe.AddTile(TileID.Bottles);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}