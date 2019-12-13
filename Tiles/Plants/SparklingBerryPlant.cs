using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Survivaria.Items.Food.BiomeSpecific.Hallow;
using Survivaria.Items.Food.BiomeSpecific.Purity;
using Terraria;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace Survivaria.Tiles.Plants
{
	public class SparklingBerryPlant : ModTile
	{
		public override void SetDefaults() {
			Main.tileFrameImportant[Type] = true;
			Main.tileCut[Type] = false;
			Main.tileNoFail[Type] = true;
            Main.tileWaterDeath[Type] = true;
            Main.tileSpelunker[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.StyleAlch);
            TileObjectData.newTile.Width = 2;
            TileObjectData.newTile.Height = 2;
            TileObjectData.newTile.CoordinateHeights = new int[] { 16, 16};
            TileObjectData.newTile.DrawYOffset = 2;
            TileObjectData.newTile.WaterDeath = true;
            TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.SolidTile, TileObjectData.newTile.Width - 1, 0);
            TileObjectData.newTile.CoordinatePadding = 2;
            TileObjectData.newTile.AnchorValidTiles = new[]
			{
				109, //TileID.HallowedGrass
			};
            ModTranslation name = CreateMapEntryName();
            name.SetDefault("Sparkling Berry");
            AddMapEntry(new Color(219, 212, 79), name);
            TileObjectData.addTile(Type);
		}
        /*public override void SetSpriteEffects(int i, int j, ref SpriteEffects spriteEffects)
        {
            if (i % 2 == 1)
            {
                spriteEffects = SpriteEffects.FlipHorizontally;
            }
        }*/

        public override bool Drop(int i, int j)
        {
			int stage = Main.tile[i, j].frameX / 18 / 2;
			if (stage == 2 && Main.tile[i, j].frameX == 72 && Main.tile[i, j].frameY == 18) {
				Item.NewItem(i * 16, j * 16, 0, 0, ModContent.ItemType<SparklingBerry>());
			}
			return false;
		}

        public override void RandomUpdate(int i, int j)
        {
            int x = i - Main.tile[i, j].frameX / 18 % 2;
            int y = j - Main.tile[i, j].frameY / 18 % 2;

            Tile tile;
            Tile tile2;
            if (Main.rand.Next(4) == 0)
            {
                for (int l = x; l < x + 2; l++)
                {
                    for (int m = y; m < y + 2; m++)
                    {
                        tile = Framing.GetTileSafely(l, m);
                        tile2 = Framing.GetTileSafely(l + 1, m);
                        if (tile.active() && tile.type == Type)
                        {
                            if (tile.frameX == 0)
                            {
                                tile.frameX += 36;
                                tile2.frameX += 36;
                            }

                            else if (tile.frameX == 36)
                            {
                                tile.frameX += 36;
                                tile2.frameX += 36;
                            }
                        }
                    }
                }
            }
            else if (Main.tile[i, j].frameX == 36 * 2)
            {
                if (Main.rand.Next(20) == 0) WorldGen.KillTile(i, j, false, false, true);
            }
            NetMessage.SendTileSquare(-1, x + 1, y, 3);
        }
    }
}
