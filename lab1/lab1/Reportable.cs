using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1;

internal class Reportable
{
    public void Report(IReporter reporter)
    {
        reporter.Print(this);
    }
}
