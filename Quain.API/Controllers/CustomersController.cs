namespace Quain.API.Controllers
{
    using MediatR;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Quain.Services.Handlers.Customers.CreateCustomer;
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


        [HttpPost("create")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<CreateCustomerResponse>> Create([FromBody] CustomerInput customerInput, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(CreateCustomerCommand.From(customerInput), cancellationToken);
            return Ok(response);
        }
    }
}
