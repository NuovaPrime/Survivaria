using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;

namespace Survivaria.Players
{
    public partial class SurvivariaPlayer : ModPlayer
    {
        public override void PostUpdate()
        {
            if (CurrentHunger > MaximumHunger)
                CurrentHunger = MaximumHunger;
            if (CurrentHunger < 0)
                CurrentHunger = 0;

            UpdateHunger();
        }

        public override void ResetEffects()
        {
            ResetHungerEffects();
        }
    }
}
