using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Survivaria.Items.Misc
{
	public class DynastyTrowel : SurvivariaItem
	{

    public DynastyTrowel() : base("Dynasty Trowel", "Passed down generations of gardeners, it brings fertility to the plants it touches.\nCan be used to harvest seeds from grown plants.", 28, 26, Item.buyPrice(0, 10, 0, 0), ItemRarityID.Green)
    {
    }

    public override void SetDefaults()
    {
        base.SetDefaults();
        item.useTime = 10;
        item.pick = 1;
        item.useStyle = 1;
        item.maxStack = 1;
        item.UseSound = SoundID.Item1;
        item.autoReuse = true;
    }

	}
}
