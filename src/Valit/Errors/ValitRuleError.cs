using System;

namespace Valit.Errors
{
    internal class ValitRuleError
    {
        private readonly Func<string> _messageFunc;
        public string Message => _messageFunc();
        public int? ErrorCode { get; }

        private ValitRuleError(Func<string> messageFunc)
        {
            _messageFunc = messageFunc;
        }

        private ValitRuleError(int errorCode)
        {
            ErrorCode = errorCode;
            _messageFunc = () => null;
        }

        public static ValitRuleError CreateForMessage(Func<string> messageFunc)
            => new ValitRuleError(messageFunc);

        public static ValitRuleError CreateForErrorCode(int errorCode)
            => new ValitRuleError(errorCode);   
    }
}