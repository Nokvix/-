namespace GameProject.Model.ElementsOfPlay;

public class Gang : IGang
{
    public const int CostOfIncreasingGang  = 500;
    public const int NumberOfPeopleAddedToGang = 10;
    public int NumberOfPeopleAvailable { get; private set; } = 0;
    public int NumberOfPeopleOnGuard { get; private set; } = 0;
    public int TotalPeopleInGang { get; private set; } = 0;
    public int CostOfGang { get; private set; } = 0;
    public void AddPeopleToGang()
    {
        NumberOfPeopleAvailable += NumberOfPeopleAddedToGang;
        CostOfGang += CostOfIncreasingGang;
        TotalPeopleInGang += NumberOfPeopleAddedToGang;
    }

    public void PutPeopleOnGuard()
    {
        NumberOfPeopleAvailable -= 10;
        NumberOfPeopleOnGuard += 10;
    }

    public void GetPeopleBackAfterSale()
    {
        NumberOfPeopleAvailable += NumberOfPeopleOnGuard;
        NumberOfPeopleOnGuard = 0;
    }

    private void UpdateTotalNumberPeopleInBanner()
    {
        TotalPeopleInGang = NumberOfPeopleAvailable + NumberOfPeopleOnGuard;
    }

    public void KilledDefendingProperty(int number)
    {
        NumberOfPeopleOnGuard -= number;
        UpdateTotalNumberPeopleInBanner();
    }

    public void KilledAllAttackers()
    {
        NumberOfPeopleAvailable = 0;
        UpdateTotalNumberPeopleInBanner();
    }

    public void KilledSomeOfAttackers(int security)
    {
        if (NumberOfPeopleAvailable >= security)
        {
            NumberOfPeopleAvailable -= security;
            UpdateTotalNumberPeopleInBanner();
        }
        else KilledAllAttackers();
    }
}