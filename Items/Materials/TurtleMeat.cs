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
    public class TurtleMeat : SurvivariaItem
    {
        public TurtleMeat() : base("Turtle Meat", "A strong and springy meat that cannot be eaten easily.", 20, 30, Item.buyPrice(0, 0, 50, 0), ItemRarityID.Blue, 0, 0)
        {
        }
    }
}
