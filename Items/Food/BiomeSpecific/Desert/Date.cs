using System.Threading.Tasks;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace Survivaria.Items.Food.BiomeSpecific.Desert
{
    public class Date : FoodItem
    {
        public Date() : base("Date", "A nutritious food for expeditions in the desert.", 16, 24, Item.buyPrice(0, 0, 1, 0), ItemRarityID.Blue, 6, 0, SoundID.Item2)
        {
        }
    }
}
