using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Survivaria.Items.Food.BiomeSpecific.Crimson;

namespace Survivaria.Items.Drinks
{
    public class BloodyShot : DrinkItem
    {
        public BloodyShot() : base("Bloody Shot", "A sip of this is enough to feel tough like a bull.", 20, 26, Item.buyPrice(0, 0, 2, 5), ItemRarityID.Green, 6, 6, SoundID.Item1, BuffID.Regeneration, 60 * 180)
        {
        }

        public override void SetDefaults()
        {
            base.SetDefaults();
            item.UseSound = mod.GetLegacySoundSlot(SoundType.Custom, "Sounds/Drinking/LightDrink");
        }

		public override bool UseItem(Player player)
        {
            player.AddBuff(BuffID.Ironskin, 60 * 120);
            return base.UseItem(player);
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<BleedRoot>());
            recipe.AddIngredient(ItemID.Bottle);
            recipe.AddTile(TileID.Kegs);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}