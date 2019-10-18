using System.Threading.Tasks;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace Survivaria.Items.Food.BiomeSpecific.Space
{
    public class Starfruit : FoodItem
    {
        public Starfruit() : base("Starfruit", "It absorbed the power of the stars to ripen.", 24, 30, Item.buyPrice(0, 0, 30, 0), ItemRarityID.Green, 4, 4, SoundID.Item2, BuffID.ManaRegeneration, 60 * 30)
        {
        }
        public override void SetDefaults()
        {
            base.SetDefaults();
            item.UseSound = mod.GetLegacySoundSlot(SoundType.Custom, "Sounds/Drinking/FruitEating");
        }

    }
}