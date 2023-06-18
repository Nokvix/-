using GameProject.View.DrawingElements;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Vector2 = System.Numerics.Vector2;

namespace GameProject.View.UserInterface;

public class UserInterfaceBankruptcy
{
    public static Background CreateBackground(ContentManager content)
    {
        var background = new Background(new SpriteRectangle(content.Load<Texture2D>("Подведение итогов"), 
            new Rectangle(0, 0, 1920, 1080)));
        return background;
    }

    public static Button CreateHomeScreenExitButton(ContentManager content)
    {
        var activeButton = content.Load<Texture2D>("Кнопка вернуться на главный экран банкрот");
        var illuminatedButton = content.Load<Texture2D>("Кнопка вернуться на главный экран банкрот светящаяся");
        var inactiveButton = content.Load<Texture2D>("Кнопка вернуться на главный экран банкрот неактивная");
        var sprite = new SpriteRectangle(activeButton, new Rectangle(1560, 890, 270, 90));
        return new Button(sprite, activeButton, illuminatedButton, inactiveButton);
    }

    public static Inscription CreateInscriptionLoser(ContentManager content)
    {
        var yellow = content.Load<Texture2D>("жёлтый игрок");
        var blue = content.Load<Texture2D>("синий игрок");
        var red = content.Load<Texture2D>("красный игрок");
        var green = content.Load<Texture2D>("зёленый игрок");
        var sprite = new SpriteVector(yellow, new Vector2(923, 392));
        return new Inscription(sprite, yellow, blue, red, green);
    }
    
    public static Inscription CreateInscriptionWinner(ContentManager content)
    {
        var yellow = content.Load<Texture2D>("жёлтый игрок");
        var blue = content.Load<Texture2D>("синий игрок");
        var red = content.Load<Texture2D>("красный игрок");
        var green = content.Load<Texture2D>("зёленый игрок");
        var sprite = new SpriteVector(yellow, new Vector2(617, 563));
        return new Inscription(sprite, yellow, blue, red, green);
    }
}