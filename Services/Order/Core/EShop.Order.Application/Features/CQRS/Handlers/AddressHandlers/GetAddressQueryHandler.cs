using EShop.Order.Application.Features.CQRS.Results.AddressResults;
using EShop.Order.Application.Interfaces;
using EShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Order.Application.Features.CQRS.Handlers.AddressHandlers
{
    public class GetAddressQueryHandler
    {
        private readonly IRepository<Address> _addressRepository;

        public GetAddressQueryHandler(IRepository<Address> addressRepository)
        {
            _addressRepository = addressRepository;
        }

        public async Task<List<GetAddressByIdQueryResult>> Handle()
        {
            var addresses = await _addressRepository.GetAllAsync();
            return addresses.Select(address => new GetAddressByIdQueryResult
            {
                AddressId = address.AddressId,
                City = address.City,
                Detail = address.Detail,
                District = address.District,
                UserId = address.UserId
            }).ToList();
        }

    }
}
