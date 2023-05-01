using Core.Features.Employee.DTO;
using FluentValidation;

namespace Infrastructure.Validators
{
    public class EmployeeValidator:AbstractValidator<CreateEmployeeDTO>
    {
        public EmployeeValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .MaximumLength(50);

            RuleFor(x => x.LastName)
                .NotEmpty()
                .MaximumLength(50);
        }
    }
}
