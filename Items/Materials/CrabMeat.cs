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
    public class CrabMeat : SurvivariaItem
    {
        public CrabMeat() : base("Crab Meat", "A juicy white flesh that keeps a strong taste of sea, even cooked.", 20, 30, Item.buyPrice(0, 0, 2, 50), ItemRarityID.Blue, 0, 0)
        {
        }
    }
}
