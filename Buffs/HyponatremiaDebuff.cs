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
    public class HyponatremiaDebuff : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Hyponatremia");
            Description.SetDefault("You've drank too much.\nUnable to drink, lowered health regen, slightly lowered damage, increased hunger drain rate.");
            Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = true;
            Main.persistentBuff[Type] = true;
            //canBeCleared = false;
        }

		public override void Update(Player player, ref int buffIndex)
        {
            SurvivariaPlayer modPlayer = player.GetModPlayer<SurvivariaPlayer>();
            player.lifeRegen -= 1;
            player.allDamageMult -= 0.08f;
            modPlayer.HungerLossMulti += 0.10f;
        }
    }
}
