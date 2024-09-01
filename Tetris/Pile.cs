using Cabinet;

namespace Tetris;

public class Pile
{
	private List<Block> blocks = [];

	public IEnumerable<Block> Blocks => blocks;

	public void Add(Block block) => blocks.Add(block);

	public int AddRange(IEnumerable<Block> otherBlocks)
	{
		blocks.AddRange(otherBlocks);
		return RemoveLines();
	}

	private int RemoveLines()
	{
		var maxHeight = blocks.Max(x => x.Position.Y);
		var indexies = new List<int>();
		for (int i = 0; i <= maxHeight; i++)
		{
			if (blocks.Where(x => x.Position.Y == i).Count() >= 10)
			{
				blocks.RemoveAll(x => x.Position.Y == i);
				indexies.Add(i);
			}
		}
		indexies.Reverse();
		foreach (var item in indexies)
		{
			var lowerBlocks = blocks.Where(x => x.Position.Y <= item);
			var upperBlocks = blocks
				.Where(x => x.Position.Y > item)
				.Select(x => new Block(x.Id, x.Position - Vector2.Up))
				.ToList();
			blocks = lowerBlocks.Concat(upperBlocks).ToList();
		}
		return indexies.Count;
	}
}