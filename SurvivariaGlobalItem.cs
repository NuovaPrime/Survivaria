using Microsoft.Xna.Framework;
using Survivaria.Buffs;
using Survivaria.Items;
using Survivaria.Items.BossItems;
using Survivaria.Items.Food.BiomeSpecific.Desert;
using Survivaria.Items.Food.BiomeSpecific.Jungle;
using Survivaria.Items.Food.BiomeSpecific.Purity;
using Survivaria.Items.Food.BiomeSpecific.Underground;
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
    public class SurvivariaGlobalRecipeItem : GlobalItem
    {

        
        public override bool InstancePerEntity => true;
        public override bool CloneNewInstances => true;
        public override void OpenVanillaBag(string context, Player player, int arg)
        {
            if (Main.rand.Next(10) == 0)
            {
                if (context == "bossBag" && arg == ItemID.KingSlimeBossBag)
                {
                    player.QuickSpawnItem(ModContent.ItemType<TubofSlime>());
                }
            }
        }
        public override bool CanUseItem(Item item, Player player)
        {
            if (HungerAmount > 0)
                if (player.HasBuff(ModContent.BuffType<NauseaDebuff>()))
                    return false;

            if (ThirstAmount > 0)
                if (player.HasBuff(ModContent.BuffType<HyponatremiaDebuff>()))
                    return false;
            return true;
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
            if (item.type == ItemID.BottledHoney)
                HungerAmount = 5;
            if (item.type == ItemID.Mushroom)
                HungerAmount = 5;
            if (item.type == ItemID.Eggnog)
            {
                HungerAmount = 6;
                ThirstAmount = 2;
            }
            if (item.type == ItemID.StrangeBrew)
                ThirstAmount = 10;
            if (item.type == ItemID.Honeyfin)
                HungerAmount = 10;
            if (item.type == ItemID.LesserHealingPotion)
                ThirstAmount = 8;
            if (item.type == ItemID.LesserManaPotion)
                ThirstAmount = 8;
            if (item.type == ItemID.HealingPotion)
                ThirstAmount = 10;
            if (item.type == ItemID.ManaPotion)
                ThirstAmount = 10;
            if (item.type == ItemID.LesserRestorationPotion)
                ThirstAmount = 8;
            if (item.type == ItemID.RestorationPotion)
                ThirstAmount = 10;
            if (item.type == ItemID.GreaterHealingPotion)
                ThirstAmount = 12;
            if (item.type == ItemID.GreaterManaPotion)
                ThirstAmount = 12;
            if (item.type == ItemID.SuperHealingPotion)
                ThirstAmount = 14;
            if (item.type == ItemID.SuperManaPotion)
                ThirstAmount = 14;
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
            if (item.type == ItemID.GingerbreadCookie)
            {
                HungerAmount = 8;
                ThirstAmount = -4;
            }
            if (item.type == ItemID.RecallPotion)
                ThirstAmount = 10;
            if (item.type == ItemID.GenderChangePotion)
                ThirstAmount = 10;
            if (item.type == ItemID.WormholePotion)
                ThirstAmount = 10;
            if (item.type == ItemID.TeleportationPotion)
                ThirstAmount = 10;
            if (item.type == ItemID.ObsidianSkinPotion)
                ThirstAmount = 10;
            if (item.type == ItemID.RegenerationPotion)
                ThirstAmount = 10;
            if (item.type == ItemID.SwiftnessPotion)
                ThirstAmount = 10;
            if (item.type == ItemID.GillsPotion)
                ThirstAmount = 10;
            if (item.type == ItemID.IronskinPotion)
                ThirstAmount = 10;
            if (item.type == ItemID.ManaRegenerationPotion)
                ThirstAmount = 10;
            if (item.type == ItemID.MagicPowerPotion)
                ThirstAmount = 10;
            if (item.type == ItemID.FeatherfallPotion)
                ThirstAmount = 10;
            if (item.type == ItemID.SpelunkerPotion)
                ThirstAmount = 10;
            if (item.type == ItemID.InvisibilityPotion)
                ThirstAmount = 10;
            if (item.type == ItemID.ShinePotion)
                ThirstAmount = 10;
            if (item.type == ItemID.NightOwlPotion)
                ThirstAmount = 10;
            if (item.type == ItemID.BattlePotion)
                ThirstAmount = 10;
            if (item.type == ItemID.ThornsPotion)
                ThirstAmount = 10;
            if (item.type == ItemID.WaterWalkingPotion)
                ThirstAmount = 10;
            if (item.type == ItemID.ArcheryPotion)
                ThirstAmount = 10;
            if (item.type == ItemID.HunterPotion)
                ThirstAmount = 10;
            if (item.type == ItemID.GravitationPotion)
                ThirstAmount = 10;
            if (item.type == ItemID.MiningPotion)
                ThirstAmount = 10;
            if (item.type == ItemID.HeartreachPotion)
                ThirstAmount = 10;
            if (item.type == ItemID.CalmingPotion)
                ThirstAmount = 10;
            if (item.type == ItemID.BuilderPotion)
                ThirstAmount = 10;
            if (item.type == ItemID.TitanPotion)
                ThirstAmount = 10;
            if (item.type == ItemID.FlipperPotion)
                ThirstAmount = 10;
            if (item.type == ItemID.SummoningPotion)
                ThirstAmount = 10;
            if (item.type == ItemID.TrapsightPotion)
                ThirstAmount = 10;
            if (item.type == ItemID.AmmoReservationPotion)
                ThirstAmount = 10;
            if (item.type == ItemID.LifeforcePotion)
                ThirstAmount = 10;
            if (item.type == ItemID.EndurancePotion)
                ThirstAmount = 10;
            if (item.type == ItemID.RagePotion)
                ThirstAmount = 10;
            if (item.type == ItemID.InfernoPotion)
                ThirstAmount = 10;
            if (item.type == ItemID.WrathPotion)
                ThirstAmount = 10;
            if (item.type == ItemID.FishingPotion)
                ThirstAmount = 10;
            if (item.type == ItemID.SonarPotion)
                ThirstAmount = 10;
            if (item.type == ItemID.CratePotion)
                ThirstAmount = 10;
            if (item.type == ItemID.WarmthPotion)
                ThirstAmount = 10;
        }

        public override bool UseItem(Item item, Player player)
        {
            if ((item.modItem is SurvivariaItem) == false)
            {
                SurvivariaPlayer modPlayer = player.GetModPlayer<SurvivariaPlayer>();

                player.GetModPlayer<SurvivariaPlayer>().AddHunger(HungerAmount);
                player.GetModPlayer<SurvivariaPlayer>().AddThirst(ThirstAmount);
            }
            return base.UseItem(item, player);
        }

        public int HungerAmount { get; set; }
        public int ThirstAmount { get; set; }
    }

    public class SurvivariaGlobalItem : GlobalItem
    {
        public override void ExtractinatorUse(int extractType, ref int resultType, ref int resultStack)
        {
            if (extractType == 0)
            {
                if (Main.rand.Next(8) == 0)
                {
                    resultType = ModContent.ItemType<Salt>();
                    resultStack = 1;
                }
            }       
            base.ExtractinatorUse(extractType, ref resultType, ref resultStack);
        }
    }
}
