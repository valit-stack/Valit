using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using Valit.Errors;

namespace Valit.Result
{
    internal class ValitResult : IValitResult
    {
        public static readonly ValitResult Success = new ValitResult();

        public bool Succeeded { get; }

        public ImmutableArray<int> ErrorCodes { get; private set; }
        public ImmutableArray<string> ErrorMessages { get; }

        private ValitResult()
        {
            Succeeded = true;
            ErrorMessages = ImmutableArray<string>.Empty;
            ErrorCodes = ImmutableArray<int>.Empty;
        }

        private ValitResult(IEnumerable<ValitRuleError> errors)
        {
            Succeeded = false;

            ErrorMessages = errors
                .Where(e => !string.IsNullOrEmpty(e.Message))
                .Select(e => e.Message)
                .ToImmutableArray();

            ErrorCodes = errors
                .Where(e => e.ErrorCode.HasValue)
                .Select(e => e.ErrorCode.Value)
                .ToImmutableArray();
        }

        private ValitResult(ImmutableArray<string> errorMessages, ImmutableArray<int> errorCodes)
        {
            ErrorMessages = errorMessages;
            ErrorCodes = errorCodes;
        }

        internal static ValitResult Fail(IEnumerable<ValitRuleError> errors)
            => new ValitResult(errors);

        internal static ValitResult Fail(ImmutableArray<string> errorMessages, ImmutableArray<int> errorCodes)
            => new ValitResult(errorMessages, errorCodes);

        public static ValitResult operator &(ValitResult result1, IValitResult result2)
        {
            var succeed = result1.Succeeded && result2.Succeeded;
            var errorMessages = result1.ErrorMessages.Concat(result2.ErrorMessages).ToImmutableArray();
            var errorCodes = result1.ErrorCodes.Concat(result2.ErrorCodes).ToImmutableArray();
            return succeed ? Success : Fail(errorMessages, errorCodes);
        }
    }
}
