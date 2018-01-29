using System;

namespace Valit.Errors
{
    internal class ValitRuleError
    {
        private readonly Func<string> _messageFunc;
        public string Message => _messageFunc();
        public int? ErrorCode { get; }
        public bool IsDefault { get; }

        private ValitRuleError(Func<string> messageFunc, bool isDefault)
        {
            IsDefault = isDefault;            
            _messageFunc = messageFunc;
        }

        private ValitRuleError(int errorCode)
        {
            ErrorCode = errorCode;            
            IsDefault = false;
            _messageFunc = () => string.Empty;
        }

        public static ValitRuleError CreateForMessage(Func<string> messageFunc, bool isDefault = false)
            => new ValitRuleError(messageFunc, isDefault);

        public static ValitRuleError CreateForErrorCode(int errorCode)
            => new ValitRuleError(errorCode);
    }
}
