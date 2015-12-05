using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WitchHunter.Exceptions
{
    class InvalidObjectParameterException : ArgumentOutOfRangeException
    {
        public InvalidObjectParameterException(string paramName, string message)
            : base(paramName, message)
        {
        }

    }
}
