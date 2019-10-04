using System.Threading.Tasks;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace Survivaria.Items.Food.BiomeSpecific.Underground
{
    public class MushyCarrot : FoodItem
    {
        public MushyCarrot() : base("Mushy Carrot", "Unlike its appearance leads to believe, it isn't a fungus.\nGrants night vision for 30 seconds.", 24, 30, Item.buyPrice(0, 0, 1, 0), ItemRarityID.Blue, 7, 1, SoundID.Item2, BuffID.NightOwl, 60 * 30)
        {
        }
    }
}