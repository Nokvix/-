using GameProject.Model.ElementsOfPlay;

namespace GameProject.Model.ElementsOfField;

public abstract class Cell
{
    public string Name { get; private set; }
    public int Index { get; private set; }
    
    public Cell(string name, int index)
    {
        Name = name;
        Index = index;
    }

    public abstract string PerformActionOnPlayer(Chip chip);
}