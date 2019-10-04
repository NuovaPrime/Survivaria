using System.Threading.Tasks;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace Survivaria.Items.Food.BiomeSpecific.Snow
{
    public class PearlBerry : FoodItem
    {
        public PearlBerry() : base("Pearl Berry", "These pear-shaped fruits are often used for desserts because of the soft taste and texture.", 24, 30, Item.buyPrice(0, 0, 1, 0), ItemRarityID.Blue, 4, 3, SoundID.Item2)
        {
        }
    }
}