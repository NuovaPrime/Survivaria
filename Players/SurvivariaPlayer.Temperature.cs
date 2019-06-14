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
        internal void ResetTemperatureEffects()
        {
            CurrentTemperature = 0;
        }

        public float CurrentTemperature { get; set; }
    }
}
