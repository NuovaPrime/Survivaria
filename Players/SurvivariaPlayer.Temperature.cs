using Terraria.ModLoader;

namespace Survivaria.Players
{
    public partial class SurvivariaPlayer : ModPlayer
    {
        internal void ResetTemperatureEffects()
        {
            CurrentTemperature = 0;
        }

        public float CurrentTemperature { get; set; }
    }
}
