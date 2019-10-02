using System.Threading.Tasks;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace Survivaria.Items.Food.BiomeSpecific.Corruption
{
    public class CursedEggplant : FoodItem
    {
        public CursedEggplant() : base("Cursed Eggplant", "A very juicy fruit despite it's horrendous looks.", 16, 24, Item.buyPrice(0, 0, 1, 25), ItemRarityID.Blue, 4, 2, SoundID.Item2)
        {
        }
    }
}
