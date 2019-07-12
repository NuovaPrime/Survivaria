using System.Threading.Tasks;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace Survivaria.Items.Food.BiomeSpecific.Purity
{
    public class Guavado : FoodItem
    {
        public Guavado() : base("Guavado", "It has a faint aroma of citrus, and its buttery texture makes it a delicacy.", 22, 26, 8, SoundID.Item2, 999)
        {
        }
    }
}