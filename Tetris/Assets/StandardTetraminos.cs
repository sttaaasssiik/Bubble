using Cabinet;

namespace Tetris.Assets;

public static class StandardTetraminos
{
    public static List<List<List<Block>>> Data => new()
    {
        ITetramino,
        OTetramino,
        LTetramino,
        JTetramino,
        STetramino,
        ZTetramino
    };

    public static List<List<Block>> ITetramino => new()
    {
        new ()
        {
            new("I", new Vector2(0, 0)),
            new("I", new Vector2(0, -1)),
            new("I", new Vector2(0, -2)),
            new("I", new Vector2(0, -3)),
        },
        new ()
        {
            new("I", new Vector2(-2, -1)),
            new("I", new Vector2(-1, -1)),
            new("I", new Vector2(0, -1)),
            new("I", new Vector2(1, -1))
        },
        new ()
        {
            new("I", new Vector2(0, 0)),
            new("I", new Vector2(0, -1)),
            new("I", new Vector2(0, -2)),
            new("I", new Vector2(0, -3)),
        },
        new ()
        {
            new("I", new Vector2(-2, -1)),
            new("I", new Vector2(-1, -1)),
            new("I", new Vector2(0, -1)),
            new("I", new Vector2(1, -1))
        }
    };

    public static List<List<Block>> OTetramino => new()
    {
        new()
        {
            new("O", new Vector2(0, 0)),
            new("O", new Vector2(0, -1)),
            new("O", new Vector2(1, 0)),
            new("O", new Vector2(1, -1)),
        },
        new()
        {
            new("O", new Vector2(0, 0)),
            new("O", new Vector2(0, -1)),
            new("O", new Vector2(1, 0)),
            new("O", new Vector2(1, -1)),
        },
        new()
        {
            new("O", new Vector2(0, 0)),
            new("O", new Vector2(0, -1)),
            new("O", new Vector2(1, 0)),
            new("O", new Vector2(1, -1)),
        },
        new()
        {
            new("O", new Vector2(0, 0)),
            new("O", new Vector2(0, -1)),
            new("O", new Vector2(1, 0)),
            new("O", new Vector2(1, -1)),
        },
    };

    public static List<List<Block>> LTetramino => new()
    {
        new()
        {
            new("L", new Vector2(0, 0)),
            new("L", new Vector2(0, -1)),
            new("L", new Vector2(0, -2)),
            new("L", new Vector2(1, -2)),
        },
        new()
        {
            new("L", new Vector2(-1, -1)),
            new("L", new Vector2(0, -1)),
            new("L", new Vector2(1, -1)),
            new("L", new Vector2(-1, -2)),
        },
        new()
        {
            new("L", new Vector2(0, -2)),
            new("L", new Vector2(0, -1)),
            new("L", new Vector2(0, 0)),
            new("L", new Vector2(-1, 0)),
        },
        new()
        {
            new("L", new Vector2(-1, -1)),
            new("L", new Vector2(0, -1)),
            new("L", new Vector2(1, -1)),
            new("L", new Vector2(1, 0)),
        },
    };

    public static List<List<Block>> JTetramino => new()
    {
        new()
        {
            new("J", new Vector2(0, 0)),
            new("J", new Vector2(0, -1)),
            new("J", new Vector2(0, -2)),
            new("J", new Vector2(-1, -2)),
        },
        new()
        {
            new("J", new Vector2(-1, 0)),
            new("J", new Vector2(-1, -1)),
            new("J", new Vector2(0, -1)),
            new("J", new Vector2(1, -1)),
        },
        new()
        {
            new("J", new Vector2(0, 0)),
            new("J", new Vector2(1, 0)),
            new("J", new Vector2(0, -1)),
            new("J", new Vector2(0, -2)),
        },
        new()
        {
            new("J", new Vector2(-1, -1)),
            new("J", new Vector2(0, -1)),
            new("J", new Vector2(1, -1)),
            new("J", new Vector2(1, -2)),
        },
    };

    public static List<List<Block>> STetramino => new()
    {
        new()
        {
            new("S", new Vector2(0, 0)),
            new("S", new Vector2(1, 0)),
            new("S", new Vector2(0, -1)),
            new("S", new Vector2(-1, -1)),
        },
        new()
        {
            new("S", new Vector2(0, 1)),
            new("S", new Vector2(0, 0)),
            new("S", new Vector2(1, 0)),
            new("S", new Vector2(1, -1)),
        },
        new()
        {
            new("S", new Vector2(0, 0)),
            new("S", new Vector2(1, 0)),
            new("S", new Vector2(0, -1)),
            new("S", new Vector2(-1, -1)),
        },
        new()
        {
            new("S", new Vector2(0, 1)),
            new("S", new Vector2(0, 0)),
            new("S", new Vector2(1, 0)),
            new("S", new Vector2(1, -1)),
        },
    };

    public static List<List<Block>> ZTetramino => new()
    {
        new()
        {
            new("Z", new Vector2(0, 0)),
            new("Z", new Vector2(1, 0)),
            new("Z", new Vector2(1, -1)),
            new("Z", new Vector2(2, -1)),
        },
        new()
        {
            new("Z", new Vector2(2, 1)),
            new("Z", new Vector2(2, 0)),
            new("Z", new Vector2(1, 0)),
            new("Z", new Vector2(1, -1)),
        },
        new()
        {
            new("Z", new Vector2(0, 0)),
            new("Z", new Vector2(1, 0)),
            new("Z", new Vector2(1, -1)),
            new("Z", new Vector2(2, -1)),
        },
        new()
        {
            new("Z", new Vector2(2, 1)),
            new("Z", new Vector2(2, 0)),
            new("Z", new Vector2(1, 0)),
            new("Z", new Vector2(1, -1)),
        },
    };
}