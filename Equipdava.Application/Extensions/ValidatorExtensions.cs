using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Equipdava.DB.DbContexts;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Equipdava.Application.Extensions
{
    public static class ValidatorExtensions
    {
        public static IRuleBuilderOptions<T, Tuple<int, int>> ShouldNotAllowDuplicateResource<T>(
            this IRuleBuilder<T, Tuple<int, int>> ruleBuilder, EquipdavaDbContext dbContext)
        {
            return ruleBuilder.Must(x => dbContext.EmployeesResources
                    .Where(y => y.EmployeeId == x.Item1 && y.ResourceId == x.Item2)
                    .Include(y => y.Resource)
                    .Count().Equals(1))
                .WithMessage("Cannot add duplicate resource!");
        }
    }
}
