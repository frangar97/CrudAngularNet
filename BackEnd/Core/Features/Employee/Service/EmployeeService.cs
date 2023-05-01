using Core.Features.Base;

namespace Core.Features.Employee.Service
{
    public class EmployeeService:IEmployeeService
    {
        private readonly IUnitOfWork unitOfWork;
        public EmployeeService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task CreateEmployee(EmployeeEntity entity)
        {
            await unitOfWork.EmployeeRepository.AddAsync(entity);
            await unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteEmployee(int id)
        {
            await unitOfWork.EmployeeRepository.DeleteAsync(id);
            await unitOfWork.SaveChangesAsync();
        }

        public IEnumerable<EmployeeEntity> GetAll()
        {
            return unitOfWork.EmployeeRepository.GetAll();
        }

        public async Task<EmployeeEntity?> GetEmployeeById(int id)
        {
            return await unitOfWork.EmployeeRepository.FindAsync(id);
        }

        public async Task UpdateEmployee(int id, EmployeeEntity employee)
        {
            EmployeeEntity? employeeEntity = await unitOfWork.EmployeeRepository.FindAsync(id);
            if (employeeEntity != null)
            {
                employeeEntity.Name = employee.Name;
                employeeEntity.LastName = employee.LastName;

                unitOfWork.EmployeeRepository.Update(employeeEntity);
                await unitOfWork.SaveChangesAsync();
            }
        }
    }
}
