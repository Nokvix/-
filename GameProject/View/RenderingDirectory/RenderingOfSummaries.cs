using GameProject.Controller;
using GameProject.View.DrawingElements;
using GameProject.View.UserInterface;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace GameProject.View.RenderingDirectory;

public class RenderingOfSummaries : Rendering
{
    private static readonly ContentManager Content = Program.Game.Content;
    public SoundEffect SoundOfEndGame = Content.Load<SoundEffect>("Звук конец игры");
    public SpriteBatch SpriteBatch;
    public Background Background = UserInterfaceBankruptcy.CreateBackground(Content);
    public Button HomeScreenExitButton = UserInterfaceBankruptcy.CreateHomeScreenExitButton(Content);
    public Inscription InscriptionLoser = UserInterfaceBankruptcy.CreateInscriptionLoser(Content);
    public Inscription InscriptionWinner = UserInterfaceBankruptcy.CreateInscriptionWinner(Content);

    public void DrawScreen()
    {
        SpriteBatch = Program.Game.SpriteBatch;
        Background.Draw(SpriteBatch);
        HomeScreenExitButton.Draw(SpriteBatch);
        InscriptionLoser.Draw(SpriteBatch);
        InscriptionWinner.Draw(SpriteBatch);
    }
}