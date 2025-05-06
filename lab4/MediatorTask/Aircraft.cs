using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediatorTask;

class Aircraft
{
    public string Name { get; }
    private CommandCentre _mediator;

    public Aircraft(string name, CommandCentre mediator)
    {
        Name = name;
        _mediator = mediator;
    }

    public void RequestLanding()
    {
        _mediator.RequestLanding(this);
    }

    public void RequestTakeOff()
    {
        _mediator.RequestTakeOff(this);
    }
}
