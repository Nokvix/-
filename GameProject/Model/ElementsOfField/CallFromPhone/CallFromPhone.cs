using GameProject.Controller;
using GameProject.Model.ElementsOfPlay;
using MonopolyGame.FieldObjects;

namespace GameProject.Model.ElementsOfField.CallFromPhone;

public class CallFromPhone : Cell
{
    public CallFromPhone(string name, int index) : base(name, index) { }
    private string _cardCallFromUnknownNumber;

    public override string PerformActionOnPlayer(Chip chip)
    {
        if (Program.Game.Flag)
        {
            Program.Game.GameRendering.PhoneCallSound.Play();
            _cardCallFromUnknownNumber = CardCallFromUnknownNumberGenerate.GetCardCallFromUnknownNumber(chip);
            Program.Game.Flag = false;
        }
        return _cardCallFromUnknownNumber;
    }
}