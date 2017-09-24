namespace Valit
{
    public interface IValitResult
    {
         bool Succeeded { get; }

         string[] Errors { get; }
    }
}