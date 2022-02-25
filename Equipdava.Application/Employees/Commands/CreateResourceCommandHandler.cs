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

namespace Equipdava.Application.Employees.Commands
{
    public class CreateResourceCommandHandler : IRequestHandler<CreateResourceCommand, IEnumerable<Resource>>
    {
        private readonly EquipdavaDbContext _dbContext;
        private readonly IMapper _mapper;

        public CreateResourceCommandHandler(EquipdavaDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext; 
            _mapper = mapper;
        }
        
        public async Task<IEnumerable<Resource>> Handle(CreateResourceCommand request, CancellationToken cancellationToken)
        {
            var numberOfNewResources = request.Quantity;

            var resourceList = new List<Resource>();

            var resourceTypeString = ((ResourceTypeCategory) request.ResourceTypeId).ToString();

            foreach (var i in Enumerable.Range(0, numberOfNewResources))
            {
                var resource = new DB.Entities.Resource()
                {
                    IsAllocated = false,
                    Model = request.Model,
                    Brand = request.Brand,
                    ResourceTypeId = request.ResourceTypeId,
                };

                await _dbContext.Resources.AddAsync(resource, cancellationToken);

                await _dbContext.SaveChangesAsync(cancellationToken);

                ////resource.ResourceType.Name = resourceTypeString;
                ////await _dbContext.SaveChangesAsync(cancellationToken);

                //var resourceType = resource.ResourceType;
                //resourceType.Name = resourceTypeString;

                await _dbContext.SaveChangesAsync(cancellationToken);

                resourceList.Add(_mapper.Map<Resource>(resource));
            }

            return _mapper.Map<IEnumerable<Resource>>(resourceList);
        }
    }
}
