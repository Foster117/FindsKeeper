using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Validation.Exceptions
{
    public class InvalidPasswordLengthException : ValidationException
    {
        int _minLength;
        public override string Message => $"Password must be at least {_minLength} characters.";
        public InvalidPasswordLengthException(int minLength)
        {
            _minLength = minLength;
        }
    }
}
