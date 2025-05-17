using lab6.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab6.ViewModels;

class MenuVM : Core.VMBase
{
    public RelayCommand LogoutCmd { get; set; }
    public RelayCommand ExitCmd { get; set; }

    public EventHandler? LogoutHndl { get; set; }
    public EventHandler? ExitHndl { get; set; }


    public MenuVM()
    {
        LogoutCmd = new RelayCommand((param) => LogoutHndl?.Invoke(this, EventArgs.Empty));
        ExitCmd = new RelayCommand((param) => ExitHndl?.Invoke(this, EventArgs.Empty));
    }
}
