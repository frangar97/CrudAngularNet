namespace Core.Features.Base
{
    public interface IUnitOfWork:IDisposable
    {
        void SaveChanges();
        void SaveChangesAsync();
    }
}
