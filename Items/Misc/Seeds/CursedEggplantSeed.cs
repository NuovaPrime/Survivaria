using Survivaria.Tiles.Plants;
using Survivaria.Tiles.Stations;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Survivaria.Items.Misc.Seeds
{
    public class CursedEggplantSeed : SurvivariaItem
    {
        public CursedEggplantSeed() : base("Cursed Eggplant Seed", "A squishy seed used to plant cursed eggplant in corrupt soil.", 28, 26, Item.buyPrice(0, 0, 1, 0), ItemRarityID.Blue)
        {
        }

        public override void SetDefaults()
        {
            item.consumable = true;
            item.createTile = ModContent.TileType<CursedEggplantPlant>();
            item.useStyle = ItemUseStyleID.SwingThrow;
            base.SetDefaults();
        }
    }
}
