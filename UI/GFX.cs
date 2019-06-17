using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using Terraria.ModLoader;

namespace Survivaria.UI
{
    public static class GFX
    {
        private const string
            UI_DIRECTORY = "UI/",
            HUNGER_INDICATOR_TEXTURE = UI_DIRECTORY + "HungerIndicator",
            THIRST_INDICATOR_TEXTURE = UI_DIRECTORY + "ThirstIndicator",
            TEMPERATURE_BORDER_TEXTURE = UI_DIRECTORY + "TemperatureBorder",
            TEMPERATURE_FILL_TEXTURE = UI_DIRECTORY + "TemperatureFill";

        public static Texture2D
            hungerIndicatorTexture,
            thirstIndicatorTexture,
            temperatureBorderTexture,
            temperatureFillTexture;

        public static void LoadGFX(Mod mod)
        {
            hungerIndicatorTexture = mod.GetTexture(HUNGER_INDICATOR_TEXTURE);
            thirstIndicatorTexture = mod.GetTexture(THIRST_INDICATOR_TEXTURE);
            temperatureBorderTexture = mod.GetTexture(TEMPERATURE_BORDER_TEXTURE);
            temperatureFillTexture = mod.GetTexture(TEMPERATURE_FILL_TEXTURE);
        }

        public static void UnloadGFX()
        {
            hungerIndicatorTexture = null;
            thirstIndicatorTexture = null;
            temperatureBorderTexture = null;
            temperatureFillTexture = null;
        }
    }
}
