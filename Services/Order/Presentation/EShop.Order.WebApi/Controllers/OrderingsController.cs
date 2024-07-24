using EShop.Order.Application.Features.Mediator.Commands.OrderingCommands;
using EShop.Order.Application.Features.Mediator.Queries.OrderingQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EShop.Order.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderingsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrderingsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllOrderings()
        {
            var orderings = await _mediator.Send(new GetOrderingQuery());
            return Ok(orderings);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderingById(int id)
        {
            var ordering = await _mediator.Send(new GetOrderingByIdQuery(id));
            return Ok(ordering);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrdering([FromBody] CreateOrderingCommand command)
        {
            await _mediator.Send(command);
            return Ok("Order Created Successfully");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateOrdering([FromBody] UpdateOrderingCommand command)
        {
            await _mediator.Send(command);
            return Ok("Order Updated Successfully");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrdering(int id)
        {
            await _mediator.Send(new DeleteOrderingCommand(id));
            return Ok("Order Deleted Successfully");
        }

    }
}
