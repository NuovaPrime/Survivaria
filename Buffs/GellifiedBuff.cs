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
    public class GellifiedBuff : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Gellified");
            Description.SetDefault("Increased jump height and immunity to slimes. Reduced movement speed.");
            Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = false;
        }
        internal int[] SlimeIDs = new int[] { NPCID.BlueSlime, NPCID.GreenSlime, NPCID.PurpleSlime, NPCID.RedSlime, NPCID.SandSlime, NPCID.Slimeling, NPCID.Slimer, NPCID.Slimer2, NPCID.YellowSlime, NPCID.BlackSlime, NPCID.BabySlime, NPCID.BunnySlimed, NPCID.BunnySlimed, NPCID.CorruptSlime, NPCID.DungeonSlime, NPCID.RainbowSlime, NPCID.SlimeSpiked, NPCID.SpikedIceSlime, NPCID.SpikedJungleSlime, NPCID.UmbrellaSlime, NPCID.SlimeRibbonGreen, NPCID.SlimeRibbonRed, NPCID.SlimeRibbonWhite, NPCID.SlimeRibbonYellow };
        public override void Update(Player player, ref int buffIndex)
        {
            player.jumpSpeedBoost += 0.2f;
            foreach (int ID in SlimeIDs)
            {
                player.npcTypeNoAggro[ID] = true;
            }
            player.moveSpeed -= 0.10f;
        }
    }
}
