using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeTask;

interface IRasterizer
{
    void Draw(Shape shape);
}

class PixelRasterizer : IRasterizer
{
    public void Draw(Shape shape)
    {
        Console.WriteLine($"Drawing {shape.Type} using Pixel Graphics");        
    }
}

class VectorRasterizer : IRasterizer
{
    public void Draw(Shape shape)
    {
        Console.WriteLine($"Drawing {shape.Type} using Vector Graphics"); 
    }
}