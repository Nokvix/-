using Microsoft.Xna.Framework.Input;

namespace GameProject.Controller.States;

public class RulesSecondPageOnStartScreenState : State
{
    public RulesSecondPageOnStartScreenState(State nextState) : base(nextState) { }

    public override void PerformTask()
    {
        ActivateHomeScreenExitButton();
        ActivatePreviousPageButton();
    }
    
    private static void ActivateHomeScreenExitButton()
    {
        var homeScreenExitButton = Program.Game.RulesSecondPageOnStartScreenRendering.HomeScreenExitButton;
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
    
    private static void ActivatePreviousPageButton()
    {
        var previousPageButton = Program.Game.RulesSecondPageOnStartScreenRendering.PreviousPageButton;
        var mouseOverPreviousPageButton = previousPageButton.SpriteRectangle.Rectangle.Contains(Mouse.GetState().Position);

        if (mouseOverPreviousPageButton) 
            previousPageButton.ChangeToIlluminatedImage();
        else 
            previousPageButton.ChangeToActiveImage();
        
        if (Mouse.GetState().LeftButton == ButtonState.Released)
        {
            Program.Game.IsButtonDepressed = true;
        }

        if (mouseOverPreviousPageButton && Program.Game.IsButtonDepressed && Mouse.GetState().LeftButton == ButtonState.Pressed)
        {
            Program.Game.IsButtonDepressed = false;
            StoreOfStates.ChangeStateToFirstPageRulesOnStartScreen();
        }
    }
}