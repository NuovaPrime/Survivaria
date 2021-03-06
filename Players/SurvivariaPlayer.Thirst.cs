﻿using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Survivaria.Buffs;
using Terraria.DataStructures;
using System.Collections.Generic;
using Terraria.GameContent.Events;
using Survivaria.Items.Misc;

namespace Survivaria.Players
{
    public partial class SurvivariaPlayer : ModPlayer
    {
        public void AddThirst(int amount)
        {
            CurrentThirst += amount;
            int extraDifference = 0;
            if (CurrentThirst > 100)
            {
                extraDifference = 100 - amount;
                CurrentThirst = 100;
                player.AddBuff(ModContent.BuffType<HyponatremiaDebuff>(), amount * 3 * 60);
            }	
        }
        internal void ResetThirstEffects()
        {
            _t = 0;
            MaximumThirst = 100;
            ThirstLossMulti = 1f;
        }

        private int LossTimer = 0;
        internal void UpdateThirst() //Called every single tick;
        {
            if (ModContent.GetInstance<SurvivariaConfigServer>().ThirstEnabled)
            {
                ThirstLossTimer++;//Do NOT include debugging in separate files. Include in player file.

                CurrentThirst -= ThirstLossRate();

                if (CurrentThirst >= 80)
                {
                    player.manaCost -= 0.10f;
                    player.pickSpeed += 0.10f;
                    player.allDamageMult += 0.08f;
                    player.AddBuff(ModContent.BuffType<WellHydratedBuff>(), 2);
                }
                if (CurrentThirst <= 41)
                {
                    player.manaCost += 0.25f;
                    player.pickSpeed -= 0.20f;
                    player.allDamageMult -= 0.15f;
                    player.moveSpeed -= 0.10f;
                    if (CurrentHunger >= 21) player.AddBuff(ModContent.BuffType<ThirstyDebuff>(), 2);
                }
                if (CurrentThirst < 21)
                {
                    if (Main.rand.Next(5000) == 0)
                        Main.PlaySound(mod.GetLegacySoundSlot(SoundType.Custom, "Sounds/ThirstCough").WithVolume(1f));
                    player.manaCost += 0.25f;
                    player.pickSpeed -= 0.20f;
                    player.allDamageMult -= 0.15f;
                    player.moveSpeed -= 0.10f;
                    if (CurrentThirst > 0) player.AddBuff(ModContent.BuffType<DehydratedDebuff>(), 2);
                }
                if (CurrentThirst <= 0)
                {
                    LossTimer++;
                    if (player.lifeRegen > 0) player.lifeRegen = 0;
                    if (LossTimer >= 20)
                    {
                        if (player.statLife > 0) player.statLife -= 1;
                        if (player.statMana > 0) player.statMana -= 2;
                        string playerName = Main.LocalPlayer.name;
                        if (player.statLife <= 0)
                        {
                            player.KillMe(PlayerDeathReason.ByCustomReason(playerName + " turned back to dust."), 10.0, 0, false);
                            CurrentThirst = 20;
                        }
                        CurrentSanity -= 0.05f;
                        LossTimer = 0;
                    }
                    player.AddBuff(ModContent.BuffType<ParchedDebuff>(), 2);
                }
                if (player.HasItem(ModContent.ItemType<HydrolyzerCrystals>())) HydrolyzerCrystals = true;
            }
        }

        public double ThirstLossRate()
        {
            if (player.HasBuff(BuffID.Wet)) ThirstLossMulti -= 0.25f;
            if (CurrentTemperature <= 0)
                ThirstLossMulti -= 0.2f;
            if (CurrentTemperature >= 38)
                ThirstLossMulti += 0.2f;
            if (CurrentTemperature >= 52)
                ThirstLossMulti += 0.3f;
            if (Main.expertMode) ThirstLossMulti += 0.15f;
            if (ThirstLossTimer >= 60)//1200, 30 for debug
            {
                _t = 0.05 * ThirstLossMulti * ModContent.GetInstance<SurvivariaConfigServer>().ThirstDrainRateMulti;//0.06, 1 for debug

                if (player.moveSpeed >= 20 && !player.controlMount)
                    _t *= 2; //Gets doubled;

                ThirstLossTimer = 0;
            }

            return _t;
        }
        private double _t = 0;
        public int ThirstLossTimer { get; set; }
        public float ThirstLossMulti { get; set; }
        public double CurrentThirst { get; set; } = 70;
        public double MaximumThirst { get; set; }
    }
}
