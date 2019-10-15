using System.Threading.Tasks;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace Survivaria.Items.Food.BiomeSpecific.Jungle
{
    public class DragonFruit : FoodItem
    {
        public DragonFruit() : base("Dragon Fruit", "The skin has beautiful patterns akin to dragon scales.", 24, 30, Item.buyPrice(0, 0, 30, 0), ItemRarityID.Blue, 3, 6, SoundID.Item2, BuffID.ObsidianSkin, 60 * 30)
        {
        }
    }
}
