using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Terraria.UI;
using Terraria.GameContent.UI.Elements;

// TODO:
// Decompose code
// Rename some things for clarity
// Start generating worlds 
namespace TerraTraverse.UI
{
    public class TerraTraverseUISystem : ModSystem
    {
        public UserInterface userInterface;
        public CloseButtonHandler closeButtonHandler;

        public override void Load()
        {
            userInterface = new UserInterface();
            closeButtonHandler= new CloseButtonHandler();
            
            closeButtonHandler.Activate(); 
        }

        public override void UpdateUI(GameTime gameTime)
        {
            userInterface?.Update(gameTime);
        }
    }

    // Hide most default UI elements
    public class TerraMenu : ModMenu
    {
        public override bool PreDrawLogo(SpriteBatch spriteBatch, ref Vector2 logoDrawCenter, ref float logoRotation, ref float logoScale, ref Color drawColor)
        {
            return false; 
        }

        public override void OnSelected()
        {   
            Main.menuMode = 888;
                        
            if (ModContent.GetInstance<TerraTraverseUISystem>().closeButtonHandler!= null)
            {
                Main.MenuUI.SetState(ModContent.GetInstance<TerraTraverseUISystem>().closeButtonHandler);
            }
        }
    }
    
    // Styling for the close button
    public class CloseButton : UIPanel
    {
        private UIText text;
        private Color colour = Color.White;

        public CloseButton(string buttonText, Color buttonColour)
        {
            Width.Set(150f, 0f);
            Height.Set(40f, 0f);
            SetPadding(0); 

            BackgroundColor = new Color(63, 82, 151) * 0.7f;

            text = new UIText(buttonText, 1f, false)
            {
                HAlign = 0.5f,
                VAlign = 0.5f
            };
            Append(text);
            colour = buttonColour;
        }

        public override void MouseOver(UIMouseEvent evt)
        {
            base.MouseOver(evt);
            BackgroundColor = new Color(73, 94, 171);
        }
        
        public override void MouseOut(UIMouseEvent evt)
        {
            base.MouseOut(evt);
            BackgroundColor = new Color(63, 82, 151) * 0.7f;
        }
    }

    // Logic for closing menu
    public class CloseButtonHandler : UIState
    {
        public CloseButton MyTextButton; 

        public override void OnInitialize()
        {
            MyTextButton = new CloseButton("Close Menu", Color.White); 
            
            MyTextButton.Left.Set(100f, 0f);
            MyTextButton.Top.Set(200f, 0f);
            
            MyTextButton.OnLeftClick += new MouseEvent(CloseMenu);
            
            Append(MyTextButton);
        }

        private void CloseMenu(UIMouseEvent evt, UIElement listeningElement)
        {
            Main.menuMode = 0;
        }
    }
}
