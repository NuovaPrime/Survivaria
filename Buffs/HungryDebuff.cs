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
    public class HungryDebuff : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Hungry");
            Description.SetDefault("Max life, regeneration and speed slightly decreased.\nConsider eating a little bit.");
            Main.buffNoTimeDisplay[Type] = true;
            Main.debuff[Type] = true;
        }

		public override void Update(Player player, ref int buffIndex)
        {
        }
    }
}
