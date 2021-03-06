﻿using System.Threading.Tasks;
using Terraria;

using Terraria.ID;
using Terraria.ModLoader;

namespace Survivaria.Items.Food.BiomeSpecific.Crimson
{
    public class Greneyede : FoodItem
    {
        public Greneyede() : base("Greneyede", "Tastes surprisingly good, but you don't feel safe being watched when eating it.", 16, 24, Item.buyPrice(0, 0, 0, 80), ItemRarityID.Green, 5, 3, SoundID.Item2, BuffID.Battle, 30 * 60)
        {
        }
        public override void SetDefaults()
        {
            base.SetDefaults();
            item.UseSound = mod.GetLegacySoundSlot(SoundType.Custom, "Sounds/Eating/FruitEating");
        }

    }
}
