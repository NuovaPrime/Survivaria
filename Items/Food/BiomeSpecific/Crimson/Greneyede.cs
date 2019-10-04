using System.Threading.Tasks;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace Survivaria.Items.Food.BiomeSpecific.Crimson
{
    public class Greneyede : FoodItem
    {
        public Greneyede() : base("Greneyede", "Tastes surprisingly good, but you don't feel safe being watched when eating it.", 16, 24, Item.buyPrice(0, 0, 0, 80), ItemRarityID.Blue, 5, 3, SoundID.Item2)
        {
        }
    }
}
