using System.Threading.Tasks;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace Survivaria.Items.Food.BiomeSpecific.Hell
{
    public class FieryTuber : FoodItem
    {
        public FieryTuber() : base("Fiery Tuber", "An unbelievably spicy root, who would eat something like this?", 16, 24, Item.buyPrice(0, 0, 1, 25), ItemRarityID.LightRed, 9, -4, SoundID.Item2, BuffID.OnFire, 3 * 60)
        {
        }

		public override bool UseItem(Player player)
        {
            player.AddBuff(BuffID.Warmth, 60 * 30);
            return true;
        }

    }
}
