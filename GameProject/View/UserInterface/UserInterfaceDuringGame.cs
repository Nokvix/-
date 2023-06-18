using System.Collections.Generic;
using GameProject.Controller;
using GameProject.View.DrawingElements;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace GameProject.View.UserInterface;

public static class UserInterfaceDuringGame
{
    private const int ButtonWidth = 204;
    private const int ButtonHeight = 68;
    private const int CoordinateXOfLeftHandButtons = 1206;
    private const int XCoordinateForRightHandButtons = 1590;
    private const int InitialCoordinateYOfButtons = 681;

    public static Button CreateBuyAssetButton(ContentManager content)
    {
        var activeButton = content.Load<Texture2D>("Кнопка купить имущество");
        var illuminatedButton = content.Load<Texture2D>("Подсвеченная кнопка купить имущество");
        var inactiveButton = content.Load<Texture2D>("Неактивная кнопка купить имущество");
        var sprite = new SpriteRectangle(inactiveButton, 
            new Rectangle(CoordinateXOfLeftHandButtons, InitialCoordinateYOfButtons, ButtonWidth, ButtonHeight));
        return new Button(sprite, activeButton, illuminatedButton, inactiveButton);
    }

    public static Button CreateSellAssetButton(ContentManager content)
    {
        var activeButton = content.Load<Texture2D>("Кнопка продать имущество");
        var illuminatedButton = content.Load<Texture2D>("Подсвеченная кнопка продать имущество");
        var inactiveButton = content.Load<Texture2D>("Неактивная кнопка продать имущество");
        
        var sprite = new SpriteRectangle(inactiveButton,
            new Rectangle(CoordinateXOfLeftHandButtons, InitialCoordinateYOfButtons + 84, ButtonWidth, ButtonHeight));
        return new Button(sprite, activeButton, illuminatedButton, inactiveButton);
    }

    public static Button CreateThrowingCubeButton(ContentManager content)
    {
        var activeButton = content.Load<Texture2D>("Кнопка бросить кубики");
        var illuminatedButton = content.Load<Texture2D>("Подсвеченная кнопка бросить кубики");
        var inactiveButton = content.Load<Texture2D>("Неактивная кнопка бросить кубики");
        var sprite = new SpriteRectangle(activeButton,
            new Rectangle(CoordinateXOfLeftHandButtons, InitialCoordinateYOfButtons + 2 * 84, ButtonWidth, ButtonHeight));
        return new Button(sprite, activeButton, illuminatedButton, inactiveButton);
    }

    public static Button CreateButtonToRecruitPeopleToGang(ContentManager content)
    {
        var activeButton = content.Load<Texture2D>("Кнопка набрать людей в банду");
        var illuminatedButton = content.Load<Texture2D>("Подсвеченная кнопка набрать людей в банду");
        var inactiveButton = content.Load<Texture2D>("Неактивная кнопка набрать людей в банду");
        var sprite = new SpriteRectangle(inactiveButton,
            new Rectangle(XCoordinateForRightHandButtons, InitialCoordinateYOfButtons, ButtonWidth, ButtonHeight));
        return new Button(sprite, activeButton, illuminatedButton, inactiveButton);
    }

    public static Button CreateButtonToAttackProperty(ContentManager content)
    {
        var activeButton = content.Load<Texture2D>("Кнопка напасть на имущество");
        var illuminatedButton = content.Load<Texture2D>("Подсвеченная кнопка напасть на имущество");
        var inactiveButton = content.Load<Texture2D>("Неактивная кнопка напасть на имущество");
        var sprite = new SpriteRectangle(inactiveButton,
            new Rectangle(XCoordinateForRightHandButtons, InitialCoordinateYOfButtons + 84, ButtonWidth, ButtonHeight));
        return new Button(sprite, activeButton, illuminatedButton, inactiveButton);
    }

    public static Button CreateButtonToPutGuardOnProperty(ContentManager content)
    {
        var activeButton = content.Load<Texture2D>("Кнопка поставить охрану");
        var illuminatedButton = content.Load<Texture2D>("Подсвеченная кнопка поставить охрану");
        var inactiveButton = content.Load<Texture2D>("Неактивная кнопка поставить охрану");
        var sprite = new SpriteRectangle(inactiveButton,
            new Rectangle(XCoordinateForRightHandButtons, InitialCoordinateYOfButtons + 84 * 2, ButtonWidth, ButtonHeight));
        return new Button(sprite, activeButton, illuminatedButton, inactiveButton);
    }

    public static Button CreateButtonToEndMove(ContentManager content)
    {
        var activeButton = content.Load<Texture2D>("Кнопка завершить ход");
        var illuminatedButton = content.Load<Texture2D>("Подсвеченная кнопка завершить ход");
        var inactiveButton = content.Load<Texture2D>("Неактивная кнопка завершить ход");
        var sprite = new SpriteRectangle(inactiveButton, new Rectangle(1795, 975, 102, 68));
        return new Button(sprite, activeButton, illuminatedButton, inactiveButton);
    }

    public static Button CreateHomeScreenExitButton(ContentManager content)
    {
        var activeButton = content.Load<Texture2D>("Кнопка выйти на главный экран");
        var illuminatedButton = content.Load<Texture2D>("Кнопка выйти на главный экран светящаяся");
        var inactiveButton = content.Load<Texture2D>("Кнопка выйти на главный экран неактивная");
        var sprite = new SpriteRectangle(activeButton, new Rectangle(1257, 975, 102, 68));
        return new Button(sprite, activeButton, illuminatedButton, inactiveButton);
    }

    public static  Button CreateRuleButtonDuringGame(ContentManager content)
    {
        var activeButton = content.Load<Texture2D>("Кнопка правила во время игры");
        var illuminatedButton = content.Load<Texture2D>("Кнопка правила во время игры светящаяся");
        var inactiveButton = content.Load<Texture2D>("Кнопка правила во время игры неактивная");
        var sprite = new SpriteRectangle(activeButton, new Rectangle(1116, 975, 102, 68));
        return new Button(sprite, activeButton, illuminatedButton, inactiveButton);
    }

    public static (Cube, Cube) CreateCubes(ContentManager content)
    {
        var picturesOfFacesOfCube = new Texture2D[]
        {
            content.Load<Texture2D>("Кубик 1"),
            content.Load<Texture2D>("Кубик 2"),
            content.Load<Texture2D>("Кубик 3"),
            content.Load<Texture2D>("Кубик 4"),
            content.Load<Texture2D>("Кубик 5"),
            content.Load<Texture2D>("Кубик 6")
        };
        var cube1 = new Cube(new SpriteRectangle(picturesOfFacesOfCube[0], new Rectangle(1386, 933, 100, 100)), 
            picturesOfFacesOfCube);
        var cube2 = new Cube(new SpriteRectangle(picturesOfFacesOfCube[0], new Rectangle(1515, 933, 100, 100)), 
            picturesOfFacesOfCube);
        return (cube1, cube2);
    }

    public static Background CreateBackground(ContentManager content)
    {
        var background = new Background(new SpriteRectangle(content.Load<Texture2D>("Поле"), 
            new Rectangle(0, 0, 1920, 1080)));
        return background;
    }

    public static List<ChipPainting> CreateChips(ContentManager content)
    {
        var allChips = new List<ChipPainting>();
        var numberOfPlayers = Program.Game.NumberOfPlayers;
        if (numberOfPlayers is >= 2 and < 5)
        {
            allChips.Add(new ChipPainting(ChipColour.Yellow, new SpriteRectangle(content.Load<Texture2D>("Жёлтая фишка"),
                new Rectangle(996, 1001, 39, 39))));
            allChips.Add(new ChipPainting(ChipColour.Blue, new SpriteRectangle(content.Load<Texture2D>("Синяя фишка"),
                new Rectangle(954, 977, 39, 39))));
            if (numberOfPlayers >= 3)
            {
                allChips.Add(new ChipPainting(ChipColour.Red, new SpriteRectangle(content.Load<Texture2D>("Красная фишка"),
                    new Rectangle(988, 953, 39, 39))));
                if (numberOfPlayers == 4)
                    allChips.Add(new ChipPainting(ChipColour.Green, new SpriteRectangle(content.Load<Texture2D>("Зелёная фишка"),
                        new Rectangle(946, 929, 39, 39))));
            }
        }
        
        return allChips;
    }

    public static List<PlayerInformationWindow> CreatePlayerInformationWindows(ContentManager content)
    {
        var allWindows = new List<PlayerInformationWindow>();
        var numberOfPlayers = Program.Game.NumberOfPlayers;
        if (numberOfPlayers is >= 2 and < 5)
        {
            allWindows.Add(new PlayerInformationWindow(
                new SpriteRectangle(content.Load<Texture2D>("Светящееся окно жёлтого"),
                    new Rectangle(1150, 19, 315, 315)),
                content.Load<Texture2D>("Светящееся окно жёлтого"),
                content.Load<Texture2D>("Окно жёлтого"), 0));
            allWindows.Add(new PlayerInformationWindow(
                new SpriteRectangle(content.Load<Texture2D>("Окно синего"),
                    new Rectangle(1534, 19, 315, 315)),
                content.Load<Texture2D>("Светящееся окно синего"),
                content.Load<Texture2D>("Окно синего"), 1));
            if (numberOfPlayers >= 3)
            {
                allWindows.Add(new PlayerInformationWindow(new SpriteRectangle(content.Load<Texture2D>("Окно красного"),
                        new Rectangle(1150, 350, 315, 315)), content.Load<Texture2D>("Светящееся окно красного"),
                    content.Load<Texture2D>("Окно красного"), 2));
                if (numberOfPlayers == 4)
                    allWindows.Add(new PlayerInformationWindow(new SpriteRectangle(content.Load<Texture2D>("Окно зелёного"),
                            new Rectangle(1534, 350, 315, 315)),
                        content.Load<Texture2D>("Светящееся окно зелёного"),
                        content.Load<Texture2D>("Окно зелёного"), 3));
            }
        }
        return allWindows;
    }

    public static PropertyOwner[] CreatePropertyOwner(ContentManager content)
    {
        const int side = 20;
        var image = content.Load<Texture2D>("Обозначение владения жёлтый");
        var propertyOwner = new PropertyOwner[22];
        propertyOwner[0] = new PropertyOwner(new SpriteRectangle(image, new Rectangle(808, 897, side, side)), 1);
        propertyOwner[1] = new PropertyOwner(new SpriteRectangle(image, new Rectangle(628, 897, side, side)), 3);
        propertyOwner[2] = new PropertyOwner(new SpriteRectangle(image, new Rectangle(449, 897, side, side)), 5);
        propertyOwner[3] = new PropertyOwner(new SpriteRectangle(image, new Rectangle(271, 897, side, side)), 7);
        propertyOwner[4] = new PropertyOwner(new SpriteRectangle(image, new Rectangle(182, 897, side, side)), 8);
        propertyOwner[5] = new PropertyOwner(new SpriteRectangle(image, new Rectangle(163, 807, side, side)), 10);
        propertyOwner[6] = new PropertyOwner(new SpriteRectangle(image, new Rectangle(163, 628, side, side)), 12);
        propertyOwner[7] = new PropertyOwner(new SpriteRectangle(image, new Rectangle(163, 539, side, side)), 13);
        propertyOwner[8] = new PropertyOwner(new SpriteRectangle(image, new Rectangle(163, 449, side, side)), 14);
        propertyOwner[9] = new PropertyOwner(new SpriteRectangle(image, new Rectangle(163, 271, side, side)), 16);
        propertyOwner[10] = new PropertyOwner(new SpriteRectangle(image, new Rectangle(163, 182, side, side)), 17);
        propertyOwner[11] = new PropertyOwner(new SpriteRectangle(image, new Rectangle(182, 0, side, side)), 19);
        propertyOwner[12] = new PropertyOwner(new SpriteRectangle(image, new Rectangle(272, 0, side, side)), 20);
        propertyOwner[13] = new PropertyOwner(new SpriteRectangle(image, new Rectangle(450, 0, side, side)), 22);
        propertyOwner[14] = new PropertyOwner(new SpriteRectangle(image, new Rectangle(540, 0, side, side)), 23);
        propertyOwner[15] = new PropertyOwner(new SpriteRectangle(image, new Rectangle(719, 0, side, side)), 25);
        propertyOwner[16] = new PropertyOwner(new SpriteRectangle(image, new Rectangle(808, 0, side, side)), 26);
        propertyOwner[17] = new PropertyOwner(new SpriteRectangle(image, new Rectangle(897, 253, side, side)), 28);
        propertyOwner[18] = new PropertyOwner(new SpriteRectangle(image, new Rectangle(897, 431, side, side)), 30);
        propertyOwner[19] = new PropertyOwner(new SpriteRectangle(image, new Rectangle(897, 521, side, side)), 31);
        propertyOwner[20] = new PropertyOwner(new SpriteRectangle(image, new Rectangle(897, 788, side, side)), 34);
        propertyOwner[21] = new PropertyOwner(new SpriteRectangle(image, new Rectangle(897, 878, side, side)), 35);
        return propertyOwner;
    }

    public static Rectangle[] CreateCellEntity()
    {
        var cellEntity = new Rectangle[]
        {
            new Rectangle(897, 897, 183, 183),
            new Rectangle(808, 897, 90, 183),
            new Rectangle(717, 897, 91, 183),
            new Rectangle(628, 897, 89, 183),
            new Rectangle(540, 897, 89, 183),
            new Rectangle(449, 897, 92, 183),
            new Rectangle(361, 897, 89, 183),
            new Rectangle(271, 897, 91, 183),
            new Rectangle(182, 897, 90, 183),
            new Rectangle(0, 897, 183, 183),
            new Rectangle(0, 807, 183, 91),
            new Rectangle(0, 718, 183, 90),
            new Rectangle(0, 628, 183, 91),
            new Rectangle(0, 539, 183, 90),
            new Rectangle(0, 449, 183, 91),
            new Rectangle(0, 360, 183, 90),
            new Rectangle(0, 271, 183, 90),
            new Rectangle(0, 182, 183, 90),
            new Rectangle(0, 0, 183, 183),
            new Rectangle(182, 0, 91, 183),
            new Rectangle(272, 0, 90, 183),
            new Rectangle(361, 0, 90, 183),
            new Rectangle(450, 0, 91, 183),
            new Rectangle(540, 0, 90, 183),
            new Rectangle(629, 0, 91, 183),
            new Rectangle(719, 0, 90, 183),
            new Rectangle(808, 0, 90, 183),
            new Rectangle(897, 0, 183, 183),
            new Rectangle(897, 182, 183, 91),
            new Rectangle(897, 272, 183, 90),
            new Rectangle(897, 361, 183, 90),
            new Rectangle(897, 450, 183, 91),
            new Rectangle(897, 540, 183, 89),
            new Rectangle(897, 628, 183, 91),
            new Rectangle(897, 718, 183, 90),
            new Rectangle(897, 807, 183, 91)
        };
        return cellEntity;
    }
}