using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Survivaria.Items.Food.Meal
{
    public class MushroomMedleyVile : FoodItem
    {
        public MushroomMedleyVile() : base("Mushroom Medley", "When you mix all kinds of stuff, it becomes a stuffed mix.", 24, 30, Item.buyPrice(0, 0, 40, 0), ItemRarityID.Green, 26, 2, SoundID.Item2, BuffID.Shine, 60 * 180)
        {
        }

        public override void SetDefaults()
        {
            base.SetDefaults();
            item.UseSound = mod.GetLegacySoundSlot(SoundType.Custom, "Sounds/Drinking/CrunchEating");
        }

		public override bool UseItem(Player player)
        {
            player.AddBuff(BuffID.Swiftness, 60 * 180);
            player.AddBuff(BuffID.Mining, 60 * 180);
            return base.UseItem(player);
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Mushroom);
            recipe.AddIngredient(ItemID.GlowingMushroom);
            recipe.AddIngredient(ItemID.VileMushroom);
            recipe.AddTile(TileID.Furnaces);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}