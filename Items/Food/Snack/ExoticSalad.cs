using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Survivaria.Items.Food.BiomeSpecific.Jungle;
using Survivaria.Items.Food.BiomeSpecific.Space;
using Survivaria.Items.Materials;

namespace Survivaria.Items.Food.Snack
{
    public class ExoticSalad : FoodItem
    {
        public ExoticSalad() : base("Exotic Salad", "A colorful assortment that brings all the vitamins one could need.", 24, 30, Item.buyPrice(0, 0, 70, 0), ItemRarityID.Orange, 12, 6, SoundID.Item2, BuffID.ObsidianSkin, 60 * 180)
        {
        }

        public override void SetDefaults()
        {
            base.SetDefaults();
            item.UseSound = mod.GetLegacySoundSlot(SoundType.Custom, "Sounds/Drinking/FruitEating");
        }

		public override bool UseItem(Player player)
        {
            player.AddBuff(BuffID.Thorns, 60 * 180);
            player.AddBuff(BuffID.ManaRegeneration, 60 * 180);
            return true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddRecipeGroup("Survivaria:Pears");
            recipe.AddIngredient(ModContent.ItemType<DragonFruit>());
            recipe.AddIngredient(ModContent.ItemType<Starfruit>());
            recipe.AddIngredient(ItemID.Bowl);
            recipe.AddTile(TileID.Tables);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}