using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Survivaria.Items.Food;

namespace Survivaria.Items.Food.BiomeSpecific.Crimson
{
    public class BleedRoot : FoodItem
    {
        public BleedRoot() : base("Bleed Root", "A leafy beet that excretes blood occasionally as if it was beating.", 26, 36, Item.buyPrice(0, 0, 2, 50), ItemRarityID.Green, 7, 3, SoundID.Item2, BuffID.Regeneration, 30 * 60)
        {
        }
        public override void SetDefaults()
        {
            base.SetDefaults();
            item.UseSound = mod.GetLegacySoundSlot(SoundType.Custom, "Sounds/Drinking/FruitEating");
        }

    }
}
