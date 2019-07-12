using System.Threading.Tasks;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace Survivaria.Items.Food.BiomeSpecific.Jungle
{
    public class DragonFruit : FoodItem
    {
        public DragonFruit() : base("DragonFruit", "The skin has beautiful patterns akin to dragon scales.", 24, 30, 6, SoundID.Item2, 999)
        {
        }
    }
}