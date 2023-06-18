namespace GameProject.Model.ElementsOfPlay;

public interface IGang
{
    int NumberOfPeopleAvailable { get; }
    int NumberOfPeopleOnGuard { get; }
    int CostOfGang { get; }
    void AddPeopleToGang();
}