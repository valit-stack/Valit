using System;

namespace Valit.Errors
{
    internal class ValitRuleError
    {
        private readonly Func<string> _message;
        public string Message => _message();
        public int? ErrorCode { get; }

        private ValitRuleError(Func<string> message)
        {
            _message = message;
        }

        private ValitRuleError(int errorCode)
        {
            ErrorCode = errorCode;
            _message = () => null;
        }

        public static ValitRuleError CreateForMessage(Func<string> message)
            => new ValitRuleError(message);

        public static ValitRuleError CreateForErrorCode(int errorCode)
            => new ValitRuleError(errorCode);   
    }
}