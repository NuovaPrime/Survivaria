using System.Threading.Tasks;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Survivaria.Items.Food.BiomeSpecific.Purity;
using Survivaria.Players;

namespace Survivaria.Items.Misc
{
    public class RetentiveScarf : SurvivariaItem
    {
        public RetentiveScarf() : base("Retentive Scarf", "It helps preventing dehydration and is quite prized when going into harsh environments.", 28, 26, Item.buyPrice(0, 0, 40, 0), ItemRarityID.Blue)
        {
        }

        public override void SetDefaults()
        {
            item.accessory = true;
            base.SetDefaults();
        }

		public override void UpdateEquip(Player player)
		{
			player.ThirstLossMulti -= 0.3f;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Reece>(), 5);
            recipe.AddIngredient(ItemID.Silk, 7);
			recipe.AddTile(TileID.Loom);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
    }
}
