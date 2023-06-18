using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameProject.View.DrawingElements;

public class PlayerInformationWindow
{
    public SpriteRectangle SpriteRectangle { get; private set; }
    private Texture2D PlayerMoveImage { get; set; }
    private Texture2D NotPlayerMoveImage { get; set; }
    public int Index { get; init; }

    public PlayerInformationWindow(SpriteRectangle spriteRectangle, Texture2D playerMoveImage, Texture2D notPlayerMoveImage, int index)
    {
        SpriteRectangle = spriteRectangle;
        PlayerMoveImage = playerMoveImage;
        NotPlayerMoveImage = notPlayerMoveImage;
        Index = index;
    }

    public void ChangeToPlayerMoveImage()
    {
        SpriteRectangle.ChangeImages(PlayerMoveImage);
    }

    public void ChangeToNotPlayerMoveImage()
    {
        SpriteRectangle.ChangeImages(NotPlayerMoveImage);
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(SpriteRectangle.Image, SpriteRectangle.Rectangle, Color.White);
    }
}