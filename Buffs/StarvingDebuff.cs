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
    public class StarvingDebuff : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Starving");
            Description.SetDefault("Max life, regeneration and speed greatly decreased.\nLife and mana loss.\nConsider eating immediately!");
            Main.buffNoTimeDisplay[Type] = true;
            Main.debuff[Type] = true;
        }

		public override void Update(Player player, ref int buffIndex)
        {
        }
    }
}
