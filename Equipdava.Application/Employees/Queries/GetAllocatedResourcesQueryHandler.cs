using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Equipdava.Application.Employees.Models;
using Equipdava.DB.DbContexts;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Equipdava.Application.Employees.Queries
{
    public class GetAllocatedResourcesQueryHandler : IRequestHandler<GetAllocatedResourcesQuery, IEnumerable<AllocatedResource>>
    {
        private readonly EquipdavaDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetAllocatedResourcesQueryHandler(EquipdavaDbContext dbContext, IMapper mapper)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<AllocatedResource>> Handle(GetAllocatedResourcesQuery request, CancellationToken cancellationToken)
        {
            var allocatedResources = await _dbContext.EmployeesResources
                .Include(x => x.Employee)
                .Include(y => y.Resource)
                .ThenInclude(z => z.ResourceType)
                .ToListAsync(cancellationToken);
            
            return _mapper.Map<IEnumerable<AllocatedResource>>(allocatedResources);
        }
    }
}
