namespace Cabinet.Tests;

public class ColorTests
{
	[Fact]
	public void FromRGB_Should_Return_Correct_Color()
	{
		var result = Color.FromRgba(0, 0, 0, 0);

		Assert.Equal(Color.FromRgba(0, 0, 0, 0), result);
	}
}