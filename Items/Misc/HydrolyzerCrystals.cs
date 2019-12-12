﻿using System.Threading.Tasks;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Survivaria.Items.Food.BiomeSpecific.Purity;
using Survivaria.Players;
using Survivaria.Items.Materials;

namespace Survivaria.Items.Misc
{
    public class HydrolyzerCrystals : SurvivariaItem
    {
        public HydrolyzerCrystals() : base("Hydrolyzer Crystals", "A handful of rare crystals that react with saliva to dictate the dehydration levels of the user.\nDisplays current thirst levels in detail when held in inventory or equipped.", 28, 26, Item.buyPrice(0, 10, 0, 0), ItemRarityID.Blue)
        {
        }

        public override void SetDefaults()
        {
            item.accessory = true;
            item.maxStack = 1;
            base.SetDefaults();
        }

		public override void UpdateEquip(Player player)
		{
            SurvivariaPlayer modPlayer = player.GetModPlayer<SurvivariaPlayer>();
            modPlayer.HydrolyzerCrystals = true;
		}
    }
}