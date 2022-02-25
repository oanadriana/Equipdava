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
    public class DeleteResourceCommandHandler : IRequestHandler<DeleteResourceCommand, Unit>
    {
        private EquipdavaDbContext _dbContext;

        public DeleteResourceCommandHandler(EquipdavaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(DeleteResourceCommand request, CancellationToken cancellationToken)
        {

            //var deleteResource = _dbContext.Resources
            //    .Where(x => x.Model == request.Model && x.Brand == request.Brand &&
            //           x.ResourceTypeId == request.ResourceTypeId);

            foreach (var i in Enumerable.Range(0,request.Quantity))
            {
                var deleteResource = await _dbContext.Resources
                    .FirstOrDefaultAsync(
                        x => x.Model == request.Model && x.Brand == request.Brand &&
                             x.ResourceTypeId == request.ResourceTypeId, cancellationToken);

                _dbContext.Resources.Remove(deleteResource);

                await _dbContext.SaveChangesAsync(cancellationToken);
            }

            return new Unit();
        }
    }
}
