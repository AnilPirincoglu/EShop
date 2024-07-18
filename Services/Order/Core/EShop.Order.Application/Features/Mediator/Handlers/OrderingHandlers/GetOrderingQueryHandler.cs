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
    public class GetOrderingQueryHandler : IRequestHandler<GetOrderingQuery, List<GetOrderingQueryResult>>
    {
        private readonly IRepository<Ordering> _orderingRepository;

        public GetOrderingQueryHandler(IRepository<Ordering> orderingRepository)
        {
            _orderingRepository = orderingRepository;
        }

        public async Task<List<GetOrderingQueryResult>> Handle(GetOrderingQuery request, CancellationToken cancellationToken)
        {
            var orders = await _orderingRepository.GetAllAsync();
            return orders.Select(order => new GetOrderingQueryResult
            {
                OrderId = order.OrderId,
                OrderDate = order.OrderDate,
                OrderTotalPrice = order.OrderTotalPrice,
                UserId = order.UserId
            }).ToList();
        }
    }
}
