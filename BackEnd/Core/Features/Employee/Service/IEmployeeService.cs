namespace Core.Features.Employee.Service
{
    public interface IEmployeeService
    {
        IEnumerable<EmployeeEntity> GetAll();
        Task CreateEmployee(EmployeeEntity entity);
        Task DeleteEmployee(int id);
        Task UpdateEmployee(int id, EmployeeEntity employee);
        Task<EmployeeEntity?> GetEmployeeById(int id);
    }
}
