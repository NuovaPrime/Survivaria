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

        }

		public double GetTemperature()
		{
			if (player.ZoneDesert)
			{
				_t += 0.005;
			}

			return _t;
		}

		private double _t = 0;
        public double CurrentTemperature { get; set; }
    }
}
