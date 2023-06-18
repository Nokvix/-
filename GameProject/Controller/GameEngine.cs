using GameProject.View;
using GameProject.View.DrawingElements;
using GameProject.View.RenderingDirectory;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GameProject.Controller;

public class GameEngine : Game
{
    public StagesOfGame GameStage = StagesOfGame.StartScreen;
    public int NumberOfPlayers = 0;
    private GraphicsDeviceManager _graphics;
    public GameRendering GameRendering;
    public StartScreenRendering StartScreenRendering;
    public RenderingOfSummaries RenderingOfSummaries;
    public RulesFirstPageOnStartScreenRendering RulesFirstPageOnStartScreenRendering;
    public RulesSecondPageOnStartScreenRendering RulesSecondPageOnStartScreenRendering;
    public RulesFirstPageDuringGameRendering RulesFirstPageDuringGameRendering;
    public RulesSecondPageDuringGameRendering RulesSecondPageDuringGameRendering;
    public RenderingMovesHaveRunOut RenderingMovesHaveRunOut;
    public SpriteBatch SpriteBatch;
    public bool Flag = true;
    public int Bankrupt = -1;
    public bool NumberOfPlayersSelected = false;
    public bool IsButtonDepressed = true;

    public GameEngine()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
        _graphics.PreferredBackBufferHeight = 1080;
        _graphics.PreferredBackBufferWidth = 1920;
        _graphics.IsFullScreen = true;
    }

    protected override void Initialize()
    {
        
        if (GameStage == StagesOfGame.StartScreen)
        {
            StartScreenRendering = new StartScreenRendering();
            StoreOfStates.Initialize();
            StoreOfStates.CurrentState = StoreOfStates.States["StartScreenState"];
            StoreOfStates.CurrentState.PerformTask();
        }
        else if (GameStage == StagesOfGame.Game)
        {
            StoreOfStates.CurrentState = StoreOfStates.States["EntryState"];
            StoreOfStates.CurrentState.PerformTask();
            StoreOfStates.ChangeState();
        }
        else if (GameStage == StagesOfGame.Bankruptcy)
            StoreOfStates.CurrentState.PerformTask();
        else if (GameStage == StagesOfGame.RulesFirstPageOnStartScreen)
            StoreOfStates.CurrentState.PerformTask();
        else if (GameStage == StagesOfGame.RulesSecondPageOnStartScreen)
            StoreOfStates.CurrentState.PerformTask();
        else if (GameStage == StagesOfGame.RulesFirstPageDuringGame)
            StoreOfStates.CurrentState.PerformTask();
        else if (GameStage == StagesOfGame.RulesSecondPageDuringGame)
            StoreOfStates.CurrentState.PerformTask();
        else if (GameStage == StagesOfGame.MovesHaveRunOut) 
            StoreOfStates.CurrentState.PerformTask();

        base.Initialize();
    }

    protected override void LoadContent()
    {
        SpriteBatch = new SpriteBatch(GraphicsDevice);
    }

    protected override void Update(GameTime gameTime)
    {
        if (Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();
        if (GameStage == StagesOfGame.StartScreen)
            StoreOfStates.CurrentState.PerformTask();
        else if (GameStage == StagesOfGame.Game)
            StoreOfStates.CurrentState.PerformTask();
        else if (GameStage == StagesOfGame.Bankruptcy)
            StoreOfStates.CurrentState.PerformTask();
        else if (GameStage == StagesOfGame.RulesFirstPageOnStartScreen)
            StoreOfStates.CurrentState.PerformTask();
        else if (GameStage == StagesOfGame.RulesSecondPageOnStartScreen)
            StoreOfStates.CurrentState.PerformTask();
        else if (GameStage == StagesOfGame.RulesFirstPageDuringGame) 
            StoreOfStates.CurrentState.PerformTask();
        else if (GameStage == StagesOfGame.RulesSecondPageDuringGame)
            StoreOfStates.CurrentState.PerformTask();
        else if (GameStage == StagesOfGame.MovesHaveRunOut) 
            StoreOfStates.CurrentState.PerformTask();

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);
        SpriteBatch.Begin();
        if (GameStage == StagesOfGame.StartScreen)
            StoreOfStates.CurrentState.Draw(StartScreenRendering);
        else if (GameStage == StagesOfGame.Game)
            StoreOfStates.CurrentState.Draw(GameRendering);
        else if (GameStage == StagesOfGame.Bankruptcy)
            StoreOfStates.CurrentState.Draw(RenderingOfSummaries);
        else if (GameStage == StagesOfGame.RulesFirstPageOnStartScreen)
            StoreOfStates.CurrentState.Draw(RulesFirstPageOnStartScreenRendering);
        else if (GameStage == StagesOfGame.RulesSecondPageOnStartScreen)
            StoreOfStates.CurrentState.Draw(RulesSecondPageOnStartScreenRendering);
        else if (GameStage == StagesOfGame.RulesFirstPageDuringGame)
            StoreOfStates.CurrentState.Draw(RulesFirstPageDuringGameRendering);
        else if (GameStage == StagesOfGame.RulesSecondPageDuringGame)
            StoreOfStates.CurrentState.Draw(RulesSecondPageDuringGameRendering);
        else if (GameStage == StagesOfGame.MovesHaveRunOut)
            StoreOfStates.CurrentState.Draw(RenderingMovesHaveRunOut);
        SpriteBatch.End();

        base.Draw(gameTime);
    }
}