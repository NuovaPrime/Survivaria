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
}
