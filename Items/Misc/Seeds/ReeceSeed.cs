using Survivaria.Tiles.Plants;
using Survivaria.Tiles.Stations;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Survivaria.Items.Misc.Seeds
{
    public class ReeceSeed : SurvivariaItem
    {
        public ReeceSeed() : base("Reece Seed", "A sturdy seed used to plant reece in normal soil.", 28, 26, Item.buyPrice(0, 0, 1, 0), ItemRarityID.Blue)
        {
        }

        public override void SetDefaults()
        {
            item.consumable = true;
            item.createTile = ModContent.TileType<ReecePlant>();
            item.useStyle = ItemUseStyleID.SwingThrow;
            base.SetDefaults();
        }
    }
}
