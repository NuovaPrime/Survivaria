using System.Threading.Tasks;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace Survivaria.Items.Food.BiomeSpecific.Hell
{
    public class AshStraws : FoodItem
    {
        public AshStraws() : base("Ash Straws", "A dry and soothing black berry, prized by the most delicate.", 16, 24, Item.buyPrice(0, 0, 1, 0), ItemRarityID.LightRed, 4, -5, SoundID.Item2)
        {
        }
    }
}
