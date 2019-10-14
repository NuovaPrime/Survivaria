using System.Threading.Tasks;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace Survivaria.Items.Food.BiomeSpecific.Underground
{
    public class Granut : FoodItem
    {
        public Granut() : base("Granut", "An odd nut that brings you strength even when out of energy.", 24, 30, Item.buyPrice(0, 0, 30, 0), ItemRarityID.Orange, 6, -3, SoundID.Item2, BuffID.Summoning, 60 * 30)
        {
        }
    }
}