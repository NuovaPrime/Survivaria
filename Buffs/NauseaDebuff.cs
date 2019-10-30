using Survivaria.Players;
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
    public class NauseaDebuff : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Nausea");
            Description.SetDefault("You've eaten too much.\nUnable to eat, lowered mana regen, slightly lowered damage, increased thirst drain rate.");
            Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = true;
            Main.persistentBuff[Type] = true;
            canBeCleared = false;
        }

		public override void Update(Player player, ref int buffIndex)
        {
            SurvivariaPlayer modPlayer = player.GetModPlayer<SurvivariaPlayer>();
            player.manaRegen -= 1;
            player.allDamageMult -= 0.08f;
            modPlayer.ThirstLossMulti += 0.10f;
        }
    }
}
