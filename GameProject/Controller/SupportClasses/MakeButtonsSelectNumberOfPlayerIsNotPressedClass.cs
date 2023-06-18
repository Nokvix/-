namespace GameProject.Controller.SupportClasses;

public class MakeButtonsSelectNumberOfPlayerIsNotPressedClass
{
    public static void MakeButtonsSelectNumberOfPlayerIsNotPressed()
    {
        var button2Player = Program.Game.StartScreenRendering.Button2Player;
        var button3Player = Program.Game.StartScreenRendering.Button3Player;
        var button4Player = Program.Game.StartScreenRendering.Button4Player;

        button2Player.IsPressed = false;
        button3Player.IsPressed = false;
        button4Player.IsPressed = false;
    }
}