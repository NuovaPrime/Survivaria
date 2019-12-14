using Survivaria.Tiles.Plants;
using Survivaria.Tiles.Stations;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Survivaria.Items.Misc.Seeds
{
    public class PearlBerrySeed : SurvivariaItem
    {
        public PearlBerrySeed() : base("Pearl Berry Seed", "A soothing seed used to plant pearl berry in snow.", 28, 26, Item.buyPrice(0, 0, 1, 0), ItemRarityID.Blue)
        {
        }

        public override void SetDefaults()
        {
            item.consumable = true;
            item.createTile = ModContent.TileType<PearlBerryPlant>();
            item.useStyle = ItemUseStyleID.SwingThrow;
            base.SetDefaults();
        }
    }
}
