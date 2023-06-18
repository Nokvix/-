using System.Numerics;
using Microsoft.Xna.Framework.Graphics;

namespace GameProject.View.DrawingElements;

public class SpriteVector
{
    public SpriteVector(Texture2D image, Vector2 vector)
    {
        Image = image;
        Vector = vector;
    }
    
    public Texture2D Image { get; private set; }
    public Vector2 Vector;

    public void ChangeImages(Texture2D image)
    {
        Image = image;
    }
}