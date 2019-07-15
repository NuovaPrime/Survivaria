using Microsoft.Xna.Framework;
using Survivaria.UI;
using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;
using Terraria.UI;

namespace Survivaria
{
	public class Survivaria : Mod
	{
        internal ModHotKey resourceMenuKey;
        private static ResourceMenu _resourceMenu;
        private static UserInterface _resourceMenuInterface;

        public Survivaria()
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

        internal static Survivaria Instance { get; private set; }
    }
}
