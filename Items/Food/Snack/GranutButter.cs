using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Survivaria.Items.Food.BiomeSpecific.Underground;
using Survivaria.Tiles.Stations;

namespace Survivaria.Items.Food.Snack
{
    public class GranutButter : FoodItem
    {
        public GranutButter() : base("Granut Butter", "The patterns caused by salt gives the impression to be looking at a night sky.", 24, 30, Item.buyPrice(0, 0, 60, 0), ItemRarityID.Orange, 12, -6, SoundID.Item2, BuffID.Summoning, 60 * 180)
        {
        }

        public override void SetDefaults()
        {
            base.SetDefaults();
            item.UseSound = mod.GetLegacySoundSlot(SoundType.Custom, "Sounds/Drinking/CrunchEating");
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Salt>());
            recipe.AddIngredient(ModContent.ItemType<Granut>());
            recipe.AddIngredient(ItemID.Bottle);
            recipe.AddTile(TileID.CookingPots);
			recipe.AddTile(ModContent.TileType<MAPTile>());
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}