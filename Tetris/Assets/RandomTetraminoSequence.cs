using Cabinet;

namespace Tetris.Assets;

public class RandomTetraminoSequence : ITetraminoSequence
{
	private readonly IEnumerator<Tetramino> tetraminos;
	private Tetramino next;

	public RandomTetraminoSequence(TetraminoAssets tetraminoAssetExtractor)
	{
		var random = new Random();

		IEnumerator<Tetramino> GetSequence()
		{
			while (true)
			{
				var kind = random.Next() % tetraminoAssetExtractor.KindsCount;
				yield return new Tetramino(tetraminoAssetExtractor, kind, 0, new Vector2(0, 0));
			}
		}

		tetraminos = GetSequence();

		tetraminos.MoveNext();
		next = tetraminos.Current;
		tetraminos.MoveNext();
		AfterNext = tetraminos.Current;
	}

	public Tetramino Next
	{
		get
		{
			next = AfterNext;
			tetraminos.MoveNext();
			AfterNext = tetraminos.Current;
			return next;
		}
	}

	public Tetramino AfterNext { get; private set; }
}