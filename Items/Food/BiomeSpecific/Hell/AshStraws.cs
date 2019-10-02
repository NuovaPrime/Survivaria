using System.Threading.Tasks;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace Survivaria.Items.Food.BiomeSpecific.Hell
{
    public class AshStraws : FoodItem
    {
        public AshStraws() : base("Ash Straws", "Extremely sweet and spicy black berries.\nBriefly lights you on fire upon consumption.", 16, 24, Item.buyPrice(0, 0, 1, 0), ItemRarityID.LightRed, 8, -2, SoundID.Item2, BuffID.OnFire, 2 * 60)
        {
        }
    }
}
