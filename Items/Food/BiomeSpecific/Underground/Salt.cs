using System.Threading.Tasks;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace Survivaria.Items.Food.BiomeSpecific.Underground
{
    public class Salt : FoodItem
    {
        public Salt() : base("Salt", "It comes in many forms, but serves the same purpose. To use with moderation.", 24, 30, Item.buyPrice(0, 0, 1, 0), ItemRarityID.Blue, -1, -5, SoundID.Item2)
        {
        }
        public override void SetDefaults()
        {
            base.SetDefaults();
            item.UseSound = mod.GetLegacySoundSlot(SoundType.Custom, "Sounds/Drinking/CrunchEating");
        }

    }
}