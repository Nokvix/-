using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameProject.View.DrawingElements;

public class Button
{
    public SpriteRectangle SpriteRectangle { get; private set; }
    public bool IsPressed { get; set; } = false;
    private Texture2D ActiveImage { get; }
    private Texture2D IlluminatedImage { get; }
    private Texture2D InactiveImage { get; }
    

    public Button(SpriteRectangle spriteRectangle, Texture2D activeImage, Texture2D illuminatedImage, Texture2D inactiveImage)
    {
        SpriteRectangle = spriteRectangle;
        ActiveImage = activeImage;
        IlluminatedImage = illuminatedImage;
        InactiveImage = inactiveImage;
    }

    public void ChangeToActiveImage()
    {
        SpriteRectangle.ChangeImages(ActiveImage);
    }

    public void ChangeToIlluminatedImage()
    {
        SpriteRectangle.ChangeImages(IlluminatedImage);
    }

    public void ChangeToInactiveImage()
    {
        SpriteRectangle.ChangeImages(InactiveImage);
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(SpriteRectangle.Image, SpriteRectangle.Rectangle, Color.White);
    }
}