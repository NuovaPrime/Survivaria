using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Survivaria.Items.Food.Snack
{
    public class CrabBar : FoodItem
    {
        public CrabBar() : base("Crab Sticks?", "A pretty popular food!", 24, 30, Item.buyPrice(0, 13, 3, 7), ItemRarityID.Purple, 42, 0, SoundID.Item2, BuffID.Gills, 60 * 9001)
        {
        }

        public override void SetDefaults()
        {
            base.SetDefaults();
            item.UseSound = mod.GetLegacySoundSlot(SoundType.Custom, "Sounds/Drinking/MeatEating");
        }

		public override bool UseItem(Player player)
        {
            player.AddBuff(BuffID.Flipper, 60 * 9001);
            return base.UseItem(player);
        }
    }
}