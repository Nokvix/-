using GameProject.View.DrawingElements;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace GameProject.View.UserInterface;

public class UserInterfaceRulesSecondPageOnStartScreen
{
    public static Background CreateBackground(ContentManager content)
    {
        var background = new Background(new SpriteRectangle(content.Load<Texture2D>("Правила 2 страница"), 
            new Rectangle(0, 0, 1920, 1080)));
        return background;
    }
    
    public static Button CreateHomeScreenExitButton(ContentManager content)
    {
        var activeButton = content.Load<Texture2D>("Кнопка вернуться на главный экран банкрот");
        var illuminatedButton = content.Load<Texture2D>("Кнопка вернуться на главный экран банкрот светящаяся");
        var inactiveButton = content.Load<Texture2D>("Кнопка вернуться на главный экран банкрот неактивная");
        var sprite = new SpriteRectangle(activeButton, new Rectangle(1602, 972, 270, 90));
        return new Button(sprite, activeButton, illuminatedButton, inactiveButton);
    }

    public static Button CreatePreviousPageButton(ContentManager content)
    {
        var activeButton = content.Load<Texture2D>("Кнопка на предыдущую страницу");
        var illuminatedButton = content.Load<Texture2D>("Кнопка на предыдущую страницу светящаяся");
        var inactiveButton = content.Load<Texture2D>("Кнопка на предыдущую страницу неактивная");
        var sprite = new SpriteRectangle(activeButton, new Rectangle(1602, 867, 270, 90));
        return new Button(sprite, activeButton, illuminatedButton, inactiveButton);
    }
}