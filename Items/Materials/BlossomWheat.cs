﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Survivaria.Items.Materials
{
    public class BlossomWheat : SurvivariaItem
    {
        public BlossomWheat() : base("Blossom Wheat", "A commonly used plant that spreads seeds as the wind blows.", 20, 30, Item.buyPrice(0, 0, 1, 0), ItemRarityID.Blue, 0, 0)
        {
        }
    }
}
