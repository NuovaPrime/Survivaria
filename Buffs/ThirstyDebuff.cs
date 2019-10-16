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
    public class ThirstyDebuff : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Thirsty");
            Description.SetDefault("Damage and speed decreased.\nIncreased mana cost.\nConsider drinking a little bit.");
            Main.buffNoTimeDisplay[Type] = true;
            Main.debuff[Type] = true;
        }

		public override void Update(Player player, ref int buffIndex)
        {
        }
    }
}
