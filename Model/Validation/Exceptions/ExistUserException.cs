using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Validation.Exceptions
{
    public class ExistUserException : ValidationException
    {
        private string _name;
        public override string Message => $"Name \"{_name}\" is already taken.";
        public ExistUserException(string name)
        {
            _name = name;
        }
    }
}
