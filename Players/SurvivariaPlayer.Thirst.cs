using Terraria;
using Terraria.ModLoader;

namespace Survivaria.Players
{
    public partial class SurvivariaPlayer : ModPlayer
    {
        internal void ResetThirstEffects()
        {
            _t = 0;
            MaximumThirst = 100;
            ThirstLossMulti = 1f;
        }

        internal void UpdateThirst() //Called every single tick;
        {
            ThirstLossTimer++;//Do NOT include debugging in separate files. Include in player file.

            CurrentThirst -= ThirstLossRate();
        }

        public double ThirstLossRate()
        {
            if (ThirstLossTimer >= 1200)//1200, 30 for debug
            {
                _t = 0.002 * ThirstLossMulti;//0.002, 1 for debug

                if (player.moveSpeed >= 20 && !player.controlMount)
                    _t *= 2; //Gets doubled;

                ThirstLossTimer = 0;
            }
            if (CurrentTemperature <= 0)
                ThirstLossMulti -= 0.2f;
            if (CurrentTemperature >= 38 && CurrentTemperature < 52)
                ThirstLossMulti += 0.2f;
            if (CurrentTemperature >= 52)
                ThirstLossMulti += 0.5f;

            return _t;
        }
        private double _t = 0;
        public int ThirstLossTimer { get; set; }
        public float ThirstLossMulti { get; set; }
        public double CurrentThirst { get; set; } = 100;
        public double MaximumThirst { get; set; }
    }
}
