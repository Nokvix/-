using GameProject.Controller;
using GameProject.Model.ElementsOfPlay;
using MonopolyGame.FieldObjects;

namespace GameProject.Model.ElementsOfField;

public class CardOfRoadRepairs : Cell
{
    public CardOfRoadRepairs(string name, int index) : base(name, index) { }

    public override string PerformActionOnPlayer(Chip chip)
    {
        if (Program.Game.Flag)
        {
            Program.Game.GameRendering.RoadRepairsSound.Play();
            chip.DecrementMoney(100);
            Program.Game.Flag = false;
        }
        return $"Идёт ремонт дороги. \nДля движения по платной дороге \nзаплатите 100$";
    }
}