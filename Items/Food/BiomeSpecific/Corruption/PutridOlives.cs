﻿using System.Threading.Tasks;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace Survivaria.Items.Food.BiomeSpecific.Corruption
{
    public class PutridOlives : FoodItem
    {
        public PutridOlives() : base("Putrid Olives", "Some extremely bitter and detestable toppings.\nMakes you stink.", 16, 24, Item.buyPrice(0, 0, 0, 80), ItemRarityID.Blue, 5, 0, SoundID.Item2, BuffID.Stinky, 30 * 60)
        {
        }
    }
}