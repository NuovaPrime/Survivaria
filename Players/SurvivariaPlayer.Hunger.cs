using Terraria.ModLoader;

namespace Survivaria.Players
{
    public partial class SurvivariaPlayer : ModPlayer
    {
        internal void ResetHungerEffects()
        {
            HungerLossRate = 0.01;
            MaximumHunger = 100;
        }

        internal void UpdateHunger()
        {
            hungerLossTimer++;

			if (player.active)
			{
				if (hungerLossTimer >= 1200)
				{
					CurrentHunger -= HungerLossRate;
					hungerLossTimer = 0;
				}
			}
        }

		int hungerLossTimer = 0; //I swear to God Nuova, if I see you not storing all variables at one point in small code...
		public double HungerLossRate { get; set; }
        public double CurrentHunger { get; set; }
        public double MaximumHunger { get; set; }
    }
}
