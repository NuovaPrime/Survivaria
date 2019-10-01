using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;

namespace Survivaria.Players
{
    public partial class SurvivariaPlayer : ModPlayer
    {
        internal void ResetTemperatureEffects()
        {
        }

        internal void UpdateTemperature()
        {

        }

        public float CurrentTemperature { get; set; } = 0;

        public void CalculatePlayerTemperature()
        {
            if (player.ZoneDesert || player.ZoneUndergroundDesert)
                CurrentTemperature = 38;
            if (player.ZoneSnow)
                CurrentTemperature = -24;
            if (player.ZoneSkyHeight)
                CurrentTemperature = -52;
            if (player.ZoneRockLayerHeight)
                CurrentTemperature = 10;
            if (player.ZoneGlowshroom)
                CurrentTemperature = 12;
            if (player.ZoneHoly)
                CurrentTemperature = 28;
            if (player.ZoneCorrupt || player.ZoneCrimson)
                CurrentTemperature = 20;
            if (player.ZoneDungeon)
                CurrentTemperature = -12;
            if (player.ZoneDirtLayerHeight)
                CurrentTemperature = 16;
            if (player.ZoneMeteor || (player.position.Y <= Main.worldSurface * 2 && player.ZoneRockLayerHeight))
                CurrentTemperature = 40;
            if (player.ZoneUnderworldHeight)
                CurrentTemperature = 52;
            if (player.ZoneJungle)
                CurrentTemperature = 30;

            else if (player.ZoneOverworldHeight && !player.ZoneBeach && !player.ZoneDesert && !player.ZoneJungle && !player.ZoneSnow && !player.ZoneUnderworldHeight && !player.ZoneCorrupt && !player.ZoneCrimson && !player.ZoneMeteor && !player.ZoneGlowshroom && !player.ZoneDungeon && !player.ZoneDirtLayerHeight && !player.ZoneHoly && !player.ZoneRockLayerHeight && !player.ZoneSkyHeight && !player.ZoneOldOneArmy && !player.ZoneUndergroundDesert && !player.ZoneSandstorm && !player.ZoneWaterCandle && !player.ZonePeaceCandle)
            {
                CurrentTemperature = 24;

                if (player.ZoneRain)
                    CurrentTemperature = 18;
            }
        }
    }
}
