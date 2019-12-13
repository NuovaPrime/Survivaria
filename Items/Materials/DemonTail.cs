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
    public class DemonTail : SurvivariaItem
    {
        public DemonTail() : base("Demon Tail", "Many would be surprised that it can even be eaten.", 20, 30, Item.buyPrice(0, 3, 0, 0), ItemRarityID.LightPurple, 0, 0)
        {
        }
    }
}
