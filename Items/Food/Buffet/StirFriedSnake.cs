using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Survivaria.Items.Food.BiomeSpecific.Underground;
using Survivaria.Items.Food.BiomeSpecific.Jungle;
using Survivaria.Items.Materials;

namespace Survivaria.Items.Food.Buffet
{
    public class StirFriedSnake : FoodItem
    {
        public StirFriedSnake() : base("Stir Fried Snake", "It is very popular as an easy to make food, while still being of quality.", 24, 30, Item.buyPrice(0, 12, 0, 0), ItemRarityID.Lime, 53, -3, SoundID.Item2, BuffID.Bewitched, 60 * 420)
        {
        }

        public override void SetDefaults()
        {
            base.SetDefaults();
            item.UseSound = mod.GetLegacySoundSlot(SoundType.Custom, "Sounds/Drinking/MeatEating");
        }

		public override bool UseItem(Player player)
        {
            player.AddBuff(BuffID.Lifeforce, 60 * 420);
            player.AddBuff(BuffID.Hunter, 60 * 420);
            return true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<SnakeMeat>());
            recipe.AddIngredient(ModContent.ItemType<Guarleek>());
            recipe.AddIngredient(ModContent.ItemType<MushyCarrot>());
            recipe.AddTile(TileID.Furnaces);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}