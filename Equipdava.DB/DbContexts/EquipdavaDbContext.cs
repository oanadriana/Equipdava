using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Equipdava.DB.Entities;
using Microsoft.EntityFrameworkCore;

namespace Equipdava.DB.DbContexts
{
    public class EquipdavaDbContext : DbContext
    {
        public EquipdavaDbContext(DbContextOptions<EquipdavaDbContext> options) : base(options)
        {
        }
        
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeResource> EmployeesResources { get; set; }
        public DbSet<Resource> Resources { get; set; }
        public DbSet<ResourceType> ResourceTypes { get; set; }
    }
}
