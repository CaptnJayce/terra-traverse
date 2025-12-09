using Terraria;
using Microsoft.Xna.Framework;
using Terraria.UI;
using Terraria.GameContent.UI.Elements;
using TerraTraverse.WorldGeneration;
using Terraria.Utilities;
using System.Linq;

namespace TerraTraverse.UI
{

    public class TerraUI : UIState
    {
        private static TerraGen _terraGen;
        private WorldSizeButton _worldSizeButton;

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

            _worldSizeButton = new WorldSizeButton
            {
                VAlign = 0.8f,
                HAlign = 0.5f
            };
            Append(_worldSizeButton);
        }

        // TODO: refactor this out of TerraMenu at some point
        private void CreateWorld(UIMouseEvent evt, UIElement listeningElement)
        {
            _terraGen = new TerraGen();

            if (_worldSizeButton.SelectedSize != null)
            {
                _terraGen.WorldSizeSetting = (TerraGen.Size)_worldSizeButton.SelectedSize.Value;
            }
            else
            {
                _terraGen.WorldSizeSetting = TerraGen.Size.Medium;
            }

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
