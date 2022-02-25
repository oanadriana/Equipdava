using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Equipdava.DB.DbContexts;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Equipdava.Application.Employees.Commands
{
    public class DeleteResourceFromEmployeeCommandHandler : IRequestHandler<DeleteResourceFromEmployeeCommand, Unit>
    {
        private readonly EquipdavaDbContext _dbContext;

        public DeleteResourceFromEmployeeCommandHandler(EquipdavaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(DeleteResourceFromEmployeeCommand request, CancellationToken cancellationToken)
        {
            var deleteResource = await _dbContext.EmployeesResources
                .SingleOrDefaultAsync(r => r.ResourceId == request.ResourceId, cancellationToken);

            _dbContext.EmployeesResources.Remove(deleteResource);

            var allocatedResource = await _dbContext.Resources.SingleOrDefaultAsync(x => x.Id == request.ResourceId, cancellationToken);

            allocatedResource.IsAllocated = false;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return new Unit();
        }
    }
}
