using Survivaria.Tiles.Plants;
using Survivaria.Tiles.Stations;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Survivaria.Items.Misc.Seeds
{
    public class StarfruitSeed : SurvivariaItem
    {
        public StarfruitSeed() : base("Starfruit Seed", "A mysterious seed used to plant starfruit in space.", 28, 26, Item.buyPrice(0, 0, 1, 25), ItemRarityID.Blue)
        {
        }

        public override void SetDefaults()
        {
            item.consumable = true;
            item.createTile = ModContent.TileType<StarfruitPlant>();
            item.useStyle = ItemUseStyleID.SwingThrow;
            base.SetDefaults();
        }
    }
}
