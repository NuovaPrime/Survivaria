using Survivaria.Buffs;
using System.Threading.Tasks;
using Terraria;

using Terraria.ID;
using Terraria.ModLoader;

namespace Survivaria.Items.BossItems
{
    public class TubofSlime : SurvivariaItem //Making this a survivariaitem because boss items are too unique and should not be influenced by any buffs or debuffs inflicted upon all foods.
    {
        public TubofSlime() : base("Tub of Slime", "A barrel filled to the brim with royal gel.", 28, 26, Item.buyPrice(0, 1, 0, 0), ItemRarityID.Green, 72, 0, SoundID.Item28, ModContent.BuffType<GellifiedBuff>(), 10800, 1)
        {
        }

        public override void SetDefaults()
        {
            item.consumable = true;
            base.SetDefaults();
        }
    }
}
