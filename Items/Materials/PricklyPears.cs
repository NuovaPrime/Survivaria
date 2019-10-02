using System.Threading.Tasks;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace Survivaria.Items.Materials
{
    public class PricklyPears : SurvivariaItem
    {
        public PricklyPears() : base("Prickly Pears", "Extremely juicy but quite prickly to the touch.", 16, 24, Item.buyPrice(0, 0, 0, 50), ItemRarityID.Blue, 0, 0, SoundID.Item2)
        {
        }
    }
}
