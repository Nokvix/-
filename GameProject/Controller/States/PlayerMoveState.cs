using GameProject.Model;
using Microsoft.Xna.Framework.Input;

namespace GameProject.Controller.States;

public class PlayerMoveState : State
{
    public PlayerMoveState(State nextState) : base(nextState) { }

    public override void PerformTask()
    {
        var throwingCubeButton = Program.Game.GameRendering.ThrowingCubeButton;
        var playerColour = GetColourOfChipString.GetColourOfChip().ToLower();
        AssignmentOfOutputInformationOnly.OutputTextAboutNeedToRollCube(playerColour);
        ActivateRulesButton();
        ActivateHomeScreenExitButton();
        var mouseOverRollCubeButton = throwingCubeButton.SpriteRectangle.Rectangle.Contains(Mouse.GetState().X, Mouse.GetState().Y);
        if (mouseOverRollCubeButton) 
            throwingCubeButton.ChangeToIlluminatedImage();
        else 
            throwingCubeButton.ChangeToActiveImage();
        
        if (!mouseOverRollCubeButton || Mouse.GetState().LeftButton != ButtonState.Pressed) return;
        Program.Game.GameRendering.CanGo = true;
        Program.Game.GameRendering.RollingCube.Play();
        throwingCubeButton.ChangeToInactiveImage();
        StoreOfStates.ChangeState();
    }

    private static void ActivateHomeScreenExitButton()
    {
        var homeScreenExitButton = Program.Game.GameRendering.HomeScreenExitButton;
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

    private static void ActivateRulesButton()
    {
        var previousText = Program.Game.GameRendering.InformationalText;
        var ruleButton = Program.Game.GameRendering.RuleButtonDuringGame;
        var mouseOverRuleButton = ruleButton.SpriteRectangle.Rectangle.Contains(Mouse.GetState().Position);
        ruleButton.ChangeToActiveImage();

        if (mouseOverRuleButton)
        {
            ruleButton.ChangeToIlluminatedImage();
            AssignmentOfOutputInformationOnly.DisplayWarningAboutRules();
        }
        else
        {
            ruleButton.ChangeToActiveImage();
            AssignmentOfOutputInformationOnly.ToRestoreMainMessage(previousText);
        }

        if (mouseOverRuleButton && Mouse.GetState().LeftButton == ButtonState.Pressed)
        {
            StoreOfStates.ChangeToRulesDuringGameState();
        }
    }
}