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
    public class EaterBuff : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Fed Up");
            Description.SetDefault("Halved hunger rate. Immune to poison. Attacks have a slight chance to inflict cursed flames.");
            Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = false;
        }
        public override void Update(Player player, ref int buffIndex)
        {
			player.buffImmune[BuffID.Poisoned] = true;
        }
    }
}
