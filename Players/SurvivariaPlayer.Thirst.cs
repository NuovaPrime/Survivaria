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
        }

        internal void UpdateThirst() //Called every single tick;
        {
            ThirstLossTimer++;

            Main.NewText("Thirst is : " + CurrentThirst);

            CurrentThirst -= ThirstLossRate();
        }

        public double ThirstLossRate()
        {
            if (ThirstLossTimer >= 30)//1200
            {
                _t = 1;//0.001

                if (player.moveSpeed >= 20 && !player.controlMount)
                    _t *= 2; //Gets doubled;

                ThirstLossTimer = 0;
            }

            return _t;
        }
        private double _t = 0;
        public int ThirstLossTimer { get; set; }
        public double CurrentThirst { get; set; } = 100;
        public double MaximumThirst { get; set; }
    }
}
