using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Survivaria.Items.Drinks;
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
    public class SurvivariaWorld : ModWorld
    {
        /*public override void PostUpdate()
        {
            GeneratePlants();
        }

        public void GeneratePlants()
        {
            int tileToPlace = mod.TileType<PeppermintPlant>();
            int x = WorldGen.genRand.Next(0, Main.maxTilesX);
            int y = WorldGen.genRand.Next(0, );
            if (WorldGen.genRand.Next(100) == 0)
            {
                if (Main.tile[x, y].type == TileID.Grass && !Main.tile[x, y - 1].active())
                {
                    WorldGen.PlaceTile(x, y - 1, tileToPlace);
                    Main.NewText("Plant placed at: " + new Vector2(x, y));
                }
                    
            }

        }*/

        public override void PostWorldGen()
        {
            int[] itemsToPlaceInChests = { mod.ItemType<EmptyGourd>() };
            int itemsToPlaceInChestsChoice = 0;
            for (int chestIndex = 0; chestIndex < 1000; chestIndex++)
            {
                Chest chest = Main.chest[chestIndex];
                if (chest != null && Main.tile[chest.x, chest.y].type == TileID.Containers && Main.tile[chest.x, chest.y].frameX == 0 * 36)
                {
                    for (int inventoryIndex = 0; inventoryIndex < 40; inventoryIndex++)
                    {
                        if (chest.item[inventoryIndex].type == 0)
                        {
                            if (Main.rand.Next(4) == 0)
                            {
                                chest.item[inventoryIndex].SetDefaults(itemsToPlaceInChests[itemsToPlaceInChestsChoice]);
                                itemsToPlaceInChestsChoice = (itemsToPlaceInChestsChoice + 1) % itemsToPlaceInChests.Length;
                                // Alternate approach: Random instead of cyclical: chest.item[inventoryIndex].SetDefaults(Main.rand.Next(itemsToPlaceInIceChests));
                                break;
                            }   
                        }
                    }
                }
            }
        }
    }
}
