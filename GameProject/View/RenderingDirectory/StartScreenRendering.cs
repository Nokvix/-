using GameProject.Controller;
using GameProject.View.DrawingElements;
using GameProject.View.UserInterface;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace GameProject.View.RenderingDirectory;

public class StartScreenRendering : Rendering
{
    private static readonly ContentManager Content = Program.Game.Content;
    public SpriteBatch SpriteBatch;
    
    public Button PlayButton = UserInterfaceStartScreen.CreatePlayButton(Content);
    public Button RuleButton = UserInterfaceStartScreen.CreateRuleButton(Content);
    public Button ExitButton = UserInterfaceStartScreen.CreateExitButton(Content);
    public Button Button2Player = UserInterfaceStartScreen.Create2PlayerButton(Content);
    public Button Button3Player = UserInterfaceStartScreen.Create3PlayerButton(Content);
    public Button Button4Player = UserInterfaceStartScreen.Create4PlayerButton(Content);
    public Background Background = UserInterfaceStartScreen.CreateBackground(Content);

    public void DrawScreen()
    {
        SpriteBatch = Program.Game.SpriteBatch;
        Background.Draw(SpriteBatch);
        PlayButton.Draw(SpriteBatch);
        RuleButton.Draw(SpriteBatch);
        ExitButton.Draw(SpriteBatch);
        Button2Player.Draw(SpriteBatch);
        Button3Player.Draw(SpriteBatch);
        Button4Player.Draw(SpriteBatch);
    }
}