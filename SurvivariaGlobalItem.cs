using Survivaria.Items.BossItems;
using Survivaria.Items.Food.BiomeSpecific.Desert;
using Survivaria.Items.Food.BiomeSpecific.Jungle;
using Survivaria.Items.Food.BiomeSpecific.Purity;
using Survivaria.Items.Materials;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Survivaria
{
    public class SurvivariaGlobalItem : GlobalItem
    {
        public override void OpenVanillaBag(string context, Player player, int arg)
        {
            if (Main.rand.Next(10) == 0)
            {
                if (context == "bossBag" && arg == ItemID.KingSlimeBossBag)
                {
                    player.QuickSpawnItem(mod.ItemType<TubofSlime>());
                }
            }
        }
    }

    public class SurvivariaGlobalTile : GlobalTile
    {
        public override bool Drop(int i, int j, int type) //Thanks antiaris for this
        {
            if (Main.netMode != 1 && !WorldGen.noTileActions && !WorldGen.gen)
            {
                if (type == TileID.Trees && Main.tile[i, j + 1].type == TileID.Grass)
                {
                    Item.NewItem(i * 16, (j - 5) * 16, 32, 32, mod.ItemType<Guavado>(), Main.rand.Next(0, 3));
                }
                if (type == TileID.Cactus && Main.tile[i, j + 1].type == TileID.Sand)
                {
                    Item.NewItem(i * 16, (j - 5) * 16, 32, 32, mod.ItemType<Date>(), Main.rand.Next(0, 3));
                }
                if (type == TileID.Trees && (Main.tile[i, j + 1].type == TileID.Mud || Main.tile[i, j + 1].type == TileID.JungleGrass))
                {
                    Item.NewItem(i * 16, (j - 5) * 16, 32, 32, mod.ItemType<DragonFruit>(), Main.rand.Next(0, 3));
                }
                if (Main.tile[i, j - 1].type == TileID.Grass && type != TileID.Trees && type != TileID.MushroomPlants && type != 0)
                {
                    Item.NewItem(i * 16, (j - 5) * 16, 32, 32, mod.ItemType<BlossomWheat>(), Main.rand.Next(0, 3));
                }
            }
            return base.Drop(i, j, type);
        }
    }
}
