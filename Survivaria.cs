using Terraria.ModLoader;

namespace Survivaria
{
	public class Survivaria : Mod
	{
		public Survivaria()
		{
            Properties = new ModProperties()
            {
                Autoload = true,
                AutoloadGores = true,
                AutoloadSounds = true
            };
        }
	}
}
