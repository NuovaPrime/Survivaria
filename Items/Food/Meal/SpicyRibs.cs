using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Survivaria.Items.Food.BiomeSpecific.Purity;
using Survivaria.Items.Food.BiomeSpecific.Jungle;
using Survivaria.Items.Materials;

namespace Survivaria.Items.Food.Meal
{
    public class SpicyRibs : FoodItem
    {
        public SpicyRibs() : base("Spicy Ribs", "Now that's the hot stuff!", 24, 30, Item.buyPrice(0, 5, 0, 0), ItemRarityID.LightRed, 36, -2, SoundID.Item2, BuffID.Endurance, 60 * 300)
        {
        }

        public override void SetDefaults()
        {
            base.SetDefaults();
            item.UseSound = mod.GetLegacySoundSlot(SoundType.Custom, "Sounds/Drinking/MeatEating");
        }

		public override bool UseItem(Player player)
        {
            player.AddBuff(BuffID.Rage, 60 * 300);
            player.AddBuff(BuffID.WeaponImbueFire, 60 * 300);
            return true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<WyvernMeat>());
            recipe.AddIngredient(ModContent.ItemType<Peppermint>());
            recipe.AddIngredient(ModContent.ItemType<DragonFruit>());
            recipe.AddTile(TileID.Furnaces);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}