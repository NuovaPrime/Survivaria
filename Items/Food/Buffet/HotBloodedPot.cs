using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Survivaria.Items.Food.BiomeSpecific.Purity;
using Survivaria.Items.Food.BiomeSpecific.Crimson;
using Survivaria.Items.Materials;

namespace Survivaria.Items.Food.Buffet
{
    public class HotBloodedPot : FoodItem
    {
        public HotBloodedPot() : base("Hot Blooded Pot", "It sets the fires of hell ablaze inside you.", 24, 30, Item.buyPrice(0, 20, 0, 0), ItemRarityID.Pink, 62, 4, SoundID.Item2, BuffID.Inferno, 60 * 420)
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
            player.AddBuff(BuffID.SoulDrain, 60 * 420);
            return base.UseItem(player);
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<BleedRoot>(), 2);
            recipe.AddIngredient(ModContent.ItemType<DemonTail>());
            recipe.AddIngredient(ModContent.ItemType<Peppermint>(), 2);
            recipe.AddIngredient(ItemID.Bowl);
            recipe.AddTile(TileID.CookingPots);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}