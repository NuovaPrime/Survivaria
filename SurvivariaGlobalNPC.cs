using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Survivaria.Items.BossItems;

namespace Survivaria
{
    public class SurvivariaGlobalNPC : GlobalNPC
    {
        public override bool InstancePerEntity
        {
            get
            {
                return true;
            }
        }

        public override void NPCLoot(NPC npc)
        {
            if (!Main.expertMode)
            {
                if (npc.type == NPCID.KingSlime)
                {
                    if (Main.rand.Next(10) == 0)
                        Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType<TubofSlime>());
                }
            }
            base.NPCLoot(npc);
        }
    }
}
