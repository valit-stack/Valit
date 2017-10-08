using System;

using static Valit.Exceptions.SemanticExceptions;

namespace Valit
{
    public static class ValitExceptionExtensions
    {
        internal static void ThrowIfNull<T>(this T @object)
            where T : class
        {
            if(@object == null)
            {
                throw Null_dereferenced();
            }
        }

        internal static void ThrowIfNull<T>(this T @object, string message)
            where T: class
        {
            if(@object == null)
            {
                throw Null_dereferenced(message);
            }
        }
    }
}