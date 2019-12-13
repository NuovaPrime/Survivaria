using Survivaria.Tiles.Plants;
using Survivaria.Tiles.Stations;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Survivaria.Items.Misc.Seeds
{
    public class GuarleekSeed : SurvivariaItem
    {
        public GuarleekSeed() : base("Guarleek Seed", "A seed with a strong smell used to plant guarleek in jungle soil.", 28, 26, Item.buyPrice(0, 0, 50, 0), ItemRarityID.Blue)
        {
        }

        public override void SetDefaults()
        {
            item.consumable = true;
            item.createTile = ModContent.TileType<GuarleekPlant>();
            item.useStyle = ItemUseStyleID.SwingThrow;
            base.SetDefaults();
        }
    }
}
