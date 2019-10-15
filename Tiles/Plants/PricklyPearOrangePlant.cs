using Microsoft.Xna.Framework.Graphics;
using Survivaria.Items.Food.BiomeSpecific.Purity;
using Survivaria.Items.Food.BiomeSpecific.Snow;
using Survivaria.Items.Food.BiomeSpecific.Underground;
using Survivaria.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace Survivaria.Tiles.Plants
{
	public class PricklyPearOrangePlant : ModTile
	{
		public override void SetDefaults() {
			Main.tileFrameImportant[Type] = true;
            Main.tileLighted[Type] = true;
			Main.tileCut[Type] = false;
			Main.tileNoFail[Type] = true;
			TileObjectData.newTile.CopyFrom(TileObjectData.StyleAlch);
            TileObjectData.newTile.Height = 1;
            TileObjectData.newTile.Width = 1;
            TileObjectData.newTile.CoordinateHeights = new int[] { 18 };
            TileObjectData.newTile.DrawYOffset = 1;
            TileObjectData.newTile.AnchorValidTiles = new[]
			{
				80, //TileID.Cactus
			};
			TileObjectData.addTile(Type);
		}

        public override bool Drop(int i, int j)
        {
            Item.NewItem(i * 16, j * 16, 0, 0, ModContent.ItemType<PricklyPearOrange>());
            return false;
        }
		//public override void RightClick(int i, int j)
		//{
		//	base.RightClick(i, j);
		//}
	}
}
