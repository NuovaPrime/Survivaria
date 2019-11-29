using Microsoft.Xna.Framework;
using Survivaria.Items.Food;
using Survivaria.Players;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Terraria;

using Terraria.ID;
using Terraria.ModLoader;

namespace Survivaria.Items.CrossMod.Fargos
{
    public class MutantBossFood : SurvivariaItem
    {
        public MutantBossFood() : base("Bowl of ???", "The bowl pulses with unbelievable power, I wonder if it's edible.", 24, 30, Item.buyPrice(1, 0, 0, 0), ItemRarityID.Purple, 1, 1, SoundID.Item2, ModContent.BuffType<MutantBossFoodBuff>(), 300)
        {
        }
        public override bool Autoload(ref string name)
        {
            return ModLoader.GetMod("FargowiltasSouls") != null;
        }
        public override void SetDefaults()
        {
            base.SetDefaults();
            item.UseSound = mod.GetLegacySoundSlot(SoundType.Custom, "Sounds/Eating/MeatEating");
        }
        internal static Random random = new Random();
        public static char GetLetter()
        {
            int num = random.Next(0, 26);
            char let;
            if (random.Next(1) == 0)
                let = (char)('a' + num);
            else
                let = (char)('A' + num);

            return let;
        }
        public override bool UseItem(Player player)
        {
            SurvivariaPlayer modPlayer = player.GetModPlayer<SurvivariaPlayer>();
            modPlayer.CurrentHunger = 100;
            modPlayer.CurrentThirst = 100;
            return base.UseItem(player);
        }
        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            foreach (TooltipLine line2 in tooltips)
            {
                if (line2.mod == "Terraria" && line2.Name == "ItemName")
                {
                    line2.text = "Bowl of " + GetLetter() + GetLetter() + GetLetter() + GetLetter() + GetLetter() + GetLetter();
                    line2.overrideColor = Color.Red;
                }
            }
            base.ModifyTooltips(tooltips);
        }
    }
}