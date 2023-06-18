namespace GameProject.Controller.SupportClasses;

public class MakeAllButtonsActiveClass
{
    public static void MakeAllButtonsActive()
    {
        var ruleButton = Program.Game.StartScreenRendering.RuleButton;
        var exitButton = Program.Game.StartScreenRendering.ExitButton;
        var button2Player = Program.Game.StartScreenRendering.Button2Player;
        var button3Player = Program.Game.StartScreenRendering.Button3Player;
        var button4Player = Program.Game.StartScreenRendering.Button4Player;
        
        ruleButton.ChangeToActiveImage();
        exitButton.ChangeToActiveImage();
        if (!button2Player.IsPressed) button2Player.ChangeToActiveImage();
        if (!button3Player.IsPressed) button3Player.ChangeToActiveImage();
        if (!button4Player.IsPressed) button4Player.ChangeToActiveImage();
    }
}