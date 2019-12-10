using System.Threading.Tasks;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Survivaria.Items.Food.BiomeSpecific.Purity;
using Survivaria.Players;
using Survivaria.Items.Materials;

namespace Survivaria.Items.Misc
{
    public class BloodAnalyzer : SurvivariaItem
    {
        public BloodAnalyzer() : base("Blood Analyzer", "A high-tech piece of goblin tech that tests the sugar and nutrition levels of the user.\nDisplays current hunger levels in detail when held in inventory or equipped.", 28, 26, Item.buyPrice(0, 10, 0, 0), ItemRarityID.Blue)
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
            modPlayer.BloodAnalyzer = true;
		}
    }
}
