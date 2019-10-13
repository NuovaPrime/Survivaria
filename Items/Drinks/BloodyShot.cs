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
    public class BloodyShot : DrinkItem
    {
        public BloodyShot() : base("Bloody Shot", "A sip of this is enough to feel tough like a bull.", 20, 26, Item.buyPrice(0, 0, 2, 5), ItemRarityID.Green, 6, 6, BuffID.Regeneration, 60 * 180)
        {
        }

		public override bool UseItem(Player player)
        {
            player.AddBuff(BuffID.IronSkin, 60 * 120);
            return true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemType<BleedRoot>());
            recipe.AddTile(TileID.Keg);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}