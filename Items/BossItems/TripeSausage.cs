using Survivaria.Buffs;
using System.Threading.Tasks;
using Terraria;

using Terraria.ID;
using Terraria.ModLoader;

namespace Survivaria.Items.BossItems
{
    public class TripeSausage : SurvivariaItem //Making this a survivariaitem because boss items are too unique and should not be influenced by any buffs or debuffs inflicted upon all foods.
    {
        public TripeSausage() : base("Endless Tripe Sausage", "Another one, and another one, and another one, and...", 28, 26, Item.buyPrice(0, 5, 0, 0), ItemRarityID.Green, 100, -16, SoundID.Item2, ModContent.BuffType<EaterBuff>(), 60*60*15, 1)
        {
        }

        public override void SetDefaults()
        {
            base.SetDefaults();
            item.consumable = true;
            item.UseSound = mod.GetLegacySoundSlot(SoundType.Custom, "Sounds/Drinking/MeatEating");
        }
    }
}
