using Core.Features.Employee;
using Core.Features.Employee.DTO;
using Core.Features.Employee.Service;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService employeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }

        [HttpGet]
        public IActionResult GetEmployees()
        {
            var employees = employeeService.GetAll();
            var employeesDTO = employees.Select(x => new EmployeeDTO { Id=x.Id,Name=x.Name,LastName=x.LastName,CreatedDate=x.CreatedDate}).ToList();
            return Ok(employeesDTO);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployee(int id)
        {
            var employeeEntity = await employeeService.GetEmployeeById(id);

            if(employeeEntity  == null)
            {
                return NotFound();
            }

            var employeeDTO = new EmployeeDTO { Id = employeeEntity.Id, Name = employeeEntity.Name, LastName = employeeEntity.LastName, CreatedDate = employeeEntity.CreatedDate };
            return Ok(employeeDTO);

        }

        [HttpPost]
        public async Task<IActionResult> CreateEmployee([FromBody] CreateEmployeeDTO createEmployeeDTO)
        {
            var employeeEntity = new EmployeeEntity { Name= createEmployeeDTO.Name,LastName= createEmployeeDTO.LastName,CreatedDate=DateTime.Now };
            await employeeService.CreateEmployee(employeeEntity);
            var employeeDTO = new EmployeeDTO { Id=employeeEntity.Id,Name=employeeEntity.Name,LastName=employeeEntity.LastName,CreatedDate=employeeEntity.CreatedDate};
            return Ok(employeeDTO);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmployee(int id,[FromBody] CreateEmployeeDTO createEmployeeDTO)
        {
            var employeeEntity = new EmployeeEntity { Name = createEmployeeDTO.Name, LastName = createEmployeeDTO.LastName };
            await employeeService.UpdateEmployee(id, employeeEntity);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            await employeeService.DeleteEmployee(id);
            return Ok();
        }
    }
}
