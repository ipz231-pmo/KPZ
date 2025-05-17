using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace lab6.Core;

class RelayCommand : ICommand
{
    public event EventHandler? CanExecuteChanged
    {
        add => CommandManager.RequerySuggested += value;
        remove => CommandManager.RequerySuggested -= value;
    }


    private Func<object?, bool>? canExecute;
    private Action<object?> execute;

    public RelayCommand(Action<object?> execute, Func<object?, bool>? canExecute = null)
    {
        this.canExecute = canExecute;
        this.execute = execute;
    }

    public bool CanExecute(object? parameter) => canExecute == null || canExecute(parameter);
    public void Execute(object? parameter) => execute(parameter);
}
