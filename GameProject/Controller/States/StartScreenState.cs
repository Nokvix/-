using GameProject.Controller.SupportClasses;
using GameProject.View.RenderingDirectory;
using Microsoft.Xna.Framework.Input;

namespace GameProject.Controller.States;

public class StartScreenState : State
{
    public StartScreenState(State nextState) : base(nextState) { }

    public override void PerformTask()
    {
        ActivateButtons();
        if (Program.Game.NumberOfPlayersSelected)
            ActivatePlayButton();
    }

    public static void ActivateButtons()
    {
        ActivateRuleButton();
        ActivateExitButton();
        ActivateButton2Player();
        ActivateButton3Player();
        ActivateButton4Player();
    }

    public static void ActivateRuleButton()
    {
        var ruleButton = Program.Game.StartScreenRendering.RuleButton;
        var mouseOverRuleButton = ruleButton.SpriteRectangle.Rectangle.Contains(Mouse.GetState().Position);
        if (mouseOverRuleButton)
        {
            MakeAllButtonsActiveClass.MakeAllButtonsActive();
            ruleButton.ChangeToIlluminatedImage();
        }
        else
            ruleButton.ChangeToActiveImage();

        if (mouseOverRuleButton && Mouse.GetState().LeftButton == ButtonState.Pressed)
        {
            Program.Game.GameStage = StagesOfGame.RulesFirstPageOnStartScreen;
            StoreOfStates.ChangeToRulesOnStartScreenState();
        }
    }

    public static void ActivateExitButton()
    {
        var exitButton = Program.Game.StartScreenRendering.ExitButton;
        var mouseOverExitButton = exitButton.SpriteRectangle.Rectangle.Contains(Mouse.GetState().Position);
        if (mouseOverExitButton)
        {
            MakeAllButtonsActiveClass.MakeAllButtonsActive();
            exitButton.ChangeToIlluminatedImage();
        }
        else
            exitButton.ChangeToActiveImage();

        if (mouseOverExitButton && Mouse.GetState().LeftButton == ButtonState.Pressed) 
            Program.Game.Exit();
    }

    public static void ActivateButton2Player()
    {
        var button2Player = Program.Game.StartScreenRendering.Button2Player;
        var mouseOverButton2Player = button2Player.SpriteRectangle.Rectangle.Contains(Mouse.GetState().Position);
        if (mouseOverButton2Player)
        {
            MakeAllButtonsActiveClass.MakeAllButtonsActive();
            button2Player.ChangeToIlluminatedImage();
        }
        else if (!mouseOverButton2Player && !button2Player.IsPressed) 
            button2Player.ChangeToActiveImage();

        if (mouseOverButton2Player && Mouse.GetState().LeftButton == ButtonState.Pressed)
        {
            button2Player.ChangeToIlluminatedImage();
            Program.Game.NumberOfPlayersSelected = true;
            Program.Game.NumberOfPlayers = 2;
            MakeButtonsSelectNumberOfPlayerIsNotPressedClass.MakeButtonsSelectNumberOfPlayerIsNotPressed();
            button2Player.IsPressed = true;
        }
    }

    public static void ActivateButton3Player()
    {
        var button3Player = Program.Game.StartScreenRendering.Button3Player;
        var mouseOverButton3Player = button3Player.SpriteRectangle.Rectangle.Contains(Mouse.GetState().Position);
        if (mouseOverButton3Player)
        {
            MakeAllButtonsActiveClass.MakeAllButtonsActive();
            button3Player.ChangeToIlluminatedImage();
        }
        else if (!mouseOverButton3Player && !button3Player.IsPressed) 
            button3Player.ChangeToActiveImage();

        if (mouseOverButton3Player && Mouse.GetState().LeftButton == ButtonState.Pressed)
        {
            button3Player.ChangeToIlluminatedImage();
            Program.Game.NumberOfPlayersSelected = true;
            Program.Game.NumberOfPlayers = 3;
            MakeButtonsSelectNumberOfPlayerIsNotPressedClass.MakeButtonsSelectNumberOfPlayerIsNotPressed();
            button3Player.IsPressed = true;
        }
    }

    public static void ActivateButton4Player()
    {
        var button4Player = Program.Game.StartScreenRendering.Button4Player;
        var mouseOverButton4Player = button4Player.SpriteRectangle.Rectangle.Contains(Mouse.GetState().Position);
        if (mouseOverButton4Player)
        {
            MakeAllButtonsActiveClass.MakeAllButtonsActive();
            button4Player.ChangeToIlluminatedImage();
        }
        else if (!mouseOverButton4Player && !button4Player.IsPressed)
            button4Player.ChangeToActiveImage();

        if (mouseOverButton4Player && Mouse.GetState().LeftButton == ButtonState.Pressed)
        {
            button4Player.ChangeToIlluminatedImage();
            Program.Game.NumberOfPlayersSelected = true;
            Program.Game.NumberOfPlayers = 4;
            MakeButtonsSelectNumberOfPlayerIsNotPressedClass.MakeButtonsSelectNumberOfPlayerIsNotPressed();
            button4Player.IsPressed = true;
        }
    }

    public void ActivatePlayButton()
    {
        var playButton = Program.Game.StartScreenRendering.PlayButton;
        playButton.ChangeToActiveImage();
        var mouseOverPlayButton = playButton.SpriteRectangle.Rectangle.Contains(Mouse.GetState().Position);
        if (mouseOverPlayButton)
            playButton.ChangeToIlluminatedImage();
        else
            playButton.ChangeToActiveImage();

        if (mouseOverPlayButton && Mouse.GetState().LeftButton == ButtonState.Pressed)
        {
            Program.Game.GameStage = StagesOfGame.Game;
            Program.Game.GameRendering = new GameRendering();
            StoreOfStates.ChangeStateToGame();
        }
    }
}