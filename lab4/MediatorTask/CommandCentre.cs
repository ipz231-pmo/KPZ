using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediatorTask;

class CommandCentre
{
    private List<Runway> _runways = new();
    private Dictionary<Aircraft, Runway> _landedAircraft = new();

    public void RegisterRunways(params Runway[] runways)
    {
        _runways.AddRange(runways);
    }

    public void RequestLanding(Aircraft aircraft)
    {
        Console.WriteLine($"Aircraft {aircraft.Name} is requesting to land.");

        var availableRunway = _runways.FirstOrDefault(r => !r.IsTaken);
        if (availableRunway != null)
        {
            availableRunway.IsTaken = true;
            availableRunway.HighLightRed();
            _landedAircraft[aircraft] = availableRunway;
            Console.WriteLine($"Aircraft {aircraft.Name} has landed on runway {availableRunway.Id}.");
        }
        else
        {
            Console.WriteLine($"No available runway for aircraft {aircraft.Name}.");
        }
    }

    public void RequestTakeOff(Aircraft aircraft)
    {
        if (_landedAircraft.TryGetValue(aircraft, out var runway))
        {
            runway.IsTaken = false;
            runway.HighLightGreen();
            _landedAircraft.Remove(aircraft);
            Console.WriteLine($"Aircraft {aircraft.Name} has taken off from runway {runway.Id}.");
        }
        else
        {
            Console.WriteLine($"Aircraft {aircraft.Name} is not on any runway.");
        }
    }
}
