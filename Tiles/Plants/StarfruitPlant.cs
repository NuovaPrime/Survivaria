using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Survivaria.Items.Food.BiomeSpecific.Space;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace Survivaria.Tiles.Plants
{
	public class StarfruitPlant : ModTile
	{
		public override void SetDefaults() {
			Main.tileFrameImportant[Type] = true;
			Main.tileCut[Type] = false;
            Main.tileLighted[Type] = true;
            Main.tileNoFail[Type] = true;
            Main.tileWaterDeath[Type] = true;
            Main.tileSpelunker[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style1x1);
            TileObjectData.newTile.DrawYOffset = 1;
            TileObjectData.newTile.WaterDeath = true;
            TileObjectData.newTile.AnchorValidTiles = new[]
			{
				2, //TileID.Grass
			};
            ModTranslation name = CreateMapEntryName();
            name.SetDefault("Starfruit");
            AddMapEntry(new Color(219, 212, 79), name);
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
				Item.NewItem(i * 16, j * 16, 0, 0, ModContent.ItemType<Starfruit>());
			}
			return false;
		}
        public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
        {
            r = 0f;
            g = 0.05f;
            b = 0.3f;
        }

        public override void RandomUpdate(int i, int j) {
			if (Main.tile[i, j].frameX == 0) {
                if (Main.rand.Next(4) == 0) Main.tile[i, j].frameX += 18;
			}
			else if (Main.tile[i, j].frameX == 18) {
                if (Main.rand.Next(4) == 0) Main.tile[i, j].frameX += 18;
			}
		}
		//public override void RightClick(int i, int j)
		//{
		//	base.RightClick(i, j);
		//}
	}
}
