using System;

namespace Valit
{
    public class ValitException : Exception
    {
		public ValitException(string message, Exception innerException)
            :base(message, innerException)
        {
        }
    }
}