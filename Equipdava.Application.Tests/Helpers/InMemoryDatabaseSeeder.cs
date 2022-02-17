using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Equipdava.DB.DbContexts;

namespace Equipdava.Application.Tests.Helpers
{
    public static class InMemoryDatabaseSeeder
    {
        public static void SeedEmployees(this EquipdavaDbContext dbContext)
        {
            var today = DateTime.Today;

            dbContext.Employees.Add(new DB.Entities.Employee
            {
                FirstName = "Gigel",
                LastName = "Frone",
                Email = "gigel.frone@yahoo.co.uk",
                Phone = "0463724850",
                JobTitle = "Singer",
                Department = "Arts",
                HireDate = today,
                City = "Onesti"
            });

            dbContext.SaveChanges();
        }
    }
}
