using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Survivaria.Buffs
{
    public class QueenBuff : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Heir Not");
            Description.SetDefault("Increased movement speed and vision. Bees are now non-hostile. Gives honey while in the jungle.");
            Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = false;
        }
        public override void Update(Player player, ref int buffIndex)
        {
			player.moveSpeed += 0.22f;
			player.nightVision = true;
			player.npcTypeNoAggro[NPCID.Hornet] = true;
			player.npcTypeNoAggro[NPCID.MossHornet] = true;
			player.npcTypeNoAggro[NPCID.Bee] = true;
			player.npcTypeNoAggro[NPCID.BeeSmall] = true;
			player.npcTypeNoAggro[NPCID.HornetFatty] = true;
			player.npcTypeNoAggro[NPCID.HornetHoney] = true;
			player.npcTypeNoAggro[NPCID.HornetLeafy] = true;
			player.npcTypeNoAggro[NPCID.HornetStingy] = true;
			player.npcTypeNoAggro[NPCID.HornetSpikey] = true;
			player.npcTypeNoAggro[NPCID.VortexHornetQueen] = true;
			player.npcTypeNoAggro[NPCID.VortexHornet] = true;
			if(player.ZoneJungle) player.AddBuff(BuffID.Honey, 2);
        }
    }
}
