using Survivaria.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.GameInput;
using Terraria.ModLoader;

namespace Survivaria.Players
{
    public partial class SurvivariaPlayer : ModPlayer
    {
        public override void PostUpdate()
        {
            if (CurrentHunger > MaximumHunger)
                CurrentHunger = MaximumHunger;
            if (CurrentHunger < 0)
                CurrentHunger = 0;

            UpdateHunger();
        }

        public override void ProcessTriggers(TriggersSet triggersSet)
        {
            if (Survivaria.Instance.resourceMenuKey.JustPressed)
                ResourceMenu.visible = !ResourceMenu.visible;
        }

        public override void ResetEffects()
        {
            ResetHungerEffects();
        }
    }
}
