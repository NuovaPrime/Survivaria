using System.Threading.Tasks;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace Survivaria.Items.Food.BiomeSpecific.Corruption
{
    public class CursedEggplant : FoodItem
    {
        public CursedEggplant() : base("Cursed Eggplant", "A very hearthy fruit that is delicious despite its unappealing look.\nIncreases damage for 30 seconds.", 16, 24, Item.buyPrice(0, 0, 1, 25), ItemRarityID.Blue, 8, 2, SoundID.Item2, BuffID.Wrath, 30 * 60)
        {
        }
    }
}
