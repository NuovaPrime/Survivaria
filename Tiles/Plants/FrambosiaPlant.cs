using Microsoft.Xna.Framework.Graphics;
using Survivaria.Items.Food.BiomeSpecific.Corruption;
using Survivaria.Items.Food.BiomeSpecific.Crimson;
using Survivaria.Items.Food.BiomeSpecific.Hell;
using Survivaria.Items.Food.BiomeSpecific.Jungle;
using Survivaria.Items.Food.BiomeSpecific.Purity;
using Survivaria.Items.Food.BiomeSpecific.Underground;
using Survivaria.Items.Materials;
using Terraria;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace Survivaria.Tiles.Plants
{
	public class FrambosiaPlant : ModTile
	{
		public override void SetDefaults() {
            Main.tileFrameImportant[Type] = true;
            Main.tileCut[Type] = false;
            Main.tileLighted[Type] = true;
            Main.tileNoFail[Type] = true;
            Main.tileSpelunker[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style1x1);
            TileObjectData.newTile.AnchorTop = new AnchorData(AnchorType.SolidTile, TileObjectData.newTile.Width, 0);
            TileObjectData.newTile.AnchorBottom = AnchorData.Empty;
            TileObjectData.newTile.DrawYOffset = -2;
            TileObjectData.newTile.AnchorValidTiles = new[]
			{
                367, //TileID.Marble
			};
			TileObjectData.addTile(Type);
		}

		public override bool Drop(int i, int j) {
			int stage = Main.tile[i, j].frameX / 18;
			if (stage == 2) {
				Item.NewItem(i * 16, j * 16, 0, 0, ModContent.ItemType<Frambosia>());
			}
			return false;
		}

        public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
        {
            int stage = Main.tile[i, j].frameX / 18;
            if (stage == 2)
            {
                r = 0.09f;
                g = 0.09f;
                b = 0.03f;
            }
            if (stage == 1)
            {
                r = 0.05f;
                g = 0.05f;
                b = 0.02f;
            }
            if (stage == 0)
            {
                r = 0.02f;
                g = 0.02f;
                b = 0.01f;
            }
        }

        public override void RandomUpdate(int i, int j) {
			if (Main.tile[i, j].frameX == 0) {
				Main.tile[i, j].frameX += 18;
			}
			else if (Main.tile[i, j].frameX == 18) {
				Main.tile[i, j].frameX += 18;
			}
		}
		//public override void RightClick(int i, int j)
		//{
		//	base.RightClick(i, j);
		//}
	}
}
