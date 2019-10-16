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
    public class WellHydratedBuff : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Well Hydrated");
            Description.SetDefault("Minor increase to damage and mining speed.\nSlightly reduced mana cost.");
            Main.buffNoTimeDisplay[Type] = true;
            Main.debuff[Type] = false;
        }

		public override void Update(Player player, ref int buffIndex)
        {
        }
    }
}
