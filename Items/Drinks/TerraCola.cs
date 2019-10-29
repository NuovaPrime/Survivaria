using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Survivaria.Items.Food.BiomeSpecific.Underground;
using Survivaria.Items.Food.BiomeSpecific.Space;

namespace Survivaria.Items.Drinks
{
    public class TerraCola : DrinkItem
    {
        public TerraCola() : base("Terra-Cola", "No one knows the true recipe.", 20, 26, Item.buyPrice(0, 1, 0, 0), ItemRarityID.Pink, -4, 6, SoundID.Item1, BuffID.ManaRegeneration, 60 * 420)
        {
        }

        public override void SetDefaults()
        {
            base.SetDefaults();
            item.UseSound = mod.GetLegacySoundSlot(SoundType.Custom, "Sounds/Drinking/GourdDrink");
        }

		public override bool UseItem(Player player)
        {
            player.AddBuff(BuffID.MagicPower, 60 * 420);
            player.AddBuff(BuffID.Lovestruck, 60 * 420);
            return base.UseItem(player);
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<SparklingWater>());
            recipe.AddIngredient(ModContent.ItemType<Frambosia>());
            recipe.AddIngredient(ModContent.ItemType<Starfruit>());
            recipe.AddTile(TileID.Bottles);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}