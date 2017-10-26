using System;
using System.Runtime.Serialization;

namespace Valit
{
    public class ValitException : Exception
    {
        public ValitException()
        {
        }

		public ValitException(string message)
            :base(message)
        {            
        }

		public ValitException(string message, Exception innerException)
            :base(message, innerException)
        {
        }

		protected ValitException(SerializationInfo info, StreamingContext context)
            :base(info, context)
        {            
        }
    }
}