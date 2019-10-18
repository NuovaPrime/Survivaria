using System.Threading.Tasks;
using Terraria;

using Terraria.ID;
using Terraria.ModLoader;

namespace Survivaria.Items.Food.BiomeSpecific.Hallow
{
    public class SparklingBerry : FoodItem
    {
        public SparklingBerry() : base("Sparkling Berry", "Vibrant hallowed dust circulates inside the berry, producing a texture unlike any other when eaten.", 16, 24, Item.buyPrice(0, 1, 0, 0), ItemRarityID.Pink, 2, 3, SoundID.Item2, BuffID.MagicPower, 60 * 60)
        {
        }
        public override void SetDefaults()
        {
            base.SetDefaults();
            item.UseSound = mod.GetLegacySoundSlot(SoundType.Custom, "Sounds/Drinking/FruitEating");
        }

    }
}
