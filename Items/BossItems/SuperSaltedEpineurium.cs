using Survivaria.Buffs;
using System.Threading.Tasks;
using Terraria;

using Terraria.ID;
using Terraria.ModLoader;

namespace Survivaria.Items.BossItems
{
    public class SuperSaltedEpineurium : SurvivariaItem //Making this a survivariaitem because boss items are too unique and should not be influenced by any buffs or debuffs inflicted upon all foods.
    {
        public SuperSaltedEpineurium() : base("Super Salted Epineurium", "Ripped out of your defeated enemy, a trophy of the victorious.", 28, 26, Item.buyPrice(0, 5, 0, 0), ItemRarityID.Green, 56, -26, SoundID.Item2, ModContent.BuffType<BrainBuff>(), 60*60*5, 1)
        {
        }

        public override void SetDefaults()
        {
            base.SetDefaults();
            item.consumable = true;
            item.useStyle = 2;
            item.UseSound = mod.GetLegacySoundSlot(SoundType.Custom, "Sounds/Eating/MeatEating");
        }
    }
}
