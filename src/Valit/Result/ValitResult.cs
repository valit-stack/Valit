using System.Collections.Generic;
using System.Linq;

namespace Valit
{
    internal class ValitResult : IValitResult
    {
        public bool Succeeded { get; private set; }

        public string[] ErrorMessages { get; private set; }

        public int[] ErrorCodes { get; private set; }

        private ValitResult()
        {
            Succeeded = true;
            ErrorMessages = Enumerable.Empty<string>().ToArray();
            ErrorCodes = Enumerable.Empty<int>().ToArray();
        }

        private ValitResult(IEnumerable<ValitRuleError> errors)
        {
            Succeeded = false;

            ErrorMessages = errors
                .Where(e => e.Message != null)
                .Select(e => e.Message)
                .ToArray();

            ErrorCodes = errors
                .Where(e => e.ErrorCode.HasValue)
                .Select(e => e.ErrorCode.Value)
                .ToArray();
        }

        private ValitResult(string[] errorMessages, int[] errorCodes)
        {
            ErrorMessages = errorMessages;
            ErrorCodes = errorCodes;
        }

        internal static ValitResult CreateSucceeded()
            => new ValitResult();

        internal static ValitResult CreateFailed(IEnumerable<ValitRuleError> errors)
            => new ValitResult(errors);

        internal static ValitResult CreateFailed(string[] errorMessages, int[] errorCodes)
            => new ValitResult(errorMessages, errorCodes);

        public static ValitResult operator &(ValitResult result1, IValitResult result2)
        {
            var succeed = result1.Succeeded && result2.Succeeded;
            var errorMessages = result1.ErrorMessages.Concat(result2.ErrorMessages).ToArray();
            var errorCodes = result1.ErrorCodes.Concat(result2.ErrorCodes).ToArray();
            return succeed? ValitResult.CreateSucceeded() : ValitResult.CreateFailed(errorMessages, errorCodes);
        }
    }
}
