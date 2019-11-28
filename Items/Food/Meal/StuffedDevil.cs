using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Survivaria.Items.Materials;
using Survivaria.Items.Food.BiomeSpecific.Corruption;

namespace Survivaria.Items.Food.Meal
{
    public class StuffedDevil : FoodItem
    {
        public StuffedDevil() : base("Stuffed Devil", "Now you can get a taste of their own magic.", 24, 30, Item.buyPrice(0, 7, 0, 0), ItemRarityID.Pink, 36, -2, SoundID.Item2, BuffID.Inferno, 60 * 420)
        {
        }

        public override void SetDefaults()
        {
            base.SetDefaults();
            item.UseSound = mod.GetLegacySoundSlot(SoundType.Custom, "Sounds/Eating/MeatEating");
        }

		public override bool UseItem(Player player)
        {
            player.AddBuff(BuffID.Wrath, 60 * 420);
            player.AddBuff(BuffID.WeaponImbueCursedFlames, 60 * 420);
            return base.UseItem(player);
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.VileMushroom);
            recipe.AddIngredient(ModContent.ItemType<DemonTail>());
            recipe.AddIngredient(ModContent.ItemType<CursedEggplant>());
            recipe.AddTile(TileID.Furnaces);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}