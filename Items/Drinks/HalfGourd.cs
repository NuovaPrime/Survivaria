using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Survivaria.Players;

namespace Survivaria.Items.Drinks
{
    public class HalfGourd : SurvivariaItem
    {
        public HalfGourd() : base("Half Gourd", "A weathered gourd, half full of unfiltered water.", 20, 26, Item.buyPrice(0, 1, 50, 0), ItemRarityID.Green, 0, 8)
        {
        }

        public override void SetDefaults()
        {
            base.SetDefaults();
            item.consumable = true;
            item.useStyle = 2;
            item.UseSound = mod.GetLegacySoundSlot(SoundType.Custom, "Sounds/Drinking/GourdDrink");
            item.maxStack = 1;
        }

        public override bool UseItem(Player player)
        {
            player.GetModPlayer<SurvivariaPlayer>().AddThirst(8);
            player.PutItemInInventory(ModContent.ItemType<EmptyGourd>());
            return true;
        }
    }
}
