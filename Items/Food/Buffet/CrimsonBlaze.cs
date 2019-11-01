using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Survivaria.Items.Food.BiomeSpecific.Hell;
using Survivaria.Items.Food.BiomeSpecific.Purity;
using Survivaria.Items.Food.BiomeSpecific.Crimson;
using Survivaria.Items.Materials;

namespace Survivaria.Items.Food.Buffet
{
    public class CrimsonBlaze : FoodItem
    {
        public CrimsonBlaze() : base("Crimson Blaze", "A deep red tainted omen for the hell to come.", 24, 30, Item.buyPrice(0, 10, 0, 0), ItemRarityID.LightRed, 46, -8, SoundID.Item2, BuffID.Battle, 60 * 420)
        {
        }

        public override void SetDefaults()
        {
            base.SetDefaults();
            item.UseSound = mod.GetLegacySoundSlot(SoundType.Custom, "Sounds/Drinking/MeatEating");
        }

		public override bool UseItem(Player player)
        {
            player.AddBuff(BuffID.Warmth, 60 * 420);
            player.AddBuff(BuffID.Panic, 60 * 420);
            player.AddBuff(BuffID.Heartreach, 60 * 420);
            return base.UseItem(player);
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<AshStraws>());
            recipe.AddIngredient(ModContent.ItemType<BlossomWheat>(), 2);
            recipe.AddIngredient(ModContent.ItemType<Greneyede>(), 2);
            recipe.AddIngredient(ModContent.ItemType<Peppermint>(), 2);
            recipe.AddTile(TileID.Furnaces);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}