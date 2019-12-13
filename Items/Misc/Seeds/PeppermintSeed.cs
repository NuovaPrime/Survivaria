using Survivaria.Tiles.Plants;
using Survivaria.Tiles.Stations;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Survivaria.Items.Misc.Seeds
{
    public class PeppermintSeed : SurvivariaItem
    {
        public PeppermintSeed() : base("Peppermint Seed", "A seed that makes eyes water used to plant peppermint in normal soil.", 28, 26, Item.buyPrice(0, 0, 25, 0), ItemRarityID.Blue)
        {
        }

        public override void SetDefaults()
        {
            item.consumable = true;
            item.createTile = ModContent.TileType<PeppermintPlant>();
            item.useStyle = ItemUseStyleID.SwingThrow;
            base.SetDefaults();
        }
    }
}
