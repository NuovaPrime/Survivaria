using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Survivaria.Items.Food.BiomeSpecific.Purity;
using Survivaria.Items.Food.BiomeSpecific.Ocean;
using Survivaria.Items.Materials;

namespace Survivaria.Items.Food.Meal
{
    public class MRE : FoodItem
    {
        public MRE() : base("MRE", "A full meal ready to eat for any situation.", 24, 30, Item.buyPrice(0, 0, 0, 0), ItemRarityID.Green, 25, 25, SoundID.Item2, BuffID.WellFed, 60 * 180)
        {
        }

        public override void SetDefaults()
        {
            base.SetDefaults();
            item.UseSound = mod.GetLegacySoundSlot(SoundType.Custom, "Sounds/Eating/CrunchEating");
        }
    }
}