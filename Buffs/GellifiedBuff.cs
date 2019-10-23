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
    public class GellifiedBuff : ModBuff
    {
        public float slimeJump;
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Gellified");
            Description.SetDefault("Immunity to slimes and you are able to jump on enemy heads.");
            Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = false;
        }
        public override void Update(Player player, ref int buffIndex) //Thanks to orian34 for letting us use this from shapeshifter
        {
            player.extraFall += 15;
            player.npcTypeNoAggro[1] = true;
            player.npcTypeNoAggro[16] = true;
            player.npcTypeNoAggro[59] = true;
            player.npcTypeNoAggro[71] = true;
            player.npcTypeNoAggro[81] = true;
            player.npcTypeNoAggro[138] = true;
            player.npcTypeNoAggro[121] = true;
            player.npcTypeNoAggro[122] = true;
            player.npcTypeNoAggro[141] = true;
            player.npcTypeNoAggro[147] = true;
            player.npcTypeNoAggro[183] = true;
            player.npcTypeNoAggro[184] = true;
            player.npcTypeNoAggro[204] = true;
            player.npcTypeNoAggro[225] = true;
            player.npcTypeNoAggro[244] = true;
            player.npcTypeNoAggro[302] = true;
            player.npcTypeNoAggro[333] = true;
            player.npcTypeNoAggro[335] = true;
            player.npcTypeNoAggro[334] = true;
            player.npcTypeNoAggro[336] = true;
            player.npcTypeNoAggro[537] = true;
            if (player.velocity.Y == 0 && !player.mount.Active)
            {
                if (player.controlDown)
                {
                    slimeJump += 25f;
                    if (slimeJump >= 3000)
                    {
                        slimeJump = 3000f;
                    }
                }
            }
            else
            {
                if (slimeJump > 0 && !player.mount.Active)
                {
                    for (int i = 0; i < 50; i++)
                    {
                        Dust.NewDust(new Vector2(player.position.X, player.position.Y + 34), 16, 4, 103, 0f, -1f, 0, default(Color));
                    }
                }
                slimeJump = 0f;
            }
            int j = (int)(slimeJump / 100f) - 3;
            Player.jumpHeight += j;
            if (slimeJump > 0) { player.drippingSlime = true; }
            if (player.velocity.Y > 0f && !player.mount.Active)
            {
                Rectangle rect = player.getRect();
                rect.Offset(-1, player.height - 1);
                rect.Height = 2;
                rect.Inflate(10, 3);
                for (int i = 0; i < 200; i++)
                {
                    NPC target = Main.npc[i];
                    if (target.CanBeChasedBy() && target.immune[player.whoAmI] == 0)
                    {
                        Rectangle rect2 = target.getRect();
                        if (rect.Intersects(rect2) && (target.noTileCollide || Collision.CanHit(player.position, player.width, player.height, target.position, target.width, target.height)))
                        {
                            float num = 40f * player.minionDamage;
                            float knockback = 5f;
                            int direction = player.direction;
                            if (player.velocity.X < 0f) direction = -1;
                            if (player.velocity.X > 0f) direction = 1;
                            if (player.whoAmI == Main.myPlayer)
                            {
                                target.StrikeNPC((int)num, knockback, direction, false, false, false);
                                if (Main.netMode != 0) NetMessage.SendData(28, -1, -1, null, i, num, knockback, (float)direction, 0, 0, 0);
                                for (int i2 = 0; i2 < 30; i2++)
                                {
                                    Dust.NewDust(new Vector2(player.position.X, player.position.Y + 34), 16, 4, 103, 0f, -1f, 0, default(Color));
                                }
                            }
                            target.immune[player.whoAmI] = 10;
                            player.velocity.Y = -10f;
                            player.immune = true;
                            player.immuneTime = 6;
                            break;
                        }
                    }
                }
            }
        }
    }
}
