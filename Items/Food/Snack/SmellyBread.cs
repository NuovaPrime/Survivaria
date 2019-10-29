using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Survivaria.Items.Food.BiomeSpecific.Purity;
using Survivaria.Items.Food.BiomeSpecific.Corruption;
using Survivaria.Items.Materials;
using Survivaria.Tiles.Stations;

namespace Survivaria.Items.Food.Snack
{
    public class SmellyBread : FoodItem
    {
        public SmellyBread() : base("Smelly Bread", "The stench is pretty unappealing but no one will bother you because of it.", 24, 30, Item.buyPrice(0, 0, 5, 0), ItemRarityID.Green, 14, -2, SoundID.Item2, BuffID.Stinky, 60 * 180)
        {
        }

        public override void SetDefaults()
        {
            base.SetDefaults();
            item.UseSound = mod.GetLegacySoundSlot(SoundType.Custom, "Sounds/Drinking/CrunchEating");
        }

		public override bool UseItem(Player player)
        {
            player.AddBuff(BuffID.Calm, 60 * 180);
            return base.UseItem(player);
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<PutridOlives>());
            recipe.AddIngredient(ModContent.ItemType<BlossomWheat>());
            recipe.AddTile(TileID.Furnaces);
			recipe.AddTile(ModContent.TileType<GrindStoneTile>());
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}