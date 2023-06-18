using GameProject.Controller;
using GameProject.View.DrawingElements;
using GameProject.View.UserInterface;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace GameProject.View.RenderingDirectory;

public class RulesSecondPageDuringGameRendering : Rendering
{
    private static readonly ContentManager Content = Program.Game.Content;
    public SpriteBatch SpriteBatch;

    public Background Background = UserInterfaceRulesSecondPageDuringGame.CreateBackground(Content);
    public Button ReturnToGameButton = UserInterfaceRulesSecondPageDuringGame.CreateReturnToGameButton(Content);
    public Button PreviousPageButton = UserInterfaceRulesSecondPageDuringGame.CreatePreviousPageButton(Content);

    public void DrawScreen()
    {
        SpriteBatch = Program.Game.SpriteBatch;
        Background.Draw(SpriteBatch);
        ReturnToGameButton.Draw(SpriteBatch);
        PreviousPageButton.Draw(SpriteBatch);
    }
}