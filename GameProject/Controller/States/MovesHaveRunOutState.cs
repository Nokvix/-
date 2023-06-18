using GameProject.Model;
using Microsoft.Xna.Framework.Input;

namespace GameProject.Controller.States;

public class MovesHaveRunOutState : State
{
    public MovesHaveRunOutState(State nextState) : base(nextState) { }

    public override void PerformTask()
    {
        ActivateWinnerInformation();
        ActivateHomeScreenExitButton();
    }
    
    private static void ActivateWinnerInformation()
    {
        var winnerIndex = -1;
        var bestResult = -1;
        for (var i = 0; i < Program.Game.NumberOfPlayers; i++)
        {
            var player = Field.Players[i];
            if (player.TotalValueProperty >= bestResult)
            {
                bestResult = player.TotalValueProperty;
                winnerIndex = i;
            }
        }

        Program.Game.RenderingMovesHaveRunOut.TotalValueProperty = bestResult + "$";

        switch (winnerIndex)
        {
            case 0:
                Program.Game.RenderingMovesHaveRunOut.InscriptionWinner.ChangeToYellow();
                break;
            case 1:
                Program.Game.RenderingMovesHaveRunOut.InscriptionWinner.ChangeToBlue();
                break;
            case 2:
                Program.Game.RenderingMovesHaveRunOut.InscriptionWinner.ChangeToRed();
                break;
            case 3:
                Program.Game.RenderingMovesHaveRunOut.InscriptionWinner.ChangeToGreen();
                break;
        }
    }
    
    private static void ActivateHomeScreenExitButton()
    {
        var homeScreenExitButton = Program.Game.RenderingMovesHaveRunOut.HomeScreenExitButton;
        homeScreenExitButton.ChangeToActiveImage();
        homeScreenExitButton.ChangeToIlluminatedImage();
        var mouseOverHomeScreenExitButton = homeScreenExitButton.SpriteRectangle.Rectangle.Contains(Mouse.GetState().Position);
        
        if (mouseOverHomeScreenExitButton)
        {
            homeScreenExitButton.ChangeToIlluminatedImage();
            AssignmentOfOutputInformationOnly.DisplayStartScreenWarning();
        }
        else 
            homeScreenExitButton.ChangeToActiveImage();

        if (mouseOverHomeScreenExitButton && Mouse.GetState().LeftButton == ButtonState.Pressed)
        {
            StoreOfStates.ChangeStateToStartScreen();
        }
    }
}