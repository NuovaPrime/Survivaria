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
        internal void ResetSanityEffects()
        {
            
        }

        public float CurrentSanity { get; set; }
    }
}
