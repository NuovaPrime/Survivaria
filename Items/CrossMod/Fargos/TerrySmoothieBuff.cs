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
			player.allDamageMult += 0.5f;
            player.statDefense += 10;
            player.lifeRegen += 2;
            if (timer == 600)
            {
                Main.PlaySound(15, (int)player.position.X, (int)player.position.Y, 0);
                Projectile.NewProjectile(player.position, Vector2.Zero, ModContent.ProjectileType<MutantGrab>(), 1000, 1f, player.whoAmI);
                timer = 0;
            }
        }
    }
}
