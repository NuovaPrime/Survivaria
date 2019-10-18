using System.Threading.Tasks;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace Survivaria.Items.Food.BiomeSpecific.Snow
{
    public class FrostPlum : FoodItem
    {
        public FrostPlum() : base("Frost Plum", "The unripened fruits are often used to preserve food, as it produces cold while maturing.", 24, 30, Item.buyPrice(0, 0, 20, 0), ItemRarityID.Blue, 3, 4, SoundID.Item2, BuffID.Frozen, 3 * 60)
        {
        }

        public override void SetDefaults()
        {
            base.SetDefaults();
            item.UseSound = mod.GetLegacySoundSlot(SoundType.Custom, "Sounds/Drinking/FruitEating");
        }

		public override bool UseItem(Player player)
        {
            player.AddBuff(BuffID.Chilled, 60 * 30);
            return true;
        }

    }
}