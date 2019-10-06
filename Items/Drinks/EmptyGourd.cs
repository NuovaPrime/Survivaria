using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Survivaria.Items.Drinks
{
    public class EmptyGourd : SurvivariaItem
    {
        public EmptyGourd() : base("Empty Gourd", "A weathered but still usable refillable gourd.", 20, 26, Item.buyPrice(0, 1, 50, 0), ItemRarityID.Green, 0, 0)
        {
        }

        public override void SetDefaults()
        {
            base.SetDefaults();
            item.consumable = false;
        }
    }
}
