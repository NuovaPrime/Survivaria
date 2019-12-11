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
    public class UnicornMeat : SurvivariaItem
    {
        public UnicornMeat() : base("Unicorn Meat", "A very real meat from a very surreal creature.", 20, 30, Item.buyPrice(0, 3, 0, 0), ItemRarityID.Pink, 0, 0)
        {
        }
    }
}
