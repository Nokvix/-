using GameProject.Model;
using GameProject.Model.ElementsOfPlay;
using MonopolyGame.FieldObjects;

namespace GameProject.Controller.States;

public class RollCubeState : State
{
    public RollCubeState(State nextState) : base(nextState) { }

    public override void PerformTask()
    {
        var currentChipPosition = Field.Players[Field.CurrentPlayerIndex].CurrentPosition;
        var color = GetColourOfChipString.GetColourOfChip();
        var cubes = new ThrowingCube().GetValueAfterRollingDice(color);
        
        MovementOfChipState.PreviousPosition = currentChipPosition;
        Field.Players[Field.CurrentPlayerIndex].SetPosition(currentChipPosition + cubes.Amount);
        StoreOfStates.ChangeState();
    }
}