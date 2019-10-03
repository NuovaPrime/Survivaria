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
    public class Reece : SurvivariaItem
    {
        public Reece() : base("Reece", "Its polyvalence has made ancient civilizations use those in all parts of their lives.", 20, 30, Item.buyPrice(0, 0, 1, 0), ItemRarityID.Blue, 0, 0)
        {
        }
    }
}
