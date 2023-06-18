using GameProject.Model;
using MonopolyGame.FieldObjects;

namespace GameProject.Controller.States;

public class EntryState : State
{
    public EntryState(State nextState) : base(nextState) { }

    public override void PerformTask() => Field.InitialiseFieldAndPlayers(Program.Game.NumberOfPlayers);
}