using GameProject.Model;
using Microsoft.Xna.Framework.Input;
using MonopolyGame.FieldObjects;

namespace GameProject.Controller.States;

public class MovementOfChipState : State
{
    public MovementOfChipState(State nextState) : base(nextState) { }

    public static int PreviousPosition { get; set; }
    
    public override void PerformTask()
    {
        ActivateRulesButton();
        ActivateHomeScreenExitButton();
        Program.Game.GameRendering.MoveChip(Field.CurrentPlayerIndex, PreviousPosition,
            Field.Players[Field.CurrentPlayerIndex].CurrentPosition);
        if (!Program.Game.GameRendering.CanGo)
        {
            StoreOfStates.ChangeState();
        }
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