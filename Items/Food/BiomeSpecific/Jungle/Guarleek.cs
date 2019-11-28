using System.Threading.Tasks;
using Terraria;

using Terraria.ID;
using Terraria.ModLoader;

namespace Survivaria.Items.Food.BiomeSpecific.Jungle
{
    public class Guarleek : FoodItem
    {
        public Guarleek() : base("Guarleek", "It is said that the smell isn't for the faint-hearted, but those are just rumors.", 24, 30, Item.buyPrice(0, 3, 0, 0), ItemRarityID.Lime, 5, 1, SoundID.Item2, BuffID.Lifeforce, 60 * 60)
        {
        }

        public override void SetDefaults()
        {
            base.SetDefaults();
            item.UseSound = mod.GetLegacySoundSlot(SoundType.Custom, "Sounds/Eating/FruitEating");
        }

		public override bool UseItem(Player player)
        {
            player.AddBuff(BuffID.Stinky, 60 * 60);
            return base.UseItem(player);
        }

    }
}