using System.Threading.Tasks;
using Terraria;

using Terraria.ID;
using Terraria.ModLoader;

namespace Survivaria.Items.Food.BiomeSpecific.Hell
{
    public class AshStraws : FoodItem
    {
        public AshStraws() : base("Ash Straws", "A dry and soothing black berry, prized by the most delicate.", 16, 24, Item.buyPrice(0, 0, 40, 0), ItemRarityID.Orange, 4, -5, SoundID.Item2)
        {
        }
        public override void SetDefaults()
        {
            base.SetDefaults();
            item.UseSound = mod.GetLegacySoundSlot(SoundType.Custom, "Sounds/Eating/FruitEating");
        }

    }
}
