namespace Valit
{
    public interface IValitResult
    {
         bool Succeeded { get; }

         string[] ErrorMessages { get; }

         int[] ErrorCodes { get; }
    }
}