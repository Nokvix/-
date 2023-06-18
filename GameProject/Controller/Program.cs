namespace GameProject.Controller;

public static class Program
{
    public static GameEngine Game;
    private static void Main()
    {
        Game = new GameEngine();
        Game.Run();
    }
}