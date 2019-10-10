using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Survivaria.Players
{
    public partial class SurvivariaPlayer : ModPlayer
    {
        internal void ResetHungerEffects()
        {
			_h = 0;
            HungerMaximum = 100;
            HungerLossMulti = 1f;
        }

        internal void UpdateHunger() //Called every single tick;
		{
			HungerLossTimer++;

			CurrentHunger -= HungerLossRate();

            if (CurrentHunger >= 85)
            {
                player.lifeRegen += 1;
                player.AddBuff(BuffID.WellFed, 30);
                ThirstLossMulti += 0.05f;
                CurrentTemperature += 2;
            }
            if (CurrentHunger <= 41 && CurrentHunger >= 21)
            {
                player.statLifeMax2 -= 10;
                player.pickSpeed -= 0.15f;
                player.meleeSpeed -= 0.15f;
                player.moveSpeed -= 0.10f;
            }
            if (CurrentHunger < 21 && CurrentHunger >= 1)
            {
                player.statLifeMax2 -= 50;
                player.pickSpeed -= 0.45f;
                player.meleeSpeed -= 0.45f;
                player.moveSpeed -= 0.40f;
                
            }
            if (CurrentHunger <= 0)
            {
                LossTimer++;
                if (LossTimer >= 20)
                {
                    player.statLife -= 1;
                    player.statMana -= 1;
                    CurrentSanity -= 0.05f;
                    LossTimer = 0;
                }
            }
        }

		public double HungerLossRate()
		{
			if (HungerLossTimer >= 1200)//1200, 30 for debug
			{
				_h = 0.001 * HungerLossMulti;//0.001, 1 for debug

				if (player.moveSpeed >= 20 && !player.controlMount)
					_h *= 2; //Gets doubled;

                HungerLossTimer = 0;
			}

            if (player.HasBuff(BuffID.Bleeding))
                HungerLossMulti += 0.05f;
            if (CurrentSanity >= 30)
                HungerLossMulti += 0.08f;
            if (player.lifeRegenCount >= 2)
                HungerLossMulti += 0.1f;
            if (CurrentTemperature <= 0)
                HungerLossMulti += 0.12f;

            return _h;
		}

		private double _h = 0; // Someone comment on what this is.

        public int HungerLossTimer { get; private set; }
        public float HungerLossMulti { get; set; } = 1f;

        public double HungerMaximum { get; set; }
        public double CurrentHunger { get; set; } = 100;
    }
}
