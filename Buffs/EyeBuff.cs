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
    public class EyeBuff : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Raging");
            Description.SetDefault("Increased melee damage and speed. Increased damage taken. Shows enemies.");
            Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = false;
        }
        public override void Update(Player player, ref int buffIndex)
        {
			player.moveSpeed += 0.26f;
			player.meleeSpeed += 0.26f;
			player.meleeDamage += 0.26f;
			player.endurance -= 0.34f;
			player.detectCreature = true;
        }
    }
}
