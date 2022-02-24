using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Equipdava.Application.Employees.Commands;
using Equipdava.Application.Extensions;
using Equipdava.DB.DbContexts;
using FluentValidation;

namespace Equipdava.Application.Employees.Validators
{
    public class CreateNewResourceForEmployeeCommandValidator : AbstractValidator<CreateNewResourceForEmployeeCommand>
    {
        private readonly EquipdavaDbContext _dbContext;

        public CreateNewResourceForEmployeeCommandValidator(EquipdavaDbContext dbContext)
        {
            _dbContext = dbContext;

            RuleFor(x => x.ResourceId)
                .Must(x => _dbContext.Resources.Any(r => r.Id == x))
                .WithMessage($"Resource does not exist!");

            RuleFor(x => x.EmployeeId)
                .Must(x => _dbContext.Employees.Any(e => e.Id == x))
                .WithMessage("Employee does not exist!");

            //RuleFor(x => Tuple.Create(x.EmployeeId, x.ResourceId))
            //    .ShouldNotAllowDuplicateResource(dbContext);

        }
    }
}
