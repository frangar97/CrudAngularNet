using Core.Features.Base;

namespace Core.Features.Employee
{
    public class EmployeeEntity:BaseEntity
    {
        public String Name { get; set; }
        public String LastName { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
