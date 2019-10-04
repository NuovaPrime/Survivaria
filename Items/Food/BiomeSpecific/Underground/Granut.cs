using System.Threading.Tasks;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace Survivaria.Items.Food.BiomeSpecific.Underground
{
    public class Granut : FoodItem
    {
        public Granut() : base("Granut", "An odd nut that brings you strength even when out of energy.\nIncreases max minions for 30 seconds.", 24, 30, Item.buyPrice(0, 0, 1, 0), ItemRarityID.Blue, 6, -3, SoundID.Item2, BuffID.Summoning, 60 * 30)
        {
        }
    }
}