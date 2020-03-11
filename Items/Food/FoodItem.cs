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
        protected FoodItem(string displayName, string tooltip, int width, int height, int value = 0, int rarity = 0, int hungerAmount = 0, int thirstAmount = 0, LegacySoundStyle eatSound = null, int buffApplied = 0, int buffTime = 0) : base(displayName, tooltip, width, height, value, rarity, hungerAmount, thirstAmount, eatSound, buffApplied, buffTime)
        {
        }

        public override void SetDefaults()
        {
            item.consumable = true;
            item.useTime = 20;
            item.useAnimation = 20;
            item.useStyle = 2;
            item.UseSound = EatSound;

            base.SetDefaults();
        }
    }
}
