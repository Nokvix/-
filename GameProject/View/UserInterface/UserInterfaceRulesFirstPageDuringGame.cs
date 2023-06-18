﻿using GameProject.View.DrawingElements;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace GameProject.View.UserInterface;

public class UserInterfaceRulesFirstPageDuringGame
{
    public static Background CreateBackground(ContentManager content)
    {
        var background = new Background(new SpriteRectangle(content.Load<Texture2D>("Правила"), 
            new Rectangle(0, 0, 1920, 1080)));
        return background;
    }
    
    public static Button CreateReturnToGameButton(ContentManager content)
    {
        var activeButton = content.Load<Texture2D>("Кнопка вернуться к игре");
        var illuminatedButton = content.Load<Texture2D>("Кнопка вернуться к игре светящаяся");
        var inactiveButton = content.Load<Texture2D>("Кнопка вернуться к игре неактивная");
        var sprite = new SpriteRectangle(activeButton, new Rectangle(1602, 972, 270, 90));
        return new Button(sprite, activeButton, illuminatedButton, inactiveButton);
    }
    
    public static Button CreateNextPageButton(ContentManager content)
    {
        var activeButton = content.Load<Texture2D>("Кнопка на следующую страницу");
        var illuminatedButton = content.Load<Texture2D>("Кнопка на следующую страницу светящаяся");
        var inactiveButton = content.Load<Texture2D>("Кнопка на следующую страницу неактивная");
        var sprite = new SpriteRectangle(activeButton, new Rectangle(1602, 867, 270, 90));
        return new Button(sprite, activeButton, illuminatedButton, inactiveButton);
    }
}