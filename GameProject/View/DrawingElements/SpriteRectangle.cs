using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameProject.View.DrawingElements;

public class SpriteRectangle
{
    public SpriteRectangle(Texture2D image, Rectangle rectangle)
    {
        Image = image;
        Rectangle = rectangle;
    }
    
    public Texture2D Image { get; private set; }
    public Rectangle Rectangle;

    public void ChangeImages(Texture2D image)
    {
        Image = image;
    }
}