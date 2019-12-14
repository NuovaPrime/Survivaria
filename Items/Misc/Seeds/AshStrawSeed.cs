using Survivaria.Tiles.Plants;
using Survivaria.Tiles.Stations;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Survivaria.Items.Misc.Seeds
{
    public class AshStrawSeed : SurvivariaItem
    {
        public AshStrawSeed() : base("Ash Straws Seed", "A dry seed used to plant ash straws in ash.", 28, 26, Item.buyPrice(0, 0, 1, 25), ItemRarityID.Blue)
        {
        }

        public override void SetDefaults()
        {
            item.consumable = true;
            item.createTile = ModContent.TileType<AshStrawPlant>();
            item.useStyle = ItemUseStyleID.SwingThrow;
            base.SetDefaults();
        }
    }
}
