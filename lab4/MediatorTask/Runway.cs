using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediatorTask;

class Runway
{
    public readonly Guid Id = Guid.NewGuid();
    public bool IsTaken { get; set; }

    public void HighLightRed()
    {
        Console.WriteLine($"Runway {Id} is busy!");
    }

    public void HighLightGreen()
    {
        Console.WriteLine($"Runway {Id} is free!");
    }
}
