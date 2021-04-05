using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Validation.Exceptions
{
    public class InvalidPasswordException : ValidationException
    {
        public override string Message => "Invalid password.";
    }
}
