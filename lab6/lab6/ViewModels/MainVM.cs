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
		vm.RegisterHndl += (sender, e) =>
		{
            setRegisterVM();
		};
        CurrentVM = vm;
    }

    private void setRegisterVM()
    {
        var vm = new RegisterVM();
        vm.RegisterHndl += (sender, e) => {
            currentUser = e.User;
            setMenuVM();
        };
        vm.AuthHndl += (sender, e) => {
            setAuthVM();
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
        vm.ExitHndl += (sender, e) => { App.Current.MainWindow.Close(); };
        vm.StartHndl += (sender, e) => setGameVM();
		CurrentVM = vm;
	}
    private void setGameVM()
    {
        var vm = new GameVM();
        vm.EndHndl += (sender, e) => { setMenuVM(); };
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
