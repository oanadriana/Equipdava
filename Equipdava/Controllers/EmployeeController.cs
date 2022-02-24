using Equipdava.Application.Employees.Commands;
using Equipdava.Application.Employees.Queries;
using Equipdava.Models.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Equipdava.Controllers
{
    [ApiController]
    [Route("api/employees")]
    public class EmployeeController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IConfiguration _configuration;

        public EmployeeController(IMediator mediator, IConfiguration configuration)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _configuration = configuration;
        }

        [HttpPost]
        public async Task<IActionResult> CreateNewEmployee([FromBody] CreateNewEmployeeCommand createNewEmployeeCommand)
        {
            return Ok(await _mediator.Send(createNewEmployeeCommand));
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEmployees()
        {
            var employees = await _mediator.Send(new GetAllEmployeesQuery());

            return Ok(employees);
        }

        [HttpPost("{employeeId}/resources")]
        public async Task<IActionResult> CreateNewResourceToEmployee([FromBody] CreateNewResourceToEmployeeRequest request,
            int employeeId)
        {
            var createNewResourceToEmployeeCommand = new CreateNewResourceForEmployeeCommand()
            {
                ResourceId = request.ResourceId,
                EmployeeId = employeeId
            };

            return Ok(await _mediator.Send(createNewResourceToEmployeeCommand));
        }
    }
}
