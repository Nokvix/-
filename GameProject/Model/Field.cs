using System;
using System.Collections.Generic;
using System.Drawing;
using GameProject.Controller;
using GameProject.Model.ElementsOfField;
using GameProject.Model.ElementsOfField.CallFromPhone;
using GameProject.Model.ElementsOfPlay;
using MonopolyGame.FieldObjects;

namespace GameProject.Model;

public static class Field
{
    public static Cell[] FieldCells { get; private set; }
    public static List<Chip> Players { get; private set; }
    public static int CurrentPlayerIndex;

    public static void InitialiseFieldAndPlayers(int numberOfPlayers)
    {
        CurrentPlayerIndex = 0;
        Players = numberOfPlayers switch
        {
            2 => new List<Chip> { new Chip(0), new Chip(1) },
            3 => new List<Chip> { new Chip(0), new Chip(1), new Chip(2) },
            4 => new List<Chip> { new Chip(0), new Chip(1), new Chip(2), new Chip(3) },
            _ => throw new ArgumentException()
        };
        FieldCells = new Cell[]
        {
            new CornerCells("Старт", 0),
            new Asset("Грунтовая дорога", 1, Color.Brown, 120, 4, 
                new Dictionary<int, int> { {1, 4}, {2, 20}, {3, 60}, {4, 180}, {5, 320}, {6, 500} }),
            new SurpriseCard("Суперприз", 2),
            new Asset("Асфальтированная дорога", 3, Color.Brown, 160, 8, 
                new Dictionary<int, int> {{1, 8}, {2, 40}, {3, 120}, {4, 360}, {5, 640}, {6, 900} }),
            new CardOfRoadRepairs("Ремонт дороги", 4),
            new Asset("Кафе", 5, Color.Blue, 200, 12, new Dictionary<int, int> 
                { {1, 12}, {2, 60}, {3, 180}, {4, 540}, {5, 800}, {6, 1100} }),
            new BlackBoxCard("Чёрный ящик", 6),
            new Asset("Ресторан", 7, Color.Blue, 200, 12, 
                new Dictionary<int, int>{ {1, 12}, {2, 60}, {3, 180}, {4, 540}, {5, 800}, {6, 1100} }),
            new Asset("Аквапарк", 8, Color.Blue, 240, 16, 
                new Dictionary<int, int> { {1, 16}, {2, 80}, {3, 200}, {4, 600}, {5, 900}, {6, 1200} }),
            new CornerCells("Прошли мимо", 9),
            new Asset("Городской парк", 10, Color.Pink, 280, 20, 
                new Dictionary<int, int> { {1, 20}, {2, 100}, {3, 300}, {4, 900}, {5, 1250}, {6, 1500} }),
            new CallFromPhone("Звонок с незнакомого номера", 11),
            new Asset("Гольф курорт", 12, Color.Pink, 280, 20, 
                new Dictionary<int, int> { {1, 20}, {2, 100}, {3, 300}, {4, 900}, {5, 1250}, {6, 1500} }),
            new Asset("Горнолыжный курорт", 13, Color.Pink, 320, 24, 
                new Dictionary<int, int> { {1, 24}, {2, 120}, {3, 360}, {4, 1000}, {5, 1400}, {6, 1800} }),
            new Asset("Жилой дом", 14, Color.Orange, 360, 28, 
                new Dictionary<int, int> { {1, 28}, {2, 140}, {3, 400}, {4, 1100}, {5, 1500}, {6, 1900} }),
            new BlackBoxCard("Чёрный ящик", 15),
            new Asset("Бизнес центр", 16, Color.Orange, 360, 28, 
                new Dictionary<int, int> { {1, 28}, {2, 140}, {3, 400}, {4, 1100}, {5, 1500}, {6, 1900} }),
            new Asset("Жилой комплекс", 17, Color.Orange, 400, 32, 
                new Dictionary<int, int> { {1, 32}, {2, 160}, {3, 440}, {4, 1200}, {5, 1600}, {6, 2000} }),
            new CornerCells("Отдых", 18),
            new Asset("Автосалон", 19, Color.Red, 440, 36, 
                new Dictionary<int, int> { {1, 36}, {2, 180}, {3, 500}, {4, 1400}, {5, 1750}, {6, 2100} }),
            new Asset("Магазин электроники", 20, Color.Red, 440, 36, 
                new Dictionary<int, int> { {1, 36}, {2, 180}, {3, 500}, {4, 1400}, {5, 1750}, {6, 2100} }),
            new CardPayYourTaxes("Конец года \nЗаплатите налоги", 21),
            new Asset("Сеть продуктовых магазинов", 22, Color.Red, 480, 40, 
                new Dictionary<int, int> { {1, 40}, {2, 200}, {3, 600}, {4, 1500}, {5, 1850}, {6, 2200} }),
            new Asset("Хостел", 23, Color.Yellow, 520, 44, 
                new Dictionary<int, int> { {1, 44}, {2, 220}, {3, 660}, {4, 1600}, {5, 1950}, {6, 2300} }),
            new BlackBoxCard("Чёрный ящик", 24),
            new Asset("Гостиница", 25, Color.Yellow, 520, 44, 
                new Dictionary<int, int> { {1, 44}, {2, 220}, {3, 660}, {4, 1600}, {5, 1950}, {6, 2300} }),
            new Asset("Элитный отель", 26, Color.Yellow, 560, 48, 
                new Dictionary<int, int> { {1, 48}, {2, 240}, {3, 720}, {4, 1700}, {5, 2050}, {6, 2400} }),
            new CornerCells("Вас взяли в заложники", 27),
            new Asset("Ford Motors", 28, Color.Green, 600, 52, 
                new Dictionary<int, int> { {1, 52}, {2, 260}, {3, 780}, {4, 1800}, {5, 2200}, {6, 2550} }),
            new CallFromPhone("Звонок с незнакомого номера", 29),
            new Asset("VolkswagenAG", 30, Color.Green, 600, 52,
                new Dictionary<int, int> { {1, 52}, {2, 260}, {3, 780}, {4, 1800}, {5, 2200}, {6, 2550} }),
            new Asset("Toyota Motor Corporation", 31, Color.Green, 640, 56, 
                new Dictionary<int, int> { {1, 56}, {2, 300}, {3, 900}, {4, 2000}, {5, 2400}, {6, 2800} }),
            new BlackBoxCard("Чёрный ящик", 32),
            new ItsYourBirthday("У вас день рождения", 33),
             new Asset("Конгресс", 34, Color.DarkBlue, 700, 70, 
                 new Dictionary<int, int> { {1, 70}, {2, 350}, {3, 1000}, {4, 2200}, {5, 2600}, {6, 3000} }),
             new Asset("Храм неба", 35, Color.DarkBlue, 800, 100, 
                 new Dictionary<int, int> { {1, 100}, {2, 400}, {3, 1200}, {4, 2800}, {5, 3400}, {6, 4000} })
        };
    }

    public static void BuyProperty(int assetIndex, int playerIndex)
    {
        var currentAsset = FieldCells[assetIndex] as Asset;
        Program.Game.GameRendering.PurchaseSound.Play();
        currentAsset.AssigningOwner(Players[playerIndex]);
        Program.Game.GameRendering.InformationalText = "Объект куплен";
        Players[playerIndex].BuyProperty(currentAsset);
    }

    public static void SellOffProperty(int assetIndex, int playerIndex)
    {
        var currentAsset = FieldCells[assetIndex] as Asset;
        Program.Game.GameRendering.SalesSound.Play();
        Players[playerIndex].SellProperty(currentAsset);
        Players[playerIndex].Gang.GetPeopleBackAfterSale(); 
        currentAsset.RemoveOwner(Players[playerIndex]);
        Program.Game.GameRendering.InformationalText = "Объект продан";
    }

    public static void IncreaseNumberOfPeopleInGang(int playerIndex)
    {
        Program.Game.GameRendering.GangRecruitment.Play();
        Players[playerIndex].IncreaseNumberOfPeopleInGang();
        Program.Game.GameRendering.InformationalText = "В банду рекрутировано 10 человек";
    }

    public static void PutGuardOnProperty(int currentPosition)
    {
        var currentAsset = FieldCells[currentPosition] as Asset;
        Program.Game.GameRendering.PutOnGuardSound.Play();
        currentAsset.PutGuardOnProperty();
        Program.Game.GameRendering.InformationalText =
            $"На охрану поставлено 10 человек \nНа объекте {currentAsset.Security} охранников";
    }

    public static void RaidProperty(int currentPosition)
    {
        var currentPlayer = Players[CurrentPlayerIndex];
        var currentAsset = FieldCells[currentPosition] as Asset;
        Program.Game.GameRendering.AssaultOnObject.Play();
        currentAsset.CalculateChanceOfCapture(currentPlayer);
        var randomNumber = Random.Shared.Next(1, 101);
        var color = GetColourOfChipString.GetColourOfChip();
        if (currentAsset.ChanceOfCapture == 0)
        {
            if (currentAsset.Security > 0)
            {
                Program.Game.GameRendering.InformationalText =
                    $"Рейд оказался неудачным. \n{color} потерял {currentAsset.Security} бойцов";
            }
            else 
                Program.Game.GameRendering.InformationalText =
                    $"Рейд оказался неудачным. \n{color} потерял {currentPlayer.Gang.NumberOfPeopleAvailable} бойцов";
            currentPlayer.Gang.KilledAllAttackers();
        }
        else if (randomNumber <= currentAsset.ChanceOfCapture)
        {
            if (currentAsset.Security > 0)
                Program.Game.GameRendering.InformationalText =
                    $"Вы захватили объект! \nБыло уничтожено {currentAsset.Security} охранников. " +
                    $"\nТеперь {color.ToLower()} владеет объектом \n{currentAsset.Name}";
            else Program.Game.GameRendering.InformationalText =
                $"Вы захватили объект. \nТеперь {color.ToLower()} владеет объектом \n{currentAsset.Name}";
            currentAsset.HandOverSeizesProperty(currentPlayer, currentPosition);
        }
        else
        {
            if (currentPlayer.Gang.NumberOfPeopleAvailable < currentAsset.Security)
            {
                Program.Game.GameRendering.InformationalText =
                    $"Рейд оказался неудачным. \n{color} потерял {currentPlayer.Gang.NumberOfPeopleAvailable} бойцов";
            }
            else
            {
                if (currentAsset.Security > 0)
                {
                    Program.Game.GameRendering.InformationalText =
                        $"Рейд оказался неудачным. \n{color} потерял {currentAsset.Security} бойцов";
                    currentPlayer.Gang.KilledSomeOfAttackers(currentAsset.Security);
                }
                else
                {
                    Program.Game.GameRendering.InformationalText =
                        $"Рейд оказался неудачным. \n{color} потерял {currentPlayer.Gang.NumberOfPeopleAvailable} бойцов";
                    currentPlayer.Gang.KilledAllAttackers();
                }
            }
            
        }
    }
}