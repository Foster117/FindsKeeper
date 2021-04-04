using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Validation.Exceptions
{
    public class NonЕxistUserException : ValidationException
    {
        private string _name;
        public override string Message => $"User \"{_name}\" is not registered.";
        public NonЕxistUserException(string name)
        {
            _name = name;
        }
    }
}
