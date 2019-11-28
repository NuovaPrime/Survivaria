using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Survivaria.Items.Food.BiomeSpecific.Underground;
using Survivaria.Items.Materials;

namespace Survivaria.Items.Food.Buffet
{
    public class WormyCurry : FoodItem
    {
        public WormyCurry() : base("Wormy Curry", "It isn't appetizing, but you won't be able to stop getting mouthfuls of it.", 24, 30, Item.buyPrice(0, 0, 50, 0), ItemRarityID.Green, 42, -3, SoundID.Item2, BuffID.Endurance, 60 * 180)
        {
        }

        public override void SetDefaults()
        {
            base.SetDefaults();
            item.UseSound = mod.GetLegacySoundSlot(SoundType.Custom, "Sounds/Eating/MeatEating");
        }

		public override bool UseItem(Player player)
        {
            player.AddBuff(BuffID.Wrath, 60 * 180);
            player.AddBuff(BuffID.Mining, 60 * 180);
            return base.UseItem(player);
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.RottenChunk);
            recipe.AddIngredient(ItemID.VileMushroom);
            recipe.AddIngredient(ModContent.ItemType<Salt>());
            recipe.AddIngredient(ModContent.ItemType<Reece>());
            recipe.AddIngredient(ItemID.Bowl);
            recipe.AddTile(TileID.CookingPots);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}