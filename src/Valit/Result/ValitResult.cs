using System.Linq;

namespace Valit
{
    public class ValitResult
    {
        public bool Succeeded { get; private set; }

        public string[] Errors { get; private set; }

        private ValitResult()
        {
            Succeeded = true;
            Errors = Enumerable.Empty<string>().ToArray();
        }

        private ValitResult(string[] errors)
        {
            Succeeded = false;
            Errors = errors;
        }

        internal static ValitResult CreateSucceeded()
            => new ValitResult();

        internal static ValitResult CreateFailed(string[] errors)
            => new ValitResult( errors);


        public static ValitResult operator &(ValitResult result1, ValitResult result2)
        {
            var succeed = result1.Succeeded && result2.Succeeded;
            var errors = result1.Errors.Concat(result2.Errors).ToArray();
            return succeed? ValitResult.CreateSucceeded() : ValitResult.CreateFailed(errors);
        }
    }
}
