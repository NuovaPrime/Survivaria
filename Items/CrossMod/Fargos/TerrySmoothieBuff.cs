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
    public class TerrySmoothieBuff : ModBuff
    {
        int timer = 0;
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Smug Vibes");
            Description.SetDefault("You feel loli smoothie vibes coursing through your veins.\nGives boosts to various stats and you periodically summon the soul of Mutant, damaging all nearby enemies.");
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
			player.allDamageMult += 0.2f;
            player.magicCrit += 20;
            player.meleeCrit += 20;
            player.rangedCrit += 20;
            player.thrownCrit += 20;
            player.statDefense += 10;
            player.lifeRegen += 4;
            player.lifeRegenCount += 2;
            player.lifeRegenTime += 2;
            player.statDefense += 10;
            player.statLifeMax2 += 100;
            player.endurance += 0.1f;
            if (timer == 600)
            {
                Projectile.NewProjectile(player.Center, Vector2.Zero, ModContent.ProjectileType<MutantGrab>(), 7000, 12f, player.whoAmI);
                timer = 0;
            }
        }
    }
}
