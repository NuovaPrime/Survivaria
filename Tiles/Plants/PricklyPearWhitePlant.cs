using Microsoft.Xna.Framework.Graphics;
using Survivaria.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace Survivaria.Tiles.Plants
{
    public class PricklyPearWhitePlant : ModTile
    {
        public override void SetDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            Main.tileLighted[Type] = true;
            Main.tileCut[Type] = false;
            Main.tileNoFail[Type] = true;
            Main.tileWaterDeath[Type] = true;
            Main.tileSpelunker[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
            TileObjectData.newTile.DrawYOffset = 2;
            TileObjectData.newTile.WaterDeath = true;
            TileObjectData.newTile.AnchorValidTiles = new[]
            {
                53, //TileID.Sand
			};
            TileObjectData.addTile(Type);
        }

        public override bool Drop(int i, int j)
        {
            int stage = Main.tile[i, j].frameX / 18 / 2;
            if (stage == 2)
            {
                Item.NewItem(i * 16, j * 16, 0, 0, ModContent.ItemType<PricklyPearWhite>());
            }
            return false;
        }

        public override void RandomUpdate(int i, int j)
        {
            if (Main.tile[i, j].frameX == 0)
            {
                if (Main.rand.Next(4) == 0)
                {
                    Main.tile[i, j].frameX += 36;
                    Main.tile[i + 1, j].frameX += 36;
                }
            }
            else if (Main.tile[i, j].frameX == 36)
            {
                if (Main.rand.Next(4) == 0)
                {
                    Main.tile[i, j].frameX += 36;
                    Main.tile[i + 1, j].frameX += 36;
                }
            }
        }
    }
}
