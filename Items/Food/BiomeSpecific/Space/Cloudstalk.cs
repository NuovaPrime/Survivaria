using System.Threading.Tasks;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace Survivaria.Items.Food.BiomeSpecific.Space
{
    public class Cloudstalk : FoodItem
    {
        public Cloudstalk() : base("Cloudstalk", "These weightless beans are left hanging, waiting to be caught by a gust of wind.", 24, 30, Item.buyPrice(0, 0, 1, 0), ItemRarityID.Blue, 7, -2, SoundID.Item2, BuffID.Featherfall, 60 * 30)
        {
        }
    }
}