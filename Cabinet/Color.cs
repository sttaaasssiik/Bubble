namespace Cabinet;

public struct Color
{
	public byte R { get; set; }

	public byte G { get; set; }

	public byte B { get; set; }

	public byte A { get; set; }

	public static Color FromRgba(byte r, byte g, byte b, byte a) => new() { R = r, G = g, B = b, A = a };
}