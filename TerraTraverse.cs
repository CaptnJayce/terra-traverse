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
        private static UserInterface _terraInterface;
        private static TerraUI _terraUIState;

        public override bool PreDrawLogo (SpriteBatch spriteBatch, ref Vector2 logoDrawCenter, ref float logoRotation, ref float logoScale, ref Color drawColor)
        {
            return false; 
        }

        public override void OnSelected()
        {   
            Main.menuMode = 888;
            _terraUIState = new TerraUI();
            _terraUIState.SetupUI();
            _terraInterface = new UserInterface();
            _terraInterface.SetState(_terraUIState);
            Main.MenuUI.SetState(_terraUIState);
        }
    }
}
