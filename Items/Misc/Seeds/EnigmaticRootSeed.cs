using Survivaria.Tiles.Plants;
using Survivaria.Tiles.Stations;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Survivaria.Items.Misc.Seeds
{
    public class EnigmaticRootSeed : SurvivariaItem
    {
        public EnigmaticRootSeed() : base("Enigmatic Root Seed", "A strange seed used to plant enigmatic root under jungle soil.", 28, 26, Item.buyPrice(0, 0, 1, 0), ItemRarityID.Blue)
        {
        }

        public override void SetDefaults()
        {
            item.consumable = true;
            item.createTile = ModContent.TileType<EnigmaticRootPlant>();
            item.useStyle = ItemUseStyleID.SwingThrow;
            base.SetDefaults();
        }
    }
}
