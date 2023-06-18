using Microsoft.Xna.Framework.Input;

namespace GameProject.Controller.States;

public class RulesFirstPageOnStartScreenState : State
{
    public RulesFirstPageOnStartScreenState(State nextState) : base(nextState) { }

    public override void PerformTask()
    {
        ActivateHomeScreenExitButton();
        ActivateNextPageButton();
    }
    
    private static void ActivateHomeScreenExitButton()
    {
        var homeScreenExitButton = Program.Game.RulesFirstPageOnStartScreenRendering.HomeScreenExitButton;
        homeScreenExitButton.ChangeToActiveImage();
        var mouseOverHomeScreenExitButton = homeScreenExitButton.SpriteRectangle.Rectangle.Contains(Mouse.GetState().Position);

        if (mouseOverHomeScreenExitButton)
            homeScreenExitButton.ChangeToIlluminatedImage();
        else
            homeScreenExitButton.ChangeToActiveImage();

        if (mouseOverHomeScreenExitButton && Mouse.GetState().LeftButton == ButtonState.Pressed)
        {
            StoreOfStates.ChangeStateToStartScreen();
        }
    }

    private static void ActivateNextPageButton()
    {
        var nextPageButton = Program.Game.RulesFirstPageOnStartScreenRendering.NextPageButton;
        var mouseOverNextPageButton = nextPageButton.SpriteRectangle.Rectangle.Contains(Mouse.GetState().Position);

        if (mouseOverNextPageButton) 
            nextPageButton.ChangeToIlluminatedImage();
        else 
            nextPageButton.ChangeToActiveImage();
        
        if (Mouse.GetState().LeftButton == ButtonState.Released)
        {
            Program.Game.IsButtonDepressed = true;
        }

        if (mouseOverNextPageButton && Program.Game.IsButtonDepressed && Mouse.GetState().LeftButton == ButtonState.Pressed)
        {
            Program.Game.IsButtonDepressed = false;
            StoreOfStates.ChangeStateToSecondPageRulesOnStartScreen();
        }
    }
}