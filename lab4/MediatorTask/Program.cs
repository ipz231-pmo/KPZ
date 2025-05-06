
using MediatorTask;

CommandCentre commandCentre = new();

Runway runway1 = new();
Runway runway2 = new();

Aircraft aircraft1 = new("A1", commandCentre);
Aircraft aircraft2 = new("A2", commandCentre);

commandCentre.RegisterRunways(runway1, runway2);

aircraft1.RequestLanding();
aircraft2.RequestLanding();
aircraft1.RequestTakeOff();
aircraft2.RequestTakeOff();