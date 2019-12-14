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
    public class SnakeMeat : SurvivariaItem
    {
        public SnakeMeat() : base("Snake Meat", "Surprisingly tender considering the mass of muscles composing it.", 20, 30, Item.buyPrice(0, 2, 0, 0), ItemRarityID.LightRed, 0, 0)
        {
        }
    }
}
