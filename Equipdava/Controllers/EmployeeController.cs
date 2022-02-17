using Equipdava.Application.Employees.Commands;
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
    }
}
