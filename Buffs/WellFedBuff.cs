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
    public class WellFedBuff : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Well Fed");
            Description.SetDefault("Minor increase to all stats.\nSlight regeneration boost.\nThirst drops slightly faster.");
            Main.buffNoTimeDisplay[Type] = true;
            Main.debuff[Type] = false;
        }

		public override void Update(Player player, ref int buffIndex)
        {
        }
    }
}
