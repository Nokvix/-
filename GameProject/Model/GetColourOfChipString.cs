namespace GameProject.Model;

public class GetColourOfChipString
{
    public static string GetColourOfChip()
    {
        var playerColour = Field.CurrentPlayerIndex switch
        {
            0 => "Желтый",
            1 => "Синий",
            2 => "Красный",
            3 => "Зеленый",
            _ => default
        };
        return playerColour;
    }
    
    public static string GetColourOfOwner(int ownerId)
    {
        var playerColour = ownerId switch
        {
            0 => "Желтый",
            1 => "Синий",
            2 => "Красный",
            3 => "Зеленый",
            _ => default
        };
        return playerColour;
    }
}