using Terraria;
using Terraria.ModLoader;

namespace Survivaria.Players
{
    public partial class SurvivariaPlayer : ModPlayer
    {
        internal void ResetHungerEffects()
        {
			_h = 0;
            HungerMaximum = 100;
        }

        internal void UpdateHunger() //Called every single tick;
		{
			HungerLossTimer++;

			CurrentHunger -= HungerLossRate();
        }

		public double HungerLossRate()
		{
			if (HungerLossTimer >= 1200)//1200, 30 for debug
			{
				_h = 0.001;//0.001, 1 for debug

				if (player.moveSpeed >= 20 && !player.controlMount)
					_h *= 2; //Gets doubled;

                HungerLossTimer = 0;
			}

			return _h;
		}

		private double _h = 0; // Someone comment on what this is.

        public int HungerLossTimer { get; private set; }

        public double HungerMaximum { get; set; }
        public double CurrentHunger { get; set; } = 100;
    }
}
