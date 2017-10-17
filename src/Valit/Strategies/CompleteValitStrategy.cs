namespace Valit.Strategies
{
    public class CompleteValitStrategy : IValitStrategy
    {
        public void Fail<TObject>(IValitRule<TObject> rule, IValitResult result, out bool cancel) 
            where TObject : class
        {
            cancel = false;
        }

        public void Done(IValitResult result)
        {
        }
    }
}
