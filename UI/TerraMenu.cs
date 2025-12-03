using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public class TerraMenu : ModMenu
{
    public override string DisplayName => "TerraTraverse";

    private TerraMenuUI uiState;

    public override void OnSelected()
    {
        uiState = new TerraMenuUI();
        uiState.Activate();
        UserInterface.SetState(uiState);
    }

    public override void OnDeselected()
    {
        UserInterface.SetState(null);
    }

    public override void Update(bool isOnTitleScreen)
    {
        base.Update(isOnTitleScreen);
        UserInterface?.Update(Main._drawInterfaceGameTime);
    }

    public override bool PreDrawLogo(SpriteBatch spriteBatch, ref Vector2 logoDrawCenter, ref float logoRotation, ref float logoScale, ref Color drawColor)
    {
        return false;
    }
}
