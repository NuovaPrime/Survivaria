using Survivaria.Buffs;
using System.Threading.Tasks;
using Terraria;

using Terraria.ID;
using Terraria.ModLoader;

namespace Survivaria.Items.BossItems
{
    public class SpaghettiOfCthulhu : SurvivariaItem //Making this a survivariaitem because boss items are too unique and should not be influenced by any buffs or debuffs inflicted upon all foods.
    {
        public SpaghettiOfCthulhu() : base("Spaghetti of Cthulhu", "It needs to be spun around the fork, made into a ball then straight into the mouth.", 28, 26, Item.buyPrice(0, 3, 0, 0), ItemRarityID.Green, 54, 0, SoundID.Item2, ModContent.BuffType<EyeBuff>(), 60*60*4, 1)
        {
        }

        public override void SetDefaults()
        {
            base.SetDefaults();
            item.consumable = true;
            item.UseSound = mod.GetLegacySoundSlot(SoundType.Custom, "Sounds/Eating/MeatEating");
        }
    }
}
