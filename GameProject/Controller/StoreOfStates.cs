using System.Collections.Generic;
using GameProject.Controller.States;
using GameProject.Model;
using GameProject.View;
using GameProject.View.DrawingElements;
using GameProject.View.RenderingDirectory;

namespace GameProject.Controller;

public static class StoreOfStates
{
    private static State _previousPlayerMovesState;
    public static State CurrentState;
    public static readonly Dictionary<string, State> States = new();
    private static State _entryState;
    private static PlayerMoveState _playerMoveState;
    private static RollCubeState _rollCubeState;
    private static MovementOfChipState _movementOfChipState;
    private static CellHitState _cellHitState;
    private static StrokeCompletionState _strokeCompletionState;
    private static StartScreenState _startScreenState;
    private static SummingUpState _summingUpState;
    private static RulesFirstPageOnStartScreenState _rulesFirstPageOnStartScreenState;
    private static RulesSecondPageOnStartScreenState _rulesSecondPageOnStartScreenState;
    private static RulesFirstPageDuringGameState _rulesFirstPageDuringGameState;
    private static RulesSecondPageDuringGameState _rulesSecondPageDuringGameState;
    private static MovesHaveRunOutState _movesHaveRunOutState;

    public static void Initialize()
    {
        _startScreenState = new StartScreenState(_entryState);
        _summingUpState = new SummingUpState(_startScreenState);
        _rulesFirstPageOnStartScreenState = new RulesFirstPageOnStartScreenState(_startScreenState);
        _rulesSecondPageOnStartScreenState = new RulesSecondPageOnStartScreenState(_startScreenState);
        _rulesFirstPageDuringGameState = new RulesFirstPageDuringGameState(_playerMoveState);
        _rulesSecondPageDuringGameState = new RulesSecondPageDuringGameState(_playerMoveState);
        _movesHaveRunOutState = new MovesHaveRunOutState(_startScreenState);
        
        _strokeCompletionState = new StrokeCompletionState(_playerMoveState);
        _cellHitState = new CellHitState(_strokeCompletionState);
        _movementOfChipState = new MovementOfChipState(_cellHitState);
        _rollCubeState = new RollCubeState(_movementOfChipState);
        _playerMoveState = new PlayerMoveState(_rollCubeState);
        _entryState = new EntryState(_playerMoveState);
        _strokeCompletionState.NextState = _playerMoveState;
        States["EntryState"] = _entryState;
        States["PlayerMoveState"] = _playerMoveState;
        States["RollCubeState"] = _rollCubeState;
        States["MovementOfChipState"] = _movementOfChipState;
        States["CellHitState"] = _cellHitState;
        States["StrokeCompletionState"] = _strokeCompletionState;
        
        States["StartScreenState"] = _startScreenState;
        States["SummingUpState"] = _summingUpState;
        States["RulesFirstPageOnStartScreenState"] = _rulesFirstPageOnStartScreenState;
        States["RulesFirstPageDuringGameState"] = _rulesFirstPageDuringGameState;
        States["MovesHaveRunOutState"] = _movesHaveRunOutState;
        States["RulesSecondPageOnStartScreenState"] = _rulesSecondPageOnStartScreenState;
        States["RulesSecondPageDuringGameState"] = _rulesSecondPageDuringGameState;
    }

    public static void ChangeState()
    {
        CurrentState = CurrentState.NextState;
    }

    public static void ChangeStateToFirstPageRulesDuringGame()
    {
        Program.Game.GameStage = StagesOfGame.RulesFirstPageDuringGame;
        Program.Game.RulesFirstPageDuringGameRendering = new RulesFirstPageDuringGameRendering();
        CurrentState = States["RulesFirstPageDuringGameState"];
        CurrentState.PerformTask();
    }

    public static void ChangeStateToSecondPageRulesDuringGame()
    {
        Program.Game.GameStage = StagesOfGame.RulesSecondPageDuringGame;
        Program.Game.RulesSecondPageDuringGameRendering = new RulesSecondPageDuringGameRendering();
        CurrentState = States["RulesSecondPageDuringGameState"];
        CurrentState.PerformTask();
    }

    public static void ChangeStateToFirstPageRulesOnStartScreen()
    {
        Program.Game.GameStage = StagesOfGame.RulesFirstPageOnStartScreen;
        Program.Game.RulesFirstPageOnStartScreenRendering = new RulesFirstPageOnStartScreenRendering();
        CurrentState = States["RulesFirstPageOnStartScreenState"];
        CurrentState.PerformTask();
    }

    public static void ChangeStateToSecondPageRulesOnStartScreen()
    {
        Program.Game.GameStage = StagesOfGame.RulesSecondPageOnStartScreen;
        Program.Game.RulesSecondPageOnStartScreenRendering = new RulesSecondPageOnStartScreenRendering();
        CurrentState = States["RulesSecondPageOnStartScreenState"];
        CurrentState.PerformTask();
    }

    public static void ChangeStateToGame()
    {
        CurrentState = States["EntryState"];
        CurrentState.PerformTask();
        ChangeState();
    }

    public static void ChangeStateToStartScreen()
    {
        Program.Game.NumberOfPlayersSelected = false;
        Program.Game.NumberOfPlayers = 0;
        Program.Game.GameStage = StagesOfGame.StartScreen;
        Program.Game.StartScreenRendering = new StartScreenRendering();
        CurrentState = States["StartScreenState"];
        CurrentState.PerformTask();
    }

    public static void ChangeToMovesHaveRunOut()
    {
        Program.Game.RenderingMovesHaveRunOut = new RenderingMovesHaveRunOut();
        Program.Game.GameStage = StagesOfGame.MovesHaveRunOut;
        CurrentState = States["MovesHaveRunOutState"];
        AssignmentOfOutputInformationOnly.NotificationOfEndOfGameMovesHaveRunOut();
        CurrentState.PerformTask();
    }

    public static void ChangeToSummingUpState()
    {
        Program.Game.RenderingOfSummaries = new RenderingOfSummaries();
        Program.Game.GameStage = StagesOfGame.Bankruptcy;
        CurrentState = States["SummingUpState"];
        AssignmentOfOutputInformationOnly.NotificationOfEndOfGameBankrupt();
        CurrentState.PerformTask();
    }

    public static void ChangeToRulesOnStartScreenState()
    {
        Program.Game.RulesFirstPageOnStartScreenRendering = new RulesFirstPageOnStartScreenRendering();
        CurrentState = States["RulesFirstPageOnStartScreenState"];
        CurrentState.PerformTask();
    }

    public static void ChangeToRulesDuringGameState()
    {
        Program.Game.RulesFirstPageDuringGameRendering = new RulesFirstPageDuringGameRendering();
        Program.Game.GameStage = StagesOfGame.RulesFirstPageDuringGame;
        _previousPlayerMovesState = CurrentState;
        CurrentState = States["RulesFirstPageDuringGameState"];
        CurrentState.PerformTask();
    }
    
    public static void ChangeToPlayerMoveState()
    {
        Program.Game.GameStage = StagesOfGame.Game;
        CurrentState = _previousPlayerMovesState;
        CurrentState.PerformTask();
    }
}