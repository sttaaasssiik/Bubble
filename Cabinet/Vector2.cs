namespace Cabinet;

public struct Vector2
{
    public int X { get; set; }

    public int Y { get; set; }

    public Vector2(int x, int y)
    {
        X = x;
        Y = y;
    }

    public static Vector2 Up => new(0, 1);

    public static Vector2 Down => new(0, -1);

    public static Vector2 Left => new(-1, 0);

    public static Vector2 Right => new(1, 0);

    public static Vector2 operator +(Vector2 a, Vector2 b) => new(a.X + b.X, a.Y + b.Y);

    public static Vector2 operator -(Vector2 a, Vector2 b) => new(a.X - b.X, a.Y - b.Y);

    public static bool operator ==(Vector2 a, Vector2 b) => a.X == b.X && a.Y == b.Y;

    public static bool operator !=(Vector2 a, Vector2 b) => !(a.X == b.X && a.Y == b.Y);
}