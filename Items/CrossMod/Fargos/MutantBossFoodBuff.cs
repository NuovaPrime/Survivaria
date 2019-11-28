using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Survivaria.Items.CrossMod.Fargos
{
    public class MutantBossFoodBuff : ModBuff
    {
        int timer = 0;
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Cursed Strength");
            Description.SetDefault("You feel immortal, but you also feel uneasy.");
            Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = false;
        }
        public override bool Autoload(ref string name, ref string texture)
        {
            return ModLoader.GetMod("FargowiltasSouls") != null;
        }
        public override void Update(Player player, ref int buffIndex)
        {
            timer++;
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
			player.allDamageMult += 100f;
            player.endurance += 100f;
            player.statLifeMax2 += 100000;
            if (timer == 295)
            {
                if (player.statLife > 0 && player.active)
                {
                    player.KillMe(PlayerDeathReason.ByCustomReason(player.name + " was killed from the inside by Mutant."), 10000, player.direction);
                    player.ResetEffects();
                    NPC.NewNPC((int)player.Center.X, (int)player.Center.Y, ModLoader.GetMod("FargowiltasSouls").NPCType("MutantBoss"));
                    timer = 0;
                }               
                else
                {
                    player.ClearBuff(Type);
                    timer = 0;
                }
                    
            }
        }
    }
}
