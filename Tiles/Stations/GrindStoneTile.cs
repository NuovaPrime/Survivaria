using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Survivaria.Items.Food.BiomeSpecific.Jungle;
using Survivaria.Items.Food.BiomeSpecific.Purity;
using Survivaria.Items.Misc;
using Terraria;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace Survivaria.Tiles.Stations
{
		public class GrindStoneTile : ModTile
		{
				public override void SetDefaults()
				{
						Main.tileFrameImportant[Type] = true;
						Main.tileCut[Type] = false;
						Main.tileNoFail[Type] = true;
	          TileObjectData.newTile.CopyFrom(TileObjectData.Style2x1);
	          TileObjectData.newTile.CoordinateHeights = new[] { 18 };
	          disableSmartCursor = true;
	          ModTranslation name = CreateMapEntryName();
	          name.SetDefault("Grinding Stone");
	          AddMapEntry(new Color(166, 120, 71), name);
	          TileObjectData.addTile(Type);
	          adjTiles = new int[] { ModContent.TileType<MAPTile>() };
	      }

	      public override void KillMultiTile(int i, int j, int frameX, int frameY)
	      {
	          Item.NewItem(i * 16, j * 16, 32, 16, ModContent.ItemType<GrindStone>());
	      }
    }
}
