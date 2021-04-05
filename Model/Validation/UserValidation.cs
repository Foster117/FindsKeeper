using Model.Database;
using Model.Database.Models;
using Model.Repositories;
using Model.Validation.Exceptions;
using System;

namespace Model.Validation
{
    public class UserValidation
    {
        IUserRepository _userRepository;

        //ctor
        public UserValidation(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void ValidateUserNameRegistration(string name)
        {
            ValidateUserNameLength(name);
            CheckForUnusedName(name);
        }

        public void ValidateUserNameSignIn(string name)
        {
            ValidateUserNameLength(name);
            CheckForUserExistence(name);
        }

        ///////////////
        private void ValidateUserNameLength(string name)
        {
            int minLength = 2;
            if (String.IsNullOrEmpty(name) || name.Length < minLength)
            {
                throw new InvalidNameLengthException(minLength);
            }
        }

        private void CheckForUnusedName(string name)
        {
            User user = _userRepository.GetUserByName(name);
            if (user != null)
            {
                throw new ExistUserException(name);
            }
        }

        private void CheckForUserExistence(string name)
        {
            User user = _userRepository.GetUserByName(name);
            if (user == null)
            {
                throw new NonЕxistUserException(name);
            }
        }
    }
}
