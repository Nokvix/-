using System;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Color = Microsoft.Xna.Framework.Color;


namespace GameProject.View.DrawingElements;

public class PropertyOwner
{
    public PropertyOwner(SpriteRectangle spriteRectangle, int propertyIndex)
    {
        SpriteRectangle = spriteRectangle;
        PropertyIndex = propertyIndex;
    }
    
    public SpriteRectangle SpriteRectangle { get; private set; }
    public bool IsBought { get; private set; } = false;
    public int PropertyIndex { get; private set; }

    public void AssignOwner(int chipIndex, ContentManager content)
    {
        IsBought = true;
        switch (chipIndex)
        {
            case 0:
                SpriteRectangle.ChangeImages(content.Load<Texture2D>("Обозначение владения жёлтый"));
                break;
            case 1:
                SpriteRectangle.ChangeImages(content.Load<Texture2D>("Обозначение владения синий"));
                break;
            case 2:
                SpriteRectangle.ChangeImages(content.Load<Texture2D>("Обозначение владения красный"));
                break;
            case 3:
                SpriteRectangle.ChangeImages(content.Load<Texture2D>("Обозначение владения зелёный"));
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    public void RemoveOwnerOnSale()
    {
        IsBought = false;
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        if (IsBought) 
            spriteBatch.Draw(SpriteRectangle.Image, SpriteRectangle.Rectangle, Color.White);
    }
}