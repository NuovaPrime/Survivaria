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
    public class DehydratedDebuff : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Dehydrated");
            Description.SetDefault("Damage and speed greatly decreased.\nGreatly increased mana cost.\nConsider drinking now.");
            Main.buffNoTimeDisplay[Type] = true;
            Main.debuff[Type] = true;
        }

		public override void Update(Player player, ref int buffIndex)
        {
        }
    }
}
