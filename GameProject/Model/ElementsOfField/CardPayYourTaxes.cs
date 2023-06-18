using GameProject.Controller;
using GameProject.Model.ElementsOfPlay;
using MonopolyGame.FieldObjects;

namespace GameProject.Model.ElementsOfField;

public class CardPayYourTaxes : Cell
{
    public CardPayYourTaxes(string name, int index) : base(name, index) { }

    public override string PerformActionOnPlayer(Chip chip)
    {
        if (Program.Game.Flag)
        {
            Program.Game.GameRendering.TaxPaymentSound.Play();
            chip.DecrementMoney(150);
            Program.Game.Flag = false;
        }
        return $"Конец года. \nЗаплатите налогов на сумму 150$";
    }
}