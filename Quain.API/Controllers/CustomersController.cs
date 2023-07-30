namespace Quain.API.Controllers
{
    using MediatR;
    using Microsoft.AspNetCore.Mvc;
    using Quain.Services.Handlers.Customers.CreateCustomer;
    using Quain.Services.Handlers.Customers.GetCustomer;
    using Quain.Services.Handlers.Customers.UpdateCustomerPoints;
    using Quain.Services.Handlers.Customers.UpdatePointsByCustomerId;
    using Quain.Services.Inputs;

    [Route("[controller]")]
    //[Authorize]
    [ApiController]
    public class CustomersController : Controller
    {
        private readonly IMediator _mediator;

        public CustomersController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet("{codClient}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<GetCustomerResponse>> GetCustomerByCodClient(string codClient, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(GetCustomerCommand.From(codClient), cancellationToken);
            return Ok(response);
        }

        [HttpPost("create/{codClient}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<CreateCustomerResponse>> Create(string codClient, [FromQuery] string nComp, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(CreateCustomerCommand.From(codClient, nComp), cancellationToken);
            return CreatedAtAction(nameof(Create), response);
        }

        [HttpPut("{codClient}/updatePoints/ByBill/{ncomp}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<UpdateCustomerPointsResponse>> UpdatePointsByBill(string codClient, string ncomp, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(UpdateCustomerPointsCommand.From(codClient, ncomp), cancellationToken);
            return Ok(response);
        }

        [HttpPut("updatePoints/ByCustomerId/{customerId}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<UpdatePointsByCustomerIdResponse>> UpdatePointsByCustomerId(Guid customerId, [FromBody] PointsInput pointsInput, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(UpdatePointsByCustomerIdCommand.From(customerId, pointsInput), cancellationToken);
            return Ok(response);
        }
    }
}
