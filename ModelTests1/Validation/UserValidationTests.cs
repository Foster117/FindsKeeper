using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Database;
using Model.Repositories;
using Model.Database.Models;
using Model.Validation.Exceptions;
using Rhino.Mocks;

namespace Model.Validation.Tests
{
    [TestClass()]
    public class UserValidationTests
    {
        [TestMethod()]
        [ExpectedException(typeof(InvalidNameLengthException))]
        public void ValidateUserNameRegistration_IncorrectNameLength_ExpectedException()
        {
            string name = "X";
            IUserRepository userRepoMock = MockRepository.GenerateMock<IUserRepository>();
            UserValidation validation = new UserValidation(userRepoMock);
            userRepoMock.Stub(_ => _.GetUserByName(name)).Return(new User());

            validation.ValidateUserNameRegistration(name);
        }

        [TestMethod()]
        [ExpectedException(typeof(InvalidNameLengthException))]
        public void ValidateUserNameRegistration_NameIsNull_ExpectedException()
        {
            string name = null;
            IUserRepository userRepoMock = MockRepository.GenerateMock<IUserRepository>();
            UserValidation validation = new UserValidation(userRepoMock);
            userRepoMock.Stub(_ => _.GetUserByName(name)).Return(new User());

            validation.ValidateUserNameRegistration(name);
        }

        [TestMethod()]
        [ExpectedException(typeof(ExistUserException))]
        public void ValidateUserNameRegistration_NameIsExist_ExpectedException()
        {
            string name = "GoldHunter";
            IUserRepository userRepoMock = MockRepository.GenerateMock<IUserRepository>();
            UserValidation validation = new UserValidation(userRepoMock);
            userRepoMock.Stub(_ => _.GetUserByName(name)).Return(new User());

            validation.ValidateUserNameRegistration(name);
            //userRepoMock.AssertWasCalled(_ => _.GetUserByName(Arg<string>.Is.Anything), options => options.Repeat.Times(1));
        }
        ///////////////////////
        //////////////////////

        [TestMethod()]
        [ExpectedException(typeof(NonЕxistUserException))]
        public void ValidateUserNameSignIn_NameIsNotExist_ExpectedException()
        {
            string name = "GoldHunter";
            IUserRepository userRepoMock = MockRepository.GenerateMock<IUserRepository>();
            UserValidation validation = new UserValidation(userRepoMock);
            userRepoMock.Stub(_ => _.GetUserByName(name)).Return(null);

            validation.ValidateUserNameSignIn(name);
        }
    }
}