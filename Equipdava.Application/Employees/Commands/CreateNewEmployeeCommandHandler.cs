using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Equipdava.DB.DbContexts;
using Equipdava.Domain.Models;
using MediatR;

namespace Equipdava.Application.Employees.Commands
{
    public class CreateNewEmployeeCommandHandler : IRequestHandler<CreateNewEmployeeCommand, Employee>
    {
        private readonly EquipdavaDbContext _dbContext;
        private readonly IMapper _mapper;

        public CreateNewEmployeeCommandHandler(EquipdavaDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<Employee> Handle(CreateNewEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employee = new DB.Entities.Employee()
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                Phone = request.Phone,
                JobTitle = request.JobTitle,
                Department = request.Department,
                HireDate = DateTime.Today,
                City = request.City
            };

            await _dbContext.Employees.AddAsync(employee, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return _mapper.Map<Employee>(employee);
        }
    }
}
