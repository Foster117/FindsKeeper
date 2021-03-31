using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ViewModel
{
    public class AuthenticationViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private bool _isRegBtnsVisible;
        private bool _isLogoutBtnsVisible;
        private string _userName;
        private readonly IDialogService dialogService;
        public ICommand OpenRegWindowCommand { get; set; }
        public ICommand OpenLoginWindowCommand { get; set; }
        public ICommand LogoutCommand { get; set; }
        public string UserName { get { return _userName; }
            set 
            {
                _userName = value;
                OnPropertyChanged(nameof(UserName));
            }
        }
        public bool IsRegBtnsVisible {
            get { return _isRegBtnsVisible; }
            set 
            {
                _isRegBtnsVisible = value;
                OnPropertyChanged(nameof(IsRegBtnsVisible));
            }
        }
        public bool IsLogoutBtnsVisible {
            get { return _isLogoutBtnsVisible; }
            set
            {
                _isLogoutBtnsVisible = value;
                OnPropertyChanged(nameof(IsLogoutBtnsVisible));
            }
        }

        public AuthenticationViewModel(IDialogService dialogService)
        {
            CurrentUser.UserStateNotify += UserStateHandler;
            this.dialogService = dialogService;
            IsRegBtnsVisible = true;
            IsLogoutBtnsVisible = false;
            OpenRegWindowCommand = new DelegateCommand(OpenRegWindow);
            OpenLoginWindowCommand = new DelegateCommand(OpenLoginWindow);
            LogoutCommand = new DelegateCommand(Logout);
        }

        private void UserStateHandler(string state)
        {
            if (state == "Logged")
            {
                IsRegBtnsVisible = false;
                IsLogoutBtnsVisible = true;
                UserName = CurrentUser.GetUserName();
                return;
            }
            if (state == "LoggedOut")
            {
                IsLogoutBtnsVisible = false;
                IsRegBtnsVisible = true;
                UserName = null;
            }
        }
        private void OpenRegWindow(object obj)
        {
            dialogService.OpenWindow(new RegistrationWindowViewModel());
        }
        private void OpenLoginWindow(object obj)
        {
            dialogService.OpenWindow(new LoginWindowViewModel());
        }
        private void Logout(object obj)
        {
            CurrentUser.Logout();
        }
        void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
