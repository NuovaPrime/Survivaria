using Survivaria.Tiles.Plants;
using Survivaria.Tiles.Stations;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Survivaria.Items.Misc.Seeds
{
    public class AmalgaeSeed : SurvivariaItem
    {
        public AmalgaeSeed() : base("Amalgae Seed", "A greasy and damp seed used to plant amalgae underwater.", 28, 26, Item.buyPrice(0, 0, 1, 0), ItemRarityID.Blue)
        {
        }

        public override void SetDefaults()
        {
            item.consumable = true;
            item.createTile = ModContent.TileType<AmalgaePlant>();
            item.useStyle = ItemUseStyleID.SwingThrow;
            base.SetDefaults();
        }
    }
}
