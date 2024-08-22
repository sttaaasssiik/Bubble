namespace Bubble.Tetris;

public class TetraminoAssetExtractor(List<List<List<Block>>> tetraminoAssets)
{
    private readonly List<List<List<Block>>> tetraminoAssets = tetraminoAssets;

    public int GetRotationsForKindCount(int kind) => tetraminoAssets[kind].Count;

    public int KindsCount => tetraminoAssets.Count;

    public IEnumerable<Block> this[int kind, int rotation] => tetraminoAssets[kind][rotation];
}