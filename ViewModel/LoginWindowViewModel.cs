using Model;
using Model.Database.Models;
using Model.Repositories;
using Model.Validation;
using Model.Validation.Exceptions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ViewModel
{
    public class LoginWindowViewModel : INotifyPropertyChanged, IClosable
    {
        IUserRepository _userRepository = RepositoryFactory.GetRepositoryFactory().UserRepository;
        public Action CloseAction { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
        public ICommand LoginCommand { get; set; }
        public ICommand CloseCommand { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        private string _errorMessage;
        public string ErrorMessage
        {
            get { return _errorMessage; }
            set
            {
                _errorMessage = value;
                OnPropertyChanged(nameof(ErrorMessage));
            }
        }

        public LoginWindowViewModel()
        {
            LoginCommand = new DelegateCommand(Login);
            CloseCommand = new DelegateCommand(CloseWindow);
        }

        private void Login(object parameter)
        {
            ErrorMessage = null;
            User user;
            UserValidation userValidation = new UserValidation(_userRepository);
            PasswordValidation passwordValidation = new PasswordValidation();

            try
            {
                userValidation.ValidateUserNameSignIn(UserName);
            }
            catch (ValidationException ex)
            {
                ErrorMessage = ex.Message;
                return;
            }

            user = _userRepository.GetUserByName(UserName);

            try
            {
                passwordValidation.ValidatePasswordSignIn(user.Password, Password);
            }
            catch (ValidationException ex)
            {
                ErrorMessage = ex.Message;
                return;
            }

            CurrentUser.Login(user);
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
