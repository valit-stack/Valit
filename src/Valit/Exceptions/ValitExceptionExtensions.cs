using System;

using static Valit.Exceptions.SemanticExceptions;

namespace Valit
{
    public static class ValitExceptionExtensions
    {
        internal static T ThrowIfNull<T>(this T @object)
            where T : class
        {
            if(@object == null)
            {
                throw NullDereferenced();
            }

            return @object;
        }

        internal static T ThrowIfNull<T>(this T @object, string message)
            where T: class
        {
            if(@object == null)
            {
                throw NullDereferenced(message);
            }

            return @object;
        }
    }
}