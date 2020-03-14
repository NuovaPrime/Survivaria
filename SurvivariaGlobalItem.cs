using Microsoft.Xna.Framework;
using Survivaria.Buffs;
using Survivaria.Items;
using Survivaria.Items.BossItems;
using Survivaria.Items.Drinks;
using Survivaria.Items.Food;
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
                if (context == "bossBag" && arg == ItemID.EyeOfCthulhuBossBag) player.QuickSpawnItem(ModContent.ItemType<SpaghettiOfCthulhu>());
                if (context == "bossBag" && arg == ItemID.BrainOfCthulhuBossBag) player.QuickSpawnItem(ModContent.ItemType<SuperSaltedEpineurium>());
                if (context == "bossBag" && arg == ItemID.EaterOfWorldsBossBag) player.QuickSpawnItem(ModContent.ItemType<TripeSausage>());
                if (context == "bossBag" && arg == ItemID.QueenBeeBossBag) player.QuickSpawnItem(ModContent.ItemType<HoneyCroissant>());
                if (context == "bossBag" && arg == ItemID.SkeletronBossBag) player.QuickSpawnItem(ModContent.ItemType<RootOfEvil>());
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
            return base.CanUseItem(item, player);
        }

        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            string FoodSize = "";
            string DrinkSize = "";
            if (HungerAmount < 0)
            {
                FoodSize = "Starving";
            }
            if (HungerAmount > 0)
            {
                FoodSize = "Nibble";
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
            }
            if (ThirstAmount < 0)
            {
                DrinkSize = "Dehydrating";
            }
            if (ThirstAmount > 0)
            {
                DrinkSize = "Sip";
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
            }
            if (FoodSize != null && HungerAmount > 0)
            {
                TooltipLine line = new TooltipLine(mod, "Survivaria_Tooltip_Food", FoodSize) { overrideColor = new Color(69, 255, 56) };
                tooltips.Add(line);
            }
            else if (FoodSize != null && HungerAmount < 0)
            {
                TooltipLine line = new TooltipLine(mod, "Survivaria_Tooltip_Food", FoodSize) { overrideColor = new Color(210, 64, 64) };
                tooltips.Add(line);
            }
            if (DrinkSize != null && ThirstAmount > 0)
            {
                TooltipLine line2 = new TooltipLine(mod, "Survivaria_Tooltip_Thirst", DrinkSize) { overrideColor = new Color(66, 194, 245) };
                tooltips.Add(line2);
            }
            else if (DrinkSize != null && ThirstAmount < 0)
            {
                TooltipLine line2 = new TooltipLine(mod, "Survivaria_Tooltip_Thirst", DrinkSize) { overrideColor = new Color(153, 164, 175) };
                tooltips.Add(line2);
            }
            if (item.buffType == BuffID.WellFed && ModContent.GetInstance<SurvivariaConfigServer>().HungerEnabled)
            {
                foreach (TooltipLine line2 in tooltips)
                {
                    if(line2.mod == "Terraria")
                    {
                        if (line2.Name == "WellFedExpert") line2.text = "";
                        if (line2.Name == "Tooltip0") line2.text = "";
                        if (line2.Name == "BuffTime") line2.text = "";
                    }
                }
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
            {
                HungerAmount = 1;
                ThirstAmount = 10;
            }
            if (item.type == ItemID.Honeyfin)
                HungerAmount = 10;
            if (item.type == ItemID.Bacon)
            {
                HungerAmount = 16;
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
            if (!ModContent.GetInstance<SurvivariaConfigServer>().DisablePotionStats)
            {
                if (item.type == ItemID.LesserHealingPotion)
                {
                    HungerAmount = 1;
                    ThirstAmount = 8;
                }
                if (item.type == ItemID.LesserManaPotion)
                {
                    HungerAmount = 1;
                    ThirstAmount = 8;
                }
                if (item.type == ItemID.HealingPotion)
                {
                    HungerAmount = 1;
                    ThirstAmount = 10;
                }
                if (item.type == ItemID.ManaPotion)
                {
                    HungerAmount = 1;
                    ThirstAmount = 10;
                }
                if (item.type == ItemID.LesserRestorationPotion)
                {
                    HungerAmount = 1;
                    ThirstAmount = 8;
                }
                if (item.type == ItemID.RestorationPotion)
                {
                    HungerAmount = 1;
                    ThirstAmount = 10;
                }
                if (item.type == ItemID.GreaterHealingPotion)
                {
                    HungerAmount = 1;
                    ThirstAmount = 12;
                }
                if (item.type == ItemID.GreaterManaPotion)
                {
                    HungerAmount = 1;
                    ThirstAmount = 12;
                }
                if (item.type == ItemID.SuperHealingPotion)
                {
                    HungerAmount = 1;
                    ThirstAmount = 14;
                }
                if (item.type == ItemID.SuperManaPotion)
                {
                    HungerAmount = 1;
                    ThirstAmount = 14;
                }
                if (item.type == ItemID.GingerbreadCookie)
                {
                    HungerAmount = 8;
                    ThirstAmount = -4;
                }
                if (item.type == ItemID.RecallPotion)
                {
                    HungerAmount = 1;
                    ThirstAmount = 10;
                }
                if (item.type == ItemID.GenderChangePotion)
                {
                    HungerAmount = 1;
                    ThirstAmount = 10;
                }
                if (item.type == ItemID.WormholePotion)
                {
                    HungerAmount = 1;
                    ThirstAmount = 10;
                }
                if (item.type == ItemID.TeleportationPotion)
                {
                    HungerAmount = 1;
                    ThirstAmount = 10;
                }
                if (item.type == ItemID.ObsidianSkinPotion)
                {
                    HungerAmount = 1;
                    ThirstAmount = 10;
                }
                if (item.type == ItemID.RegenerationPotion)
                {
                    HungerAmount = 1;
                    ThirstAmount = 10;
                }
                if (item.type == ItemID.SwiftnessPotion)
                {
                    HungerAmount = 1;
                    ThirstAmount = 10;
                }
                if (item.type == ItemID.GillsPotion)
                {
                    HungerAmount = 1;
                    ThirstAmount = 10;
                }
                if (item.type == ItemID.IronskinPotion)
                {
                    HungerAmount = 1;
                    ThirstAmount = 10;
                }
                if (item.type == ItemID.ManaRegenerationPotion)
                {
                    HungerAmount = 1;
                    ThirstAmount = 10;
                }
                if (item.type == ItemID.MagicPowerPotion)
                {
                    HungerAmount = 1;
                    ThirstAmount = 10;
                }
                if (item.type == ItemID.FeatherfallPotion)
                {
                    HungerAmount = 1;
                    ThirstAmount = 10;
                }
                if (item.type == ItemID.SpelunkerPotion)
                {
                    HungerAmount = 1;
                    ThirstAmount = 10;
                }
                if (item.type == ItemID.InvisibilityPotion)
                {
                    HungerAmount = 1;
                    ThirstAmount = 10;
                }
                if (item.type == ItemID.ShinePotion)
                {
                    HungerAmount = 1;
                    ThirstAmount = 10;
                }
                if (item.type == ItemID.NightOwlPotion)
                {
                    HungerAmount = 1;
                    ThirstAmount = 10;
                }
                if (item.type == ItemID.BattlePotion)
                {
                    HungerAmount = 1;
                    ThirstAmount = 10;
                }
                if (item.type == ItemID.ThornsPotion)
                {
                    HungerAmount = 1;
                    ThirstAmount = 10;
                }
                if (item.type == ItemID.WaterWalkingPotion)
                {
                    HungerAmount = 1;
                    ThirstAmount = 10;
                }
                if (item.type == ItemID.ArcheryPotion)
                {
                    HungerAmount = 1;
                    ThirstAmount = 10;
                }
                if (item.type == ItemID.HunterPotion)
                {
                    HungerAmount = 1;
                    ThirstAmount = 10;
                }
                if (item.type == ItemID.GravitationPotion)
                {
                    HungerAmount = 1;
                    ThirstAmount = 10;
                }
                if (item.type == ItemID.MiningPotion)
                {
                    HungerAmount = 1;
                    ThirstAmount = 10;
                }
                if (item.type == ItemID.HeartreachPotion)
                {
                    HungerAmount = 1;
                    ThirstAmount = 10;
                }
                if (item.type == ItemID.CalmingPotion)
                {
                    HungerAmount = 1;
                    ThirstAmount = 10;
                }
                if (item.type == ItemID.BuilderPotion)
                {
                    HungerAmount = 1;
                    ThirstAmount = 10;
                }
                if (item.type == ItemID.TitanPotion)
                {
                    HungerAmount = 1;
                    ThirstAmount = 10;
                }
                if (item.type == ItemID.FlipperPotion)
                {
                    HungerAmount = 1;
                    ThirstAmount = 10;
                }
                if (item.type == ItemID.SummoningPotion)
                {
                    HungerAmount = 1;
                    ThirstAmount = 10;
                }
                if (item.type == ItemID.TrapsightPotion)
                {
                    HungerAmount = 1;
                    ThirstAmount = 10;
                }
                if (item.type == ItemID.AmmoReservationPotion)
                {
                    HungerAmount = 1;
                    ThirstAmount = 10;
                }
                if (item.type == ItemID.LifeforcePotion)
                {
                    HungerAmount = 1;
                    ThirstAmount = 10;
                }
                if (item.type == ItemID.EndurancePotion)
                {
                    HungerAmount = 1;
                    ThirstAmount = 10;
                }
                if (item.type == ItemID.RagePotion)
                {
                    HungerAmount = 1;
                    ThirstAmount = 10;
                }
                if (item.type == ItemID.InfernoPotion)
                {
                    HungerAmount = 1;
                    ThirstAmount = 10;
                }
                if (item.type == ItemID.WrathPotion)
                {
                    HungerAmount = 1;
                    ThirstAmount = 10;
                }
                if (item.type == ItemID.FishingPotion)
                {
                    HungerAmount = 1;
                    ThirstAmount = 10;
                }
                if (item.type == ItemID.SonarPotion)
                {
                    HungerAmount = 1;
                    ThirstAmount = 10;
                }
                if (item.type == ItemID.CratePotion)
                {
                    HungerAmount = 1;
                    ThirstAmount = 10;
                }
                if (item.type == ItemID.WarmthPotion)
                {
                    HungerAmount = 1;
                    ThirstAmount = 10;
                }
            }
            base.SetDefaults(item);
        }

        public override bool UseItem(Item item, Player player)
        {
            if (!(item.modItem is SurvivariaItem || item.modItem is FoodItem || item.modItem is DrinkItem))
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
