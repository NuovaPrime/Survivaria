using Microsoft.Xna.Framework;
using Survivaria.Buffs;
using Survivaria.Players;
using System.Collections.Generic;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace Survivaria.Items
{
    // Taken from Dragonball Terraria by Webmilio.
    public abstract class SurvivariaItem : ModItem
    {
        private readonly string _displayName, _tooltip;
        private readonly int _width, _height;
        public string FoodSize = null;
        public string DrinkSize = null;

        protected SurvivariaItem(string displayName, string tooltip, int width, int height, int value = 0, int rarity = ItemRarityID.White, int hungerAmount = 0, int thirstAmount = 0, LegacySoundStyle eatSound = null, int buffApplied = 0, int buffTime = 0, int maxStack = 999)
        {
            _displayName = displayName;
            _tooltip = tooltip;

            _width = width;
            _height = height;

            Value = value;
            Rarity = rarity;
            MaxStack = maxStack;
            EatSound = eatSound;

            BuffApplied = buffApplied;
            BuffTime = buffTime;

            HungerAmount = hungerAmount;
            ThirstAmount = thirstAmount;
        }

        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();

            DisplayName.SetDefault(_displayName);
            Tooltip.SetDefault(_tooltip);
        }

        public override void SetDefaults()
        {
            item.width = _width;
            item.height = _height;

            item.value = Value;
            item.rare = Rarity;
            item.UseSound = EatSound;
            item.maxStack = MaxStack;
            item.potion = false;

            item.buffType = BuffApplied;
            item.buffTime = BuffTime;

            item.useTime = 20;
            item.useAnimation = 20;
            item.useStyle = 2;

            base.SetDefaults();
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
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
                TooltipLine line = new TooltipLine(mod, "Survivaria_Tooltip_Food", FoodSize) { overrideColor = new Color(69, 255, 56) };
                tooltips.Add(line);
            }
            if (DrinkSize != null && ThirstAmount > 0)
            {
                TooltipLine line2 = new TooltipLine(mod, "Survivaria_Tooltip_Thirst", DrinkSize) { overrideColor = new Color(66, 194, 245) };
                tooltips.Add(line2);
            }
            base.ModifyTooltips(tooltips);
        }

        public override bool UseItem(Player player)
        {
            player.GetModPlayer<SurvivariaPlayer>().AddHunger(HungerAmount);
            player.GetModPlayer<SurvivariaPlayer>().AddThirst(ThirstAmount);
            return true;
        }
        

        public int Value { get; }
        public int Rarity { get; }
        public int HungerAmount { get; set; }
        public int ThirstAmount { get; set; }
        public LegacySoundStyle EatSound { get; set; }
        public int MaxStack { get; set; }
        public int BuffApplied { get; set; }
        public int BuffTime { get; set; }
    }
}
