using EShop.Order.Application.Features.CQRS.Commands.AddressCommands;
using EShop.Order.Application.Features.CQRS.Handlers.AddressHandlers;
using EShop.Order.Application.Features.CQRS.Queries.AddressQueries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EShop.Order.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressesController : ControllerBase
    {
        private readonly GetAddressQueryHandler _getAddressQueryHandler;
        private readonly GetAddressByIdQueryHandler _getAddressQueryByIdHandler;
        private readonly CreateAddressCommandHandler _createAddressCommandHandler;
        private readonly DeleteAddressCommandHandler _deleteAddressCommandHandler;
        private readonly UpdateAddressCommandHandler _updateAddressCommandHandler;

        public AddressesController(GetAddressQueryHandler getAddressQueryHandler,
                                   GetAddressByIdQueryHandler getAddressQueryByIdHandler,
                                   UpdateAddressCommandHandler updateAddressCommandHandler,
                                   DeleteAddressCommandHandler deleteAddressCommandHandler,
                                   CreateAddressCommandHandler createAddressCommandHandler)
        {
            _getAddressQueryHandler = getAddressQueryHandler;
            _getAddressQueryByIdHandler = getAddressQueryByIdHandler;
            _updateAddressCommandHandler = updateAddressCommandHandler;
            _deleteAddressCommandHandler = deleteAddressCommandHandler;
            _createAddressCommandHandler = createAddressCommandHandler;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAddresses()
        {
            var addresses = await _getAddressQueryHandler.Handle();
            return Ok(addresses);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAllAddressById(int id)
        {
            var address = await _getAddressQueryByIdHandler.Handle(new GetAddressByIdQuery(id));
            return Ok(address);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAddress([FromBody] CreateAddressCommand createAddressCommand)
        {
            await _createAddressCommandHandler.Handle(createAddressCommand);
            return Ok("Address Created Successfuly");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAddress([FromBody] UpdateAddressCommand updateAddressCommand)
        {
            await _updateAddressCommandHandler.Handle(updateAddressCommand);
            return Ok("Address Updated Successfuly");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAddress(int id)
        {
            await _deleteAddressCommandHandler.Handle(new DeleteAddressCommand(id));
            return Ok("Address Deleted Successfuly");
        }
    }
}
