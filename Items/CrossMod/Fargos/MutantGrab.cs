using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
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
        public override void SetDefaults()
        {
            projectile.width = 152;
            projectile.height = 56;
            projectile.alpha = 0;
            projectile.timeLeft = 600;
            projectile.scale = 12f;
            projectile.penetrate = -1;
        }
        public override bool CanDamage()
        {
            return false;
        }
        public override Color? GetAlpha(Color lightColor)
        {
            return Color.White * projectile.Opacity;
        }
        public override void AI()
        {
            projectile.Center = Main.player[projectile.owner].Center;
            if (projectile.alpha == 0)
            {
                Main.PlaySound(15, (int)Main.player[projectile.owner].position.X, (int)Main.player[projectile.owner].position.Y, 0);
                foreach (NPC npc in Main.npc)
                {
                    if (npc.active && !npc.townNPC && Vector2.Distance(Main.player[projectile.owner].Center, npc.Center) < 2000)
                    {
                        Player player = Main.player[projectile.owner];
                        float modifier = player.meleeDamage;
                        if (modifier < player.rangedDamage)
                            modifier = player.rangedDamage;
                        if (modifier < player.magicDamage)
                            modifier = player.magicDamage;
                        if (modifier < player.minionDamage)
                            modifier = player.minionDamage;
                        if (modifier < player.thrownDamage)
                            modifier = player.thrownDamage;
                        npc.StrikeNPC((int)(projectile.damage * modifier), projectile.knockBack, -npc.direction, true);
                    }
                }
            }
            
            projectile.alpha += 5;
            if (projectile.alpha >= 255)
            {
                projectile.alpha = 255;
                projectile.Kill();
            }
        }
        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            Texture2D texture2D13 = Main.projectileTexture[projectile.type];
            int num156 = Main.projectileTexture[projectile.type].Height / Main.projFrames[projectile.type]; //ypos of lower right corner of sprite to draw
            int y3 = num156 * projectile.frame; //ypos of upper left corner of sprite to draw
            Rectangle rectangle = new Rectangle(0, y3, texture2D13.Width, num156);
            Vector2 origin2 = rectangle.Size() / 2f;
            Main.spriteBatch.Draw(texture2D13, projectile.Center - Main.screenPosition + new Vector2(0f, projectile.gfxOffY), new Microsoft.Xna.Framework.Rectangle?(rectangle), projectile.GetAlpha(lightColor), projectile.rotation, origin2, projectile.scale, SpriteEffects.None, 0f);
            return false;
        }
    }
}
