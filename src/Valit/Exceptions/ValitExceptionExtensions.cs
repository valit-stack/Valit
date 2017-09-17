namespace Valit
{
    public static class ValitExceptionExtensions
    {
        internal static void ThrowIfNull(this object @object)
        {
            if(@object == default(object))
            {
                throw new ValitException();
            }
        }

        internal static void ThrowIfNull(this object @object, string message)
        {
            if(@object == default(object))
            {
                throw new ValitException(message);
            }
        }
    }
}