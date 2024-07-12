using EShop.Order.Application.Features.CQRS.Commands.AddressCommands;
using EShop.Order.Application.Interfaces;
using EShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Order.Application.Features.CQRS.Handlers.AddressHandlers
{
    public class UpdateAddressCommandHandler
    {
        private readonly IRepository<Address> _addressRepository;

        public UpdateAddressCommandHandler(IRepository<Address> addressRepository)
        {
            _addressRepository = addressRepository;
        }

        public async Task Handle(UpdateAddressCommand updateAddressCommand)
        {
            var address = await _addressRepository.GetByIdAsync(updateAddressCommand.AddressId);
            address.City = updateAddressCommand.City;
            address.UserId = updateAddressCommand.UserId;
            address.Detail = updateAddressCommand.Detail;
            address.District = updateAddressCommand.District;
            await _addressRepository.UpdateAsync(address);
        }
    }
}
