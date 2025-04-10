using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdapterTask;

class LoggerFileWriterAdapter : Logger
{
    private FileWriter writer;
    public LoggerFileWriterAdapter(string filename)
    {
        writer = new(filename);
    }
    public override void Log(string message)
    {
        writer.WriteLine($"Log, {message}");
    }
    public override void Warn(string message)
    {
        writer.WriteLine($"Warn, {message}");
    }
    public override void Error(string message)
    {
        writer.WriteLine($"Error, {message}");
    }
}
