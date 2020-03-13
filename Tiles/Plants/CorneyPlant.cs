using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Survivaria.Items.Food.BiomeSpecific.Jungle;
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
	public class CorneyPlant : ModTile
	{
		public override void SetDefaults() {
			Main.tileFrameImportant[Type] = true;
			Main.tileCut[Type] = false;
			Main.tileNoFail[Type] = true;
            Main.tileWaterDeath[Type] = true;
            Main.tileSpelunker[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.StyleAlch);
            TileObjectData.newTile.Height = 3;
            TileObjectData.newTile.CoordinateHeights = new int[] { 16, 16, 18};
            TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.SolidTile, TileObjectData.newTile.Width, 0);
            TileObjectData.newTile.DrawYOffset = 2;
            TileObjectData.newTile.WaterDeath = true;
            TileObjectData.newTile.AnchorValidTiles = new[]
			{
				60, //TileID.JungleGrass
			};
            ModTranslation name = CreateMapEntryName();
            name.SetDefault("Corney");
            AddMapEntry(new Color(79, 191, 27), name);
			TileObjectData.addTile(Type);
		}

		public override bool Drop(int i, int j) {
			int stage = Main.tile[i, j].frameX / 18;
			Player player = Main.LocalPlayer;
			if (player.HeldItem.type == ModContent.ItemType<DynastyTrowel>())
			{
					if (stage == 2 && Main.tile[i, j].frameX == 36 && Main.tile[i, j].frameY == 18)
					{
							Item.NewItem(i * 16, j * 16, 0, 0, ModContent.ItemType<CorneySeed>());
					}
			}
			else if (player.HeldItem.type == ModContent.ItemType<LeadTrowel>() || player.HeldItem.type == ModContent.ItemType<IronTrowel>())
			{
					if (stage == 2 && Main.tile[i, j].frameX == 36 && Main.tile[i, j].frameY == 18 && Main.rand.Next(3) == 0)
					{
							Item.NewItem(i * 16, j * 16, 0, 0, ModContent.ItemType<CorneySeed>());
					}
			}
            if (stage == 2 && Main.tile[i, j].frameX == 36 && Main.tile[i, j].frameY == 18)
            {
				Item.NewItem(i * 16, j * 16, 0, 0, ModContent.ItemType<Corney>());
			}
			return false;
		}

        public override void RandomUpdate(int i, int j)
        {
            int x = i - Main.tile[i, j].frameX / 18 % 1;
            int y = j - Main.tile[i, j].frameY / 18 % 3;

            Tile tile;
            if (Main.rand.Next(5) == 0)
            {
                for (int l = x; l < x + 1; l++)
                {
                    for (int m = y; m < y + 3; m++)
                    {
                        tile = Framing.GetTileSafely(l, m);
                        if (tile.active() && tile.type == Type)
                        {
                            if (tile.frameX == 0)
                            {
                                tile.frameX += 18;
                            }

                            else if (tile.frameX == 18)
                            {
                                tile.frameX += 18;
                            }
								            else if (Main.tile[i, j].frameX == 36 && Main.tile[i, j].frameY == 18)
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
