using Survivaria.Tiles.Stations;
using System.Threading.Tasks;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace Survivaria.Items.Misc
{
    public class GrindStone : SurvivariaItem
    {
        public GrindStone() : base("Grinding Stone", "A commonly used pair of stone tools used to grind down plants and small foods.", 28, 26, Item.buyPrice(0, 1, 0, 0), ItemRarityID.Green)
        {
        }

        public override void SetDefaults()
        {
            item.consumable = true;
            item.createTile = mod.TileType<GrindStoneTile>();
            base.SetDefaults();
        }
    }
}
