using GameProject.Controller;
using GameProject.View.DrawingElements;
using GameProject.View.UserInterface;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace GameProject.View.RenderingDirectory;

public class RenderingMovesHaveRunOut : Rendering
{
    private static readonly ContentManager Content = Program.Game.Content;
    public SoundEffect SoundOfEndGame = Content.Load<SoundEffect>("Звук конец игры");
    public SpriteBatch SpriteBatch;
    public SpriteFont TotalValuePropertyFont = Content.Load<SpriteFont>("Шрифт общая стоимость имущества");
    public Background Background = UserInterfaceMovesHaveRunOut.CreateBackground(Content);
    public Button HomeScreenExitButton = UserInterfaceMovesHaveRunOut.CreateHomeScreenExitButton(Content);
    public Inscription InscriptionWinner = UserInterfaceMovesHaveRunOut.CreateInscriptionWinner(Content);
    public string TotalValueProperty = "0$";

    public void DrawScreen()
    {
        SpriteBatch = Program.Game.SpriteBatch;
        Background.Draw(SpriteBatch);
        HomeScreenExitButton.Draw(SpriteBatch);
        InscriptionWinner.Draw(SpriteBatch);
        SpriteBatch.DrawString(TotalValuePropertyFont, TotalValueProperty, new Vector2(583, 452), Color.Black);
    }
}