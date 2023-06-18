using GameProject.Model;
using Microsoft.Xna.Framework.Input;
using MonopolyGame.FieldObjects;

namespace GameProject.Controller.States;

public class SummingUpState : State
{
    public SummingUpState(State nextState) : base(nextState) { }

    public override void PerformTask()
    {
        ActivateWinnerInformation();
        ActivateLoserInformation();
        ActivateHomeScreenExitButton();
    }

    private static void ActivateWinnerInformation()
    {
        var winnerIndex = -1;
        var bestResult = -1;
        for (var i = 0; i < Program.Game.NumberOfPlayers; i++)
        {
            var player = Field.Players[i];
            if (Program.Game.Bankrupt != i && player.TotalValueProperty >= bestResult)
            {
                bestResult = player.TotalValueProperty;
                winnerIndex = i;
            }
        }

        switch (winnerIndex)
        {
            case 0:
                Program.Game.RenderingOfSummaries.InscriptionWinner.ChangeToYellow();
                break;
            case 1:
                Program.Game.RenderingOfSummaries.InscriptionWinner.ChangeToBlue();
                break;
            case 2:
                Program.Game.RenderingOfSummaries.InscriptionWinner.ChangeToRed();
                break;
            case 3:
                Program.Game.RenderingOfSummaries.InscriptionWinner.ChangeToGreen();
                break;
        }
    }

    private static void ActivateLoserInformation()
    {
        switch (Program.Game.Bankrupt)
        {
            case 0:
                Program.Game.RenderingOfSummaries.InscriptionLoser.ChangeToYellow();
                break;
            case 1:
                Program.Game.RenderingOfSummaries.InscriptionLoser.ChangeToBlue();
                break;
            case 2:
                Program.Game.RenderingOfSummaries.InscriptionLoser.ChangeToRed();
                break;
            case 3:
                Program.Game.RenderingOfSummaries.InscriptionLoser.ChangeToGreen();
                break;
        }
    }
    
    private static void ActivateHomeScreenExitButton()
    {
        var homeScreenExitButton = Program.Game.RenderingOfSummaries.HomeScreenExitButton;
        homeScreenExitButton.ChangeToActiveImage();
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