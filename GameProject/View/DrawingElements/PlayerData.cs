using GameProject.Model;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonopolyGame.FieldObjects;

namespace GameProject.View.DrawingElements;

public class PlayerData
{
    private string _moneyLeftOver = "3000$";
    private readonly Vector2 _moneyLeftOverLocation;
    private string _numberOfPeopleInGang = "0";
    private readonly Vector2 _numberOfPeopleInGangLocation;
    private string _wholePropertyValue = "0$";
    private readonly Vector2 _wholePropertyValueLocation;
    private string _numberOfPeopleOnGuard = "0";
    private readonly Vector2 _numberOfPeopleOnGuardLocation;
    private string _numberOfPeopleAvailable = "0";
    private readonly Vector2 _numberOfPeopleAvailableLocation;

    public PlayerData(Vector2 moneyLeftOverLocation1, Vector2 numberOfPeopleInGangLocation1, 
        Vector2 wholePropertyValueLocation1, Vector2 numberOfPeopleOnGuardLocation1, Vector2 numberOfPeopleAvailableLocation1)
    {
        _moneyLeftOverLocation = moneyLeftOverLocation1;
        _numberOfPeopleInGangLocation = numberOfPeopleInGangLocation1;
        _wholePropertyValueLocation = wholePropertyValueLocation1;
        _numberOfPeopleOnGuardLocation = numberOfPeopleOnGuardLocation1;
        _numberOfPeopleAvailableLocation = numberOfPeopleAvailableLocation1;
    }

    public void DrawString(SpriteBatch spriteBatch, SpriteFont font)
    {
        spriteBatch.DrawString(font, _moneyLeftOver, _moneyLeftOverLocation, Color.Black);
        spriteBatch.DrawString(font, _numberOfPeopleInGang, _numberOfPeopleInGangLocation, Color.Black);
        spriteBatch.DrawString(font, _wholePropertyValue, _wholePropertyValueLocation, Color.Black);
        spriteBatch.DrawString(font, _numberOfPeopleOnGuard, _numberOfPeopleOnGuardLocation, Color.Black);
        spriteBatch.DrawString(font, _numberOfPeopleAvailable, _numberOfPeopleAvailableLocation, Color.Black);
    }

    public void ChangeValue(int playerIndex)
    {
        _moneyLeftOver = Field.Players[playerIndex].MoneyLeftOver + "$";
        _numberOfPeopleInGang = Field.Players[playerIndex].Gang.TotalPeopleInGang.ToString();
        _wholePropertyValue = Field.Players[playerIndex].TotalValueProperty + "$";
        _numberOfPeopleOnGuard = Field.Players[playerIndex].Gang.NumberOfPeopleOnGuard.ToString();
        _numberOfPeopleAvailable = Field.Players[playerIndex].Gang.NumberOfPeopleAvailable.ToString();
    }
}