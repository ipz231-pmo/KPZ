using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeTask;

abstract class Shape
{
    public double X { get; set; }
    public double Y { get; set; }
    public IRasterizer Rasterizer { get; set; }
    public abstract string Type { get; }
    public Shape(double x, double y, IRasterizer rasterizer)
    {
        X = x;
        Y = y;
        Rasterizer = rasterizer;
    }
    public void Draw()
    {
        Rasterizer.Draw(this);
    }
}

class Circle : Shape
{
    public double Round { get; set; }
    public string BackgroundColor { get; set; }

    public override string Type => "Circle";

    public Circle(double x, double y, IRasterizer rasterizer, double round, string backgroundColor) : base(x, y, rasterizer)
    {
        Round = round;
        BackgroundColor = backgroundColor;
    }
}

class Square : Shape
{
    public double Size { get; set; }
    public string BackgroundColor { get; set; }

    public override string Type => "Square";

    public Square(double x, double y, IRasterizer rasterizer, double size, string backgroundColor) : base(x, y, rasterizer)
    {
        Size = size;
        BackgroundColor = backgroundColor;
    }
}
