using System.Collections.Immutable;

namespace Valit
{
    public interface IValitResult
    {
        bool Succeeded { get; }

        ImmutableArray<string> ErrorMessages { get; }

        ImmutableArray<int> ErrorCodes { get; }
    }
}
