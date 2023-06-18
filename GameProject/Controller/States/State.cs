using System;
using GameProject.View;
using GameProject.View.DrawingElements;
using GameProject.View.RenderingDirectory;

namespace GameProject.Controller.States;

public abstract class State
{
    public State(State nextState)
    {
        NextState = nextState;
    }
    
    public State NextState { get; set; }
    public abstract void PerformTask();
    public void Draw(Rendering gameRendering)
    {
        switch (Program.Game.GameStage)
        {
            case StagesOfGame.StartScreen:
                ((StartScreenRendering)gameRendering).DrawScreen();
                break;
            case StagesOfGame.Game:
                ((GameRendering)gameRendering).DrawField();
                break;
            case StagesOfGame.RulesFirstPageOnStartScreen:
                ((RulesFirstPageOnStartScreenRendering)gameRendering).DrawScreen();
                break;
            case StagesOfGame.RulesSecondPageOnStartScreen:
                ((RulesSecondPageOnStartScreenRendering)gameRendering).DrawScreen();
                break;
            case StagesOfGame.RulesFirstPageDuringGame:
                ((RulesFirstPageDuringGameRendering)gameRendering).DrawScreen();
                break;
            case StagesOfGame.RulesSecondPageDuringGame:
                ((RulesSecondPageDuringGameRendering)gameRendering).DrawScreen();
                break;
            case StagesOfGame.Bankruptcy:
                ((RenderingOfSummaries)gameRendering).DrawScreen();
                break;
            case StagesOfGame.MovesHaveRunOut:
                ((RenderingMovesHaveRunOut)gameRendering).DrawScreen();
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
}