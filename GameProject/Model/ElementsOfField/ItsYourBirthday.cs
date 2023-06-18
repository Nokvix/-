using GameProject.Controller;
using GameProject.Model.ElementsOfPlay;

namespace GameProject.Model.ElementsOfField;

public class ItsYourBirthday : Cell
{
    public ItsYourBirthday(string name, int index) : base(name, index) { }

    public override string PerformActionOnPlayer(Chip chip)
    {
        if (Program.Game.Flag)
        {
            Program.Game.GameRendering.HappyBirthdaySound.Play();
            chip.IncrementMoney(100);
            Program.Game.Flag = false;
        }
        return $"У вас день рождения! \nВам подарили 100$";
    }
}