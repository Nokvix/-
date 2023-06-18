using System.Collections.Generic;
using System.Drawing;
using GameProject.Controller;
using GameProject.Model.ElementsOfPlay;
using GameProject.View;
using MonopolyGame.FieldObjects;

namespace GameProject.Model.ElementsOfField;

public class Asset : Cell
{
    public Asset(string name, int index, Color color, int price, int rent, 
        Dictionary<int, int> allRentLevels) : base(name, index)
    {
        Color = color;
        Price = price;
        Rent = rent;
        AllRentLevels = allRentLevels;
        Owner = new Chip(-1);
    }
    
    public int Security { get; private set; }
    public Color Color { get; }
    public Chip Owner { get; private set; }
    public Dictionary<int, int> AllRentLevels { get; }
    public int Rent { get; private set; }
    public int LevelOfRent { get; private set; } = 1;
    public int Price { get; }
    public int ChanceOfCapture { get; private set; }

    public void CalculateChanceOfCapture(Chip currentPlayer)
    {
        ChanceOfCapture = Security switch
        {
            0 when currentPlayer.Gang.NumberOfPeopleAvailable == 10 => 85,
            0 when currentPlayer.Gang.NumberOfPeopleAvailable >= 20 => 100,
            _ => (currentPlayer.Gang.NumberOfPeopleAvailable - Security) switch
            {
                >= 30 => 100,
                20 => 80,
                10 => 60,
                0 => 40,
                -10 => 20,
                <= -20 => 0,
                _ => ChanceOfCapture
            }
        };
    }

    public void HandOverSeizesProperty(Chip currentPlayer, int currentPosition)
    {
        Owner.Gang.KilledDefendingProperty(Security);
        Owner.ReducePriceWhenGuardsAreEliminated(Security);
        Owner.Assets.Remove(this);
        Owner.ReduceTotalValueOfProperty(this);
        currentPlayer.Assets.Add(this);
        currentPlayer.IncreaseTotalValueOfProperty(this);
        AssigningOwner(currentPlayer);
        Security = 0;
        LevelOfRent = 1;
        Rent = AllRentLevels[LevelOfRent];
        Program.Game.GameRendering.ShowWhoPurchasedProperty(currentPosition, Program.Game.Content, Field.CurrentPlayerIndex,
            BuyOrSale.Buy);
    }

    public void PutGuardOnProperty()
    {
        Security += 10;
        Field.Players[Field.CurrentPlayerIndex].Gang.PutPeopleOnGuard();
    }
        
    public void AssigningOwner(Chip chip)
    {
        Owner = chip;
    }

    public void RemoveOwner(Chip chip)
    {
        Owner = new Chip(-1);
        LevelOfRent = 1;
        Rent = AllRentLevels[LevelOfRent];
        Security = 0;
    }

    public override string PerformActionOnPlayer(Chip chip)
    {
        if (chip == Owner)
        {
            if (LevelOfRent != 6)
            {
                if (Program.Game.Flag)
                {
                    LevelOfRent += 1;
                    Rent = AllRentLevels[LevelOfRent];
                    Program.Game.Flag = false;
                }
                return $"Вы уже владеете объектом \n\"{Name}\". " +
                       $"\nУровень ренты повышается с {LevelOfRent - 1} до {LevelOfRent}. \nТекущая рента {Rent}$";
            }
            return $"Вы уже владеете объектом \n\"{Name}\". \nУровень ренты максимальный \nи равен {LevelOfRent}. " +
                       $"Текущая рента {Rent}$";
        }

        if (Owner is null || Owner.PlayerId == -1)
        {
            if (Name == "Горнолыжный курорт" || Name == "Toyota Motor Corporation" || Name == "Асфальтированная дорога" 
                || Name == "Сеть продуктовых магазинов" || Name == "Магазин электроники")
                return $"У \"{Name}\" нет \nвладельца. \nВы можете купить его за {Price}$";
            return $"У \"{Name}\" нет владельца. \nВы можете купить его за {Price}$";
        }
        if (Program.Game.Flag)
        {
            chip.DecrementMoney(Rent);
            Owner.IncrementMoney(Rent);
            Program.Game.Flag = false;
        }
        var ownerColor = GetColourOfChipString.GetColourOfOwner(Owner.PlayerId);
        return $"{ownerColor} имеет в наличии \nобъект \"{Name}\". \nВы заплатили ему {Rent}$ за посещение";
    }
}