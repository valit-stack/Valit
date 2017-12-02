namespace Valit
{
    public interface IValitator<in TObject> where TObject : class
    {
        IValitResult Validate(TObject @object, IValitStrategy strategy = null);
    }
}
