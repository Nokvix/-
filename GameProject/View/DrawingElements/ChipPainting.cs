using Microsoft.Xna.Framework.Graphics;
using Color = Microsoft.Xna.Framework.Color;

namespace GameProject.View.DrawingElements;

public class ChipPainting
{
    public ChipPainting(ChipColour chipColour, SpriteRectangle spriteRectangle)
    {
        SpriteRectangle = spriteRectangle;
        ChipColour = chipColour;
    }

    public ChipColour ChipColour { get; init; }
    public SpriteRectangle SpriteRectangle { get; set; }

    public void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(SpriteRectangle.Image, SpriteRectangle.Rectangle, Color.White);
    }
}