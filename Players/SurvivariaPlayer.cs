using Survivaria.UI;
using Terraria.GameInput;
using Terraria.ModLoader;
using Terraria;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Terraria.ModLoader.IO;
using Survivaria.Buffs;
using System.Collections.Generic;
using Survivaria.Items.Food.Meal;

namespace Survivaria.Players
{
    public partial class SurvivariaPlayer : ModPlayer
    {
        public override void PostUpdate()
        {
			if (player.active)
			{
                //if (ModContent.GetInstance<SurvivariaConfigServer>().SanityEnabled)
                    //UpdateSanity();
                if (ModContent.GetInstance<SurvivariaConfigServer>().HungerEnabled)
                    UpdateHunger(); //toggles timer and tick hunger removal;
                if (ModContent.GetInstance<SurvivariaConfigServer>().ThirstEnabled)
                    UpdateThirst();
                //if (ModContent.GetInstance<SurvivariaConfigServer>().TemperatureEnabled)
                    //UpdateTemperature();
                FailSafes();
                CalculatePlayerTemperature();
                //Do not remove. Comment out.
                ///* 
                //Main.NewText("Thirst is : " + CurrentThirst, 62, 32, 255);
				//Main.NewText("Temperature is : " + CurrentTemperature, 255, 30, 0);
				//Main.NewText("Hunger is : " + CurrentHunger, 255, 150, 0);
				//Main.NewText("Sanity is : " + CurrentSanity, 0, 255, 50);//*/
			}
        }

		public override void OnHitNPCWithProj(Projectile proj, NPC target, int damage, float knockback, bool crit)
		{
			if (player.HasBuff(ModContent.BuffType<SkeleBuff>()) && Main.rand.Next(3) == 0) target.AddBuff(BuffID.ShadowFlame, 30*5, true);
			if (player.HasBuff(ModContent.BuffType<EaterBuff>()) && Main.rand.Next(38) == 0) target.AddBuff(BuffID.CursedInferno, 30*8, true);
		}

		public override void OnHitNPC(Item item, NPC target, int damage, float knockback, bool crit)
		{
			if (player.HasBuff(ModContent.BuffType<SkeleBuff>()) && Main.rand.Next(3) == 0) target.AddBuff(BuffID.ShadowFlame, 30*5, true);
			if (player.HasBuff(ModContent.BuffType<EaterBuff>()) && Main.rand.Next(28) == 0) target.AddBuff(BuffID.CursedInferno, 30*8, true);
		}

        public override void ProcessTriggers(TriggersSet triggersSet)
        {
            if (SurvivariaMod.Instance.resourceMenuKey.JustPressed)
                ResourceMenu.visible = !ResourceMenu.visible;
        }

        public override void SetupStartInventory(IList<Item> items, bool mediumcoreDeath)
        {
            Item item = new Item();
            item.SetDefaults(ModContent.ItemType<MRE>());
            item.stack = 4;
            items.Add(item);
        }

        public override void ResetEffects()
        {
            ResetHungerEffects();
			ResetSanityEffects();
			ResetTemperatureEffects();
			ResetThirstEffects();
            HydrolyzerCrystals = false;
            BloodAnalyzer = false;
        }

		public void FailSafes()
		{
			if (HungerMaximum < 0)
				HungerMaximum = 100;

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
		}

        public override TagCompound Save()
        {
            TagCompound tag = new TagCompound();
            tag.Add(nameof(MenuOffset), MenuOffset);
            tag.Add(nameof(CurrentHunger), CurrentHunger);
            tag.Add(nameof(CurrentThirst), CurrentThirst);

            return tag;
        }

        public override void Load(TagCompound tag)
        {
            MenuOffset = tag.Get<Vector2>(nameof(MenuOffset));
            CurrentHunger = tag.Get<double>(nameof(CurrentHunger));
            CurrentThirst = tag.Get<double>(nameof(CurrentThirst));
        }

        public bool HydrolyzerCrystals { get; set; }
        public bool BloodAnalyzer { get; set; }
        public Vector2 MenuOffset { get; set; } = Vector2.Zero;
    }
}
