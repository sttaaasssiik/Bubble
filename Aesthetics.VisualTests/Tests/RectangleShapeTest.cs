//using Aesthetics.Base;
//using Cabinet;

//namespace Aesthetics.VisualTests.Tests;

//public class RectangleShapeTest : TestWindow
//{
//    public RectangleShapeTest()
//    {
//        var canvas = new SimpleCanvas();
//        Content = canvas;
//        var rectangleShape = new RectangleShape()
//        {
//            Background = Color.FromRgba(255, 0, 0, 255),
//            Width = 90,
//            Height = 90
//        };
//        var rectangleShape2 = new RectangleShape()
//        {
//            Background = Color.FromRgba(0, 255, 0, 255),
//            Width = 90,
//            Height = 90
//        };
//        SimpleCanvas.SetPosition(rectangleShape2, new Vector2(100, 0));
//        canvas.Children.Add(rectangleShape);
//        canvas.Children.Add(rectangleShape2);
//    }
//}