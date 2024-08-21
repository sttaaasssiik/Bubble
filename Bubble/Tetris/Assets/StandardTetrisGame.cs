﻿using Cabinet;

namespace Bubble.Tetris.Assets;

public class StandardTetrisGame
{
    public static TetrisGame Create()
    {
        var extractor = new TetraminoAssetExtractor(StandardTetraminos.Data);
        var startingPosition = new Vector2(4, 18);

        var random = new Random();

        IEnumerator<Tetramino> GetSequence()
        {
            while (true)
            {
                var kind = random.Next() % extractor.KindsCount;
                yield return new Tetramino(extractor, kind, startingPosition, 0);
            }
        };

        var tetraminos = GetSequence();

        Tetramino NextTetramino()
        {
            tetraminos.MoveNext(); return tetraminos.Current;
        }

        return new TetrisGame(NextTetramino, StandardBoundaries.Create());
    }
}