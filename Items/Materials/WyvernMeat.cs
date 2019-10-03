using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Survivaria.Items.Materials
{
    public class WyvernMeat : SurvivariaItem
    {
        public WyvernMeat() : base("Wyvern Meat", "Of all who seeked, rare are the ones who could taste it, too often ending up as food themselves.", 20, 30, Item.buyPrice(0, 0, 50, 0), ItemRarityID.Blue, 0, 0)
        {
        }
    }
}
