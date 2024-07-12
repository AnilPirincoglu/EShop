using EShop.Order.Application.Features.CQRS.Queries.AddressQueries;
using EShop.Order.Application.Features.CQRS.Results.AddressResults;
using EShop.Order.Application.Interfaces;
using EShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Order.Application.Features.CQRS.Handlers.AddressHandlers
{
    public class GetAddressByIdQueryHandler
    {
        private readonly IRepository<Address> _addressRepository;

        public GetAddressByIdQueryHandler(IRepository<Address> addressRepository)
        {
            _addressRepository = addressRepository;
        }

        public async Task<GetAddressByIdQueryResult> Handle(GetAddressByIdQuery getAddressByIdQuery)
        {
            var address = await _addressRepository.GetByIdAsync(getAddressByIdQuery.AddressId);
            return new GetAddressByIdQueryResult
            {
                AddressId = address.AddressId,
                City = address.City,
                Detail = address.Detail,
                District = address.District,
                UserId = address.UserId
            };
        }
    }
}
