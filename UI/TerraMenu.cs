using Terraria.ModLoader;
using Terraria.GameContent.UI.Elements;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.UI;
using Terraria;

public class TerraMenu : ModMenu
{
    public override string DisplayName => "TerraTraverse";

    public override void OnSelected() {
        var ui = new TerraMenuUI();
        UserInterface?.SetState(ui);
    }

    public override void Update(bool isOnTitleScreen) {
        UserInterface?.Update(Main._drawInterfaceGameTime);
    }

    public override void PostDrawLogo(SpriteBatch spriteBatch, Vector2 logoDrawCenter, float logoRotation, float logoScale, Color drawColor) {
        UserInterface?.Draw(spriteBatch, Main._drawInterfaceGameTime);
    }
}

public class TerraMenuUI : UIState
{
    private UITextPanel<string> closeButton;

    public override void OnInitialize()
    {
        var panel = new UIPanel()
        {
            HAlign = 0.5f,
            VAlign = 0.55f,
            Width = new(250, 0f),
            Height = new(500, 0f),
            BackgroundColor = new Color(63, 82, 151)
        };
        Append(panel);

        closeButton = new UITextPanel<string>("Close")
        {
            Width = new(120, 0f),
            Height = new(40, 0f),
            HAlign = 0.5f,
            VAlign = 0.8f,
            BackgroundColor = new Color(63, 82, 151),
            TextColor = Color.White
        };
        closeButton.OnLeftClick += CloseButtonClicked;
        closeButton.OnUpdate += CloseButtonHoverEffect;
        panel.Append(closeButton);
    }

    private void CloseButtonHoverEffect(UIElement affectedElement)
    {
        var button = (UITextPanel<string>)affectedElement;

        if (button.IsMouseHovering)
        {
            button.TextColor = Color.Yellow;
            button.BackgroundColor = new Color(80, 100, 180); 
        }
        else
        {
            button.TextColor = Color.White;
            button.BackgroundColor = new Color(63, 82, 151);
        }
    }

    private void CloseButtonClicked(UIMouseEvent evt, UIElement listeningElement)
    {
        Main.menuMode = 0;
    }
}
