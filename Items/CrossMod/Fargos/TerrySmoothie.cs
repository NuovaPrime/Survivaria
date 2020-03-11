using Microsoft.Xna.Framework;
using Survivaria.Items.Food;
using Survivaria.Players;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Terraria;

using Terraria.ID;
using Terraria.ModLoader;

namespace Survivaria.Items.CrossMod.Fargos
{
    public class TerrySmoothie : FoodItem
    {
        public TerrySmoothie() : base("Mutating Smoothie", "A smoothie containing a scoop of a certain mutant's brain.", 24, 30, Item.buyPrice(1, 0, 0, 0), ItemRarityID.Purple, 1, 1, SoundID.Item2, ModContent.BuffType<TerrySmoothieBuff>(), 60 * 30)
        {
        }
        public override bool Autoload(ref string name)
        {
            return ModLoader.GetMod("FargowiltasSouls") != null;
        }
        public override void SetDefaults()
        {
            base.SetDefaults();
            item.UseSound = mod.GetLegacySoundSlot(SoundType.Custom, "Sounds/Drinking/LightDrink");
        }
    }
}