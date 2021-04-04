using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Validation.Exceptions
{
    public class InvalidNameLengthException : ValidationException
    {
        private int _minLength;
        public override string Message => $"User name must be at least {_minLength} characters.";
        public InvalidNameLengthException(int minLength)
        {
            _minLength = minLength;
        }
    }
}
