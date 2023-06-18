using GameProject.Controller;
using GameProject.View.DrawingElements;
using GameProject.View.UserInterface;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace GameProject.View.RenderingDirectory;

public class RulesFirstPageDuringGameRendering : Rendering
{
    private static readonly ContentManager Content = Program.Game.Content;
    public SpriteBatch SpriteBatch;

    public Background Background = UserInterfaceRulesFirstPageDuringGame.CreateBackground(Content);
    public Button ReturnToGameButton = UserInterfaceRulesFirstPageDuringGame.CreateReturnToGameButton(Content);
    public Button NextPageButton = UserInterfaceRulesFirstPageDuringGame.CreateNextPageButton(Content);

    public void DrawScreen()
    {
        SpriteBatch = Program.Game.SpriteBatch;
        Background.Draw(SpriteBatch);
        ReturnToGameButton.Draw(SpriteBatch);
        NextPageButton.Draw(SpriteBatch);
    }
}