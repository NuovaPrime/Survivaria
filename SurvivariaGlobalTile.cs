using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Survivaria.Items.Food.BiomeSpecific.Corruption;
using Survivaria.Items.Food.BiomeSpecific.Crimson;
using Survivaria.Items.Food.BiomeSpecific.Desert;
using Survivaria.Items.Food.BiomeSpecific.Hallow;
using Survivaria.Items.Food.BiomeSpecific.Jungle;
using Survivaria.Items.Food.BiomeSpecific.Purity;
using Survivaria.Items.Food.BiomeSpecific.Snow;
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
                int r = 3;
                if (Main.expertMode) r++;
                if (Main.rand.Next(r) == 0)
                {
                    if (type == TileID.Trees && Main.tile[i, j + 1].type == TileID.Grass)
                    {
                        Item.NewItem(i * 16, (j - 5) * 16, 32, 32, ModContent.ItemType<Guavado>(), Main.rand.Next(1, 2));
                    }
                    if (type == TileID.Cactus && Main.tile[i, j + 1].type == TileID.Sand)
                    {
                        Item.NewItem(i * 16, (j - 5) * 16, 32, 32, ModContent.ItemType<Date>(), 1);
                    }
                    if (type == TileID.Sand && Main.tile[i, j - 1].type == TileID.Cactus)
                    {
                        Item.NewItem(i * 16, (j - 5) * 16, 32, 32, ModContent.ItemType<Date>(), 1);
                    }
                    if (type == TileID.Trees && (Main.tile[i, j + 1].type == TileID.Mud || Main.tile[i, j + 1].type == TileID.JungleGrass))
                    {
                        Item.NewItem(i * 16, (j - 5) * 16, 32, 32, ModContent.ItemType<DragonFruit>(), Main.rand.Next(1, 2));
                    }
                    if (type == TileID.Trees && (Main.tile[i, j + 1].type == TileID.CorruptGrass))
                    {
                        Item.NewItem(i * 16, (j - 5) * 16, 32, 32, ModContent.ItemType<PutridOlives>(), Main.rand.Next(1, 2));
                    }
                    if (type == TileID.Trees && (Main.tile[i, j + 1].type == TileID.FleshGrass))
                    {
                        Item.NewItem(i * 16, (j - 5) * 16, 32, 32, ModContent.ItemType<Greneyede>(), Main.rand.Next(1, 2));
                    }
                    if (type == TileID.Trees && (Main.tile[i, j + 1].type == TileID.HallowedGrass))
                    {
                        Item.NewItem(i * 16, (j - 5) * 16, 32, 32, ModContent.ItemType<RockCandy>(), Main.rand.Next(1, 2));
                    }
                    if (type == TileID.PalmTree && (Main.tile[i, j + 1].type == TileID.Sand || Main.tile[i, j + 1].type == TileID.Ebonsand || Main.tile[i, j + 1].type == TileID.Crimsand || Main.tile[i, j + 1].type == TileID.Pearlsand))
                    {
                        Item.NewItem(i * 16, (j - 5) * 16, 32, 32, ModContent.ItemType<Cocolate>(), Main.rand.Next(1, 2));
                    }
                    if (type == TileID.Trees && (Main.tile[i, j + 1].type == TileID.SnowBlock))
                    {
                        Item.NewItem(i * 16, (j - 5) * 16, 32, 32, ModContent.ItemType<FrostPlum>(), Main.rand.Next(1, 2));
                    }
                }
                /*if ((Main.tile[i, j].type == TileID.Plants || Main.tile[i, j - 1].type == TileID.Plants2) && type != TileID.Trees && type != TileID.MushroomPlants && type != 0)
                {
                    if (Main.rand.Next(5) == 0)
                        Item.NewItem(i * 16, (j) * 16, 20, 30, ModContent.ItemType<BlossomWheat>(), 1);
                }*/
            }
            return base.Drop(i, j, type);
        }
        public override void RandomUpdate(int i, int j, int type)
        {
            float u = 160 * ModContent.GetInstance<SurvivariaConfigServer>().PlantGrowthRateMulti;
            if (Main.expertMode) u *= 1.1f;
            if ((Main.tile[i, j].type == TileID.Grass && Main.tile[i, j + 1].wall != WallID.Cloud && (Main.tile[i, j - 1].type == TileID.Plants || Main.tile[i, j - 1].type == TileID.Plants2 || !Main.tile[i, j - 1].active())) && Main.tile[i, j].slope() == 0 && j < Main.worldSurface && Main.dayTime && Main.hardMode && NPC.downedMechBossAny)
            {
                if (Main.rand.NextFloat(u*1.1f) < 1)
                {
                    WorldGen.PlaceTile(i, j - 2, ModContent.TileType<PeppermintPlant>(), true, true);
                    //Main.NewText("Plant placed at: " + new Vector2(i, j));
                }
            }
            if ((Main.tile[i, j].type == TileID.JungleGrass && (Main.tile[i, j - 1].type == TileID.JunglePlants || Main.tile[i, j - 1].type == TileID.JunglePlants2 || !Main.tile[i, j - 1].active())) && Main.tile[i, j].slope() == 0 && j < Main.rockLayer && Main.dayTime && NPC.downedQueenBee)
            {
                if (Main.rand.NextFloat(u*1.25f) < 1)
                {
                    WorldGen.PlaceTile(i, j - 3, ModContent.TileType<CorneyPlant>(), true, true);
                }
            }
            if (Main.tile[i, j].type == TileID.JungleGrass && (Main.tile[i, j + 1].type == TileID.JunglePlants || Main.tile[i, j + 1].type == TileID.JunglePlants2 || Main.tile[i, j + 1].type == TileID.JungleVines || !Main.tile[i, j + 1].active()) && Main.tile[i, j].slope() == 0 && j > Main.rockLayer)
            {
                if (Main.rand.NextFloat(u*1.5f) < 1)
                {
                    WorldGen.PlaceTile(i, j + 1, ModContent.TileType<EnigmaticRootPlant>(), true, true);
                }
            }
            if ((Main.tile[i, j].type == TileID.MushroomGrass && (Main.tile[i, j - 1].type == TileID.MushroomPlants || !Main.tile[i, j - 1].active()) && Main.tile[i, j].slope() == 0))
            {
                if (Main.rand.NextFloat(u*1.1f) < 1)
                {
                    WorldGen.PlaceTile(i, j - 1, ModContent.TileType<MushyCarrotPlant>(), true, true);
                }
            }
            if ((Main.tile[i, j].type == TileID.CorruptGrass && (Main.tile[i, j - 1].type == TileID.CorruptPlants || !Main.tile[i, j - 1].active()) && Main.tile[i, j].slope() == 0 && !Main.dayTime) && j < Main.worldSurface && NPC.downedBoss2)
            {
                if (Main.rand.NextFloat(u*0.9f) < 1)
                {
                    WorldGen.PlaceTile(i, j - 1, ModContent.TileType<CursedEggplantPlant>(), true, true);
                }
            }
            if ((Main.tile[i, j].type == TileID.FleshGrass && (Main.tile[i, j - 1].type == TileID.FleshWeeds || !Main.tile[i, j - 1].active()) && Main.tile[i, j].slope() == 0 && !Main.dayTime) && j < Main.worldSurface && NPC.downedBoss2)
            {
                if (Main.rand.NextFloat(u*0.9f) < 1)
                {
                    WorldGen.PlaceTile(i, j - 1, ModContent.TileType<BleedRootPlant>(), true, true);
                }
            }
            if (Main.tile[i, j].type == TileID.SnowBlock && Main.tile[i, j].slope() == 0 && !Main.tile[i, j - 1].active() && j < Main.rockLayer && Main.dayTime)
            {
                if (Main.rand.NextFloat(u*1.5f) < 1)
                {
                    WorldGen.PlaceTile(i, j - 1, ModContent.TileType<PearlBerryPlant>(), true, true);
                }
            }
            if ((Main.tile[i, j].type == TileID.Grass && Main.tile[i, j + 1].wall != WallID.Cloud && (Main.tile[i, j - 1].type == TileID.Plants || Main.tile[i, j - 1].type == TileID.Plants2 || !Main.tile[i, j - 1].active())) && Main.tile[i, j].slope() == 0 && j < Main.worldSurface && Main.dayTime)
            {
                if (Main.rand.NextFloat(u*1.3f) < 1)
                {
                    WorldGen.PlaceTile(i, j - 1, ModContent.TileType<ReecePlant>(), true, true);
                }
            }
            if ((Main.tile[i, j].type == TileID.HallowedGrass && (Main.tile[i, j - 1].type == TileID.HallowedPlants || Main.tile[i, j - 1].type == TileID.HallowedPlants2 || !Main.tile[i, j - 1].active())) && Main.tile[i, j].slope() == 0 && j < Main.rockLayer && Main.dayTime)
            {
                if (Main.rand.NextFloat(u) < 1)
                {
                    WorldGen.PlaceTile(i, j - 2, ModContent.TileType<SparklingBerryPlant>(), true, true);
                }
            }
            if ((Main.tile[i, j].type == TileID.Sand || Main.tile[i, j].type == ModLoader.GetMod("TerrariaOverhaul").TileType("WetSand")) && !Main.tile[i, j - 1].active() && Main.tile[i, j - 1].liquid > 0 && Main.tile[i, j].slope() == 0 && (i < 380 || i > Main.maxTilesX - 380) && j < Main.worldSurface && Main.dayTime)
            {
                if (Main.rand.NextFloat(u*1.1f) < 1)
                {
                    WorldGen.PlaceTile(i, j - 3, ModContent.TileType<AmalgaePlant>(), true, true);
                }
            }
            if ((Main.tile[i, j].type == TileID.Sand || Main.tile[i, j].type == ModLoader.GetMod("TerrariaOverhaul").TileType("WetSand")) && !Main.tile[i, j - 1].active() && !Main.tile[i + 1, j - 1].active() && Main.tile[i, j].slope() == 0 && 380 < i && i < Main.maxTilesX - 380 && j < Main.worldSurface && Main.dayTime)
            {
                if (Main.rand.NextFloat(u*1.15f) < 1)
                {
                    switch (Main.rand.Next(5))
                    {
                        case 0:
                            WorldGen.PlaceTile(i, j - 1, ModContent.TileType<PricklyPearOrangePlant>(), true, true);
                            break;
                        case 1:
                            WorldGen.PlaceTile(i, j - 1, ModContent.TileType<PricklyPearMagentaPlant>(), true, true);
                            break;
                        case 2:
                            WorldGen.PlaceTile(i, j - 1, ModContent.TileType<PricklyPearRedPlant>(), true, true);
                            break;
                        case 3:
                            WorldGen.PlaceTile(i, j - 1, ModContent.TileType<PricklyPearWhitePlant>(), true, true);
                            break;
                        case 4:
                            WorldGen.PlaceTile(i, j - 1, ModContent.TileType<PricklyPearYellowPlant>(), true, true);
                            break;
                    }
                }
            }
            if (Main.tile[i, j].type == TileID.Ash && !Main.tile[i, j + 1].active() && Main.tile[i, j].slope() == 0 && j > Main.maxTilesY - 220)
            {
                if (Main.rand.NextFloat(u*1.3f) < 1)
                {
                    WorldGen.PlaceTile(i, j + 1, ModContent.TileType<FireTuberPlant>(), true, true);
                }
            }
            if (Main.tile[i, j].type == TileID.Ash && !Main.tile[i, j - 1].active() && Main.tile[i, j].slope() == 0 && j > Main.maxTilesY - 220 && NPC.downedBoss3)
            {
                if (Main.rand.NextFloat(u*1.3f) < 1)
                {
                    WorldGen.PlaceTile(i, j - 1, ModContent.TileType<AshStrawPlant>(), true, true);
                }
            }
            if (Main.tile[i, j].type == TileID.Grass && Main.tile[i, j + 1].wall == WallID.Cloud && (Main.tile[i, j - 1].type == TileID.Plants || Main.tile[i, j - 1].type == TileID.Plants2 || !Main.tile[i, j - 1].active()) && Main.tile[i, j].slope() == 0 && j < Main.worldSurface)
            {
                if (Main.rand.NextFloat(u*1f) < 1)
                {
                    WorldGen.PlaceTile(i, j - 1, ModContent.TileType<StarfruitPlant>(), true, true);
                }
            }
            if ((Main.tile[i, j].type == TileID.Cloud) && !Main.tile[i, j + 1].active() && Main.tile[i, j].slope() == 0 && j < Main.worldSurface && NPC.downedSlimeKing)
            {
                if (Main.rand.NextFloat(u*1.1f) < 1)
                {
                    WorldGen.PlaceTile(i, j + 1, ModContent.TileType<CloudstalkPlant>(), true, true);
                }
            }
            if (Main.tile[i, j].type == TileID.JungleGrass && (Main.tile[i, j - 1].type == TileID.JunglePlants || Main.tile[i, j - 1].type == TileID.JunglePlants2 || !Main.tile[i, j - 1].active()) && Main.tile[i, j].slope() == 0 && j > Main.rockLayer && NPC.downedPlantBoss)
            {
                if (Main.rand.NextFloat(u*1.25f) < 1)
                {
                    WorldGen.PlaceTile(i, j - 1, ModContent.TileType<GuarleekPlant>(), true, true);
                }
            }
            if (Main.tile[i, j].type == TileID.Granite && !Main.tile[i, j - 1].active() && Main.tile[i, j].slope() == 0 && NPC.downedBoss1)
            {
                if (Main.rand.NextFloat(u*1.25f) < 1)
                {
                    WorldGen.PlaceTile(i, j - 1, ModContent.TileType<GranutPlant>(), true, true);
                }
            }
            if (Main.tile[i, j].type == TileID.Marble && !Main.tile[i, j + 1].active() && Main.tile[i, j].slope() == 0 && NPC.downedBoss1)
            {
                if (Main.rand.NextFloat(u*1.2f) < 1)
                {
                    WorldGen.PlaceTile(i, j + 1, ModContent.TileType<FrambosiaPlant>(), true, true);
                }
            }
            if (Main.tile[i, j].type == TileID.Grass && Main.tile[i, j + 1].wall != WallID.Cloud && (Main.tile[i, j - 1].type == TileID.Plants || Main.tile[i, j - 1].type == TileID.Plants2 || !Main.tile[i, j - 1].active()) && Main.tile[i, j].slope() == 0 && j < Main.worldSurface && Main.dayTime)
            {
                if (Main.rand.NextFloat(u*1.3f) < 1)
                {
                    WorldGen.PlaceTile(i, j - 1, ModContent.TileType<BlossomWheatPlant>(), true, true);
                }
            }
            base.RandomUpdate(i, j, type);
        }
    }
}
