using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Equipdava.Application.Employees.Commands;
using Microsoft.EntityFrameworkCore;
using Equipdava.Application.Employees.Validators;
using Equipdava.Application.Tests.Helpers;
using Equipdava.DB.DbContexts;
using Xunit;

namespace Equipdava.Application.Tests.Employees.Validators
{
    public class CreateNewEmployeeCommandValidatorTests
    {
        private readonly CreateNewEmployeeCommandValidator _sut;
        private readonly EquipdavaDbContext _dbContext;

        public CreateNewEmployeeCommandValidatorTests()
        {
            var options = new DbContextOptionsBuilder<EquipdavaDbContext>()
                .UseInMemoryDatabase(databaseName: "EquipdavaCreateEmployeeValidatorForTest")
                .Options;

            _dbContext = new EquipdavaDbContext(options);

            _dbContext.SeedEmployees();

            _sut = new CreateNewEmployeeCommandValidator(_dbContext);
        }

        [Fact]
        public async Task ShouldNotAllowEmptyFirstNames()
        {
            var today = DateTime.Today;

            var result = await _sut.ValidateAsync(new CreateNewEmployeeCommand
            {
                FirstName = "",
                LastName = "Frone",
                Email = "gigel.frone@yahoo.co.uk",
                Phone = "0463724850",
                JobTitle = "Singer",
                Department = "Arts",
                HireDate = today,
                City = "Onesti"
            });

            Assert.Contains(result.Errors, e => e.ErrorMessage == "Employee {{FirstName}} should not be empty");
        }

        [Fact]
        public async Task ShouldNotAllowEmptyLastNames()
        {
            var today = DateTime.Today;

            var result = await _sut.ValidateAsync(new CreateNewEmployeeCommand
            {
                FirstName = "Gigel",
                LastName = "",
                Email = "gigel.frone@yahoo.co.uk",
                Phone = "0463724850",
                JobTitle = "Singer",
                Department = "Arts",
                HireDate = today,
                City = "Onesti"
            });

            Assert.Contains(result.Errors, e => e.ErrorMessage == "Employee {{LastName}} should not be empty");
        }

        [Fact]
        public async Task ShouldNotAllowEmptyEmails()
        {
            var today = DateTime.Today;

            var result = await _sut.ValidateAsync(new CreateNewEmployeeCommand
            {
                FirstName = "Gigel",
                LastName = "Frone",
                Email = "",
                Phone = "0463724850",
                JobTitle = "Singer",
                Department = "Arts",
                HireDate = today,
                City = "Onesti"
            });

            Assert.Contains(result.Errors, e => e.ErrorMessage == "Employee {{Email}} should not be empty");
        }

        [Fact]
        public async Task ShouldNotAllowEmptyPhone()
        {
            var today = DateTime.Today;

            var result = await _sut.ValidateAsync(new CreateNewEmployeeCommand
            {
                FirstName = "Gigel",
                LastName = "Frone",
                Email = "gigel.frone@yahoo.co.uk",
                Phone = "",
                JobTitle = "Singer",
                Department = "Arts",
                HireDate = today,
                City = "Onesti"
            });

            Assert.Contains(result.Errors, e => e.ErrorMessage == "Employee {{Phone}} should not be empty");
        }

        [Fact]
        public async Task ShouldNotAllowInvalidPhone()
        {
            var today = DateTime.Today;

            var result = await _sut.ValidateAsync(new CreateNewEmployeeCommand
            {
                FirstName = "Gigel",
                LastName = "Frone",
                Email = "gigel.frone@yahoo.co.uk",
                Phone = "abc",
                JobTitle = "Singer",
                Department = "Arts",
                HireDate = today,
                City = "Onesti"
            });

            Assert.Contains(result.Errors, e => e.ErrorMessage == "Employee {{Phone}} is invalid!");
        }

        [Fact]
        public async Task ShouldNotAllowEmptyJobTitles()
        {
            var today = DateTime.Today;

            var result = await _sut.ValidateAsync(new CreateNewEmployeeCommand
            {
                FirstName = "Gigel",
                LastName = "Frone",
                Email = "gigel.frone@yahoo.co.uk",
                Phone = "0463724850",
                JobTitle = "",
                Department = "Arts",
                HireDate = today,
                City = "Onesti"
            });

            Assert.Contains(result.Errors, e => e.ErrorMessage == "Employee {{JobTitle}} should not be empty");
        }

        [Fact]
        public async Task ShouldNotAllowEmptyDepartment()
        {
            var today = DateTime.Today;

            var result = await _sut.ValidateAsync(new CreateNewEmployeeCommand
            {
                FirstName = "Gigel",
                LastName = "Frone",
                Email = "gigel.frone@yahoo.co.uk",
                Phone = "0463724850",
                JobTitle = "Singer",
                Department = "",
                HireDate = today,
                City = "Onesti"
            });

            Assert.Contains(result.Errors, e => e.ErrorMessage == "Employee {{Department}} should not be empty");
        }

        [Fact]
        public async Task ShouldNotAllowEmptyCity()
        {
            var today = DateTime.Today;

            var result = await _sut.ValidateAsync(new CreateNewEmployeeCommand
            {
                FirstName = "Gigel",
                LastName = "Frone",
                Email = "gigel.frone@yahoo.co.uk",
                Phone = "0463724850",
                JobTitle = "Singer",
                Department = "Arts",
                HireDate = today,
                City = ""
            });

            Assert.Contains(result.Errors, e => e.ErrorMessage == "Employee {{City}} should not be empty");
        }
    }
}
