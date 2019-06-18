using Survivaria.UI;
using System;
using Terraria;
using Terraria.GameInput;
using Terraria.ModLoader;

namespace Survivaria.Players
{
    public partial class SurvivariaPlayer : ModPlayer
    {
        public override void PostUpdate()
        {
			if (player.active)
			{
				#region Failsafe measures.
				if (CurrentHunger > HungerMaximum)
					CurrentHunger = HungerMaximum;

				if (CurrentHunger < 0)
					CurrentHunger = 0;

				if (CurrentSanity < 0)
					CurrentSanity = 0;

				if (CurrentSanity > SanityMaximum)
					CurrentSanity = SanityMaximum;
				#endregion

				#region Debuffs/Buffs if parameter...
				if (CurrentHunger <= 10)
				{
					player.meleeSpeed /= 2;
				}
				#endregion

				UpdateSanity();
				UpdateHunger(); //toggles timer and tick hunger removal;
			}
        }

        public override void ProcessTriggers(TriggersSet triggersSet)
        {
            if (Survivaria.Instance.resourceMenuKey.JustPressed)
                ResourceMenu.visible = !ResourceMenu.visible;
        }

        public override void ResetEffects()
        {
            ResetHungerEffects();
			ResetSanityEffects();
			ResetTemperatureEffects();
			ResetThirstEffects();
        }
    }
}
