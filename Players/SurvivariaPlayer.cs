using Survivaria.UI;
using Terraria.GameInput;
using Terraria.ModLoader;
using Terraria;

namespace Survivaria.Players
{
    public partial class SurvivariaPlayer : ModPlayer
    {
        public override void PostUpdate()
        {
			if (player.active)
			{
				#region Debuffs/Buffs if parameter...
				if (CurrentHunger <= 10)
				{
					player.meleeSpeed /= 2;
				}
				#endregion

                if (mod.GetConfig<SurvivariaConfigServer>().SanityEnabled)
                    UpdateSanity();
                if (mod.GetConfig<SurvivariaConfigServer>().HungerEnabled)
                    UpdateHunger(); //toggles timer and tick hunger removal;
                if (mod.GetConfig<SurvivariaConfigServer>().ThirstEnabled)
                    UpdateThirst();
                if (mod.GetConfig<SurvivariaConfigServer>().TemperatureEnabled)
                    UpdateTemperature();
                FailSafes();
                CalculatePlayerTemperature();
                //Do not remove. Comment out.
                ///* 
                //Main.NewText("Thirst is : " + CurrentThirst, 62, 32, 255);
				Main.NewText("Temperature is : " + CurrentTemperature, 255, 30, 0);
				//Main.NewText("Hunger is : " + CurrentHunger, 255, 150, 0);
				//Main.NewText("Sanity is : " + CurrentSanity, 0, 255, 50);//*/
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

		public void FailSafes()
		{
			if (HungerMaximum < 0)
				HungerMaximum = 100;

			if (CurrentHunger > 100)
				CurrentHunger = 100;
			else if (CurrentHunger < 0)
				CurrentHunger = 0;

			if (MaximumSanity < 0)
				MaximumSanity = 100;

			if (CurrentSanity > 100)
				CurrentSanity = 100;
			else if (CurrentSanity < 0)
				CurrentSanity = 0;

			if (MaximumThirst < 0)
				MaximumThirst = 100;

			if (CurrentThirst < 0)
				CurrentThirst = 0;
			else if (CurrentThirst > 100)
				CurrentThirst = 100;
		}
    }
}
