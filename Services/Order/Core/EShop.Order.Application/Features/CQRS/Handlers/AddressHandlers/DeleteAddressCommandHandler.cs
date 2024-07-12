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
    public class DeleteAddressCommandHandler
    {
        private readonly IRepository<Address> _addressRepository;

        public DeleteAddressCommandHandler(IRepository<Address> addressRepository)
        {
            _addressRepository = addressRepository;
        }

        public async Task Handle(DeleteAddressCommand deleteAddressCommand)
        {
            var address = await _addressRepository.GetByIdAsync(deleteAddressCommand.AddressId);
            await _addressRepository.DeleteAsync(address);
        }
    }
}
