using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Survivaria.Items.Food.BiomeSpecific.Purity;
using Survivaria.Items.Food.BiomeSpecific.Ocean;
using Survivaria.Items.Materials;

namespace Survivaria.Items.Food.Meal
{
    public class MakiRoll : FoodItem
    {
        public MakiRoll() : base("Maki Roll", "People would kill for it.", 24, 30, Item.buyPrice(0, 0, 50, 0), ItemRarityID.Green, 20, 0, SoundID.Item2, BuffID.Wrath, 60 * 180)
        {
        }

        public override void SetDefaults()
        {
            base.SetDefaults();
            item.UseSound = mod.GetLegacySoundSlot(SoundType.Custom, "Sounds/Drinking/CrunchEating");
        }

		public override bool UseItem(Player player)
        {
            player.AddBuff(BuffID.Rage, 60 * 180);
            return true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Reece>());
            recipe.AddIngredient(ModContent.ItemType<Amalgae>());
            recipe.AddIngredient(ModContent.ItemType<Guavado>());
            recipe.AddTile(TileID.CookingPots);
            recipe.AddTile(TileID.Tables);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}