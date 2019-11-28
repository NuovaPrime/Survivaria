using Survivaria.Buffs;
using System.Threading.Tasks;
using Terraria;

using Terraria.ID;
using Terraria.ModLoader;

namespace Survivaria.Items.BossItems
{
    public class RootOfEvil : SurvivariaItem //Making this a survivariaitem because boss items are too unique and should not be influenced by any buffs or debuffs inflicted upon all foods.
    {
        public RootOfEvil() : base("Root of Evil", "The cause of all the woes in the world...?", 28, 26, Item.buyPrice(0, 7, 0, 0), ItemRarityID.Orange, 22, 0, SoundID.Item2, ModContent.BuffType<SkeleBuff>(), 60*60*4, 1)
        {
        }

        public override void SetDefaults()
        {
            base.SetDefaults();
            item.consumable = true;
            item.UseSound = mod.GetLegacySoundSlot(SoundType.Custom, "Sounds/Eating/FruitEating");
        }
    }
}
