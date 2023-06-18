using System.Collections.Generic;
using GameProject.Model.ElementsOfField;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonopolyGame.FieldObjects;

namespace GameProject.Model.ElementsOfPlay;

public class Chip : IChip
{
    public const int StartingAmountOfMoney = 3000;
    public const int TotalNumberOfTiles = 36;
    public Chip(int playerId)
    {
        PlayerId = playerId;
    }

    public int HowManyTimesGangHasBeenRecruited { get; private set; }
    public int NumberOfPeopleInGang { get; set; }
    public Color Color { get; init; }
    public int PlayerId { get; private set; }
    public int MoneyLeftOver { get; private set; } = StartingAmountOfMoney;
    public List<Asset> Assets { get; private set; } = new();
    public int CurrentPosition { get; private set; } = 0;
    public int TotalValueProperty { get; private set; }
    public List<int> PropertyPrices { get; set; }
    public Gang Gang { get; private set; } = new Gang();
    public Texture2D Texture { get; set; }
    
    public void SetPosition(int newPosition)
    {

        if (newPosition<0)
        {
            newPosition += TotalNumberOfTiles;
        }
        if (newPosition >= TotalNumberOfTiles)
        {
            newPosition -= TotalNumberOfTiles;
            IncrementMoney(400);
        }
        CurrentPosition = newPosition;
    }

    public void BuyProperty(Asset asset)
    {
        Assets.Add(asset);
        DecrementMoney(asset.Price);
        TotalValueProperty += asset.Price;
    }

    public void SellProperty(Asset asset)
    {
        Assets.Remove(asset);
        IncrementMoney(asset.Price);
        TotalValueProperty -= asset.Price;
    }

    public void IncrementMoney(int amount)
    {
        MoneyLeftOver += amount;
    }

    public void DecrementMoney (int amount)
    {
        MoneyLeftOver -= amount;
    }
    
    public void IncreaseNumberOfPeopleInGang()
    {
        var currentPrice = Gang.CostOfIncreasingGang + 100 * HowManyTimesGangHasBeenRecruited;
        DecrementMoney(currentPrice);
        Gang.AddPeopleToGang();
        HowManyTimesGangHasBeenRecruited++;
    }

    public void ReducePriceWhenGuardsAreEliminated(int number)
    {
        HowManyTimesGangHasBeenRecruited -= number / 10;
    }

    public void ReduceTotalValueOfProperty(Asset asset)
    {
        TotalValueProperty -= asset.Price;
    }
    
    public void IncreaseTotalValueOfProperty(Asset asset)
    {
        TotalValueProperty += asset.Price;
    }
}