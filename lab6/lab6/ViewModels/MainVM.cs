using lab6.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace lab6.ViewModels;

class MainVM : Core.VMBase
{
	private object currentVM;
	private User? currentUser;

	public MainVM()
	{
		setAuthVM();
	}
	private void setAuthVM()
	{
        var vm = new AuthVM();
        vm.AuthHndl += (sender, e) => {
            currentUser = e.User;
            setMenuVM();
        };
        CurrentVM = vm;
    }
	private void setMenuVM()
	{
		var vm = new MenuVM();
		vm.LogoutHndl += (sender, e) =>
		{
			currentUser = null;
			setAuthVM();
		};
		CurrentVM = vm;
	}


    public object CurrentVM
    {
        get => currentVM;
        set
        {
            currentVM = value;
            NotifyOnPropertyChanged();
        }
    }
}
