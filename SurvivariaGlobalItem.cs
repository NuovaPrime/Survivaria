using Microsoft.Xna.Framework;
using Survivaria.Items.BossItems;
using Survivaria.Items.Food.BiomeSpecific.Desert;
using Survivaria.Items.Food.BiomeSpecific.Jungle;
using Survivaria.Items.Food.BiomeSpecific.Purity;
using Survivaria.Items.Materials;
using Survivaria.Players;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Survivaria
{
    public class SurvivariaGlobalItem : GlobalItem
    {

        
        public override bool InstancePerEntity => true;
        public override bool CloneNewInstances => true;
        public override void OpenVanillaBag(string context, Player player, int arg)
        {
            if (Main.rand.Next(10) == 0)
            {
                if (context == "bossBag" && arg == ItemID.KingSlimeBossBag)
                {
                    player.QuickSpawnItem(mod.ItemType<TubofSlime>());
                }
            }
        }

        
        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            string FoodSize = "";
            string DrinkSize = "";
            if (HungerAmount < 10)
            {
                FoodSize = "Nibble";
            }
            if (HungerAmount >= 10)
            {
                FoodSize = "Snack";
                if (HungerAmount >= 20)
                {
                    FoodSize = "Meal";
                    if (HungerAmount >= 40)
                    {
                        FoodSize = "Buffet";
                        if (HungerAmount >= 70)
                            FoodSize = "Feast";
                    }
                }
            }
            if (ThirstAmount <= 15)
            {
                DrinkSize = "Sip"; 
            }
            if (ThirstAmount > 15)
            {
                DrinkSize = "Refreshing";
                if (ThirstAmount >= 40)
                {
                    DrinkSize = "Hydrating";
                    if (ThirstAmount >= 70)
                        DrinkSize = "Quenching";
                }
            }
            if (FoodSize != null && HungerAmount > 0)
            {
                TooltipLine line = new TooltipLine(mod, "Survivaria_Global_Tooltip_Food", FoodSize) { overrideColor = new Color(69, 255, 56) };
                tooltips.Add(line);
            }
            if (DrinkSize != null && ThirstAmount > 0)
            {
                TooltipLine line2 = new TooltipLine(mod, "Survivaria_Global_Tooltip_Thirst", DrinkSize) { overrideColor = new Color(66, 194, 245) };
                tooltips.Add(line2);
            }
        }

        public override void SetDefaults(Item item)
        {
            if (item.type == ItemID.BottledWater)
                ThirstAmount = 16;
            if (item.type == ItemID.Mushroom)
                HungerAmount = 5;
            if (item.type == ItemID.Bacon)
            {
                HungerAmount = 12;
                ThirstAmount = -3;
            }
            if (item.type == ItemID.CookedFish)
            {
                HungerAmount = 10;
                ThirstAmount = -1;
            }
            if (item.type == ItemID.Pho)
                HungerAmount = 12;
            if (item.type == ItemID.BowlofSoup)
            {
                HungerAmount = 18;
                ThirstAmount = 3;
            }
            if (item.type == ItemID.PumpkinPie)
            {
                HungerAmount = 16;
                ThirstAmount = -2;
            }
            if (item.type == ItemID.Ale)
            {
                HungerAmount = -4;
                ThirstAmount = 8;
            }
            if (item.type == ItemID.Sake)
            {
                HungerAmount = -4;
                ThirstAmount = 8;
            }
            if (item.type == ItemID.PadThai)
                HungerAmount = 16;
            if (item.type == ItemID.Sashimi)
            {
                HungerAmount = 10;
                ThirstAmount = -1;
            }
            if (item.type == ItemID.CookedShrimp)
            {
                HungerAmount = 10;
                ThirstAmount = -1;
            }
            if (item.type == ItemID.CookedMarshmallow)
            {
                HungerAmount = 4;
                ThirstAmount = -1;
            }
            if (item.type == ItemID.ChristmasPudding)
            {
                HungerAmount = 16;
                ThirstAmount = -2;
            }
            if (item.type == ItemID.GrubSoup)
            {
                HungerAmount = 16;
                ThirstAmount = 6;
            }
            if (item.type == ItemID.SugarCookie)
            {
                HungerAmount = 6;
                ThirstAmount = -2;
            }
            if (item.type == ItemID.Eggnog)
            {
                HungerAmount = 6;
                ThirstAmount = 2;
            }
            if (item.type == ItemID.GingerbreadCookie)
            {
                HungerAmount = 8;
                ThirstAmount = -4;
            }
        }

        public override bool UseItem(Item item, Player player)
        {
            SurvivariaPlayer modPlayer = player.GetModPlayer<SurvivariaPlayer>();

            player.GetModPlayer<SurvivariaPlayer>().AddHunger(HungerAmount);
            player.GetModPlayer<SurvivariaPlayer>().AddThirst(ThirstAmount);
            return true;
        }

        public int HungerAmount { get; set; }
        public int ThirstAmount { get; set; }
    }
}
