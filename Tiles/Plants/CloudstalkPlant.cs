using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Survivaria.Items.Food.BiomeSpecific.Space;
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
	public class CloudstalkPlant : ModTile
	{
		public override void SetDefaults() {
			Main.tileFrameImportant[Type] = true;
			Main.tileCut[Type] = false;
            Main.tileLighted[Type] = true;
            Main.tileNoFail[Type] = true;
            Main.tileWaterDeath[Type] = true;
            Main.tileSpelunker[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style1x1);
            TileObjectData.newTile.AnchorTop = new AnchorData(AnchorType.SolidTile, TileObjectData.newTile.Width, 0);
            TileObjectData.newTile.AnchorBottom = AnchorData.Empty;
            TileObjectData.newTile.DrawYOffset = -2;
            TileObjectData.newTile.WaterDeath = true;
            TileObjectData.newTile.AnchorValidTiles = new[]
			{
				189, //TileID.Cloud
			};
            ModTranslation name = CreateMapEntryName();
            name.SetDefault("Cloudstalk");
            AddMapEntry(new Color(79, 191, 27), name);
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
					if (stage == 2)
					{
							Item.NewItem(i * 16, j * 16, 0, 0, ModContent.ItemType<CloudstalkSeed>());
					}
			}
			else if (player.HeldItem.type == ModContent.ItemType<LeadTrowel>() || player.HeldItem.type == ModContent.ItemType<IronTrowel>())
			{
					if (stage == 2 && Main.rand.Next(3) == 0)
					{
							Item.NewItem(i * 16, j * 16, 0, 0, ModContent.ItemType<CloudstalkSeed>());
					}
			}
			if (stage == 2) {
				Item.NewItem(i * 16, j * 16, 0, 0, ModContent.ItemType<Cloudstalk>());
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
