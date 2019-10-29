using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Survivaria.Items.Food.BiomeSpecific.Hell;
using Survivaria.Items.Food.BiomeSpecific.Underground;

namespace Survivaria.Items.Drinks
{
    public class CindersOfLove : DrinkItem
    {
        public CindersOfLove() : base("Cinders of Love", "The sweet taste of illusion hiding the bitterness of reality.", 20, 26, Item.buyPrice(0, 0, 70, 0), ItemRarityID.Orange, 4, 4, SoundID.Item1, BuffID.Heartreach, 60 * 180)
        {
        }

        public override void SetDefaults()
        {
            base.SetDefaults();
            item.UseSound = mod.GetLegacySoundSlot(SoundType.Custom, "Sounds/Drinking/LightDrink");
        }

		public override bool UseItem(Player player)
        {
            player.AddBuff(BuffID.SoulDrain, 60 * 120);
            return base.UseItem(player);
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<AshStraws>());
            recipe.AddIngredient(ModContent.ItemType<Frambosia>());
            recipe.AddIngredient(ItemID.Bottle);
            recipe.AddTile(TileID.Bottles);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}