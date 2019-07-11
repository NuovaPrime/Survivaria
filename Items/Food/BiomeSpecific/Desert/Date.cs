using System.Threading.Tasks;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace Survivaria.Items.Food.BiomeSpecific.Desert
{
    public class Date : FoodItem
    {
        public Date() : base("Date", "A nutritious food for expeditions in the desert.", 16, 24, 4, SoundID.Item2, 999)
        {
        }
    }
}
