using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameProject.View.DrawingElements;
public class Cube
{
    private SpriteRectangle SpriteRectangle { get; }
    private readonly Texture2D[] _picturesOfFacesOfCube;

    public Cube(SpriteRectangle spriteRectangle, Texture2D[] picturesOfFacesOfCube)
    {
        SpriteRectangle = spriteRectangle;
        _picturesOfFacesOfCube = picturesOfFacesOfCube;
    }

    public void ChangeImageOfCube(int value)
    {
        SpriteRectangle.ChangeImages(_picturesOfFacesOfCube[value - 1]);
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(SpriteRectangle.Image, SpriteRectangle.Rectangle, Color.White);
    }
}