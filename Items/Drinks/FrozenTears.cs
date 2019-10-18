using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Survivaria.Items.Drinks
{
    public class FrozenTears : DrinkItem
    {
        public FrozenTears() : base("Frozen Tears", "Eternal and beautiful, those tears shall never dry out.", 20, 26, Item.buyPrice(0, 5, 0, 0), ItemRarityID.LightRed, 0, 8, SoundID.Item1, BuffID.Chilled, 60 * 5)
        {
        }

		public override void SetDefaults()
        {
            item.consumable = false;
            base.SetDefaults();
            item.UseSound = mod.GetLegacySoundSlot(SoundType.Custom, "Sounds/Drinking/LightDrink");
        }
    }
}