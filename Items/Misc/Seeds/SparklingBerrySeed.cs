using Survivaria.Tiles.Plants;
using Survivaria.Tiles.Stations;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Survivaria.Items.Misc.Seeds
{
    public class SparklingBerrySeed : SurvivariaItem
    {
        public SparklingBerrySeed() : base("Sparkling Berry Seed", "A shimmering seed used to plant sparkling berry in hallowed soil.", 28, 26, Item.buyPrice(0, 0, 25, 0), ItemRarityID.Blue)
        {
        }

        public override void SetDefaults()
        {
            item.consumable = true;
            item.createTile = ModContent.TileType<SparklingBerryPlant>();
            item.useStyle = ItemUseStyleID.SwingThrow;
            base.SetDefaults();
        }
    }
}
