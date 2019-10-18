using System.Threading.Tasks;
using Terraria;

using Terraria.ID;
using Terraria.ModLoader;

namespace Survivaria.Items.Food.BiomeSpecific.Underground
{
    public class Frambosia : FoodItem
    {
        public Frambosia() : base("Frambosia", "A food believed to make you 'reach the gods' when eaten.", 24, 30, Item.buyPrice(0, 0, 30, 0), ItemRarityID.Orange, 3, 2, SoundID.Item2, BuffID.Lovestruck, 60 * 30)
        {
        }
        public override void SetDefaults()
        {
            base.SetDefaults();
            item.UseSound = mod.GetLegacySoundSlot(SoundType.Custom, "Sounds/Drinking/FruitEating");
        }

    }
}