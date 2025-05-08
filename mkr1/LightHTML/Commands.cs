using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LightHTML;

class SaveCommand : ICommand
{
    public event EventHandler? CanExecuteChanged;

    public bool CanExecute(object? parameter) { return true; }

    public void Execute(object? parameter)
    {
        Console.WriteLine("Saving...");
    }
}

class HoverCommand : ICommand
{
    public event EventHandler? CanExecuteChanged;

    public bool CanExecute(object? parameter) { return true; }

    public void Execute(object? parameter)
    {
        Console.WriteLine("Changing button style...");
    }
}

