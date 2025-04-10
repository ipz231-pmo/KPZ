using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdapterTask;

class FileWriter
{
    private string filename;
    public FileWriter(string filename)
    {
        this.filename = filename;
    }

    public void Write(string message)
    {
        using StreamWriter writer = new(filename, true);
        writer.Write(message);
    }
    public void WriteLine(string message)
    {
        using StreamWriter writer = new(filename, true);
        writer.WriteLine(message);
    }
}
