using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Survivaria.Items.Misc
{
	public class LeadTrowel : SurvivariaItem
	{

    public LeadTrowel() : base("Lead Trowel", "The perfect tool to unearth the secrets of the plants.\nCan be used to harvest seeds from grown plants.", 28, 26, Item.buyPrice(0, 0, 9, 50), ItemRarityID.Blue)
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

    public override void AddRecipes()
    {
        ModRecipe recipe = new ModRecipe(mod);
        recipe.AddIngredient(ItemID.Wood, 2);
        recipe.AddIngredient(ItemID.LeadBar, 3);
        recipe.AddTile(TileID.Anvils);
        recipe.SetResult(this);
        recipe.AddRecipe();
    }
	}
}
