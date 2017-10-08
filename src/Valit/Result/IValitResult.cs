namespace Valit
{
    public interface IValitResult
    {
         bool Succeded { get; }

         string[] Errors { get; }
    }
}