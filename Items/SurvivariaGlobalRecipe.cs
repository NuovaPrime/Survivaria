using Microsoft.Xna.Framework;
using Survivaria.Items.Drinks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Survivaria.Items
{
    public class SurvivariaGlobalRecipe : GlobalRecipe
    {
        public override bool RecipeAvailable(Recipe recipe)
        {
            Player player = Main.LocalPlayer;
            if (recipe.createItem.type == ModContent.ItemType<GlowingWater>())
                if (!player.ZoneGlowshroom)
                    return false;
            if (recipe.requiredTile == null && recipe.createItem.type == ModContent.ItemType<FilteredWater>())
                if (!player.ZoneDesert) //this is useless because it doesn't work as long as the first recipe is always available
                    return false;
            return true;
        }
    }
}
