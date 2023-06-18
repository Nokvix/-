using System;
using GameProject.Controller;

namespace GameProject.Model.ElementsOfPlay;

public class ThrowingCube
{
    private int _rollFirstDice;
    private int _rollSecondDice;
    private int _amount;

    private void RollDice()
    {
        var firstRollCube = Random.Shared.Next(1, 7);
        var secondRollCube = Random.Shared.Next(1, 7);
        _rollFirstDice = firstRollCube;
        _rollSecondDice = secondRollCube;
        _amount = _rollFirstDice + _rollSecondDice;
    }

    public ValueAfterRollingDice GetValueAfterRollingDice(string chipColour)
    {
        RollDice();
        ChangeImage();
        OutputTextAboutCube(chipColour);
        return new ValueAfterRollingDice(_rollFirstDice, _rollSecondDice, _amount);
    }

    private void ChangeImage()
    {
        Program.Game.GameRendering.Cubes.Item1.ChangeImageOfCube(_rollFirstDice);
        Program.Game.GameRendering.Cubes.Item2.ChangeImageOfCube(_rollSecondDice);
    }

    private void OutputTextAboutCube(string chipColor)
    {
        Program.Game.GameRendering.InformationalText = $"{chipColor} игрок выбросил {_amount}";
    }
}

public record ValueAfterRollingDice(int RollFirstDice, int RollSecondDice, int Amount);