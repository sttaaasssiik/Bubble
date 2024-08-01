namespace Bubble.Tetris;

public class TetraminoAssetExtractor
{
    private readonly List<List<List<Block>>> tetraminoAssets;

    public TetraminoAssetExtractor(List<List<List<Block>>> tetraminoAssets)
    {
        this.tetraminoAssets = tetraminoAssets;
    }

    public int GetRotationsForKindCount(int kind) => tetraminoAssets[kind].Count;

    public int KindsCount => tetraminoAssets.Count;

    public IEnumerable<Block> this[int kind, int rotation] => tetraminoAssets[kind][rotation];
}