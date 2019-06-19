using Microsoft.Xna.Framework;
using Survivaria.Players;
using System.Collections.Generic;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace Survivaria.Items.Food
{
    public abstract class FoodItem : SurvivariaItem
    {
        public string FoodSize = null;

        protected FoodItem(string displayName, string tooltip, int width, int height, int hungerAmount, LegacySoundStyle eatSound, int maxStack, int buffApplied = 0, int buffTime = 0, int value = 0, int rarity = ItemRarityID.White) : base(displayName, tooltip, width, height)
        {
            HungerAmount = hungerAmount;
            EatSound = eatSound;
            MaxStack = maxStack;
            BuffApplied = buffApplied;
            BuffTime = buffTime;
        }

        public override void SetDefaults()
        {
            item.UseSound = EatSound;
            item.consumable = true;
            item.useTime = 20;
            item.useAnimation = 20;
            item.buffType = BuffApplied;
            item.buffTime = BuffTime;
            item.maxStack = MaxStack;
            base.SetDefaults();
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            if (HungerAmount < 10)
            {
                FoodSize = "Nibble";
                if (HungerAmount >= 10)
                {
                    FoodSize = "Snack";
                }
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
            if (FoodSize != null)
            {
                TooltipLine line = new TooltipLine(mod, "Survivaria_Tooltip_Food", FoodSize) { overrideColor = new Color(69, 255, 56) };
                tooltips.Add(line);
            }
            base.ModifyTooltips(tooltips);
        }

        public override void OnConsumeItem(Player player)
        {
            player.GetModPlayer<SurvivariaPlayer>().CurrentHunger += HungerAmount;
        }

        public LegacySoundStyle EatSound { get; set; }
        public int HungerAmount { get; set; }
        public int MaxStack { get; set; }
        public int BuffApplied { get; set; }
        public int BuffTime { get; set; }
    }
}
