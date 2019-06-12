using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;

namespace Survivaria.Players
{
    public partial class SurvivariaPlayer : ModPlayer
    {
        internal void ResetHungerEffects()
        {
            HungerLossRate = 1;
            MaximumHunger = 100;
        }

        public override void PostUpdate()
        {
            if (CurrentHunger > MaximumHunger)
                CurrentHunger = MaximumHunger;
            if (CurrentHunger < 0)
                CurrentHunger = 0;
        }



        public int HungerLossRate { get; set; }
        public float CurrentHunger { get; set; }
        public float MaximumHunger { get; set; }
    }
}
