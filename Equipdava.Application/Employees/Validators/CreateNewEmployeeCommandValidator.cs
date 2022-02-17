using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Equipdava.Application.Employees.Commands;
using Equipdava.DB.DbContexts;
using FluentValidation;

namespace Equipdava.Application.Employees.Validators
{
    public class CreateNewEmployeeCommandValidator : AbstractValidator<CreateNewEmployeeCommand>
    {
        public CreateNewEmployeeCommandValidator(EquipdavaDbContext dbContext)
        {
            RuleFor(x => x.FirstName)
                .NotEmpty()
                .WithMessage("Employee {{FirstName}} should not be empty");

            RuleFor(x => x.LastName)
                .NotEmpty()
                .WithMessage("Employee {{LastName}} should not be empty");

            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage("Employee {{Email}} should not be empty");

            RuleFor(x => x.Phone)
                .NotEmpty()
                .WithMessage("Employee {{Phone}} should not be empty")
                .Matches("^[0-9]*$")
                .WithMessage("Employee {{Phone}} is invalid!");

            RuleFor(x => x.JobTitle)
                .NotEmpty()
                .WithMessage("Employee {{JobTitle}} should not be empty");

            RuleFor(x => x.Department)
                .NotEmpty()
                .WithMessage("Employee {{Department}} should not be empty");

            RuleFor(x => x.City)
                .NotEmpty()
                .WithMessage("Employee {{City}} should not be empty");
        }
    }
}
