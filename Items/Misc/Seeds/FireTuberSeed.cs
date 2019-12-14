using Survivaria.Tiles.Plants;
using Survivaria.Tiles.Stations;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Survivaria.Items.Misc.Seeds
{
    public class FireTuberSeed : SurvivariaItem
    {
        public FireTuberSeed() : base("Fiery Tuber Seed", "A burning seed used to plant fiery tuber under ashes.", 28, 26, Item.buyPrice(0, 0, 1, 25), ItemRarityID.Blue)
        {
        }

        public override void SetDefaults()
        {
            item.consumable = true;
            item.createTile = ModContent.TileType<FireTuberPlant>();
            item.useStyle = ItemUseStyleID.SwingThrow;
            base.SetDefaults();
        }
    }
}
