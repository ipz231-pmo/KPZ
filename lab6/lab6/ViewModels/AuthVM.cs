using System;
using System.Linq;
using lab6.Core;
using lab6.Core.Services;
using lab6.Models;

namespace lab6.ViewModels
{
    public class AuthVM : VMBase
    {
        private readonly IUserService _userService;
        private readonly IMessageService _messageService;
        private string _login = string.Empty;
        private string _password = string.Empty;

        public RelayCommand AuthCmd { get; }

        public AuthVM(IUserService userService, IMessageService messageService)
        {
            _userService = userService;
            _messageService = messageService;
            AuthCmd = new RelayCommand(auth, canAuth);
        }

        public AuthVM()
            : this(new UserService(), new MessageService())
        { }

        public event EventHandler<AuthEventArgs>? AuthHndl;
        public event EventHandler? RegisterHndl;

        private void auth(object? _)
        {
            var user = _userService.Authenticate(Login, Password);
            if (user == null)
            {
                _messageService.Show("Login or password are incorrect");
                Login = string.Empty;
                Password = string.Empty;
                return;
            }
            AuthHndl?.Invoke(this, new AuthEventArgs(user));
        }

        private bool canAuth(object? _) =>
            Login.Length >= 4 && Password.Length >= 8;

        public string Login
        {
            get => _login;
            set
            {
                if (_login == value) return;
                _login = value;
                NotifyOnPropertyChanged();
                AuthCmd.RaiseCanExecuteChanged();
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
                AuthCmd.RaiseCanExecuteChanged();
            }
        }

        public class AuthEventArgs : EventArgs
        {
            public User User { get; }
            public AuthEventArgs(User user) => User = user;
        }
    }
}