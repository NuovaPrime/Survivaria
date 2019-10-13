using Survivaria.Tiles.Plants;
using System.Threading.Tasks;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace Survivaria.Items.Food.BiomeSpecific.Purity
{
    public class Peppermint : FoodItem
    {
        public Peppermint() : base("Peppermint", "Being too close already makes eyes water and noses run. Caution is advised.\nGrants panic for 30 seconds.", 24, 30, Item.buyPrice(0, 0, 1, 0), ItemRarityID.Blue, 2, -5, SoundID.Item2, BuffID.Panic, 60 * 30)
        {
        }

        public override void SetDefaults()
        {
            base.SetDefaults();
            item.createTile = mod.TileType<PricklyPearOrangePlant>();
        }
    }
}
