using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent.UI.Elements;
using Terraria.ModLoader;

namespace TerraTraverse.UI
{
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
}