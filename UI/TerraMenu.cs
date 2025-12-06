using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Terraria.UI;
using Terraria.GameContent.UI.Elements;
using TerraTraverse.WorldGeneration;
using Terraria.Utilities;

// TODO:
// Start generating worlds 
namespace TerraTraverse.UI
{
    // Logic for closing menu
    public class CloseButton : UIPanel
    {
        public CloseButton()
        {
            Width.Set(40, 0);
            Height.Set(40, 0);
            SetPadding(4);
            BackgroundColor = new Color(200, 50, 50);

            UIImage close = new UIImage(ModContent.Request<Texture2D>("TerraTraverse/Images/closeButton"));
            Append(close);
        }
    }

    public class GenerateWorldButton : UIPanel
    {
        public GenerateWorldButton()
        {
            Width.Set(150, 0);
            Height.Set(40, 0);
            SetPadding(4);
            BackgroundColor = new Color(50, 200, 50);

            UIText generate = new UIText("Generate World")
            {
                HAlign = 0.5f,
                VAlign = 0.5f
            };
            Append(generate);
        }
    }

    public class TerraUI : UIState
    {
        private static TerraGen _terraGen;

        public void SetupUI()
        {
            CloseButton closeButton = new CloseButton
            {
                VAlign = 0.5f,
                HAlign = 1f
            };
            closeButton.OnLeftClick += CloseMenu;
            Append(closeButton);

            GenerateWorldButton generateWorldButton = new GenerateWorldButton
            {
                VAlign = 0.5f,
                HAlign = 0.5f
            };
            generateWorldButton.OnLeftClick += CreateWorld;
            Append(generateWorldButton);
        }

        private static void CreateWorld(UIMouseEvent evt, UIElement listeningElement)
        {
            _terraGen = new TerraGen();
            _terraGen.InitWorldParams();

            WorldGen._genRand = new UnifiedRandom();
            WorldGen.CreateNewWorld();
            
            Main.menuMode = 0;
        }

        private static void CloseMenu(UIMouseEvent evt, UIElement listeningElement)
        {
            Main.menuMode = 0;
        }
    }
}
