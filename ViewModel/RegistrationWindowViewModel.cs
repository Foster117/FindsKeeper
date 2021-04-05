using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Model;
using Model.Application.Finds;
using Model.Application.Users;
using Model.Database.Models;
using Model.Repositories;
using Model.Validation;
using Model.Validation.Exceptions;

namespace ViewModel
{
    public class RegistrationWindowViewModel : INotifyPropertyChanged, IClosable
    {
        IUserRepository _userRepository = RepositoryFactory.GetRepositoryFactory().UserRepository;
        public Action CloseAction { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
        public ICommand AddUserCommand { get; set; }
        public ICommand CloseCommand { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string RepeatPassword { get; set; }
        private string _errorMessage;
        public string ErrorMessage { 
            get {
                return _errorMessage;
            }
            set {
                _errorMessage = value;
                OnPropertyChanged(nameof(ErrorMessage));
            }
        }

        // ctor
        public RegistrationWindowViewModel()
        {
            AddUserCommand = new DelegateCommand(AddUser);
            CloseCommand = new DelegateCommand(CloseWindow);
        }

        private void AddUser(object parameter)
        {
            UserValidation userValidation = new UserValidation(_userRepository);
            PasswordValidation passwordValidation = new PasswordValidation();

            try
            {
                userValidation.ValidateUserNameRegistration(UserName);
            }
            catch (ValidationException ex)
            {
                ErrorMessage = ex.Message;
                return;
            }

            try
            {
                passwordValidation.ValidatePasswordRegistration(Password, RepeatPassword);
            }
            catch (ValidationException ex)
            {
                ErrorMessage = ex.Message;
                return;
            }

            _userRepository.AddUser(new User() { Name = UserName, Password = passwordValidation.HashPassword(Password) });
            CurrentUser.Login(_userRepository.GetUserByName(UserName));
            CloseAction();
        }

        private void CloseWindow(object parameter)
        {
            CloseAction();
        }

        void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
