using Terraria.ModLoader;

namespace Survivaria.Players
{
    public partial class SurvivariaPlayer : ModPlayer
    {
        internal void ResetHungerEffects()
        {
			_h = 0;
        }

        internal void UpdateHunger() //Called every single tick;
		{
			hungerLossTimer++;

			CurrentHunger -= HungerLossRate;
			_h = 0;
        }

		public double HungerLossRate
		{
			get
			{
				if (hungerLossTimer >= 1200)
				{
					_h = 0.001;

					if (player.moveSpeed >= 20 && !player.controlMount)
						_h *= 2; //Gets doubled;
				}
				return _h;
			}
		}

		private double _h = 0;
		private int hungerLossTimer = 0; //I swear to God Nuova, if I see you not storing all variables at one point in small code...
		public double HungerMaximum { get; set; } 
        public double CurrentHunger { get; set; }
    }
}
