using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Survivaria.Items.Food.BiomeSpecific.Purity;
using Survivaria.Items.Misc;
using Survivaria.Items.Misc.Seeds;
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
			Main.tileCut[Type] = false;
			Main.tileNoFail[Type] = true;
            Main.tileWaterDeath[Type] = true;
            Main.tileSpelunker[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
            TileObjectData.newTile.DrawYOffset = 2;
            TileObjectData.newTile.WaterDeath = true;
            TileObjectData.newTile.AnchorValidTiles = new[]
			{
				2, //TileID.Grass
			};
            ModTranslation name = CreateMapEntryName();
            name.SetDefault("Peppermint");
            AddMapEntry(new Color(176, 22, 5), name);
            TileObjectData.addTile(Type);
		}

        public override bool Drop(int i, int j) {
			int stage = Main.tile[i, j].frameX / 18 / 2;
			Player player = Main.LocalPlayer;
			if (player.HeldItem.type == ModContent.ItemType<DynastyTrowel>())
			{
					if (stage == 2 && Main.rand.Next(3) == 0 && Main.tile[i, j].frameY == 18)
					{
							Item.NewItem(i * 16, j * 16, 0, 0, ModContent.ItemType<PeppermintSeed>());
					}
			}
			else if (player.HeldItem.type == ModContent.ItemType<LeadTrowel>() || player.HeldItem.type == ModContent.ItemType<IronTrowel>())
			{
					if (stage == 2 && Main.rand.Next(5) == 0 && Main.tile[i, j].frameY == 18)
					{
							Item.NewItem(i * 16, j * 16, 0, 0, ModContent.ItemType<PeppermintSeed>());
					}
			}
            if (stage == 2 && Main.tile[i, j].frameY == 18)
            {
				Item.NewItem(i * 16, j * 16, 0, 0, ModContent.ItemType<Peppermint>());
			}
			return false;
		}

		public override void RandomUpdate(int i, int j)
        {
            int x = i - Main.tile[i, j].frameX / 18 % 2;
            int y = j - Main.tile[i, j].frameY / 18 % 2;

            Tile tile;
            Tile tile2;
            if (Main.rand.Next(5) == 0)
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
								            else if (Main.tile[i, j].frameX == 72 && Main.tile[i, j].frameY == 18)
								            {
								                if (Main.rand.Next(4) == 0) WorldGen.KillTile(i, j, false, false, true);
								            }
                        }
                    }
                }
            }
            NetMessage.SendTileSquare(-1, x + 1, y, 3);
        }
	}
}
