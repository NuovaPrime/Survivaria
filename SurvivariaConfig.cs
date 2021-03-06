﻿using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using Terraria;
using Terraria.ModLoader;
using Terraria.ModLoader.Config;
using Terraria.ModLoader.Config.UI;
using Terraria.UI;

namespace Survivaria
{
    public class SurvivariaConfigServer : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ServerSide;

        [Label("Hunger enabled")]
        [Tooltip("Toggle the hunger system.")]
        [DefaultValue(true)]
        public bool HungerEnabled { get; set; }

        [Label("Thirst enabled")]
        [Tooltip("Toggle the thirst system.")]
        [DefaultValue(true)]
        public bool ThirstEnabled { get; set; }

        [Label("Disable Potion Extra Stats")]
        [Tooltip("Toggles the hunger and thirst that potions give.")]
        [DefaultValue(false)]
        [ReloadRequired]
        public bool DisablePotionStats { get; set; }

        [Label("Adjust Hunger Drain Rate")]
        [Tooltip("Adjusts the multiplier for hunger drain rate.")]
        [DefaultValue(1f)]
        [Range(0f, 3f)]
        public float HungerDrainRateMulti { get; set; }

        [Label("Adjust Thirst Drain Rate")]
        [Tooltip("Adjusts the multiplier for thirst drain rate.")]
        [DefaultValue(1f)]
        [Range(0f, 3f)]
        public float ThirstDrainRateMulti { get; set; }

        [Label("Adjust Plant Growth Rate")]
        [Tooltip("Adjusts the rate at which plants grow in the world.\nLower value = faster growth speed")]
        [DefaultValue(1f)]
        [Range(0f, 2f)]
        public float PlantGrowthRateMulti { get; set; }

        /*[Label("Temperature enabled")]
        [Tooltip("Toggle the temperature system.")]
        [DefaultValue(true)]*/
        //public bool TemperatureEnabled { get; set; }

        /*[Label("Sanity enabled")]
        [Tooltip("Toggle the sanity system.")]
        [DefaultValue(true)]*/
        //public bool SanityEnabled { get; set; }


    }
    /*public class SurvivariaConfigClient : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ClientSide;

    }*/
}
