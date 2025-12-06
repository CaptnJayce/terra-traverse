using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Terraria.UI;
using Terraria.GameContent.UI.Elements;
using Terraria.WorldBuilding;
using Terraria.IO;

// TODO:
// Decompose code
// Rename some things for clarity
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

            UIText generate = new UIText("Generate World");
            generate.HAlign = 0.5f;
            generate.VAlign = 0.5f;
            Append(generate);
        }
    }

    public class TerraUI : UIState
    {
        public void SetupUI()
        {
            CloseButton closeButton = new CloseButton
            {
                VAlign = 0.5f,
                HAlign = 1f
            };
            closeButton.OnLeftClick += new MouseEvent(CloseMenu);
            Append(closeButton);

            GenerateWorldButton generateWorldButton = new GenerateWorldButton
            {
                VAlign = 0.5f,
                HAlign = 0.5f
            };
            generateWorldButton.OnLeftClick += new MouseEvent(CreateWorld);
            Append(generateWorldButton);
        }

        private void CreateWorld(UIMouseEvent evt, UIElement listeningElement)
        {
            // This does NOT work lol. Gets stuck at Settling Liquids 34%
            WorldFileData worldData = new WorldFileData();
            WorldFile.SaveWorld();
            Main.ActiveWorldFileData = worldData;

            Main.WorldFileMetadata = worldData.Metadata;
            WorldGen.GenerateWorld(Main.ActiveWorldFileData.WorldSizeX); 

            WorldFile.SaveWorld();
            Main.menuMode = 10;

            // WorldGen.CreateNewWorld();
        }

        private void CloseMenu(UIMouseEvent evt, UIElement listeningElement)
        {
            Main.menuMode = 0;
        }
    }
}
