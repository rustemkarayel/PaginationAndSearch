using EntityLayer;
using FluentValidation;

namespace PagedList_SearchBar.Validations
{
    public class EmployeeValidator : AbstractValidator<Employee>
    {
        public EmployeeValidator()
        {
            //Rule for FirstName
            RuleFor(employee => employee.FirstName).NotEmpty().WithMessage("FirstName boş bırakılamaz!");
            RuleFor(employee => employee.FirstName).MaximumLength(50).WithMessage("Maximum 50 karakter girilmelidir!");

            //Rule for LastName
            RuleFor(employee => employee.LastName).NotEmpty().WithMessage("LastName boş bırakılamaz!");
            RuleFor(employee => employee.LastName).MaximumLength(50).WithMessage("Maximum 50 karakter girilmelidir!");

            //Rule for age
            RuleFor(employee => employee.Age).NotEmpty().WithMessage("Age boş bırakılamaz!");

            //Rule for City
            RuleFor(employee => employee.City).NotEmpty().WithMessage("City boş bırakılamaz!");
            RuleFor(employee => employee.City).MaximumLength(50).WithMessage("Maximum 50 karakter girilmelidir!");

            //Rule for Wage
            RuleFor(employee => employee.Wage).NotEmpty().WithMessage("Wage boş bırakılamaz!");
        }
    }
}
