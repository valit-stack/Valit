namespace Valit.Result
{
    internal class ValitResult : IValitResult
    {
        public bool Succeeded { get; private set; }

        public string[] Errors { get; private set; }

        private ValitResult(bool succeeded)
        {
            Succeeded = succeeded;
        }

        private ValitResult(bool succeeded, string[] errors) : this(succeeded)
        {
            Errors = errors;
        }

        internal static IValitResult CreateSucceeded()
            => new ValitResult(true);

        internal static IValitResult CreateFailed(string[] errors)
            => new ValitResult(false, errors);
    }
}
