using Microsoft.Xna.Framework.Graphics;
using Survivaria.Items.Food.BiomeSpecific.Purity;
using Terraria;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace Survivaria.Tiles.Plants
{
	public class PeppermintPlant : ModTile
	{
		public override void SetDefaults() {
			Main.tileFrameImportant[Type] = true;
			Main.tileCut[Type] = true;
			Main.tileNoFail[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.StyleAlch);
            TileObjectData.newTile.Width = 2;
            TileObjectData.newTile.Height = 2;
            TileObjectData.newTile.CoordinateHeights = new int[] { 16, 18};
            TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.SolidTile, TileObjectData.newTile.Width - 1, 0);
            TileObjectData.newTile.AnchorValidTiles = new[]
			{
				2, //TileID.Grass
			};
			TileObjectData.addTile(Type);
		}
        /*public override void SetSpriteEffects(int i, int j, ref SpriteEffects spriteEffects)
        {
            if (i % 2 == 1)
            {
                spriteEffects = SpriteEffects.FlipHorizontally;
            }
        }*/

        public override bool Drop(int i, int j) {
			int stage = Main.tile[i, j].frameX / 18 / 2;
			if (stage == 2) {
				Item.NewItem(i * 16, j * 16, 0, 0, mod.ItemType<Peppermint>());
			}
			return false;
		}

		public override void RandomUpdate(int i, int j)
        {
            if (Main.tile[i, j].frameX == 0)
            {
                Main.tile[i, j].frameX += 36;
                Main.tile[i + 1, j].frameX += 36;
            }
			else if (Main.tile[i, j].frameX == 36)
            {
                Main.tile[i, j].frameX += 36;
                Main.tile[i + 1, j].frameX += 36;
            }
		}
	}
}
