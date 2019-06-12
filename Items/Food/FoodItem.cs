using Survivaria.Players;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace Survivaria.Items.Food
{
    public abstract class FoodItem : SurvivariaItem
    {
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
