using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameProject.View.DrawingElements;

public class Inscription
{
    public SpriteVector SpriteVector { get; private set; }
    private Texture2D YellowPlayer { get; }
    private Texture2D BluePlayer { get; }
    private Texture2D RedPlayer { get; }
    private Texture2D GreenPlayer { get; }

    public Inscription(SpriteVector spriteVector, Texture2D yellowPlayer, Texture2D bluePlayer, Texture2D redPlayer, Texture2D greenPlayer)
    {
        SpriteVector = spriteVector;
        YellowPlayer = yellowPlayer;
        BluePlayer = bluePlayer;
        RedPlayer = redPlayer;
        GreenPlayer = greenPlayer;
    }

    public void ChangeToYellow()
    {
        SpriteVector.ChangeImages(YellowPlayer);
    }

    public void ChangeToBlue()
    {
        SpriteVector.ChangeImages(BluePlayer);
    }

    public void ChangeToRed()
    {
        SpriteVector.ChangeImages(RedPlayer);
    }

    public void ChangeToGreen()
    {
        SpriteVector.ChangeImages(GreenPlayer);
    }
    
    public void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(SpriteVector.Image, SpriteVector.Vector, Color.White);
    }
}