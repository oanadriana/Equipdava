using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Equipdava.DB.DbContexts;
using Equipdava.Domain.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Equipdava.Application.Employees.Queries
{
    public class GetAllEmployeesQueryHandler : IRequestHandler<GetAllEmployeesQuery, IEnumerable<Employee>>
    {
        private readonly EquipdavaDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetAllEmployeesQueryHandler(EquipdavaDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Employee>> Handle(GetAllEmployeesQuery request, CancellationToken cancellationToken)
        {
            var employees = await _dbContext.Employees.ToListAsync(cancellationToken);

            return _mapper.Map<IEnumerable<Employee>>(employees);
        }
    }
}
