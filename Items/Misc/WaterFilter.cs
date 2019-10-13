using Survivaria.Tiles.Stations;
using System.Threading.Tasks;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace Survivaria.Items.Misc
{
    public class WaterFilter : SurvivariaItem
    {
        public WaterFilter() : base("Water Filter", "A small machine used to filter out unwanted minerals from water.", 28, 26, Item.buyPrice(0, 1, 0, 0), ItemRarityID.Green)
        {
        }

        public override void SetDefaults()
        {
            item.consumable = true;
            item.createTile = mod.TileType<WaterFilterTile>();
            base.SetDefaults();
        }
    }
}
