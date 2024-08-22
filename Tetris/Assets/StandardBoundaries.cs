using Cabinet;

namespace Tetris.Assets;

public static class StandardBoundaries
{
    public static IEnumerable<Block> Create()
    {
        var boundaries = new List<Block>();
        for (int i = 0; i < 20; i++)
        {
            boundaries.Add(new Block("", new Vector2(-1, i)));
            boundaries.Add(new Block("", new Vector2(10, i)));
        }
        for (int i = -1; i < 11; i++)
        {
            boundaries.Add(new Block("", new Vector2(i, -1)));
        }
        return boundaries;
    }
}