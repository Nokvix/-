using GameProject.Controller;
using GameProject.Model.ElementsOfField;
using GameProject.Model.ElementsOfField.BlackBoxCard;
using GameProject.Model.ElementsOfPlay;

namespace MonopolyGame.FieldObjects;

public class BlackBoxCard : Cell
{
    public BlackBoxCard(string name, int index) : base(name, index) { }
    private string _blackBoxCard;
    public override string PerformActionOnPlayer(Chip chip)
    {
        if (Program.Game.Flag)
        {
            Program.Game.GameRendering.BlackBoxSound.Play();
            _blackBoxCard = BlackBoxCardGenerator.GetBlackBoxCard(chip);
            Program.Game.Flag = false;
        }
        return _blackBoxCard;
    }
}