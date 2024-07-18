using EShop.Order.Application.Features.Mediator.Queries.OrderingQueries;
using EShop.Order.Application.Features.Mediator.Results.OrderingResults;
using EShop.Order.Application.Interfaces;
using EShop.Order.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Order.Application.Features.Mediator.Handlers.OrderingHandlers
{
    public class GetOrderingByIdQueryHandler : IRequestHandler<GetOrderingByIdQuery, GetOrderingByIdQueryResult>
    {
        private readonly IRepository<Ordering> _orderingRepository;

        public GetOrderingByIdQueryHandler(IRepository<Ordering> orderingRepository)
        {
            _orderingRepository = orderingRepository;
        }

        public async Task<GetOrderingByIdQueryResult> Handle(GetOrderingByIdQuery request, CancellationToken cancellationToken)
        {
            var order = await _orderingRepository.GetByIdAsync(request.OrderId);
            return new GetOrderingByIdQueryResult
            {
                OrderId = order.OrderId,
                OrderDate = order.OrderDate,
                OrderTotalPrice = order.OrderTotalPrice,
                UserId = order.UserId
            };
        }
    }
}
