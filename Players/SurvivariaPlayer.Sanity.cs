﻿using Terraria.ModLoader;

namespace Survivaria.Players
{
    public partial class SurvivariaPlayer : ModPlayer
	{
        internal void ResetSanityEffects()
        {
			_s = 0;
        }

		internal void UpdateSanity()
		{
			CurrentSanity -= SanityLossRate();
        }

		public double SanityLossRate()
		{
			if (player.ZoneCrimson || player.ZoneCorrupt)
				_s += 0.005;//0.005

			if (player.ZoneRockLayerHeight)
				_s += 0.0001;//0.0001
			else if (player.ZoneUnderworldHeight)
				_s += 0.0009;//0.0009

			return _s;
		}

		private double _s = 0;

		public double MaximumSanity { get; set; } = 100;
		public double CurrentSanity { get; set; } = 100;
    }
}
