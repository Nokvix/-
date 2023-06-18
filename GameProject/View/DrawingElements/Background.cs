using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameProject.View.DrawingElements;

public class Background
{
    private SpriteRectangle SpriteRectangle { get; init; }

    public Background(SpriteRectangle spriteRectangle)
    {
        SpriteRectangle = spriteRectangle;
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(SpriteRectangle.Image, SpriteRectangle.Rectangle, Color.White);
    }
}