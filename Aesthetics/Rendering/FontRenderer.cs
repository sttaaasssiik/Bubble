using SixLabors.Fonts;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Drawing;
using SixLabors.ImageSharp.Drawing.Processing;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;

namespace Aesthetics.Rendering;

public class FontRenderer
{
    public void Render()
    {
        using Image img = new Image<Rgba32>(1500, 500);

        PathBuilder pathBuilder = new();
        //pathBuilder.SetOrigin(new PointF(500, 0));
        //pathBuilder.AddCubicBezier(new PointF(50, 450), new PointF(200, 50), new PointF(300, 50), new PointF(450, 450));
        pathBuilder.AddLine(new PointF(0, 100), new Point(100, 100));

        IPath path = pathBuilder.Build();

        var font = SystemFonts.CreateFont("Segoe UI", 39, FontStyle.Regular);
        const string text = "Hello World Hello World Hello World Hello World Hello World";

        var textOptions = new TextOptions(font)
        {
            //WrappingLength = path.ComputeLength(),
            VerticalAlignment = VerticalAlignment.Bottom,
            HorizontalAlignment = HorizontalAlignment.Left,
        };

        var glyphs = TextBuilder.GenerateGlyphs(text, path, textOptions);

        img.Mutate(ctx => ctx
            .Fill(Color.White)
            .Fill(Color.Black, glyphs));

        img.Save("C://A/wordart.png");
    }
}