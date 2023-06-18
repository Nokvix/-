using GameProject.Controller;
using GameProject.View.DrawingElements;
using GameProject.View.UserInterface;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace GameProject.View.RenderingDirectory;

public class RulesFirstPageOnStartScreenRendering : Rendering
{
    private static readonly ContentManager Content = Program.Game.Content;
    public SpriteBatch SpriteBatch;

    public Background Background = UserInterfaceRulesFirstPageOnStartScreen.CreateBackground(Content);
    public Button HomeScreenExitButton = UserInterfaceRulesFirstPageOnStartScreen.CreateHomeScreenExitButton(Content);
    public Button NextPageButton = UserInterfaceRulesFirstPageOnStartScreen.CreateNextPageButton(Content);

    public void DrawScreen()
    {
        SpriteBatch = Program.Game.SpriteBatch;
        Background.Draw(SpriteBatch);
        HomeScreenExitButton.Draw(SpriteBatch);
        NextPageButton.Draw(SpriteBatch);
    }
}