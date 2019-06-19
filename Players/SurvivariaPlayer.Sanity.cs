using Terraria.ModLoader;

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
			ResetSanityEffects();
		}

		public double SanityLossRate()
		{
			if (player.ZoneCrimson || player.ZoneCorrupt)
				_s += 0.005;

			if (player.ZoneRockLayerHeight)
				_s += 0.0001;
			else if (player.ZoneUnderworldHeight)
				_s += 0.0009;

			return _s;
		}

		private double _s = 0;
		public double SanityMaximum { get; set; }
        public double CurrentSanity { get; set; }
    }
}
