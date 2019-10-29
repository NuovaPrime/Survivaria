using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Survivaria.Items.Food.BiomeSpecific.Underground;
using Survivaria.Items.Food.BiomeSpecific.Corruption;

namespace Survivaria.Items.Food.Meal
{
    public class DamnedBreakfast : FoodItem
    {
        public DamnedBreakfast() : base("Damned Breakfast", "It never gets old!", 24, 30, Item.buyPrice(0, 4, 0, 0), ItemRarityID.LightRed, 38, -8, SoundID.Item2, BuffID.Werewolf, 60 * 300)
        {
        }

        public override void SetDefaults()
        {
            base.SetDefaults();
            item.UseSound = mod.GetLegacySoundSlot(SoundType.Custom, "Sounds/Drinking/MeatEating");
        }

		public override bool UseItem(Player player)
        {
            player.AddBuff(BuffID.Wrath, 60 * 300);
            player.AddBuff(BuffID.WeaponImbueCursedFlames, 60 * 300);
            return base.UseItem(player);
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Bacon);
            recipe.AddIngredient(ModContent.ItemType<Salt>());
            recipe.AddIngredient(ModContent.ItemType<CursedEggplant>());
            recipe.AddTile(TileID.Furnaces);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}