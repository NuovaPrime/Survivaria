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
    public class SkeleBuff : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Corrupted...?");
            Description.SetDefault("Makes you immune to a number of buffs and debuffs, you inflict shadowflames on hit.");
            Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = false;
        }
        public override void Update(Player player, ref int buffIndex)
        {
			player.buffImmune[BuffID.Poisoned] = true;
			player.buffImmune[BuffID.Venom] = true;
			player.buffImmune[BuffID.Bleeding] = true;
			player.buffImmune[BuffID.Weak] = true;
			player.buffImmune[BuffID.Silenced] = true;
			player.buffImmune[BuffID.Cursed] = true;
			player.buffImmune[BuffID.Confused] = true;
			player.buffImmune[BuffID.CursedInferno] = true;
			player.buffImmune[BuffID.Ichor] = true;
			player.buffImmune[BuffID.ShadowFlame] = true;
			player.buffImmune[BuffID.Stinky] = true;
			player.buffImmune[BuffID.DryadsWard] = true;
			player.buffImmune[BuffID.Sunflower] = true;
			player.buffImmune[BuffID.Campfire] = true;
			player.buffImmune[BuffID.Honey] = true;
			player.buffImmune[BuffID.HeartLamp] = true;
        }
    }
}
