using Core.Features.Employee;

namespace Core.Features.Base
{
    public interface IUnitOfWork:IDisposable
    {
        IRepository<EmployeeEntity> EmployeeRepository { get; }
        void SaveChanges();
        void SaveChangesAsync();
    }
}
