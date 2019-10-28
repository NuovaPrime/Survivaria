using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Survivaria.Buffs;
using Terraria.DataStructures;
using System.Collections.Generic;
using Terraria.GameContent.Events;

namespace Survivaria.Players
{
    public partial class SurvivariaPlayer : ModPlayer
    {
        public void AddHunger(int amount)
        {
            CurrentHunger += amount;
            int extraDifference = 0;
            if (CurrentHunger > 100)
            {
                extraDifference = 100 - amount;
                CurrentHunger = 100;
                player.AddBuff(ModContent.BuffType<NauseaDebuff>(), amount * 5 * 60);
            }
        }
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
				player.wellFed = true;
				player.statDefense += 2;
                player.allDamageMult += 0.05f;
				player.meleeCrit += 2;
				player.meleeSpeed += 0.05f;
				player.magicCrit += 2;
				player.rangedCrit += 2;
				player.thrownCrit += 2;
				player.minionKB += 0.5f;
				player.moveSpeed += 0.2f;
                ThirstLossMulti += 0.05f;
                CurrentTemperature += 2;
                player.AddBuff(ModContent.BuffType<WellFedBuff>(), 2);
            }
            if (CurrentHunger <= 41)
            {
				if(player.lifeRegen > 1) player.lifeRegen -= 2;
                player.statLifeMax2 -= 10;
                player.pickSpeed -= 0.15f;
                player.meleeSpeed -= 0.15f;
                player.moveSpeed -= 0.10f;
                if(CurrentHunger >= 21) player.AddBuff(ModContent.BuffType<HungryDebuff>(), 2);
            }
            if (CurrentHunger < 21)
            {
                if (Main.rand.Next(2000) == 0)
                    Main.PlaySound(mod.GetLegacySoundSlot(SoundType.Custom, "Sounds/StomachGrowl"));
				if(player.lifeRegen > 1) player.lifeRegen -= 2;
                player.statLifeMax2 -= 40;
                player.pickSpeed -= 0.3f;
                player.meleeSpeed -= 0.3f;
                player.moveSpeed -= 0.3f;
                if(CurrentHunger > 0) player.AddBuff(ModContent.BuffType<FamishedDebuff>(), 2);
            }
            if (CurrentHunger <= 0)
            {
                LossTimer++;
				if(player.lifeRegen > 0) player.lifeRegen = 0;
                if (LossTimer >= 20)
                {
                    if(player.statLife > 0) player.statLife -= 1;
                    if(player.statMana > 0) player.statMana -= 1;
					string playerName = Main.LocalPlayer.name;
                    if (player.statLife <= 0)
                    {
                        player.KillMe(PlayerDeathReason.ByCustomReason(playerName + " couldn't sustain the hunger."), 10.0, 0, false);
                        CurrentHunger = 20;
                    }
                    CurrentSanity -= 0.05f;
                    LossTimer = 0;
                }
                player.AddBuff(ModContent.BuffType<StarvingDebuff>(), 2);
            }
            if (player.statLife > player.statLifeMax2) player.statLife = player.statLifeMax2;
            if (player.HasBuff(BuffID.WellFed)) player.ClearBuff(BuffID.WellFed);
        }

        public double HungerLossRate()
        {
            if (player.HasBuff(BuffID.Bleeding))
                HungerLossMulti += 0.05f;
            if (CurrentSanity <= 30)
                HungerLossMulti += 0.08f;
            if (player.lifeRegenCount >= 2)
                HungerLossMulti += 0.1f;
            if (CurrentTemperature <= 0)
                HungerLossMulti += 0.12f;
            if (Main.expertMode) HungerLossMulti += 0.15f;
            if (HungerLossTimer >= 60)//1200, 30 for debug
            {
                _h = 0.055 * HungerLossMulti;//0.001, 1 for debug

                if (player.moveSpeed >= 20 && !player.controlMount)
					_h *= 2; //Gets doubled;
				if (player.HasBuff(ModContent.BuffType<EaterBuff>())) _h /= 2;
                HungerLossTimer = 0;
			}

            return _h;
		}

		private double _h = 0; // Someone comment on what this is. - Placeholder value for math reasons, not sure?

        public int HungerLossTimer { get; private set; }
        public float HungerLossMulti { get; set; } = 1f;

        public double HungerMaximum { get; set; }
        public double CurrentHunger { get; set; } = 70;
    }
}
