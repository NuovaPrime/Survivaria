using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Survivaria.Items.Food.BiomeSpecific.Snow;
using Survivaria.Items.Misc;
using Survivaria.Items.Misc.Seeds;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace Survivaria.Tiles.Plants
{
	public class PearlBerryPlant : ModTile
	{
		public override void SetDefaults() {
			Main.tileFrameImportant[Type] = true;
            Main.tileLighted[Type] = true;
			Main.tileCut[Type] = false;
			Main.tileNoFail[Type] = true;
            Main.tileWaterDeath[Type] = true;
            Main.tileSpelunker[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style1x1);
            TileObjectData.newTile.DrawYOffset = 1;
            TileObjectData.newTile.WaterDeath = true;
            TileObjectData.newTile.AnchorValidTiles = new[]
			{
				147, //TileID.SnowBlock
			};
            ModTranslation name = CreateMapEntryName();
            name.SetDefault("Pearl Berry");
            AddMapEntry(new Color(66, 66, 65), name);
            TileObjectData.addTile(Type);
		}
		public override void SetSpriteEffects(int i, int j, ref SpriteEffects spriteEffects) {
			if (i % 2 == 1) {
				spriteEffects = SpriteEffects.FlipHorizontally;
			}
		}

		public override bool Drop(int i, int j) {
			int stage = Main.tile[i, j].frameX / 18;
			Player player = Main.LocalPlayer;
			if (player.HeldItem.type == ModContent.ItemType<DynastyTrowel>())
			{
					if (stage == 2 && Main.rand.Next(3) == 0)
					{
							Item.NewItem(i * 16, j * 16, 0, 0, ModContent.ItemType<PearlBerrySeed>());
					}
			}
			else if (player.HeldItem.type == ModContent.ItemType<LeadTrowel>() || player.HeldItem.type == ModContent.ItemType<IronTrowel>())
			{
					if (stage == 2 && Main.rand.Next(5) == 0)
					{
							Item.NewItem(i * 16, j * 16, 0, 0, ModContent.ItemType<PearlBerrySeed>());
					}
			}
			if (stage == 2) {
				Item.NewItem(i * 16, j * 16, 0, 0, ModContent.ItemType<PearlBerry>());
			}
			return false;
		}

        public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
        {
            r = 0f;
            g = 0.09f;
            b = 0.33f;
        }

        public override void RandomUpdate(int i, int j) {
			if (Main.tile[i, j].frameX == 0) {
                if (Main.rand.Next(5) == 0) Main.tile[i, j].frameX += 18;
			}
			else if (Main.tile[i, j].frameX == 18) {
                if (Main.rand.Next(5) == 0) Main.tile[i, j].frameX += 18;
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
