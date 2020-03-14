using System.Threading.Tasks;
using Terraria;

using Terraria.ID;
using Terraria.ModLoader;

namespace Survivaria.Items.Food.BiomeSpecific.Jungle
{
    public class Corney : FoodItem
    {
        public Corney() : base("Corney", "The grains are used as a tasty treat, but they melt when cooked.", 24, 30, Item.buyPrice(0, 0, 1, 0), ItemRarityID.Blue, 9, 0, SoundID.Item2, BuffID.Honey, 8 * 60)
        {
        }
        public override void SetDefaults()
        {
            base.SetDefaults();
            item.UseSound = mod.GetLegacySoundSlot(SoundType.Custom, "Sounds/Eating/FruitEating");
        }

    }
}
