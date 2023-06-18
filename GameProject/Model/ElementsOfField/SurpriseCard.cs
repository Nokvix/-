using System;
using GameProject.Controller;
using GameProject.Model.ElementsOfPlay;

namespace GameProject.Model.ElementsOfField;

public class SurpriseCard : Cell
{
    public SurpriseCard(string name, int index) : base(name, index) { }

    public override string PerformActionOnPlayer(Chip chip)
    {
        var amount = 0;
        if (Program.Game.Flag)
        {
            Program.Game.GameRendering.SurpriseSound.Play();
            var rnd = Random.Shared.Next(250, 1001);
            amount = rnd;
            chip.IncrementMoney(amount);
            Program.Game.Flag = false;
        }
        return $"Вам невероятно повезло! \nВы выиграли джекпот в размере {amount}$";
    }
}