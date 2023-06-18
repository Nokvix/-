using GameProject.Controller;
using GameProject.View.DrawingElements;
using GameProject.View.UserInterface;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace GameProject.View.RenderingDirectory;

public class RulesSecondPageOnStartScreenRendering : Rendering
{
    private static readonly ContentManager Content = Program.Game.Content;
    public SpriteBatch SpriteBatch;

    public Background Background = UserInterfaceRulesSecondPageOnStartScreen.CreateBackground(Content);
    public Button HomeScreenExitButton = UserInterfaceRulesSecondPageOnStartScreen.CreateHomeScreenExitButton(Content);
    public Button PreviousPageButton = UserInterfaceRulesSecondPageOnStartScreen.CreatePreviousPageButton(Content);

    public void DrawScreen()
    {
        SpriteBatch = Program.Game.SpriteBatch;
        Background.Draw(SpriteBatch);
        HomeScreenExitButton.Draw(SpriteBatch);
        PreviousPageButton.Draw(SpriteBatch);
    }
}