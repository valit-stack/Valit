
namespace Valit.Strategies
{
    public class FailFastValitStrategy : IValitStrategy
    {
        public void Fail<TObject>(IValitRule<TObject> rule, IValitResult result, ref bool cancel)
           where TObject : class
        {
            cancel = true;
        }

        public void Done(IValitResult result)
        {
        }
    }
}
