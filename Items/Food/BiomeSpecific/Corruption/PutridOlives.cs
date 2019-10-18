using System.Threading.Tasks;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace Survivaria.Items.Food.BiomeSpecific.Corruption
{
    public class PutridOlives : FoodItem
    {
        public PutridOlives() : base("Putrid Olives", "Some extremely bitter and detestable toppings.", 16, 24, Item.buyPrice(0, 0, 0, 80), ItemRarityID.Green, 5, 0, SoundID.Item2, BuffID.Stinky, 30 * 60)
        {
        }
        public override void SetDefaults()
        {
            base.SetDefaults();
            item.UseSound = mod.GetLegacySoundSlot(SoundType.Custom, "Sounds/Drinking/FruitEating");
        }

    }
}
