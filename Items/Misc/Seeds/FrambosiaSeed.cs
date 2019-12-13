using Survivaria.Tiles.Plants;
using Survivaria.Tiles.Stations;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Survivaria.Items.Misc.Seeds
{
    public class FrambosiaSeed : SurvivariaItem
    {
        public FrambosiaSeed() : base("Frambosia Seed", "An alluring seed used to plant frambosia under marble.", 28, 26, Item.buyPrice(0, 0, 1, 25), ItemRarityID.Blue)
        {
        }

        public override void SetDefaults()
        {
            item.consumable = true;
            item.createTile = ModContent.TileType<FrambosiaPlant>();
            item.useStyle = ItemUseStyleID.SwingThrow;
            base.SetDefaults();
        }
    }
}
