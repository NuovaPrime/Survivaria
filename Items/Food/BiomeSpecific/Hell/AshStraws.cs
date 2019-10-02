using System.Threading.Tasks;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace Survivaria.Items.Food.BiomeSpecific.Hell
{
    public class AshStraws : FoodItem
    {
        public AshStraws() : base("Ash Straws", "A dry and soothing black berry.", 16, 24, Item.buyPrice(0, 0, 1, 0), ItemRarityID.LightRed, 8, -2, SoundID.Item2, BuffID.OnFire, 2 * 60)
        {
        }
    }
}
