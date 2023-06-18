using System;
using Microsoft.Xna.Framework;

namespace GameProject.View;

public class MovementCoordinates
{
    public BoundaryCoordinates YellowChip { get; init; } = new();
    public BoundaryCoordinates BlueChip { get; init; } = new();
    public BoundaryCoordinates RedChip { get; init; } = new();
    public BoundaryCoordinates GreenChip { get; init; } = new();

    public MovementCoordinates()
    {
        YellowChip.AssignValues(new Vector2(996, 1001), new Vector2(103, 1001), 
            new Vector2(103, 110), new Vector2(996, 110));
        BlueChip.AssignValues(new Vector2(954, 977), new Vector2(61, 977), 
            new Vector2(61, 86), new Vector2(954, 86));
        RedChip.AssignValues(new Vector2(988, 953), new Vector2(95, 953), 
            new Vector2(95, 62), new Vector2(988, 62));
        GreenChip.AssignValues(new Vector2(946, 929), new Vector2(53, 929), 
            new Vector2(53, 38), new Vector2(946, 38));
    }

    public BoundaryCoordinates ObtainBoundingCoordinatesOfPlayer(int chipId)
    {
        return chipId switch
        {
            0 => YellowChip,
            1 => BlueChip,
            2 => RedChip,
            3 => GreenChip,
            _ => throw new ArgumentException("Некорректный Id игрока")
        };
    }
}

public class BoundaryCoordinates
{
    public Vector2 BottomRightCorner { get; private set; } = new();
    public Vector2 BottomLeftCorner { get; private set; } = new();
    public Vector2 TopLeftCorner { get; private set; } = new();
    public Vector2 TopRightCorner { get; private set; } = new();

    public void AssignValues(Vector2 bottomRightCorner, Vector2 bottomLeftCorner, Vector2 topLeftCorner, Vector2 topRightCorner)
    {
        BottomRightCorner = bottomRightCorner;
        BottomLeftCorner = bottomLeftCorner;
        TopLeftCorner = topLeftCorner;
        TopRightCorner = topRightCorner;
    }
}