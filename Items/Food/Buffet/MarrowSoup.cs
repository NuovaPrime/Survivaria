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
    public class MarrowSoup : FoodItem
    {
        public MarrowSoup() : base("Marrow Soup", "Surprisingly, cooking up bones can make up something edible.", 24, 30, Item.buyPrice(0, 0, 50, 0), ItemRarityID.Green, 42, -3, SoundID.Item2, BuffID.Endurance, 60 * 180)
        {
        }

        public override void SetDefaults()
        {
            base.SetDefaults();
            item.UseSound = mod.GetLegacySoundSlot(SoundType.Custom, "Sounds/Drinking/MeatEating");
        }

		public override bool UseItem(Player player)
        {
            player.AddBuff(BuffID.Rage, 60 * 180);
            player.AddBuff(BuffID.Builder, 60 * 180);
            return true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Vertebrae);
            recipe.AddIngredient(ItemID.ViciousMushroom);
            recipe.AddIngredient(ModContent.ItemType<Salt>());
            recipe.AddIngredient(ModContent.ItemType<BlossomWheat>());
            recipe.AddIngredient(ItemID.Bowl);
            recipe.AddTile(TileID.CookingPots);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}