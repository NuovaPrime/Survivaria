using System.Threading.Tasks;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace Survivaria.Items.Food.BiomeSpecific.Underground
{
    public class Frambosia : FoodItem
    {
        public Frambosia() : base("Frambosia", "A food believed to make you 'reach the gods' when eaten.\nMakes you euphoric.", 24, 30, Item.buyPrice(0, 0, 1, 0), ItemRarityID.Blue, 3, 2, SoundID.Item2, BuffID.Lovestruck, 60 * 30)
        {
        }
    }
}