using Microsoft.Xna.Framework.Input;

namespace GameProject.Controller.States;

public class RulesSecondPageDuringGameState : State
{
    public RulesSecondPageDuringGameState(State nextState) : base(nextState) { }

    public override void PerformTask()
    {
        ActivateReturnToGameButton();
        ActivatePreviousPageButton();
    }

    private static void ActivateReturnToGameButton()
    {
        var returnToGameButton = Program.Game.RulesSecondPageDuringGameRendering.ReturnToGameButton;
        var mouseOverReturnToGameButton =
            returnToGameButton.SpriteRectangle.Rectangle.Contains(Mouse.GetState().Position);
        returnToGameButton.ChangeToActiveImage();
        if (mouseOverReturnToGameButton)
            returnToGameButton.ChangeToIlluminatedImage();
        else
            returnToGameButton.ChangeToActiveImage();
        if (mouseOverReturnToGameButton && Mouse.GetState().LeftButton == ButtonState.Pressed)
        {
            StoreOfStates.ChangeToPlayerMoveState();
        }
    }

    private static void ActivatePreviousPageButton()
    {
        var previousPageButton = Program.Game.RulesSecondPageDuringGameRendering.PreviousPageButton;
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
            StoreOfStates.ChangeStateToFirstPageRulesDuringGame();
        }
    }
}