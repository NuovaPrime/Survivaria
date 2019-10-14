using System.Threading.Tasks;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace Survivaria.Items.Food.BiomeSpecific.Hallow
{
    public class RockCandy : FoodItem
    {
        public RockCandy() : base("Rock Candy", "It's a wonder this doesn't break your teeth.", 16, 24, Item.buyPrice(0, 1, 0, 0), ItemRarityID.Pink, 3, -3, SoundID.Item2, BuffID.Spelunker, 60 * 60)
        {
        }
    }
}
