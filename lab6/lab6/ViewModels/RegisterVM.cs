using lab6.Core;
using lab6.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace lab6.ViewModels;

class RegisterVM : VMBase
{
	private string login = "";
	private string password = "";
	private string passwordConfirm = "";

	public RelayCommand RegisterCmd { get; set; }

	public EventHandler<RegisterEventsArgs>? RegisterHndl { get; set; }
	public EventHandler? AuthHndl { get; set; }

	public RegisterVM()
	{
		RegisterCmd = new(register, canRegister);
	}


	private void register(object? param)
	{
		var db = MineSweeperDbContext.Instance;
		User? user = db.Users.FirstOrDefault(u => u.Login == Login);
		if (user != null)
		{
			Login = "";
			Password = "";
			PasswordConfirm = "";
			MessageBox.Show("User login are taken");
			return;
        }
		user = new User() { Login = Login, Password = Password };
		db.Users.Add(user);
		db.SaveChanges();
		RegisterHndl?.Invoke(this, new RegisterEventsArgs(user));
	}
	private bool canRegister(object? param)
	{
		return Login.Length >= 4 && Password.Length >= 8 && Password == PasswordConfirm;
	}

    public string Login
	{
		get => login; 
		set { login = value; NotifyOnPropertyChanged(); }
	}
	public string Password
	{
		get { return password; }
		set { password = value; NotifyOnPropertyChanged(); }
	}
	public string PasswordConfirm
	{
		get { return passwordConfirm; }
		set { passwordConfirm = value; NotifyOnPropertyChanged(); }
	}

	public class RegisterEventsArgs : EventArgs
	{
        public User User { get; set; }
		public RegisterEventsArgs(User user)
		{
			User = user;
		}
    }

}
