using Core.Features.Base;
using Core.Features.Employee;
using Persistence;

namespace Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BackEndContext _context;
        private IRepository<EmployeeEntity> employeeRepository;

        public UnitOfWork(BackEndContext context)
        {
            _context = context;
        }

        public IRepository<EmployeeEntity> EmployeeRepository
        {
            get 
            {
                if (employeeRepository == null)
                {
                    employeeRepository = new BaseRepository<EmployeeEntity>(_context);
                }

                return employeeRepository;
            }
        }

        public void Dispose()
        {
            if(_context != null)
            {
                _context.Dispose();
            }
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
           await _context.SaveChangesAsync();
        }
    }
}
