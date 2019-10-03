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
    public class EnigmaticRoot : SurvivariaItem
    {
        public EnigmaticRoot() : base("Enigmatic Root", "Many cooks are often puzzled when trying to figure out how to prepare it.", 20, 30, Item.buyPrice(0, 0, 5, 0), ItemRarityID.Blue, 0, 0)
        {
        }
    }
}
