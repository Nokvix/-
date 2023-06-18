using System;
using System.Collections.Generic;
using GameProject.Model.ElementsOfPlay;

namespace GameProject.Model.ElementsOfField.BlackBoxCard;

public class BlackBoxCardGenerator
{
    private static readonly List<Func<Chip, string>> BlackBoxCardList = new()
    {
        YouHaveWonTheLottery,
        YouHaveBrokenTheTrafficRules,
        YourPhoneHasBrokenDown,
        ManCameUpOnStreetAndGaveMoney,
        DogFoundTreasure,
        CaughtInDarkAlley
    };

    private static string YouHaveWonTheLottery(Chip chip)
    {
        var rnd = Random.Shared.Next(50, 501);
        chip.IncrementMoney(rnd);
        return $"Вы выиграли в лотерею {rnd}$. \nПоздравляем вас!";
    }

    private static string YouHaveBrokenTheTrafficRules(Chip chip)
    {
        var rnd = Random.Shared.Next(20, 51);
        chip.DecrementMoney(rnd);
        return $"Вы нарушили ПДД. \nЗаплатите штраф в размере {rnd}$";
    }

    private static string YourPhoneHasBrokenDown(Chip chip)
    {
        var rnd = Random.Shared.Next(75, 201);
        chip.DecrementMoney(rnd);
        return $"У вас сломался телефон. \nВы купили новый за {rnd}$";
    }

    private static string ManCameUpOnStreetAndGaveMoney(Chip chip)
    {
        var rnd = Random.Shared.Next(5, 26);
        chip.IncrementMoney(rnd);
        return $"К вам на улице подошёл \nчеловек и дал {rnd}$";
    }

    private static string DogFoundTreasure(Chip chip)
    {
        var rnd = Random.Shared.Next(50, 201);
        chip.IncrementMoney(rnd);
        return $"Ваша собака на прогулке нашла клад. \nЕго стоимость составляет {rnd}$";
    }

    private static string CaughtInDarkAlley(Chip chip)
    {
        var rnd = Random.Shared.Next(10, 101);
        chip.DecrementMoney(rnd);
        return $"Вас подловили в тёмном переулке \nи ограбили. \nУ вас забрали {rnd}$";
    }

    public static string GetBlackBoxCard(Chip chip)
    {
        var rnd = Random.Shared.Next(0, BlackBoxCardList.Count);
        var blackBoxCard = BlackBoxCardList[rnd];
        return blackBoxCard.Invoke(chip);
    }
}