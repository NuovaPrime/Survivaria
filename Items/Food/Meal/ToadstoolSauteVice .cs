using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Survivaria.Items.Food.BiomeSpecific.Underground;

namespace Survivaria.Items.Food.Meal
{
    public class ToadstoolSauteVice : FoodItem
    {
        public ToadstoolSauteVice() : base("Toadstool Sauté", "It gives off a slightly bad vibe, maybe you shouldn't eat it.", 24, 30, Item.buyPrice(0, 0, 40, 0), ItemRarityID.Green, 24, 0, SoundID.Item2, BuffID.Merfolk, 60 * 180)
        {
        }

        public override void SetDefaults()
        {
            base.SetDefaults();
            item.UseSound = mod.GetLegacySoundSlot(SoundType.Custom, "Sounds/Drinking/MeatEating");
        }

		public override bool UseItem(Player player)
        {
            player.AddBuff(BuffID.Bewitched, 60 * 180);
            player.AddBuff(BuffID.Rage, 60 * 180);
            return true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Frog);
            recipe.AddIngredient(ModContent.ItemType<Salt>());
            recipe.AddIngredient(ItemID.ViciousMushroom);
            recipe.AddTile(TileID.Furnaces);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}