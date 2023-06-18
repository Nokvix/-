using GameProject.Controller;
using GameProject.Model.ElementsOfPlay;

namespace GameProject.Model.ElementsOfField;

public class CornerCells : Cell
{
    public CornerCells(string name, int index) : base(name, index) { }

    public override string PerformActionOnPlayer(Chip chip)
    {
        if (Index == 0)
        {
            return "Вы прошли один круг. Получите 400$";
        }

        if (Index == 9)
            return "Вы прошли мимо дома, возле \nкоторого стояло много чёрных \nджипов";
        
        if (Index == 18)
            return "Можете отдохнуть";

        if (Program.Game.Flag)
        {
            chip.DecrementMoney(200);
            Program.Game.Flag = false;
        }
        return "Вас взяли в заложники. \nВы заплатили выкуп в размере 200$";
    }
}