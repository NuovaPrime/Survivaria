using System.Threading.Tasks;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace Survivaria.Items.Food.BiomeSpecific.Snow
{
    public class FrostPlum : FoodItem
    {
        public FrostPlum() : base("Frost Plum", "The unripened fruits are often used to preserve food, as it produces cold while maturing.\nBriefly freezes you upon consumption.", 24, 30, Item.buyPrice(0, 0, 1, 0), ItemRarityID.Blue, 3, 4, SoundID.Item2, BuffID.Frozen, 3 * 60)
        {
        }
    }
}