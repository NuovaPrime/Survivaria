using System.Threading.Tasks;
using Terraria;

using Terraria.ID;
using Terraria.ModLoader;

namespace Survivaria.Items.Food.BiomeSpecific.Space
{
    public class Cloudstalk : FoodItem
    {
        public Cloudstalk() : base("Cloudstalk", "These weightless beans are left hanging, waiting to be caught by a gust of wind.", 24, 30, Item.buyPrice(0, 0, 30, 0), ItemRarityID.Green, 7, -2, SoundID.Item2, BuffID.Featherfall, 60 * 30)
        {
        }
        public override void SetDefaults()
        {
            base.SetDefaults();
            item.UseSound = mod.GetLegacySoundSlot(SoundType.Custom, "Sounds/Eating/FruitEating");
        }

    }
}