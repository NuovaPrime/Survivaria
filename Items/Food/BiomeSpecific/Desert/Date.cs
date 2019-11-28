using System.Threading.Tasks;
using Terraria;

using Terraria.ID;
using Terraria.ModLoader;

namespace Survivaria.Items.Food.BiomeSpecific.Desert
{
    public class Date : FoodItem
    {
        public Date() : base("Date", "A nutritious food found in expeditions through the desert.", 16, 24, Item.buyPrice(0, 0, 1, 0), ItemRarityID.Blue, 7, -2, SoundID.Item2)
        {
        }
        public override void SetDefaults()
        {
            base.SetDefaults();
            item.UseSound = mod.GetLegacySoundSlot(SoundType.Custom, "Sounds/Eating/FruitEating");
        }

    }
}
