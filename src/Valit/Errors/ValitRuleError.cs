namespace Valit
{
    internal class ValitRuleError
    {
        public string Message  { get; private set; }
        public int? ErrorCode { get; private set; }

        private ValitRuleError(string message)
        {
            Message = message;
        }

        private ValitRuleError(int errorCode)
        {
            ErrorCode = errorCode;
        }

        public static ValitRuleError CreateForMessage(string message)
            => new ValitRuleError(message);

        public static ValitRuleError CreateForErrorCode(int errorCode)
            => new ValitRuleError(errorCode);   
    }
}