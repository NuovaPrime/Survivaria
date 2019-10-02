using System.Threading.Tasks;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace Survivaria.Items.Food.BiomeSpecific.Corruption
{
    public class PutridOlives : FoodItem
    {
        public PutridOlives() : base("Putrid Olives", "Some extremely bitter and detestable toppings.", 16, 24, Item.buyPrice(0, 0, 0, 80), ItemRarityID.Blue, 3, 0, SoundID.Item2)
        {
        }
    }
}
