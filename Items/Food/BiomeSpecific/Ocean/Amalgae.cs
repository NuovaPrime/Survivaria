using System.Threading.Tasks;
using Terraria;

using Terraria.ID;
using Terraria.ModLoader;

namespace Survivaria.Items.Food.BiomeSpecific.Ocean
{
    public class Amalgae : FoodItem
    {
        public Amalgae() : base("Amalgae", "The natural salt contained makes it dry soon after it's out of the water.", 16, 24, Item.buyPrice(0, 0, 20, 0), ItemRarityID.Blue, 5, -5, SoundID.Item2, BuffID.Gills, 60 * 30)
        {
        }
        public override void SetDefaults()
        {
            base.SetDefaults();
            item.UseSound = mod.GetLegacySoundSlot(SoundType.Custom, "Sounds/Eating/CrunchEating");
        }

    }
}
