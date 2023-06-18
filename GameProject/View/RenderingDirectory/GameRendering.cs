using System.Collections.Generic;
using GameProject.Controller;
using GameProject.View.DrawingElements;
using GameProject.View.UserInterface;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace GameProject.View.RenderingDirectory;

public class GameRendering : Rendering
{
    private static readonly ContentManager Content = Program.Game.Content;
    public SpriteBatch SpriteBatch;

    public SoundEffect PurchaseSound = Content.Load<SoundEffect>("Звук покупки");
    public SoundEffect SalesSound = Content.Load<SoundEffect>("Звук продажи");
    public SoundEffect RollingCube = Content.Load<SoundEffect>("Бросок кубиков");
    public SoundEffect AssaultOnObject = Content.Load<SoundEffect>("Звук нападения");
    public SoundEffect GangRecruitment = Content.Load<SoundEffect>("Звук набора в банду");
    public SoundEffect PutOnGuardSound = Content.Load<SoundEffect>("Звук постановки на защиту");
    public SoundEffect PhoneCallSound = Content.Load<SoundEffect>("Звонок телефона звук");
    public SoundEffect BlackBoxSound = Content.Load<SoundEffect>("Чёрный ящик звук");
    public SoundEffect SurpriseSound = Content.Load<SoundEffect>("Получение суперприза звук");
    public SoundEffect HappyBirthdaySound = Content.Load<SoundEffect>("День рождения звук");
    public SoundEffect TaxPaymentSound = Content.Load<SoundEffect>("Платёж налогов звук");
    public SoundEffect RoadRepairsSound = Content.Load<SoundEffect>("Ремонт дороги звук");
    public Texture2D MoveCounter = Content.Load<Texture2D>("Осталось ходов");
    public SpriteFont MoveCounterText = Content.Load<SpriteFont>("Счётчик ходов шрифт");
    public Background Background = UserInterfaceDuringGame.CreateBackground(Content);
    public Button BuyAssetButton = UserInterfaceDuringGame.CreateBuyAssetButton(Content);
    public Button SellAssetButton = UserInterfaceDuringGame.CreateSellAssetButton(Content);
    public Button ThrowingCubeButton = UserInterfaceDuringGame.CreateThrowingCubeButton(Content);
    public Button ButtonToRecruitPeopleToGang = UserInterfaceDuringGame.CreateButtonToRecruitPeopleToGang(Content);
    public Button ButtonToAttackProperty = UserInterfaceDuringGame.CreateButtonToAttackProperty(Content);
    public Button ButtonToPutGuardOnProperty = UserInterfaceDuringGame.CreateButtonToPutGuardOnProperty(Content);
    public Button ButtonToEndMove = UserInterfaceDuringGame.CreateButtonToEndMove(Content);
    public Button HomeScreenExitButton = UserInterfaceDuringGame.CreateHomeScreenExitButton(Content);
    public Button RuleButtonDuringGame = UserInterfaceDuringGame.CreateRuleButtonDuringGame(Content);
    public (Cube, Cube) Cubes = UserInterfaceDuringGame.CreateCubes(Content);
    public List<ChipPainting> ChipPaintings = UserInterfaceDuringGame.CreateChips(Content);

    public List<PlayerInformationWindow> PlayerInformationWindows =
        UserInterfaceDuringGame.CreatePlayerInformationWindows(Content);
    public PropertyOwner[] PropertyOwnersBadge = UserInterfaceDuringGame.CreatePropertyOwner(Content);
    public SpriteFont FontForDisplayingPlayerInformation = Content.Load<SpriteFont>("Text");
    public SpriteFont FontForGameInformation = Content.Load<SpriteFont>("FontForGameInformation");
    public Rectangle[] CellEntity = UserInterfaceDuringGame.CreateCellEntity();
    public string InformationalText = "";
    public string MovesLeft = "200";
    private const int Speed = 6;
    public bool CanGo;
    public readonly PlayerData YellowChip = new PlayerData(new Vector2(1292, 102), 
        new Vector2(1375, 149), new Vector2(1390, 196), 
        new Vector2(1392, 243), new Vector2(1402, 290));
    public readonly PlayerData BlueChip = new PlayerData(new Vector2(1675, 102), 
        new Vector2(1760, 149), new Vector2(1775, 196),
        new Vector2(1777, 243), new Vector2(1788, 290));
    public readonly PlayerData RedChip = new PlayerData(new Vector2(1292, 431), 
        new Vector2(1375, 477), new Vector2(1390, 523),
        new Vector2(1392, 568), new Vector2(1400, 614));
    public readonly PlayerData GreenChip = new PlayerData(new Vector2(1675, 433), 
        new Vector2(1760, 480), new Vector2(1775, 527),
        new Vector2(1777, 574), new Vector2(1788, 621));

    private static readonly MovementCoordinates MovementCoordinates = new();

    public void DrawField()
    {
        SpriteBatch = Program.Game.SpriteBatch;
        Background.Draw(SpriteBatch);
        BuyAssetButton.Draw(SpriteBatch);
        SellAssetButton.Draw(SpriteBatch);
        ThrowingCubeButton.Draw(SpriteBatch);
        ButtonToRecruitPeopleToGang.Draw(SpriteBatch);
        ButtonToAttackProperty.Draw(SpriteBatch);
        ButtonToPutGuardOnProperty.Draw(SpriteBatch);
        ButtonToEndMove.Draw(SpriteBatch);
        HomeScreenExitButton.Draw(SpriteBatch);
        RuleButtonDuringGame.Draw(SpriteBatch);
        SpriteBatch.Draw(MoveCounter, new Rectangle(747, 182, 151, 65), Color.White);
        Cubes.Item1.Draw(SpriteBatch);
        Cubes.Item2.Draw(SpriteBatch);
        foreach (var chip in ChipPaintings) chip.Draw(SpriteBatch);
        foreach (var propertyOwner in PropertyOwnersBadge) propertyOwner.Draw(SpriteBatch);
        foreach (var window in PlayerInformationWindows) window.Draw(SpriteBatch);
        SpriteBatch.DrawString(FontForGameInformation, InformationalText, new Vector2(267,404), Color.Black);
        SpriteBatch.DrawString(MoveCounterText, MovesLeft, new Vector2(784, 200), Color.Black);

        YellowChip.ChangeValue(0);
        YellowChip.DrawString(SpriteBatch, FontForDisplayingPlayerInformation);
        BlueChip.ChangeValue(1);
        BlueChip.DrawString(SpriteBatch, FontForDisplayingPlayerInformation);
        if (ChipPaintings.Count >= 3)
        {
            RedChip.ChangeValue(2);
            RedChip.DrawString(SpriteBatch, FontForDisplayingPlayerInformation);

            if (ChipPaintings.Count == 4)
            {
                GreenChip.ChangeValue(3);
                GreenChip.DrawString(SpriteBatch, FontForDisplayingPlayerInformation);
            }
        }
    }
    
    public void ShowWhoPurchasedProperty(int currentChipPosition, ContentManager content, int chipIndex, BuyOrSale buyOrSale)
    {
        foreach (var badge in PropertyOwnersBadge)
        {
            if (badge.PropertyIndex != currentChipPosition) continue;
            if (buyOrSale == BuyOrSale.Buy) badge.AssignOwner(chipIndex, content);
            else if (buyOrSale == BuyOrSale.Sale) badge.RemoveOwnerOnSale();
            break;
        }
    }
    
    public void MoveChip(int chipId, int currenPosition, int nextPosition)
    {
        var currentChip = ChipPaintings[chipId];
        var location = CellEntity[nextPosition];
        var currentChipRectangle = currentChip.SpriteRectangle.Rectangle;
        var coordinatesOfCurrentChip = MovementCoordinates.ObtainBoundingCoordinatesOfPlayer(chipId);
        if (location.Contains(currentChip.SpriteRectangle.Rectangle))
            CanGo = false;
        else
        {
            if (currentChipRectangle.X >= coordinatesOfCurrentChip.BottomLeftCorner.X &&
                currentChipRectangle.Y >= coordinatesOfCurrentChip.BottomLeftCorner.Y)
                currentChip.SpriteRectangle.Rectangle.X -= Speed;
            else if (currentChipRectangle.X <= coordinatesOfCurrentChip.TopLeftCorner.X && 
                     currentChipRectangle.Y >= coordinatesOfCurrentChip.TopLeftCorner.Y)
                currentChip.SpriteRectangle.Rectangle.Y -= Speed;
            else if (currentChipRectangle.X <= coordinatesOfCurrentChip.TopRightCorner.X && 
                     currentChipRectangle.Y <= coordinatesOfCurrentChip.TopRightCorner.Y)
                currentChip.SpriteRectangle.Rectangle.X += Speed;
            else if (currentChipRectangle.X >= coordinatesOfCurrentChip.BottomRightCorner.X && 
                     currentChipRectangle.Y <= coordinatesOfCurrentChip.BottomRightCorner.Y) 
                currentChip.SpriteRectangle.Rectangle.Y += Speed;
        }
    }
}
