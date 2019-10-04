using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Survivaria.Items.Food;

namespace Survivaria.Items.BiomeSpecific.Crimson
{
    public class BleedRoot : FoodItem
    {
        public BleedRoot() : base("Bleed Root", "A leafy beet that excretes blood occasionally as if it was beating.\nIncreases regeneration for 30 seconds.", 26, 36, Item.buyPrice(0, 0, 2, 50), ItemRarityID.Blue, 7, 3, BuffID.Regeneration, 30 * 60)
        {
        }
    }
}
