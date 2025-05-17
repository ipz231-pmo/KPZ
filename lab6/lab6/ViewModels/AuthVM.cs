using lab6.Core;
using lab6.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace lab6.ViewModels;

class AuthVM : Core.VMBase
{
	private string login = "";
	private string password = "";

	public RelayCommand AuthCmd { get; set; }
	public AuthVM()
	{
        AuthCmd = new RelayCommand(auth, canAuth);
	}

	public EventHandler<AuthEventArgs>? AuthHndl;
	public EventHandler? RegisterHndl;

	private void auth(object? param)
	{
		var db = MineSweeperDbContext.Instance;
		User? user = db.Users.FirstOrDefault(u => u.Login == Login);
		if (user == null)
		{
			Login = "";
			Password = "";
            MessageBox.Show("User with specified login are not exist");
            return;
        }
		if (user.Password != Password)
		{
			Password = "";
            MessageBox.Show("Password are incorrect");
            return;
		}
		AuthHndl?.Invoke(this, new AuthEventArgs(user));

	}
	private bool canAuth(object? param) => login.Length >= 4 && password.Length >= 8;
		

	public string Login
	{
		get => login; 
		set 
		{ 
			login = value;
			NotifyOnPropertyChanged();
		}
	}
	public string Password
	{
        get => password;
        set
        {
            password = value;
            NotifyOnPropertyChanged();
        }
    }
	
	public class AuthEventArgs : EventArgs
	{
        public User User { get; set; }
		public AuthEventArgs(User user)
        {
            User = user;
        }
    }
}
