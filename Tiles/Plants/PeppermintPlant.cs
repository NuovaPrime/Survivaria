using Microsoft.Xna.Framework.Graphics;
using Survivaria.Items.Food.BiomeSpecific.Purity;
using Terraria;
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
			TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
			TileObjectData.newTile.AnchorValidTiles = new[]
			{
				2, //TileID.Grass
			};
			TileObjectData.newTile.AnchorAlternateTiles = new[]
			{
				78, //ClayPot
				TileID.PlanterBox
			};
			TileObjectData.addTile(Type);
		}
		/*public override void SetSpriteEffects(int i, int j, ref SpriteEffects spriteEffects) {
			if (i % 2 == 1) {
				spriteEffects = SpriteEffects.FlipHorizontally;
			}
		}*/

		public override bool Drop(int i, int j) {
			int stage = Main.tile[i, j].frameX / 18 * 2;
			if (stage == 2) {
				Item.NewItem(i * 16, j * 16, 0, 0, mod.ItemType<Peppermint>());
			}
			return false;
		}

		public override void RandomUpdate(int i, int j) {
			if (Main.tile[i, j].frameX == 0) {
				Main.tile[i, j].frameX += 36;
			}
			else if (Main.tile[i, j].frameX == 36) {
				Main.tile[i, j].frameX += 36;
			}
		}
		//public override void RightClick(int i, int j)
		//{
		//	base.RightClick(i, j);
		//}
	}
}