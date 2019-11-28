using System.Threading.Tasks;
using Terraria;

using Terraria.ID;
using Terraria.ModLoader;

namespace Survivaria.Items.Food.BiomeSpecific.Hell
{
    public class FieryTuber : FoodItem
    {
        public FieryTuber() : base("Fiery Tuber", "An unbelievably spicy root, who would eat something like this?", 16, 24, Item.buyPrice(0, 0, 50, 0), ItemRarityID.Orange, 9, -4, SoundID.Item2, BuffID.OnFire, 3 * 30)
        {
        }

        public override void SetDefaults()
        {
            base.SetDefaults();
            item.UseSound = mod.GetLegacySoundSlot(SoundType.Custom, "Sounds/Eating/FruitEating");
        }

		public override bool UseItem(Player player)
        {
            player.AddBuff(BuffID.Warmth, 60 * 30);
            return base.UseItem(player);
        }

    }
}
