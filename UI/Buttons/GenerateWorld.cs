using Microsoft.Xna.Framework;
using Terraria.GameContent.UI.Elements;

namespace TerraTraverse.UI
{
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
}