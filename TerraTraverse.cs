using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.UI;
using TerraTraverse.UI;

namespace TerraTraverse
{
    // Hide most default UI elements
    public class TerraTraverse : ModMenu
    {
        internal static UserInterface TerraInterface;
        internal static TerraUI TerraUIState;

        public override bool PreDrawLogo (SpriteBatch spriteBatch, ref Vector2 logoDrawCenter, ref float logoRotation, ref float logoScale, ref Color drawColor)
        {
            return false; 
        }

        public override void OnSelected()
        {   
            Main.menuMode = 888;
            TerraUIState = new TerraUI();
            TerraUIState.SetupUI();
            TerraInterface = new UserInterface();
            TerraInterface.SetState(TerraUIState);
            Main.MenuUI.SetState(TerraUIState);
        }
    }
}
