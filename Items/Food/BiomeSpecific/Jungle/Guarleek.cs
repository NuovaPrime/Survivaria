using System.Threading.Tasks;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace Survivaria.Items.Food.BiomeSpecific.Jungle
{
    public class Guarleek : FoodItem
    {
        public Guarleek() : base("Guarleek", "It is said that the smell isn't for the faint-hearted, but those are just rumors.", 24, 30, Item.buyPrice(0, 0, 1, 0), ItemRarityID.Blue, 5, 1, SoundID.Item2)
        {
        }
    }
}