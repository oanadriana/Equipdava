using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Equipdava.Application.Employees.Models;
using Equipdava.DB.DbContexts;
using Equipdava.Domain.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Equipdava.Application.Employees.Queries
{
    public class GetUnallocatedResourcesQueryHandler : IRequestHandler<GetUnallocatedResourcesQuery, IEnumerable<ResourceDto>>
    {
        private readonly EquipdavaDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetUnallocatedResourcesQueryHandler(EquipdavaDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ResourceDto>> Handle(GetUnallocatedResourcesQuery request, CancellationToken cancellationToken)
        {
            var resources = await _dbContext.Resources
                .Include(x => x.ResourceType)
                .Where(x => x.ResourceTypeId == request.ResourceTypeId && x.IsAllocated == false)
                .ToListAsync(cancellationToken);

            return _mapper.Map<IEnumerable<ResourceDto>>(resources);
        }
    }
}
