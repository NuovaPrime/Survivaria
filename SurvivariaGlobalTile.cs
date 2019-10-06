using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Survivaria.Items.Food.BiomeSpecific.Desert;
using Survivaria.Items.Food.BiomeSpecific.Jungle;
using Survivaria.Items.Food.BiomeSpecific.Purity;
using Survivaria.Items.Materials;
using Survivaria.Tiles.Plants;
using System.Collections.Generic;
using System.IO;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.Generation;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Terraria.World.Generation;

namespace Survivaria
{
    public class SurvivariaGlobalTile : GlobalTile
    {
        public override bool Drop(int i, int j, int type) //Thanks antiaris for this
        {
            if (Main.netMode != 1 && !WorldGen.noTileActions && !WorldGen.gen)
            {
                if (type == TileID.Trees && Main.tile[i, j + 1].type == TileID.Grass)
                {
                    Item.NewItem(i * 16, (j - 5) * 16, 32, 32, mod.ItemType<Guavado>(), Main.rand.Next(1, 2));
                }
                if (type == TileID.Cactus && Main.tile[i, j + 1].type == TileID.Sand)
                {
                    Item.NewItem(i * 16, (j - 5) * 16, 32, 32, mod.ItemType<Date>(), 1);
                }
                if (type == TileID.Sand && Main.tile[i, j - 1].type == TileID.Cactus)
                {
                    Item.NewItem(i * 16, (j - 5) * 16, 32, 32, mod.ItemType<Date>(), 1);
                }
                if (type == TileID.Trees && (Main.tile[i, j + 1].type == TileID.Mud || Main.tile[i, j + 1].type == TileID.JungleGrass))
                {
                    Item.NewItem(i * 16, (j - 5) * 16, 32, 32, mod.ItemType<DragonFruit>(), Main.rand.Next(1, 2));
                }
                if ((Main.tile[i, j].type == TileID.Plants || Main.tile[i, j - 1].type == TileID.Plants2) && type != TileID.Trees && type != TileID.MushroomPlants && type != 0)
                {
                    if (Main.rand.Next(5) == 0)
                        Item.NewItem(i * 16, (j) * 16, 20, 30, mod.ItemType<BlossomWheat>(), 1);
                }
            }
            return base.Drop(i, j, type);
        }
        public override void RandomUpdate(int i, int j, int type)
        {
            if ((Main.tile[i, j].type == TileID.Grass || Main.tile[i, j].type == TileID.Plants || Main.tile[i, j].type == TileID.Plants2) && !Main.tile[i, j - 1].active() && Main.tile[i, j].slope() == 0 && Main.dayTime)
            {
                if (Main.rand.Next(100) == 0)
                {
                    WorldGen.PlaceTile(i, j - 1, mod.TileType<PeppermintPlant>(), true, true);
                    //Main.NewText("Plant placed at: " + new Vector2(i, j));
                }
            }
            if ((Main.tile[i, j].type == TileID.JungleGrass || Main.tile[i, j].type == TileID.JunglePlants || Main.tile[i, j].type == TileID.JunglePlants2) && !Main.tile[i, j - 1].active() && Main.tile[i, j].slope() == 0 && Main.dayTime)
            {
                if (Main.rand.Next(100) == 0)
                {
                    WorldGen.PlaceTile(i, j - 1, mod.TileType<CorneyPlant>(), true, true);
                }
            }
            base.RandomUpdate(i, j, type);
        }
    }
}
