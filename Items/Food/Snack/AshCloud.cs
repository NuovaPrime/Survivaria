using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Survivaria.Items.Food.BiomeSpecific.Hell;
using Survivaria.Items.Food.BiomeSpecific.Space;

namespace Survivaria.Items.Food.Snack
{
    public class AshCloud : FoodItem
    {
        public AshCloud() : base("Ash Cloud", "The perfect mixture of hell and paradise.", 24, 30, Item.buyPrice(0, 0, 60, 0), ItemRarityID.Orange, 14, -6, SoundID.Item2, BuffID.Heartreach, 60 * 300)
        {
        }

        public override void SetDefaults()
        {
            base.SetDefaults();
            item.UseSound = mod.GetLegacySoundSlot(SoundType.Custom, "Sounds/Drinking/CrunchEating");
        }

		public override bool UseItem(Player player)
        {
            player.AddBuff(BuffID.Featherfall, 60 * 300);
            return true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<AshStraws>());
            recipe.AddIngredient(ModContent.ItemType<Cloudstalk>());
            recipe.AddTile(TileID.Furnaces);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}