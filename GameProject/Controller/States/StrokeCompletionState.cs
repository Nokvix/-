using GameProject.Controller.SupportClasses;
using GameProject.Model;
using Microsoft.Xna.Framework.Input;
using MonopolyGame.FieldObjects;

namespace GameProject.Controller.States;

public class StrokeCompletionState : State
{
    public StrokeCompletionState(State nextState) : base(nextState) { }

    public override void PerformTask()
    {
        MakeAllButtonsInactiveClass.MakeAllButtonsInactive();
        OverwritePlayerDataClass.OverwritePlayerData();
        ActivateButtonsToEndMoveHomeScreenExit();
        ActivateRulesButton();
    }
    
    private static void ActivateButtonsToEndMoveHomeScreenExit()
    {
        var previousText = Program.Game.GameRendering.InformationalText;
        var buttonToEndMove = Program.Game.GameRendering.ButtonToEndMove;
        buttonToEndMove.ChangeToActiveImage();
        var mouseOverButtonToEndMove =
            buttonToEndMove.SpriteRectangle.Rectangle.Contains(Mouse.GetState().X, Mouse.GetState().Y);
        
        var homeScreenExitButton = Program.Game.GameRendering.HomeScreenExitButton;
        homeScreenExitButton.ChangeToActiveImage();
        var mouseOverHomeScreenExitButton = homeScreenExitButton.SpriteRectangle.Rectangle.Contains(Mouse.GetState().Position);
        
        if (mouseOverButtonToEndMove)
        {
            buttonToEndMove.ChangeToIlluminatedImage();
            homeScreenExitButton.ChangeToActiveImage();
        }
        else if (mouseOverHomeScreenExitButton)
        {
            homeScreenExitButton.ChangeToIlluminatedImage();
            buttonToEndMove.ChangeToActiveImage();
            AssignmentOfOutputInformationOnly.DisplayStartScreenWarning();
        }
        else
        {
            buttonToEndMove.ChangeToActiveImage();
            homeScreenExitButton.ChangeToActiveImage();
            AssignmentOfOutputInformationOnly.ToRestoreMainMessage(previousText);
        }

        if (mouseOverButtonToEndMove && Mouse.GetState().LeftButton == ButtonState.Pressed)
        {
            Program.Game.GameRendering.PlayerInformationWindows[Field.CurrentPlayerIndex].ChangeToNotPlayerMoveImage();
            Field.CurrentPlayerIndex = (Field.CurrentPlayerIndex + 1) % Program.Game.NumberOfPlayers;
            if (Field.CurrentPlayerIndex == 0)
            {
                var number = int.Parse(Program.Game.GameRendering.MovesLeft) - 1;
                Program.Game.GameRendering.MovesLeft = number.ToString();
            }
            if (int.Parse(Program.Game.GameRendering.MovesLeft) != 0)
            {
                Program.Game.GameRendering.PlayerInformationWindows[Field.CurrentPlayerIndex].ChangeToPlayerMoveImage();
                MakeAllButtonsInactiveClass.MakeAllButtonsInactive();
                buttonToEndMove.ChangeToInactiveImage();
                Program.Game.Flag = true;
                StoreOfStates.ChangeState();
            }
            else
                StoreOfStates.ChangeToMovesHaveRunOut();
        }
        else if (mouseOverHomeScreenExitButton && Mouse.GetState().LeftButton == ButtonState.Pressed)
            StoreOfStates.ChangeStateToStartScreen();
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