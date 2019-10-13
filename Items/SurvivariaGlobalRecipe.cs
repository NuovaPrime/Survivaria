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
            if (recipe.createItem.type == mod.ItemType<GlowingWater>())
                if (!player.ZoneGlowshroom)
                    return false;
            if (recipe.createItem.type == mod.ItemType<FilteredWater>())
                if (!player.ZoneDesert)
                    return false;
            return true;
        }
    }
}
