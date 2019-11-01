using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Survivaria.Items.BossItems;
using Survivaria.Items.Materials;
using Survivaria.Items.Drinks;

namespace Survivaria
{
    public class SurvivariaGlobalNPC : GlobalNPC
    {
        public override bool InstancePerEntity
        {
            get
            {
                return true;
            }
        }

        public override void NPCLoot(NPC npc)
        {
            if (!Main.expertMode)
            {
                if (npc.type == NPCID.KingSlime)
                {
                    if (Main.rand.Next(10) == 0)
                        Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<TubofSlime>());
                }
                if (npc.type == NPCID.EyeofCthulhu)
                {
                    if (Main.rand.Next(10) == 0) Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<SpaghettiOfCthulhu>());
                }
                if (npc.type == NPCID.BrainofCthulhu)
                {
                    if (Main.rand.Next(10) == 0) Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<SuperSaltedEpineurium>());
                }
                if (npc.type == NPCID.EaterofWorldsHead && npc.boss == true)
                {
                    if (Main.rand.Next(10) == 0) Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<TripeSausage>());
                }
                if (npc.type == NPCID.QueenBee)
                {
                    if (Main.rand.Next(10) == 0) Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<HoneyCroissant>());
                }
                if (npc.type == NPCID.SkeletronHead)
                {
                    if (Main.rand.Next(10) == 0) Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<RootOfEvil>());
                }
            }
            int r = 4;
            if (Main.expertMode) r++;
            if (npc.type == NPCID.DesertLamiaLight || npc.type == NPCID.DesertLamiaDark)
			{
				if (Main.rand.Next(r) == 0)
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<SnakeMeat>());
			}
			if (npc.type == NPCID.GiantTortoise || npc.type == NPCID.IceTortoise)
			{
				if (Main.rand.Next(r) == 0)
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<TurtleMeat>());
			}
			if (npc.type == NPCID.RedDevil)
			{
				if (Main.rand.Next(r) == 0)
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<DemonTail>());
			}
			if (npc.type == NPCID.Unicorn)
			{
				if (Main.rand.Next(r) == 0)
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<UnicornMeat>());
			}
			if (npc.type == NPCID.WyvernHead)
			{
				if (Main.rand.Next(r) == 0)
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<WyvernMeat>());
			}
			if (npc.type == NPCID.Crab)
			{
				if (Main.rand.Next(r) == 0)
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<CrabMeat>());
			}
			if (npc.type == NPCID.IcyMerman)
			{
				if (Main.rand.Next(100) == 0)
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<FrozenTears>());
			}
			if (npc.type == NPCID.IceGolem)
			{
				if (Main.rand.Next(33) == 0)
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<FrozenTears>());
			}
            base.NPCLoot(npc);
        }
    }
}
