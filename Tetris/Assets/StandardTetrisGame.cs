using Cabinet;

namespace Tetris.Assets;

public class StandardTetrisGame
{
	public static TetrisGame Create(Action<TetrisGame>? stateChanged)
	{
		var tetraminoAssets = new TetraminoAssets(StandardTetraminos.Data);
		var startingPosition = new Vector2(4, 18);

		var sequence = new RandomTetraminoSequence(tetraminoAssets);

		return new TetrisGame(sequence, StandardBoundaries.Create(), startingPosition, stateChanged);
	}
}