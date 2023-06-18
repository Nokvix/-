using System;
using System.Collections.Generic;
using GameProject.Model.ElementsOfPlay;

namespace GameProject.Model.ElementsOfField.CallFromPhone;

public class CardCallFromUnknownNumberGenerate
{
    private static readonly List<Func<Chip, string>> ListOfPhoneDialogues = new()
    {
        ItIsTimeToRepayMicroloan,
        FriendBirthday,
        WinningRaffle,
        YouHaveBeenRepaid
    };

    private static string ItIsTimeToRepayMicroloan(Chip chip)
    {
        var rnd = Random.Shared.Next(20, 131);
        chip.DecrementMoney(rnd);
        return $"Пришло время погасить микрозайм. \nВыплатите {rnd}$ для погашения долга";
    }

    private static string FriendBirthday(Chip chip)
    {
        var names = new[]
        {
            "Коли", "Егора", "Миши", "Серёжи", "Кати", "Насти", "Вани", "Рахима", "Веры", "Юли", "Андрея", "Вали",
            "Маши", "Саши", "Пети"
        };
        var rnd = Random.Shared;
        var amount = rnd.Next(20, 81);
        chip.DecrementMoney(amount);
        return $"Привет, на следующей неделе \nдень рождения у {names[rnd.Next(0, names.Length)]}" +
               $"\nПереведи {amount}$ на подарок";
    }

    private static string WinningRaffle(Chip chip)
    {
        var rnd = Random.Shared.Next(30, 151);
        chip.IncrementMoney(rnd);
        return $"Добрый день! Поздравляем, вы \nвыиграли в розыгрыше! \nВам на карту было зачислено {rnd}$";
    }

    private static string YouHaveBeenRepaid(Chip chip)
    {
        var rnd = Random.Shared.Next(10, 101);
        chip.IncrementMoney(rnd);
        return $"Привет, я вернул тебе долг. \n{rnd}$ перевёл тебе на карту";
    }
    
    public static string GetCardCallFromUnknownNumber(Chip chip)
    {
        var rnd = Random.Shared.Next(0, ListOfPhoneDialogues.Count);
        var cardCallFromUnknownNumber = ListOfPhoneDialogues[rnd];
        return cardCallFromUnknownNumber.Invoke(chip);
    }
}