using System.Threading.Tasks;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace Survivaria.Items.Food.BiomeSpecific.Hallow
{
    public class SparklingBerry : FoodItem
    {
        public SparklingBerry() : base("Sparkling Berry", "Vibrant hallowed dust circulates inside the berry, looks tasty.\nGrants the magic power buff for 1 minute upon consumption.", 16, 24, Item.buyPrice(0, 0, 2, 50), ItemRarityID.Pink, 6, 3, SoundID.Item2, BuffID.MagicPower, 60 * 60)
        {
        }
    }
}
