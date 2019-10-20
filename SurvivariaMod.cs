using Microsoft.Xna.Framework;
using Survivaria.UI;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.UI;
using Survivaria.Items.Materials;

namespace Survivaria
{
	public class SurvivariaMod : Mod
	{
        internal ModHotKey resourceMenuKey;
        private static ResourceMenu _resourceMenu;
        private static UserInterface _resourceMenuInterface;

        public SurvivariaMod()
		{
            Properties = new ModProperties()
            {
                Autoload = true,
                AutoloadGores = true,
                AutoloadSounds = true
            };

            Instance = this;
        }

        public override void Load()
        {
            //thoriumLoaded = ModLoader.GetMod("ThoriumMod") != null;

            resourceMenuKey = RegisterHotKey("Toggle Resources", "N");

            if (!Main.dedServ)
            {
                GFX.LoadGFX(this);

                ActivateResourceMenu();
            }
        }
        public override void Unload()
        {
            Instance = null;
            GFX.UnloadGFX();
            ResourceMenu.visible = true;
        }
        public static void ActivateResourceMenu()
        {
            _resourceMenu = new ResourceMenu();
            _resourceMenu.Activate();
            _resourceMenuInterface = new UserInterface();
            _resourceMenuInterface.SetState(_resourceMenu);
        }
        public override void UpdateUI(GameTime gameTime)
        {
            if (_resourceMenuInterface != null && ResourceMenu.visible)
                _resourceMenuInterface.Update(gameTime);

        }

        public override void ModifyInterfaceLayers(List<GameInterfaceLayer> layers)
        {
            int index2 = layers.FindIndex(layer => layer.Name.Contains("Hotbar"));
            if (index2 != -1)
            {
                layers.Insert(index2, new LegacyGameInterfaceLayer(
                    "Surviaria: Menus",
                    delegate
                    {
                        if (ResourceMenu.visible)
                        {
                            _resourceMenuInterface.Draw(Main.spriteBatch, Main._drawInterfaceGameTime);
                        }
                        return true;
                    },
                    InterfaceScaleType.UI)
                );
            }
        }

		public override void AddRecipes()
		{
			RecipeHelper.AddVanillaRecipes(this);
		}

        public override void AddRecipeGroups()
        {
            // Creates a new recipe group
            RecipeGroup seeds = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " " + "Seed", new[]
            {
                (int)ItemID.BlinkrootSeeds,
                ItemID.CorruptSeeds,
                ItemID.CrimsonSeeds,
                ItemID.DaybloomSeeds,
                ItemID.DeathweedSeeds,
                ItemID.FireblossomSeeds,
                ItemID.GrassSeeds,
                ItemID.HallowedSeeds,
                ItemID.JungleGrassSeeds,
                ItemID.MoonglowSeeds,
                ItemID.MushroomGrassSeeds,
                ItemID.ShiverthornSeeds,
                ItemID.WaterleafSeeds
            });
            // Registers the new recipe group with the specified name
            RecipeGroup.RegisterGroup("Survivaria:Seeds", seeds);

			RecipeGroup pears = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " " + "Prickly Pear", new int[]
            {
                ModContent.ItemType<PricklyPearMagenta>(),
                ModContent.ItemType<PricklyPearRed>(),
				ModContent.ItemType<PricklyPearOrange>(),
				ModContent.ItemType<PricklyPearYellow>(),
				ModContent.ItemType<PricklyPearWhite>()
            });
            RecipeGroup.RegisterGroup("Survivaria:Pears", pears);

			RecipeGroup ofish = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " " + "Ocean Fish", new int[]
            {
                ItemID.Tuna,
                ItemID.RedSnapper,
                ItemID.Trout
            });
            RecipeGroup.RegisterGroup("Survivaria:OceanFish", ofish);

			RecipeGroup duck = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " " + "Duck", new int[]
            {
                ItemID.MallardDuck,
                ItemID.Duck
            });
            RecipeGroup.RegisterGroup("Survivaria:Ducks", duck);

			RecipeGroup bird = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " " + "Bird", new int[]
            {
                ItemID.Bird,
                ItemID.Cardinal,
                ItemID.BlueJay
            });
            RecipeGroup.RegisterGroup("Survivaria:Birds", bird);

			RecipeGroup squirrel = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " " + "Squirrel", new int[]
            {
                ItemID.Squirrel,
                ItemID.SquirrelRed
            });
            RecipeGroup.RegisterGroup("Survivaria:Squirrels", squirrel);
        }

        public static SurvivariaMod Instance { get; set; }
    }
}
