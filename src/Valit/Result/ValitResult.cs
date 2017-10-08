using System;
using System.Linq;

using static Valit.Exceptions.SemanticExceptions;

namespace Valit
{
    internal class ValitResult : IValitResult
    {
        public static readonly ValitResult Success = new ValitResult();
        public static readonly ValitResult Failed = new ValitResult(false, Array.Empty<string>());

        public bool Succeded { get; }

        public string[] Errors { get; }

        private ValitResult()
        {
            Succeded = true;
            Errors = Array.Empty<string>();
        }

        private ValitResult(bool succeded, string[] errors)
        {
            Succeded = succeded; 
            Errors = errors;
        }

        internal static ValitResult Fail(string[] errors)
            => new ValitResult(false, errors);
       
        public static ValitResult operator &(ValitResult result1, IValitResult result2)
        {
            var succeed = result1.Succeded && result2.Succeded;
            var errors = result1.Errors.Concat(result2.Errors).ToArray();
            return succeed ? Success : Fail(errors);
        }
    }
}
