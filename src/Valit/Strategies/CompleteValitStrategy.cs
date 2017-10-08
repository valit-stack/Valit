namespace Valit.Strategies
{
    public class CompleteValitStrategy : IValitStrategy
    {
        public void Fail<TObject>(IValitRule<TObject> rule, IValitResult result, ref bool cancel) 
            where TObject : class
        {
        }

        public void Done(IValitResult result)
        {
        }
    }
}
