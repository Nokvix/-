namespace GameProject.Model.ElementsOfPlay;

public interface IChip
{
    int PlayerId { get; }
    int MoneyLeftOver { get; }
    int CurrentPosition { get; }
    Gang Gang { get; }
    void SetPosition(int newPosition);
}