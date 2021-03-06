﻿using System.Threading.Tasks;
using Terraria;

using Terraria.ID;
using Terraria.ModLoader;

namespace Survivaria.Items.Materials
{
    public class PricklyPearWhite : SurvivariaItem
    {
        public PricklyPearWhite() : base("Prickly Pears", "Lost adventurers would desperately seek these out but often get prickled in precipitation.", 16, 24, Item.buyPrice(0, 0, 1, 50), ItemRarityID.Blue, 0, 0, SoundID.Item2)
        {
        }
    }
}
