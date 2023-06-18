using GameProject.View.DrawingElements;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace GameProject.View.UserInterface;

public class UserInterfaceStartScreen
{
    public static Button CreatePlayButton(ContentManager content)
    {
        var activeButton = content.Load<Texture2D>("Кнопка играть");
        var illuminatedButton = content.Load<Texture2D>("Кнопка играть светящаяся");
        var inactiveButton = content.Load<Texture2D>("Кнопка играть неактивная");
        var sprite = new SpriteRectangle(inactiveButton, new Rectangle(829, 600, 270, 90));
        return new Button(sprite, activeButton, illuminatedButton, inactiveButton);
    }

    public static Button CreateRuleButton(ContentManager content)
    {
        var activeButton = content.Load<Texture2D>("Кнопка правила");
        var illuminatedButton = content.Load<Texture2D>("Кнопка правила светящаяся");
        var inactiveButton = content.Load<Texture2D>("Кнопка правила неактивная");
        var sprite = new SpriteRectangle(activeButton, new Rectangle(829, 720, 270, 90));
        return new Button(sprite, activeButton, illuminatedButton, inactiveButton);
    }

    public static Button CreateExitButton(ContentManager content)
    {
        var activeButton = content.Load<Texture2D>("Кнопка выход");
        var illuminatedButton = content.Load<Texture2D>("Кнопка выход светящаяся");
        var inactiveButton = content.Load<Texture2D>("Кнопка выход неактивная");
        var sprite = new SpriteRectangle(activeButton, new Rectangle(829, 840, 270, 90));
        return new Button(sprite, activeButton, illuminatedButton, inactiveButton);
    }

    public static Button Create2PlayerButton(ContentManager content)
    {
        var activeButton = content.Load<Texture2D>("Кнопка 2 игрока");
        var illuminatedButton = content.Load<Texture2D>("Кнопка 2 игрока светящаяся");
        var inactiveButton = content.Load<Texture2D>("Кнопка 2 игрока неактивная");
        var sprite = new SpriteRectangle(activeButton, new Rectangle(556, 450, 198, 57));
        return new Button(sprite, activeButton, illuminatedButton, inactiveButton);
    }

    public static Button Create3PlayerButton(ContentManager content)
    {
        var activeButton = content.Load<Texture2D>("Кнопка 3 игрока");
        var illuminatedButton = content.Load<Texture2D>("Кнопка 3 игрока светящаяся");
        var inactiveButton = content.Load<Texture2D>("Кнопка 3 игрока неактивная");
        var sprite = new SpriteRectangle(activeButton, new Rectangle(861, 450, 198, 57));
        return new Button(sprite, activeButton, illuminatedButton, inactiveButton);
    }

    public static Button Create4PlayerButton(ContentManager content)
    {
        var activeButton = content.Load<Texture2D>("Кнопка 4 игрока");
        var illuminatedButton = content.Load<Texture2D>("Кнопка 4 игрока светящаяся");
        var inactiveButton = content.Load<Texture2D>("Кнопка 4 игрока неактивная");
        var sprite = new SpriteRectangle(activeButton, new Rectangle(1167, 450, 198, 57));
        return new Button(sprite, activeButton, illuminatedButton, inactiveButton);
    }
        
    public static Background CreateBackground(ContentManager content)
    {
        var background = new Background(new SpriteRectangle(content.Load<Texture2D>("Стартовый экран"), 
            new Rectangle(0, 0, 1920, 1080)));
        return background;
    }
}