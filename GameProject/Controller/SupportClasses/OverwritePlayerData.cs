using GameProject.Model;
using MonopolyGame.FieldObjects;

namespace GameProject.Controller.SupportClasses;

public class OverwritePlayerDataClass
{
    public static void OverwritePlayerData()
    {
        for (var i = 0; i < Field.Players.Count; i++)
        {
            Program.Game.GameRendering.YellowChip.ChangeValue(i);
            Program.Game.GameRendering.BlueChip.ChangeValue(i);
            Program.Game.GameRendering.RedChip.ChangeValue(i);
            Program.Game.GameRendering.GreenChip.ChangeValue(i);
        }
    }
}