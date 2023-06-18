using Microsoft.Xna.Framework.Input;

namespace GameProject.Controller.States;

public class RulesFirstPageDuringGameState : State
{
    public RulesFirstPageDuringGameState(State nextState) : base(nextState) { }

    public override void PerformTask()
    {
        ActivateReturnToGameButton();
        ActivateNextPageButton();
    }

    private static void ActivateReturnToGameButton()
    {
        var returnToGameButton = Program.Game.RulesFirstPageDuringGameRendering.ReturnToGameButton;
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
    
    private static void ActivateNextPageButton()
    {
        var nextPageButton = Program.Game.RulesFirstPageDuringGameRendering.NextPageButton;
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
            StoreOfStates.ChangeStateToSecondPageRulesDuringGame();
        }
    }
}