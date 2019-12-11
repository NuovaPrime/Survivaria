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
    public class MutantGrab : ModProjectile
    {
        bool hasMaterialized = false;
        public override void SetDefaults()
        {
            projectile.width = 20;
            projectile.height = 20;
            projectile.damage = 1000;
            projectile.alpha = 255;
            projectile.timeLeft = 300;
            projectile.scale = 12f;
            projectile.light = 0f;
        }
        public override Color? GetAlpha(Color lightColor)
        {
            return Color.White * projectile.Opacity;
        }
        public override void AI()
        {
            projectile.Center = Main.player[projectile.owner].Center + new Vector2(45, 1000);
            if (projectile.alpha > 100 && !hasMaterialized)
                projectile.alpha -= 3;
            if ((projectile.alpha == 99 || projectile.alpha == 101) && !hasMaterialized)
                projectile.alpha = 100;
            if (projectile.alpha == 100)
            {
                hasMaterialized = true;
                foreach(NPC npc in Main.npc)
                {
                    if (Vector2.Distance(Main.player[projectile.owner].Center, npc.Center) < 2000)
                    {
                        if (!npc.townNPC)
                        {
                            npc.StrikeNPC(1000, 1f, -npc.direction);
                            npc.life -= 1000;
                        }
                    }
                }
            }
            
            if (hasMaterialized)
                projectile.alpha += 3;
        }
    }
}
