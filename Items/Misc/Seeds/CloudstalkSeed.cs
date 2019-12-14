using Survivaria.Tiles.Plants;
using Survivaria.Tiles.Stations;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Survivaria.Items.Misc.Seeds
{
    public class CloudstalkSeed : SurvivariaItem
    {
        public CloudstalkSeed() : base("Cloudstalk Seed", "A light and fleeting seed used to plant cloudstalk under clouds.", 28, 26, Item.buyPrice(0, 0, 1, 25), ItemRarityID.Blue)
        {
        }

        public override void SetDefaults()
        {
            item.consumable = true;
            item.createTile = ModContent.TileType<CloudstalkPlant>();
            item.useStyle = ItemUseStyleID.SwingThrow;
            base.SetDefaults();
        }
    }
}
