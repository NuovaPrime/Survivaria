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
    public class BleedRoot : SurvivariaItem
    {
        public BleedRoot() : base("Bleed Root", "A leafy beet that excretes blood occasionally.", 26, 36, Item.buyPrice(0, 0, 2, 50), ItemRarityID.Blue, 0, 0)
        {
        }
    }
}
