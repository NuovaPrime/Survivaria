using System.Threading.Tasks;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace Survivaria.Items.BossItems
{
    public class TubofSlime : SurvivariaItem //Making this a survivariaitem because boss items are too unique and should not be influenced by any buffs or debuffs inflicted upon all foods.
    {
        public TubofSlime() : base("Tub of Slime", "A tub of slime that seems to refill itself instantly when consumed, it has a very unique smell and texture to it. \nGives a boost to jump height and immunity to slimes for 3 minutes but also reduces movement speed. \n--Unique food--", 28, 26, Item.buyPrice(0, 1, 0, 0), ItemRarityID.Green, 70, 0, SoundID.Item28, Survivaria.Instance.BuffType("GellifiedBuff"), 10800, 1)
        {
        }

        public override void SetDefaults()
        {
            item.consumable = true;
            base.SetDefaults();
        }
    }
}
