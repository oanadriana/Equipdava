using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Equipdava.DB.DbContexts;
using Equipdava.Domain.Models;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Equipdava.Application.Employees.Commands
{
    public class CreateNewResourceForEmployeeCommandHandler : IRequestHandler<CreateNewResourceForEmployeeCommand, EmployeeResource>
    {
        private readonly EquipdavaDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IValidator<CreateNewResourceForEmployeeCommand> _validator;

        public CreateNewResourceForEmployeeCommandHandler(EquipdavaDbContext dbContext, IMapper mapper, IValidator<CreateNewResourceForEmployeeCommand> validator)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _validator = validator;
        }

        public async Task<EmployeeResource> Handle(CreateNewResourceForEmployeeCommand request,
            CancellationToken cancellationToken)
        {
            await _validator.ValidateAndThrowAsync(request, cancellationToken);

            var allocatedResource = _dbContext.Resources.Single(x => x.Id == request.ResourceId);

            var employeeResource = new Equipdava.DB.Entities.EmployeeResource()
            {
                EmployeeId = request.EmployeeId,
                ResourceId = request.ResourceId,
                AllocatedOn = DateTime.Today
            };

            allocatedResource.IsAllocated = true;

            await _dbContext.AddAsync(employeeResource, cancellationToken);

            await _dbContext.SaveChangesAsync(cancellationToken);

            return _mapper.Map<EmployeeResource>(employeeResource);
        }

        //private Task<Equipdava.DB.Entities.Resource> GetResourceFromDbTask(int resourceId)
        //{
        //    var dbContextForTask = GetDbContextInstanceForTask();

        //    return dbContextForTask.Resources.SingleOrDefault(x => x.Id == resourceId);
        //}

        //private EquipdavaDbContext GetDbContextInstanceForTask()
        //{
        //    var scope = _serviceScopeFactory.CreateScope();
        //    return scope.ServiceProvider.GetRequiredService<EquipdavaDbContext>();
        //}
    }
}
