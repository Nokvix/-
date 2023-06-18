using System;
using GameProject.Controller;
using GameProject.Model.ElementsOfField;
using GameProject.Model.ElementsOfPlay;
using MonopolyGame.FieldObjects;

namespace GameProject.Model;

public class AssignmentOfOutputInformationOnly
{
    public static void DisplayRecruitmentWarning(int currentPosition)
    {
        var currentPlayer = Field.Players[Field.CurrentPlayerIndex];
        var currentPrice = Gang.CostOfIncreasingGang + currentPlayer.HowManyTimesGangHasBeenRecruited * 100;
        if (currentPlayer.MoneyLeftOver >= Gang.CostOfIncreasingGang)
        {
            Program.Game.GameRendering.InformationalText =
                $"Вы уверены, что хотите \nрекрутировать 10 человек в \nбанду за {currentPrice}$?";
        }
        else
            Program.Game.GameRendering.InformationalText = $"Вам не хватает средств на \nрекрутирование \nНабрать 10 человек стоит {currentPrice}$";
    }

    public static void ToRestoreMainMessage(string previousText)
    {
        Program.Game.GameRendering.InformationalText = previousText;
    }

    public static void PurchaseWarning(int currentPosition)
    {
        var currentAsset = Field.FieldCells[currentPosition] as Asset;
        if (Field.Players[Field.CurrentPlayerIndex].MoneyLeftOver >= currentAsset.Price)
        {
            Program.Game.GameRendering.InformationalText =
                $"Вы уверены, что хотите купить \n{currentAsset.Name} за {currentAsset.Price}$?";
        }
        else
            Program.Game.GameRendering.InformationalText = "Вам не хватает средств на покупку";
    }

    public static void WarningAboutSale(int currentPosition)
    {
        var currentAsset = Field.FieldCells[currentPosition] as Asset;
        Program.Game.GameRendering.InformationalText =
            $"Вы уверены, что хотите продать \n{currentAsset.Name} \nза {currentAsset.Price}$?";
    }

    public static void EndOfStrokeWarning()
    {
        Program.Game.GameRendering.InformationalText =
            "Вы уверены, что хотите \nзавершить ход?";
    }

    public static void DisplayArmingWarning(int currentPosition)
    {
        var currentAsset = Field.FieldCells[currentPosition] as Asset;
        if (Field.Players[Field.CurrentPlayerIndex].Gang.NumberOfPeopleAvailable > 0)
        {
            if (currentAsset.Security > 0)
                Program.Game.GameRendering.InformationalText = $"На объекте {currentAsset.Security} охранников. " +
                                                               "\nВы уверены, что хотите поставить \n10 человек на охрану";
            else
                Program.Game.GameRendering.InformationalText = "На объекте нет охранников. " +
                                                               "\nВы уверены, что хотите поставить \n10 человек на охрану";
        }
        else
            Program.Game.GameRendering.InformationalText = "У вас не хватает свободных людей";
    }

    public static void DisplayAttackWarning(int playerPosition, int playerIndex)
    {
        var currentAsset = Field.FieldCells[playerPosition] as Asset;
        if (Field.Players[playerIndex].Gang.NumberOfPeopleAvailable > 0)
        {
            currentAsset.CalculateChanceOfCapture(Field.Players[playerIndex]);
            if (currentAsset.Security > 0)
                Program.Game.GameRendering.InformationalText =
                    $"На объекте находится {currentAsset.Security} охранников. " +
                    $"\nШанс захвата объекта равен {currentAsset.ChanceOfCapture}% " +
                    "\nВы уверены, что хотите напасть?";
            else
            {
                Program.Game.GameRendering.InformationalText = "На объекте нет охранников. " +
                                                               $"\nШанс захвата объекта равен {currentAsset.ChanceOfCapture}% " +
                                                               "\nВы уверены, что хотите напасть?";
            }
        }
        else
            Program.Game.GameRendering.InformationalText = "У вас не хватает свободных людей";
    }

    public static void OutputTextAboutHitOnCell(string chipColor, Cell currentCell)
    {
        Program.Game.GameRendering.InformationalText =
            $"{chipColor} игрок попал на поле \n\"{currentCell.Name}\" " +
            $"\n{currentCell.PerformActionOnPlayer(Field.Players[Field.CurrentPlayerIndex])}";
    }

    public static void OutputTextAboutNeedToRollCube(string chipColour)
    {
        Program.Game.GameRendering.InformationalText = $"Ходит {chipColour} игрок \nБросайте кубики";
    }

    public static void DisplayStartScreenWarning()
    {
        Program.Game.GameRendering.InformationalText =
            "Вы точно хотите выйти на главный \nэкран? \nТекущая игра сохранена не будет";
    }

    public static void DisplayWarningAboutRules()
    {
        Program.Game.GameRendering.InformationalText = "Хотите открыть правила?";
    }

    public static void WarningIfYouRunOutOfMoney()
    {
        Program.Game.GameRendering.InformationalText += $"\n\nВы стали должником. \nВаш долг составляет " +
                                                       $"{Math.Abs(Field.Players[Field.CurrentPlayerIndex].MoneyLeftOver)}$. " +
                                                       $"Чтобы \nпогасить его продайте часть \nсвоего имущества";
    }

    public static void NotificationOfEndOfGameBankrupt()
    {
        Program.Game.RenderingOfSummaries.SoundOfEndGame.Play();
    }
    
    public static void NotificationOfEndOfGameMovesHaveRunOut()
    {
        Program.Game.RenderingMovesHaveRunOut.SoundOfEndGame.Play();
    }
}