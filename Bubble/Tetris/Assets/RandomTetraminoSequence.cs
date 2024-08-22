﻿using Cabinet;

namespace Bubble.Tetris.Assets;

public class RandomTetraminoSequence : ITetraminoSequence
{
    private readonly IEnumerator<Tetramino> tetraminos;
    private Tetramino next;

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

    public RandomTetraminoSequence(TetraminoAssetExtractor tetraminoAssetExtractor, Vector2 startingPosition)
    {
        var random = new Random();

        IEnumerator<Tetramino> GetSequence()
        {
            while (true)
            {
                var kind = random.Next() % tetraminoAssetExtractor.KindsCount;
                yield return new Tetramino(tetraminoAssetExtractor, kind, 0, startingPosition);
            }
        }

        tetraminos = GetSequence();

        tetraminos.MoveNext();
        next = tetraminos.Current;
        tetraminos.MoveNext();
        AfterNext = tetraminos.Current;
    }
}