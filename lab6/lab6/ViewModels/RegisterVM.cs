using System;
using System.Windows;
using lab6.Core;
using lab6.Core.Services;
using lab6.Models;

namespace lab6.ViewModels
{
    public class RegisterVM : VMBase
    {
        private readonly IUserService _userService;
        private string _login = "";
        private string _password = "";
        private string _passwordConfirm = "";

        public RelayCommand RegisterCmd { get; }

        public event EventHandler<RegisterEventsArgs>? RegisterHndl;
        public event EventHandler? AuthHndl;

        public RegisterVM(IUserService userService)
        {
            _userService = userService;
            RegisterCmd = new RelayCommand(register, canRegister);
        }

        public RegisterVM()
            : this(new UserService())
        { }

        private void register(object? _)
        {
            try
            {
                var user = _userService.Register(Login, Password);
                RegisterHndl?.Invoke(this, new RegisterEventsArgs(user));
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message);
                Login = "";
                Password = "";
                PasswordConfirm = "";
            }
        }

        private bool canRegister(object? _)
            => Login.Length >= 4
               && Password.Length >= 8
               && Password == PasswordConfirm;

        public string Login
        {
            get => _login;
            set
            {
                if (_login == value) return;
                _login = value;
                NotifyOnPropertyChanged();
                RegisterCmd.RaiseCanExecuteChanged();
            }
        }

        public string Password
        {
            get => _password;
            set
            {
                if (_password == value) return;
                _password = value;
                NotifyOnPropertyChanged();
                RegisterCmd.RaiseCanExecuteChanged();
            }
        }

        public string PasswordConfirm
        {
            get => _passwordConfirm;
            set
            {
                if (_passwordConfirm == value) return;
                _passwordConfirm = value;
                NotifyOnPropertyChanged();
                RegisterCmd.RaiseCanExecuteChanged();
            }
        }

        public class RegisterEventsArgs : EventArgs
        {
            public User User { get; }

            public RegisterEventsArgs(User user) => User = user;
        }
    }
}