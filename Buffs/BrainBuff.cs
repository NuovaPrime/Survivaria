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
    public class BrainBuff : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Dissociated");
            Description.SetDefault("Gives immunity to most debuffs but lowers damage.");
            Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = false;
        }
        public override void Update(Player player, ref int buffIndex)
        {
			player.buffImmune[BuffID.Poisoned] = true;
			player.buffImmune[BuffID.Venom] = true;
			player.buffImmune[BuffID.Darkness] = true;
			player.buffImmune[BuffID.Blackout] = true;
			player.buffImmune[BuffID.Silenced] = true;
			player.buffImmune[BuffID.Cursed] = true;
			player.buffImmune[BuffID.Confused] = true;
			player.buffImmune[BuffID.Slow] = true;
			player.buffImmune[BuffID.Chilled] = true;
			player.buffImmune[BuffID.Warmth] = true;
			player.buffImmune[BuffID.Stoned] = true;
			player.buffImmune[BuffID.VortexDebuff] = true;
			player.allDamageMult -= 0.18f;
        }
    }
}
