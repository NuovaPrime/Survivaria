using Survivaria.Tiles.Plants;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Survivaria.Items.Food.BiomeSpecific.Purity
{
    public class Peppermint : FoodItem
    {
        public Peppermint() : base("Peppermint", "Being too close already makes eyes water and noses run. Caution is advised.", 24, 30, Item.buyPrice(0, 1, 0, 0), ItemRarityID.LightRed, 2, -5, SoundID.Item2, BuffID.Panic, 60 * 30)
        {
        }

        public override void SetDefaults()
        {
            base.SetDefaults();
            item.UseSound = mod.GetLegacySoundSlot(SoundType.Custom, "Sounds/Eating/CrunchEating");
        }

		public override bool UseItem(Player player)
        {
            player.AddBuff(BuffID.OnFire, 30 * 30);
            return base.UseItem(player);
        }
    }
}
