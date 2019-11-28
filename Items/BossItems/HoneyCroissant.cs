using Survivaria.Buffs;
using System.Threading.Tasks;
using Terraria;

using Terraria.ID;
using Terraria.ModLoader;

namespace Survivaria.Items.BossItems
{
    public class HoneyCroissant : SurvivariaItem //Making this a survivariaitem because boss items are too unique and should not be influenced by any buffs or debuffs inflicted upon all foods.
    {
        public HoneyCroissant() : base("Honey-Filled Croissant", "Stuffed full of royal jelly, a worthy food for future rulers.", 28, 26, Item.buyPrice(0, 7, 0, 0), ItemRarityID.Orange, 34, 6, SoundID.Item2, ModContent.BuffType<QueenBuff>(), 60*60*4, 1)
        {
        }

        public override void SetDefaults()
        {
            base.SetDefaults();
            item.consumable = true;
            item.UseSound = mod.GetLegacySoundSlot(SoundType.Custom, "Sounds/Eating/CrunchEating");
        }
    }
}
