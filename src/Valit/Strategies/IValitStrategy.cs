namespace Valit.Strategies
{
    public interface IValitStrategy
    {
        void Fail<TObject>(IValitRule<TObject> rule, IValitResult result, ref bool cancel) where TObject : class;
        void Done(IValitResult result);
    }
}
