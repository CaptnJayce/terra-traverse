using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Terraria.UI;
using Terraria.GameContent.UI.Elements;
using TerraTraverse.WorldGeneration;
using Terraria.Utilities;
using System.Linq;

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

    public class WorldSizeButton : UIList
    {
        public enum SizeOption
        {
            Small,
            Medium,
            Large
        }

        public SizeOption? SelectedSize { get; private set; }

        public WorldSizeButton()
        {
            Width.Set(200, 0f);
            Height.Set(150, 0f);
            ListPadding = 6f;

            Add(CreateOption("Small", SizeOption.Small));
            Add(CreateOption("Medium", SizeOption.Medium));
            Add(CreateOption("Large", SizeOption.Large));
        }

        private UIElement CreateOption(string label, SizeOption size)
        {
            UIPanel panel = new UIPanel();
            panel.Width.Set(0, 1f);
            panel.Height.Set(40, 0);
            panel.BackgroundColor = new Color(70, 70, 120);

            UIText text = new UIText(label)
            {
                HAlign = 0.5f,
                VAlign = 0.5f
            };
            panel.Append(text);

            panel.OnLeftClick += (evt, listening) =>
            {
                SelectedSize = size;
                HighlightSelected(size);
            };

            return panel;
        }

        private void HighlightSelected(SizeOption size)
        {
            foreach (var element in this._items)
            {
                if (element is UIPanel panel)
                {
                    var text = panel.Children.OfType<UIText>().FirstOrDefault();
                    if (text == null) continue;

                    if (text.Text == size.ToString())
                    {
                        panel.BackgroundColor = new Color(120, 180, 250);
                    }
                    else
                    {
                        panel.BackgroundColor = new Color(70, 70, 120);
                    }
                }
            }
        }
    }

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
