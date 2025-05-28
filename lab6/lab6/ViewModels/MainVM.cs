using lab6.Core;
using lab6.Core.Services;
using lab6.Models;
using System;

namespace lab6.ViewModels
{
    public class MainVM : VMBase
    {
        private object _currentVM;
        private User? _currentUser;

        public MainVM()
        {
            SetAuthVM();
        }

        private void SetAuthVM()
        {
            // Тепер передаємо і UserService, і MessageService
            var vm = new AuthVM(new UserService(), new MessageService());
            vm.AuthHndl += (sender, e) =>
            {
                _currentUser = e.User;
                SetMenuVM();
            };
            vm.RegisterHndl += (sender, e) =>
            {
                SetRegisterVM();
            };
            CurrentVM = vm;
        }

        private void SetRegisterVM()
        {
            var vm = new RegisterVM(new UserService(), new MessageService());
            vm.RegisterHndl += (sender, e) =>
            {
                _currentUser = e.User;
                SetMenuVM();
            };
            vm.AuthHndl += (sender, e) =>
            {
                SetAuthVM();
            };
            CurrentVM = vm;
        }

        private void SetMenuVM()
        {
            var vm = new MenuVM();
            vm.LogoutHndl += (sender, e) =>
            {
                _currentUser = null;
                SetAuthVM();
            };
            vm.ExitHndl += (sender, e) => { App.Current.MainWindow.Close(); };
            vm.StartHndl += (sender, e) => SetGameVM();
            CurrentVM = vm;
        }

        private void SetGameVM()
        {
            var vm = new GameVM();
            vm.EndHndl += (sender, e) => { SetMenuVM(); };
            CurrentVM = vm;
        }

        public object CurrentVM
        {
            get => _currentVM;
            set
            {
                _currentVM = value;
                NotifyOnPropertyChanged();
            }
        }
    }
}
