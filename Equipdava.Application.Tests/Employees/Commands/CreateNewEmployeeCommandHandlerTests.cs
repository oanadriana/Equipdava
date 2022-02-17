using AutoMapper;
using Equipdava.Application.Employees.Commands;
using Equipdava.Application.Employees.Profilles;
using Equipdava.DB.DbContexts;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Moq;
using Shouldly;
using Xunit;

namespace Equipdava.Application.Tests.Employees.Commands
{
    public class CreateNewEmployeeCommandHandlerTests
    {
        private readonly CreateNewEmployeeCommandHandler _sut;
        private readonly EquipdavaDbContext _dbContext;
        private readonly Mock<IValidator<CreateNewEmployeeCommand>> _validatorMock;

        public CreateNewEmployeeCommandHandlerTests()
        {
            var options = new DbContextOptionsBuilder<EquipdavaDbContext>()
                .UseInMemoryDatabase(databaseName: "EquipdavaCreateEmployeeValidatorTest")
                .Options;

            _validatorMock = new Mock<IValidator<CreateNewEmployeeCommand>>();
            _validatorMock.Setup(x =>
                    x.Validate(It.IsAny<CreateNewEmployeeCommand>()))
                .Returns(() => new ValidationResult());

            _dbContext = new EquipdavaDbContext(options);

            var mappingConfig = new MapperConfiguration(mc =>
                mc.AddProfile(new EmployeeProfile()));

            _sut = new CreateNewEmployeeCommandHandler(
                _dbContext,
                mappingConfig.CreateMapper(),
                _validatorMock.Object);
        }

        [Fact]
        public async Task ShouldInsertEntityIntoDatabase()
        {
            var today = DateTime.Today;

            var employeesCount = _dbContext.Employees.Count();

            employeesCount.ShouldBe(0);

            var result = await _sut.Handle(new CreateNewEmployeeCommand
            {
                FirstName = "Gigel",
                LastName = "Frone",
                Email = "gigel.frone@yahoo.co.uk",
                Phone = "0463724850",
                JobTitle = "Singer",
                Department = "Arts",
                HireDate = today,
                City = "Onesti"
            }, CancellationToken.None);

            var employeesCountAfterInsert = _dbContext.Employees.Count();
            
            employeesCountAfterInsert.ShouldBe(1);
        }
    }
}
