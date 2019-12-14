using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Survivaria.Items.Food.BiomeSpecific.Underground;
using Survivaria.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace Survivaria.Tiles.Plants
{
	public class GranutPlant : ModTile
	{
		public override void SetDefaults() {
			Main.tileFrameImportant[Type] = true;
			Main.tileCut[Type] = false;
            Main.tileLighted[Type] = true;
            Main.tileNoFail[Type] = true;
            Main.tileSpelunker[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style1x1);
            TileObjectData.newTile.DrawYOffset = 1;
            TileObjectData.newTile.AnchorValidTiles = new[]
			{
                368, //TileID.Granite
			};
            ModTranslation name = CreateMapEntryName();
            name.SetDefault("Granut");
            AddMapEntry(new Color(41, 193, 217), name);
            TileObjectData.addTile(Type);
		}
		public override void SetSpriteEffects(int i, int j, ref SpriteEffects spriteEffects) {
			if (i % 2 == 1) {
				spriteEffects = SpriteEffects.FlipHorizontally;
			}
		}

		public override bool Drop(int i, int j) {
			int stage = Main.tile[i, j].frameX / 18;
			if (stage == 2) {
				Item.NewItem(i * 16, j * 16, 0, 0, ModContent.ItemType<Granut>());
			}
			return false;
		}

        public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
        {
            int stage = Main.tile[i, j].frameX / 18;
            if (stage == 2)
            {
                r = 0f;
                g = 0.10f;
                b = 0.70f;
            }
            if (stage == 1)
            {
                r = 0f;
                g = 0.05f;
                b = 0.30f;
            }
            if (stage == 0)
            {
                r = 0f;
                g = 0.02f;
                b = 0.10f;
            }
        }

        public override void RandomUpdate(int i, int j) {
			if (Main.tile[i, j].frameX == 0) {
                if (Main.rand.Next(4) == 0) Main.tile[i, j].frameX += 18;
			}
			else if (Main.tile[i, j].frameX == 18) {
                if (Main.rand.Next(4) == 0) Main.tile[i, j].frameX += 18;
			}
            else if (Main.tile[i, j].frameX == 36)
            {
                if (Main.rand.Next(20) == 0) WorldGen.KillTile(i, j, false, false, true);
            }
        }
		//public override void RightClick(int i, int j)
		//{
		//	base.RightClick(i, j);
		//}
	}
}
