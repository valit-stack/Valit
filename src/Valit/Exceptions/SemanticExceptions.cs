using System;
using System.Collections.Generic;
using System.Text;

namespace Valit.Exceptions
{
    internal static class SemanticExceptions
    {
        public static ValitException NullDereferenced(string message)
            => new ValitException(message, new ArgumentNullException());

        public static ValitException NullDereferenced()
            => new ValitException(ValitExceptionMessages.NullDereferenced, new ArgumentNullException());

        public static ValitException MissingRuleAccessor()
            => new ValitException(ValitExceptionMessages.MissingRuleAccessor);

        public static ValitException IncorrectPathExpression()
           => new ValitException(ValitExceptionMessages.IncorrectPathExpression);
    }
}
