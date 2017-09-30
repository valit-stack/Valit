using System;
using System.Collections.Generic;
using System.Text;

namespace Valit.Exceptions
{
    static class SemanticExceptions
    {
        public static ValitException Null_dereferenced(string message)
            => throw new ValitException(message, new ArgumentNullException());

        public static ValitException Null_dereferenced()
          => throw new ValitException("Null dereferenced", new ArgumentNullException());
    }
}
