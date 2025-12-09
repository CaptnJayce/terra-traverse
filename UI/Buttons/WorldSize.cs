using System.Linq;
using Microsoft.Xna.Framework;
using Terraria.GameContent.UI.Elements;
using Terraria.UI;

namespace TerraTraverse.UI
{
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
}